using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for AddressData
/// </summary>
public class AddressData
{
     private int _Id;
     private int _CustomerId;
    private string _City;
    private int _CityZone;
    private string _Area;
    private string _Pincode;
    private string _Address1;
    private string _Address2;
    private string _FlatNo;
    private string _Landmark;
    private bool _IsPrimary;
	public AddressData()
	{
		//
		// TODO: Add constructor logic here
		//
	}
     
    public AddressData(int C_Id)
    {
        Connection connect = new Connection();
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@int_Id", C_Id));
        using (DataSet ds = connect.GetDataset("SELECT * FROM address WHERE customerid=@int_Id", param))
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                HasValue = true;
                _Id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                _CustomerId = int.Parse(ds.Tables[0].Rows[0]["customerid"].ToString());
                _City = ds.Tables[0].Rows[0]["city"].ToString();
                _CityZone = int.Parse(ds.Tables[0].Rows[0]["cityzone"].ToString());
                _Area = ds.Tables[0].Rows[0]["area"].ToString();
                _Pincode = ds.Tables[0].Rows[0]["pincode"].ToString();
                _Address1 = ds.Tables[0].Rows[0]["address1"].ToString();
                _Address2 = ds.Tables[0].Rows[0]["address2"].ToString();
                _FlatNo = ds.Tables[0].Rows[0]["flotno"].ToString();
                _Landmark = ds.Tables[0].Rows[0]["landmark"].ToString();
                _IsPrimary = bool.Parse(ds.Tables[0].Rows[0]["isprimary"].ToString());
             
               
            }
            else
            {
                HasValue = false;
            }
        }
        connect.Dispose();
        connect = null;
    }
    public AddressData(int C_Id,int isp)
    {
        Connection connect = new Connection();
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@int_Id", C_Id));
        param.Add(new MySqlParameter("@isp", isp));
        using (DataSet ds = connect.GetDataset("SELECT * FROM address WHERE customerid=@int_Id and isprimary=@isp", param))
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                HasValue = true;
                _Id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                _CustomerId = int.Parse(ds.Tables[0].Rows[0]["customerid"].ToString());
                _City = ds.Tables[0].Rows[0]["city"].ToString();
                _CityZone = int.Parse(ds.Tables[0].Rows[0]["cityzone"].ToString());
                _Area = ds.Tables[0].Rows[0]["area"].ToString();
                _Pincode = ds.Tables[0].Rows[0]["pincode"].ToString();
                _Address1 = ds.Tables[0].Rows[0]["address1"].ToString();
                _Address2 = ds.Tables[0].Rows[0]["address2"].ToString();
                _FlatNo = ds.Tables[0].Rows[0]["flotno"].ToString();
                _Landmark = ds.Tables[0].Rows[0]["landmark"].ToString();
                _IsPrimary = bool.Parse(ds.Tables[0].Rows[0]["isprimary"].ToString());


            }
            else
            {
                HasValue = false;
            }
        }
        connect.Dispose();
        connect = null;
    }
    public AddressData(int A_Id,string ad)
    {
        Connection connect = new Connection();
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@int_Id", A_Id));
        using (DataSet ds = connect.GetDataset("SELECT * FROM address WHERE id=@int_Id", param))
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                HasValue = true;
                _Id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                _CustomerId = int.Parse(ds.Tables[0].Rows[0]["customerid"].ToString());
                _City = ds.Tables[0].Rows[0]["city"].ToString();
                _CityZone = int.Parse(ds.Tables[0].Rows[0]["cityzone"].ToString());
                _Area = ds.Tables[0].Rows[0]["area"].ToString();
                _Pincode = ds.Tables[0].Rows[0]["pincode"].ToString();
                _Address1 = ds.Tables[0].Rows[0]["address1"].ToString();
                _Address2 = ds.Tables[0].Rows[0]["address2"].ToString();
                _FlatNo = ds.Tables[0].Rows[0]["flotno"].ToString();
                _Landmark = ds.Tables[0].Rows[0]["landmark"].ToString();
                _IsPrimary = bool.Parse(ds.Tables[0].Rows[0]["isprimary"].ToString());

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
        param.Add(new MySqlParameter("@customerid", _CustomerId));
        param.Add(new MySqlParameter("@city", _City));
        param.Add(new MySqlParameter("@cityzone", _CityZone));
        param.Add(new MySqlParameter("@area", _Area));
        param.Add(new MySqlParameter("@pincode", _Pincode));
        param.Add(new MySqlParameter("@address1", _Address1));
        param.Add(new MySqlParameter("@address2", _Address2));
        param.Add(new MySqlParameter("@flotno", _FlatNo));
        param.Add(new MySqlParameter("@landmark", _Landmark));
        param.Add(new MySqlParameter("@isprimary", _IsPrimary));
       
        Connection connect = new Connection();
        connect.ExecStatement("INSERT INTO address(customerid,city,cityzone,area,pincode,address1,address2,flotno,landmark,isprimary) VALUES(@customerid,@city,@cityzone,@area,@pincode,@address1,@address2,@flotno,@landmark,@isprimary)", param);
        connect.Dispose();
        connect = null;
    }

    public void Update(int id)
    {
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@customerid", _CustomerId));
        param.Add(new MySqlParameter("@city", _City));
        param.Add(new MySqlParameter("@cityzone", _CityZone));
        param.Add(new MySqlParameter("@area", _Area));
        param.Add(new MySqlParameter("@pincode", _Pincode));
        param.Add(new MySqlParameter("@address1", _Address1));
        param.Add(new MySqlParameter("@address2", _Address2));
        param.Add(new MySqlParameter("@flotno", _FlatNo));
        param.Add(new MySqlParameter("@landmark", _Landmark));
        param.Add(new MySqlParameter("@isprimary", _IsPrimary));
   
        Connection connect = new Connection();
        connect.ExecStatement("UPDATE customer SET categoryid=@catid,subCategoryName=@subcategory,description=@description,image=@image WHERE id=@id", param);
        connect.Dispose();
        connect = null;
    }
    public DataSet getAddress(String query)
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
    public int CustomerId
    {
        get { return _CustomerId; }
        set { _CustomerId = value; }
    }
    public string City
    {
        get { return _City; }
        set { _City = value; }
    }
    public int CityZone
    {
        get { return _CityZone; }
        set { _CityZone = value; }
    }

    public string Area
    {
        get { return _Area; }
        set { _Area = value; }
    }
    public string Pincode
    {
        get { return _Pincode; }
        set { _Pincode = value; }
    }
    public string Address1
    {
        get { return _Address1; }
        set { _Address1 = value; }
    }

    public string Address2
    {
        get { return _Address2; }
        set { _Address2 = value; }
    }
    public string FlatNo
    {
        get { return _FlatNo; }
        set { _FlatNo = value; }
    }
    public string Landmark
    {
        get { return _Landmark; }
        set { _Landmark = value; }
    }
    public bool IsPrimary
    {
        get { return _IsPrimary; }
        set { _IsPrimary = value; }
    }
   
   
    public bool HasValue
    {
        get;
        set;
    }


}