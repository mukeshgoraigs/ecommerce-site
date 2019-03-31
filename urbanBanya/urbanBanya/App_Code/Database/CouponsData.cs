using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for CouponsData
/// </summary>
public class CouponsData
{
	   private int _Id;
    private string _Name;
    private double _MinimumAmount;
    private string _Discount;
    private int _DiscountType;
    private string _Subcategory;
    private string _StartDate;
    private string _EndDate;   
    private string _Description;
    private string _Image;
    private string coupon;
    
  
	public CouponsData()
	{
		//
		// TODO: Add constructor logic here
		//
	}


    public CouponsData(int Id)
    {
        Connection connect = new Connection();
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@int_Id", Id));
        using (DataSet ds = connect.GetDataset("SELECT * FROM coupons WHERE id=@int_Id", param))
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                HasValue = true;
                _Id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                _Name = ds.Tables[0].Rows[0]["name"].ToString();
                _MinimumAmount =double.Parse( ds.Tables[0].Rows[0]["minimumamount"].ToString());
                _Discount = ds.Tables[0].Rows[0]["discount"].ToString();
                _DiscountType = int.Parse(ds.Tables[0].Rows[0]["discounttype"].ToString());
                _Subcategory = ds.Tables[0].Rows[0]["subcategory"].ToString();
                _StartDate = ds.Tables[0].Rows[0]["start_date"].ToString();
                _EndDate = ds.Tables[0].Rows[0]["end_date"].ToString();
                _Description = ds.Tables[0].Rows[0]["description"].ToString();
                _Image = ds.Tables[0].Rows[0]["image"].ToString();  
               
            }
            else
            {
                HasValue = false;
            }
        }
        connect.Dispose();
        connect = null;
    }

    public CouponsData(string coupon,string date)
    {
        Connection connect = new Connection();
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@name", coupon));
        param.Add(new MySqlParameter("@date", date));
        using (DataSet ds = connect.GetDataset("SELECT * FROM coupons WHERE name=@name and start_date<=@date and end_date>=@date", param))
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                HasValue = true;
                _Id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                _Name = ds.Tables[0].Rows[0]["name"].ToString();
                _MinimumAmount = double.Parse(ds.Tables[0].Rows[0]["minimumamount"].ToString());
                _Discount = ds.Tables[0].Rows[0]["discount"].ToString();
                _DiscountType = int.Parse(ds.Tables[0].Rows[0]["discounttype"].ToString());
                _Subcategory = ds.Tables[0].Rows[0]["subcategory"].ToString();
                _StartDate = ds.Tables[0].Rows[0]["start_date"].ToString();
                _EndDate = ds.Tables[0].Rows[0]["end_date"].ToString();
                _Description = ds.Tables[0].Rows[0]["description"].ToString();
                _Image = ds.Tables[0].Rows[0]["image"].ToString();  
            }
            else
            {
                HasValue = false;
            }
        }
        connect.Dispose();
        connect = null;
    }
    public CouponsData(string coupon)
    {
        Connection connect = new Connection();
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@name", coupon));
       
        using (DataSet ds = connect.GetDataset("SELECT * FROM coupons WHERE name=@name", param))
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                HasValue = true;
                _Id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                _Name = ds.Tables[0].Rows[0]["name"].ToString();
                _MinimumAmount = double.Parse(ds.Tables[0].Rows[0]["minimumamount"].ToString());
                _Discount = ds.Tables[0].Rows[0]["discount"].ToString();
                _DiscountType = int.Parse(ds.Tables[0].Rows[0]["discounttype"].ToString());
                _Subcategory = ds.Tables[0].Rows[0]["subcategory"].ToString();
                _StartDate = ds.Tables[0].Rows[0]["start_date"].ToString();
                _EndDate = ds.Tables[0].Rows[0]["end_date"].ToString();
                _Description = ds.Tables[0].Rows[0]["description"].ToString();
                _Image = ds.Tables[0].Rows[0]["image"].ToString();  
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

        param.Add(new MySqlParameter("@name", _Name));
        param.Add(new MySqlParameter("@minimumamount", _MinimumAmount));
        param.Add(new MySqlParameter("@discount", _Discount));
        param.Add(new MySqlParameter("@discounttype", _DiscountType));
        param.Add(new MySqlParameter("@subcategory", _Subcategory));
        param.Add(new MySqlParameter("@start_date", _StartDate));
        param.Add(new MySqlParameter("@end_date", _EndDate));
        param.Add(new MySqlParameter("@description", _Description));
        param.Add(new MySqlParameter("@image", _Image));
    
        Connection connect = new Connection();
        connect.ExecStatement("INSERT INTO coupons(name,minimumamount,discount,discounttype,subcategory,start_date,end_date,description,image) VALUES(@name,@minimumamount,@discount,@discounttype,@subcategory,@start_date,@end_date,@description,@image)", param);
        connect.Dispose();
        connect = null;
    }

    public void Update(int id)
    {
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@id", id));
        param.Add(new MySqlParameter("@name", _Name));
        param.Add(new MySqlParameter("@minimumamount", _MinimumAmount));
        param.Add(new MySqlParameter("@discount", _Discount));
        param.Add(new MySqlParameter("@discounttype", _DiscountType));
        param.Add(new MySqlParameter("@subcategory", _Subcategory));
        param.Add(new MySqlParameter("@start_date", _StartDate));
        param.Add(new MySqlParameter("@end_date", _EndDate));
        param.Add(new MySqlParameter("@description", _Description));
        param.Add(new MySqlParameter("@image", _Image));

        Connection connect = new Connection();
        connect.ExecStatement("UPDATE coupons SET name=@name,minimumamount=@minimumamount,discount=@discount,discounttype=@discounttype,subcategory=@subcategory,start_date=@start_date,end_date=@end_date,description=@description,image=@image WHERE id=@id", param);
        connect.Dispose();
        connect = null;
    }
    public DataSet getCoupons(String query)
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


    public string Name
    {
        get { return _Name; }
        set { _Name = value; }
    }
    public double MinimumAmount
    {
        get { return _MinimumAmount; }
        set { _MinimumAmount = value; }
    }
    public string Discount
    {
        get { return _Discount; }
        set { _Discount = value; }
    }

    public int DiscountType
    {
        get { return _DiscountType; }
        set { _DiscountType = value; }
    }
    public string SubCategory
    {
        get { return _Subcategory; }
        set { _Subcategory = value; }
    }
    public string StartDate
    {
        get { return _StartDate; }
        set { _StartDate = value; }
    }
    public string EndDate
    {
        get { return _EndDate; }
        set { _EndDate = value; }
    }
    public string Description
    {
        get { return _Description; }
        set { _Description = value; }
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