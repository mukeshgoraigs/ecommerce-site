using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Data;

/// <summary>
/// Summary description for CouponDiscountData
/// </summary>
public class CouponDiscountData
{
    private int _Id;
    private int _DiscountId;
   
    private int _DiscountType;
    private float _Amount;
    private string _CouponCode;
    private int _Noofuses;
    private int _Noofused;
    private int _Status; 
	public CouponDiscountData()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public CouponDiscountData(int Id)
    {
        Connection connect = new Connection();
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@int_Id", Id));
        using (DataSet ds = connect.GetDataset("SELECT * FROM discountCoupon WHERE id=@int_Id", param))
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                HasValue = true;
                _Id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                _DiscountId = int.Parse(ds.Tables[0].Rows[0]["discountid"].ToString());
              
                _DiscountType = int.Parse(ds.Tables[0].Rows[0]["discountType"].ToString());
                _Amount = float.Parse(ds.Tables[0].Rows[0]["amount"].ToString());
                _CouponCode = ds.Tables[0].Rows[0]["couponCode"].ToString();
                _Noofuses = int.Parse(ds.Tables[0].Rows[0]["noofuses"].ToString());
                _Noofused = int.Parse(ds.Tables[0].Rows[0]["noofused"].ToString());
                _Status = int.Parse(ds.Tables[0].Rows[0]["status"].ToString());
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

        param.Add(new MySqlParameter("@discountid", _DiscountId));
        
        param.Add(new MySqlParameter("@discountType", _DiscountType));
        param.Add(new MySqlParameter("@amount", _Amount));
        param.Add(new MySqlParameter("@couponCode", _CouponCode));
        param.Add(new MySqlParameter("@noofuses", _Noofuses));
        param.Add(new MySqlParameter("@noofused", _Noofused));
        param.Add(new MySqlParameter("@status", _Status));
    
        Connection connect = new Connection();
        connect.ExecStatement("INSERT INTO discountCoupon(discountid,discountType,amount,couponCode,noofuses,noofused,status) VALUES(@discountid,@discountType,@amount,@couponCode,@noofuses,@noofused,@status)", param);
        connect.Dispose();
        connect = null;
    }

    public void Update(int id)
    {
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@id", id));
        param.Add(new MySqlParameter("@discountid", _DiscountId));
       
        param.Add(new MySqlParameter("@discountType", _DiscountType));
        param.Add(new MySqlParameter("@amount", _Amount));
        param.Add(new MySqlParameter("@couponCode", _CouponCode));
        param.Add(new MySqlParameter("@noofuses", _Noofuses));
        param.Add(new MySqlParameter("@noofused", _Noofused));
       

        Connection connect = new Connection();
        connect.ExecStatement("UPDATE discountCoupon SET discountid=@discountid,discountType=@discountType,amount=@amount,couponCode=@couponCode,noofuses=@noofuses,noofused=@noofused WHERE id=@id", param);
        connect.Dispose();
        connect = null;
    }
    public void getCouponData(int id)
        {
        Connection connect = new Connection();
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@int_Id", id));
        using (DataSet ds = connect.GetDataset("SELECT * FROM discountCoupon WHERE discountid=@int_Id", param))
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                HasValue = true;
                _Id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                _DiscountId = int.Parse(ds.Tables[0].Rows[0]["discountid"].ToString());

                _DiscountType = int.Parse(ds.Tables[0].Rows[0]["discountType"].ToString());
                _Amount = float.Parse(ds.Tables[0].Rows[0]["amount"].ToString());
                _CouponCode = ds.Tables[0].Rows[0]["couponCode"].ToString();
                _Noofuses = int.Parse(ds.Tables[0].Rows[0]["noofuses"].ToString());
                _Noofused = int.Parse(ds.Tables[0].Rows[0]["noofused"].ToString());
                _Status = int.Parse(ds.Tables[0].Rows[0]["status"].ToString());
            }
            else
            {
                HasValue = false;
            }
        }
        connect.Dispose();
        connect = null;
    }
    public DataSet getDiscountCoupons(String query)
    {
        Connection connect = new Connection();
        List<MySqlParameter> param = new List<MySqlParameter>();

        DataSet ds = connect.GetDataset(query);
        return ds;
    }
    public DataSet getFullCoupons()
    {
        string conn = System.Configuration.ConfigurationManager.ConnectionStrings["mySQLconn"].ConnectionString;
        MySqlConnection cnn = new MySqlConnection(conn);
        MySqlDataAdapter cmd1 = new MySqlDataAdapter("select * from discountMaster", cnn);

        //Create and fill the DataSet.
        DataSet ds = new DataSet();
        cmd1.Fill(ds, "master");

        //Create a second DataAdapter for the Titles table.
        MySqlDataAdapter cmd2 = new MySqlDataAdapter("select * from discountCoupon", cnn);
        cmd2.Fill(ds, "coupons");

        //Create the relation bewtween the Category and Sub-Category tables.
        ds.Relations.Add("myrelation",
        ds.Tables["master"].Columns["id"],
        ds.Tables["coupons"].Columns["discountid"]);

        return ds;
        cnn.Close();
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


    public int DiscountId
    {
        get { return _DiscountId; }
        set { _DiscountId = value; }
    }
   
    public int DiscountType
    {
        get { return _DiscountType; }
        set { _DiscountType = value; }
    }

    public float Amount
    {
        get { return _Amount; }
        set { _Amount = value; }
    }
    public string CouponCode
    {
        get { return _CouponCode; }
        set { _CouponCode = value; }
    }
    public int NoOfUses
    {
        get { return _Noofuses; }
        set { _Noofuses = value; }
    }
    public int NoOfUsed
    {
        get { return _Noofused; }
        set { _Noofused = value; }
    }
    public int Status
    {
        get { return _Status; }
        set { _Status = value; }
    }
   
    public bool HasValue
    {
        get;
        set;
    }
}