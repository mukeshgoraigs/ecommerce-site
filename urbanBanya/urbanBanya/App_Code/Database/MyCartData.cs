using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Data;

/// <summary>
/// Summary description for CartData
/// </summary>
public class MyCartData
{
    private int _Id;
    private int _ProductId;
    private double _Price;
    private double _NewPrice;
    private int _DiscountId;
    private int _Quantity;
    private string _SessionId;
    private string _Size;
    private int _UserId;
    private bool _IsCheckOut;


    public MyCartData()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public MyCartData(int id, string sessionid,string size)
    {
        Connection connect = new Connection();
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@int_Id", id));
        param.Add(new MySqlParameter("@sessionid", sessionid));
        param.Add(new MySqlParameter("@size", size));
        using (DataSet ds = connect.GetDataset("SELECT * FROM cartdata WHERE productid=@int_Id and sessionid=@sessionid and size=@size", param))
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                HasValue = true;
                _Id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                _ProductId = int.Parse(ds.Tables[0].Rows[0]["productid"].ToString());
                _Size = ds.Tables[0].Rows[0]["size"].ToString();
                _Price = double.Parse(ds.Tables[0].Rows[0]["price"].ToString());
                _NewPrice = double.Parse(ds.Tables[0].Rows[0]["newprice"].ToString());
                _DiscountId = int.Parse(ds.Tables[0].Rows[0]["discountid"].ToString());
                _Quantity = int.Parse(ds.Tables[0].Rows[0]["quantity"].ToString());
                _SessionId = ds.Tables[0].Rows[0]["sessionid"].ToString();
                _UserId = int.Parse(ds.Tables[0].Rows[0]["userid"].ToString());
                _IsCheckOut = bool.Parse(ds.Tables[0].Rows[0]["ischeckout"].ToString());
                _Quantity = _Quantity + 1;
                Update(_Id);

            }
            else
            {
                HasValue = false;
            }
        }
        connect.Dispose();
        connect = null;
    }


    public MyCartData(int Id)
    {
        Connection connect = new Connection();
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@int_Id", Id));
        using (DataSet ds = connect.GetDataset("SELECT * FROM cartdata WHERE id=@int_Id", param))
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                HasValue = true;
                _Id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                _ProductId = int.Parse(ds.Tables[0].Rows[0]["productid"].ToString());
                _Size = ds.Tables[0].Rows[0]["size"].ToString();
                _Price = double.Parse(ds.Tables[0].Rows[0]["price"].ToString());
                _NewPrice = double.Parse(ds.Tables[0].Rows[0]["newprice"].ToString());
                _DiscountId = int.Parse(ds.Tables[0].Rows[0]["discountid"].ToString());
                _Quantity = int.Parse(ds.Tables[0].Rows[0]["quantity"].ToString());
                _SessionId = ds.Tables[0].Rows[0]["sessionid"].ToString();
                _UserId = int.Parse(ds.Tables[0].Rows[0]["userid"].ToString());
                _IsCheckOut = bool.Parse(ds.Tables[0].Rows[0]["ischeckout"].ToString());


            }
            else
            {
                HasValue = false;
            }
        }
        connect.Dispose();
        connect = null;
    }
    public MyCartData(string sessionid,int userid)
    {
        Connection connect = new Connection();
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@sessionid", sessionid));
        param.Add(new MySqlParameter("@userid", userid));
        using (DataSet ds = connect.GetDataset("SELECT * FROM cartdata WHERE sessionid=@sessionid or userid=@userid ", param))
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                HasValue = true;
                _Id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                _ProductId = int.Parse(ds.Tables[0].Rows[0]["productid"].ToString());
                _Size = ds.Tables[0].Rows[0]["size"].ToString();
                _Price = double.Parse(ds.Tables[0].Rows[0]["price"].ToString());
                _NewPrice = double.Parse(ds.Tables[0].Rows[0]["newprice"].ToString());
                _DiscountId = int.Parse(ds.Tables[0].Rows[0]["discountid"].ToString());
                _Quantity = int.Parse(ds.Tables[0].Rows[0]["quantity"].ToString());
                _SessionId = ds.Tables[0].Rows[0]["sessionid"].ToString();
                _UserId = int.Parse(ds.Tables[0].Rows[0]["userid"].ToString());
                _IsCheckOut = bool.Parse(ds.Tables[0].Rows[0]["ischeckout"].ToString());


            }
            else
            {
                HasValue = false;
            }
        }
        connect.Dispose();
        connect = null;
    }
    public void Save()
    {
        List<MySqlParameter> param = new List<MySqlParameter>();

        param.Add(new MySqlParameter("@productid", _ProductId));
        param.Add(new MySqlParameter("@size", _Size));
        param.Add(new MySqlParameter("@price", _Price));
        param.Add(new MySqlParameter("@newprice", _NewPrice));
        param.Add(new MySqlParameter("@discountid", _DiscountId));
        param.Add(new MySqlParameter("@quantity", _Quantity));
        param.Add(new MySqlParameter("@sessionid", _SessionId));
        param.Add(new MySqlParameter("@userid", _UserId));
        param.Add(new MySqlParameter("@ischeckout", _IsCheckOut));

        Connection connect = new Connection();
        connect.ExecStatement("INSERT INTO cartdata(productid,size,price,discountid,newprice,quantity,sessionid,userid,ischeckout) VALUES(@productid,@size,@price,@discountid,@newprice,@quantity,@sessionid,@userid,@ischeckout)", param);
        connect.Dispose();
        connect = null;
    }

    public void Update(int id)
    {
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@id", id));
        param.Add(new MySqlParameter("@quantity", _Quantity));


        Connection connect = new Connection();
        connect.ExecStatement("UPDATE cartdata SET quantity=@quantity WHERE id=@id", param);
        connect.Dispose();
        connect = null;
    }
    public void Update(string sessionid)
    {
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@sessionid", sessionid));
        param.Add(new MySqlParameter("@userid", _UserId));


        Connection connect = new Connection();
        connect.ExecStatement("UPDATE cartdata SET userid=@userid WHERE sessionid=@sessionid", param);
        connect.Dispose();
        connect = null;
    }
    public void UpdateByUser(int userid)
    {
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@sessionid", _SessionId));
        param.Add(new MySqlParameter("@userid", userid));


        Connection connect = new Connection();
        connect.ExecStatement("UPDATE cartdata SET sessionid=@sessionid WHERE userid=@userid", param);
        connect.Dispose();
        connect = null;
    }
    public DataSet getCart(String query)
    {
        Connection connect = new Connection();
        List<MySqlParameter> param = new List<MySqlParameter>();

        DataSet ds = connect.GetDataset(query);
        return ds;
    }

    public void Delete(string query)
    {
        Connection connect = new Connection();
        connect.ExecStatement(query);
        connect.Dispose();
        connect = null;
    }
    public int Id
    {
        get { return _Id; }
        set { _Id = value; }
    }


    public int ProductId
    {
        get { return _ProductId; }
        set { _ProductId = value; }
    }
    public string Size
    {
        get { return _Size; }
        set { _Size = value; }
    }
    public double Price
    {
        get { return _Price; }
        set { _Price = value; }
    }
    public double NewPrice
    {
        get { return _NewPrice; }
        set { _NewPrice = value; }
    }
    public int DiscountId
    {
        get { return _DiscountId; }
        set { _DiscountId = value; }
    }

    public int Quantity
    {
        get { return _Quantity; }
        set { _Quantity = value; }
    }
    public string SessionId
    {
        get { return _SessionId; }
        set { _SessionId = value; }
    }
    public int UserId
    {
        get { return _UserId; }
        set { _UserId = value; }
    }
    public bool IsCheckout
    {
        get { return _IsCheckOut; }
        set { _IsCheckOut = value; }
    }


    public bool HasValue
    {
        get;
        set;
    }
}