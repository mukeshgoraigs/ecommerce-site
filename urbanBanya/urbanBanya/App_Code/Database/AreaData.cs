using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for AreaData
/// </summary>
public class AreaData
{
        private int _Id;
    private string _City;
    private int _CityZone;
    private string _Area;
    private string _Pincode;
    private double _Extera;
	public AreaData()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public AreaData(int Id)
    {
        Connection connect = new Connection();
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@int_Id", Id));
        using (DataSet ds = connect.GetDataset("SELECT * FROM area WHERE id=@int_Id", param))
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                HasValue = true;
                _Id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                _City = ds.Tables[0].Rows[0]["city"].ToString();
                _CityZone = int.Parse(ds.Tables[0].Rows[0]["cityzone"].ToString());
                _Area = ds.Tables[0].Rows[0]["areaname"].ToString();
                 _Pincode = ds.Tables[0].Rows[0]["pincode"].ToString();
                 _Extera =double.Parse( ds.Tables[0].Rows[0]["extera"].ToString());

            }
            else
            {
                HasValue = false;
            }
        }
        connect.Dispose();
        connect = null;
    }
    public AreaData(string area)
    {
        Connection connect = new Connection();
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@areaname", area));
        using (DataSet ds = connect.GetDataset("SELECT * FROM area WHERE areaname=@areaname", param))
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                HasValue = true;
                _Id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                _City = ds.Tables[0].Rows[0]["city"].ToString();
                _CityZone = int.Parse(ds.Tables[0].Rows[0]["cityzone"].ToString());
                _Area = ds.Tables[0].Rows[0]["areaname"].ToString();
                _Pincode = ds.Tables[0].Rows[0]["pincode"].ToString();
                _Extera = double.Parse(ds.Tables[0].Rows[0]["extera"].ToString());

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

        param.Add(new MySqlParameter("@city", _City));
        param.Add(new MySqlParameter("@cityzone", _CityZone));
        param.Add(new MySqlParameter("@areaname", _Area));
         param.Add(new MySqlParameter("@pincode", _Pincode));
         param.Add(new MySqlParameter("@extera", _Extera));

        Connection connect = new Connection();
        connect.ExecStatement("INSERT INTO area(city,cityzone,areaname,pincode,extera) VALUES(@city,@cityzone,@areaname,@pincode,@extera)", param);
        connect.Dispose();
        connect = null;
    }

    public void Update(int id)
    {
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@id", id));
        param.Add(new MySqlParameter("@city", _City));
        param.Add(new MySqlParameter("@cityzone", _CityZone));
        param.Add(new MySqlParameter("@areaname", _Area));
        param.Add(new MySqlParameter("@pincode", _Pincode));
        param.Add(new MySqlParameter("@extera", _Extera));

        Connection connect = new Connection();
        connect.ExecStatement("UPDATE area SET city=@city,cityzone=@cityzone,areaname=@areaname,pincode=@pincode,extera=@extera WHERE id=@id", param);
        connect.Dispose();
        connect = null;
    }
    public DataSet getAreas(String query)
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
    public int CityZone
    {
        get { return _CityZone; }
        set { _CityZone = value; }
    }

    public string City
    {
        get { return _City; }
        set { _City = value; }
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

    public double Extera
    {
        get { return _Extera; }
        set { _Extera = value; }
    }

    public bool HasValue
    {
        get;
        set;
    }
}