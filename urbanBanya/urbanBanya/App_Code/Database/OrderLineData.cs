using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for OrderLineData
/// </summary>
public class OrderLineData
{
     private int _Id;
     private int _OrderNo;
    private int _ItemNo;
    private string _ItemName;
    private string _Size;
    private int _Quantity;
    private double _Price;
    private double _NewPrice;
    private double _TotalAmount;

	public OrderLineData()
	{
		//
		// TODO: Add constructor logic here
		//
	}



    public OrderLineData(int Id)
    {
        Connection connect = new Connection();
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@int_Id", Id));
        using (DataSet ds = connect.GetDataset("SELECT * FROM orderline WHERE id=@int_Id", param))
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                HasValue = true;
                _Id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                _OrderNo = int.Parse(ds.Tables[0].Rows[0]["orderno"].ToString());
                _ItemNo = int.Parse(ds.Tables[0].Rows[0]["itemno"].ToString());
                _ItemName = ds.Tables[0].Rows[0]["itemname"].ToString();
                _Size = ds.Tables[0].Rows[0]["size"].ToString();
                _Quantity = int.Parse(ds.Tables[0].Rows[0]["quantity"].ToString());
                _Price = double.Parse(ds.Tables[0].Rows[0]["price"].ToString());
                _NewPrice = double.Parse(ds.Tables[0].Rows[0]["newprice"].ToString());
                _TotalAmount = double.Parse(ds.Tables[0].Rows[0]["totalamount"].ToString());
              


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

        param.Add(new MySqlParameter("@orderno", _OrderNo));
        param.Add(new MySqlParameter("@itemno", _ItemNo));
        param.Add(new MySqlParameter("@itemname", _ItemName));
        param.Add(new MySqlParameter("@size", _Size));
        param.Add(new MySqlParameter("@quantity", _Quantity));
        param.Add(new MySqlParameter("@price", _Price));
        param.Add(new MySqlParameter("@newprice", _NewPrice));
        param.Add(new MySqlParameter("@totalamount", _TotalAmount));

        Connection connect = new Connection();
        connect.ExecStatement("INSERT INTO orderline(orderno,itemno,itemname,size,quantity,price,newprice,totalamount) VALUES(@orderno,@itemno,@itemname,@size,@quantity,@price,@newprice,@totalamount)", param);
        connect.Dispose();
        connect = null;
    }

    public void Update(int id)
    {
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@orderno", _OrderNo));
        param.Add(new MySqlParameter("@itemno", _ItemNo));
        param.Add(new MySqlParameter("@itemname", _ItemName));
        param.Add(new MySqlParameter("@size", _Size));
        param.Add(new MySqlParameter("@quantity", _Quantity));
        param.Add(new MySqlParameter("@price", _Price));
        param.Add(new MySqlParameter("@newprice", _NewPrice));
        param.Add(new MySqlParameter("@totalamount", _TotalAmount));


        Connection connect = new Connection();
        connect.ExecStatement("UPDATE cartdata SET quantity=@quantity WHERE id=@id", param);
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


    public int OrderId
    {
        get { return _OrderNo; }
        set { _OrderNo = value; }
    }
    public int ItemNo
    {
        get { return _ItemNo; }
        set { _ItemNo = value; }
    }
    public string ItemName
    {
        get { return _ItemName; }
        set { _ItemName = value; }
    }
    public string Size
    {
        get { return _Size; }
        set { _Size = value; }
    }
    public int Quantity
    {
        get { return _Quantity; }
        set { _Quantity = value; }
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
    public double TotalAmount
    {
        get { return _TotalAmount; }
        set { _TotalAmount = value; }
    }
   


    public bool HasValue
    {
        get;
        set;
    }
}