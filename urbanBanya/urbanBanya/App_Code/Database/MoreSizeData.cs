using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for MoreSizeData
/// </summary>
public class MoreSizeData
{
     private int _Id;
     private int _SubCatId;
    private int _ProductId;
    private string _Size;
    private double _Price;
    private string _Discount;
    private double _NewPrice;
    private int _Quantity;
    private string _Image;


	public MoreSizeData()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public MoreSizeData(int Id)
    {
        Connection connect = new Connection();
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@int_Id", Id));
        using (DataSet ds = connect.GetDataset("SELECT * FROM productdetail WHERE id=@int_Id", param))
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                HasValue = true;
                _SubCatId = int.Parse(ds.Tables[0].Rows[0]["subcategoryid"].ToString());
                _Id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                _ProductId =int.Parse(ds.Tables[0].Rows[0]["productid"].ToString());
                _Size = ds.Tables[0].Rows[0]["vsize"].ToString();
                _Price =double.Parse( ds.Tables[0].Rows[0]["vprice"].ToString());
                _Discount =ds.Tables[0].Rows[0]["vdiscount"].ToString();
                _NewPrice =double.Parse( ds.Tables[0].Rows[0]["vnewprice"].ToString());
                _Quantity =int.Parse( ds.Tables[0].Rows[0]["vquantity"].ToString());
                _Image =ds.Tables[0].Rows[0]["vimage"].ToString();
               
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
        param.Add(new MySqlParameter("@subcategoryid", _SubCatId));
        param.Add(new MySqlParameter("@productid", _ProductId));
        param.Add(new MySqlParameter("@vsize", _Size));
        param.Add(new MySqlParameter("@vprice", _Price));
       
        param.Add(new MySqlParameter("@vdiscount", _Discount));
        param.Add(new MySqlParameter("@vnewprice", _NewPrice));
        param.Add(new MySqlParameter("@vquantity", _Quantity));
        param.Add(new MySqlParameter("@vimage", _Image));
    
        Connection connect = new Connection();
        connect.ExecStatement("INSERT INTO productdetail(subcategoryid,productid,vsize,vprice,vdiscount,vnewprice,vquantity,vimage) VALUES(@subcategoryid,@productid,@vsize,@vprice,@vdiscount,@vnewprice,@vquantity,@vimage)", param);
        connect.Dispose();
        connect = null;
    }

    public void Update(int id)
    {
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@subcategoryid", _SubCatId));
        param.Add(new MySqlParameter("@id", id));
        param.Add(new MySqlParameter("@productid", _ProductId));
        param.Add(new MySqlParameter("@vsize", _Size));
        param.Add(new MySqlParameter("@vprice", _Price));
        param.Add(new MySqlParameter("@vdiscount", _Discount));
        param.Add(new MySqlParameter("@vnewprice", _NewPrice));
        param.Add(new MySqlParameter("@vquantity", _Quantity));
        param.Add(new MySqlParameter("@vimage", _Image));
    
        Connection connect = new Connection();
        connect.ExecStatement("UPDATE productdetail SET subcategoryid=@subcategoryid,productid=@productid,vsize=@vsize,vprice=@vprice,vdiscount=@vdiscount,vnewprice=@vnewprice,vquantity=@vquantity,vimage=@vimage WHERE id=@id", param);
        connect.Dispose();
        connect = null;
    }
    public DataSet getMoreSize(String query)
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

    public int SubCatId
    {
        get { return _SubCatId; }
        set { _SubCatId = value; }
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
    public string Discount
    {
        get { return _Discount; }
        set { _Discount = value; }
    }
    public double NewPrice
    {
        get { return _NewPrice; }
        set { _NewPrice = value; }
    }

    public int Quantity
    {
        get { return _Quantity; }
        set { _Quantity = value; }
    }
    public string Image
    {
        get { return _Image; }
        set { _Image = value; }
    }
   
    public bool HasValue
    {
        get;
        set;
    }
}