using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Data;

/// <summary>
/// Summary description for MasterDiscountData
/// </summary>
public class MasterDiscountData
{
    private int _Id;
    private string _DiscountName;
    private string _StartDate;
    private string _EndDate;
    private int _IsCoupon;
    private int _IsVisible;
	public MasterDiscountData()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public MasterDiscountData(int Id)
    {
        Connection connect = new Connection();
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@int_Id", Id));
        using (DataSet ds = connect.GetDataset("SELECT * FROM discountmaster WHERE id=@int_Id", param))
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                HasValue = true;
                _Id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                _DiscountName = ds.Tables[0].Rows[0]["discountName"].ToString();
                _StartDate = ds.Tables[0].Rows[0]["sDate"].ToString();
                _EndDate = ds.Tables[0].Rows[0]["eDate"].ToString();
                _IsCoupon =int.Parse( ds.Tables[0].Rows[0]["isCoupon"].ToString());
                _IsVisible =int.Parse( ds.Tables[0].Rows[0]["isVisible"].ToString());
               
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

        param.Add(new MySqlParameter("@discountName", _DiscountName));
        param.Add(new MySqlParameter("@sDate", _StartDate));
        param.Add(new MySqlParameter("@eDate", _EndDate));
        param.Add(new MySqlParameter("@isCoupon", _IsCoupon));
         param.Add(new MySqlParameter("@isVisible", _IsVisible));
    
        Connection connect = new Connection();
        connect.ExecStatement("INSERT INTO discountmaster(discountName,sDate,eDate,isCoupon,isVisible) VALUES(@discountName,@sDate,@eDate,@isCoupon,@isVisible)", param);
        connect.Dispose();
        connect = null;
    }

    public void Update(int id)
    {
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@id", id));
        param.Add(new MySqlParameter("@discountName", _DiscountName));
        param.Add(new MySqlParameter("@sDate", _StartDate));
        param.Add(new MySqlParameter("@eDate", _EndDate));
        param.Add(new MySqlParameter("@isCoupon", _IsCoupon));
        param.Add(new MySqlParameter("@isVisible", _IsVisible));
    

        Connection connect = new Connection();
        connect.ExecStatement("UPDATE discountmaster SET discountName=@discountName,sDate=@sDate,eDate=@eDate,isCoupon=@isCoupon,isVisible=@isVisible WHERE id=@id", param);
        connect.Dispose();
        connect = null;
    }
    public DataSet getDiscountMaster(String query)
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


    public string DiscountName
    {
        get { return _DiscountName; }
        set { _DiscountName = value; }
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

    public int IsCoupon
    {
        get { return _IsCoupon; }
        set { _IsCoupon = value; }
    }
    public int IsVisible
    {

        get { return _IsVisible; }
        set { _IsVisible = value; }
    }
   
    public bool HasValue
    {
        get;
        set;
    }

   
}