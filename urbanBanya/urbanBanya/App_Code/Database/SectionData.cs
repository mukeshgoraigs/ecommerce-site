using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Data;

/// <summary>
/// Summary description for HotItemData
/// </summary>
public class SectionData
{
    private int _Id;
    private int _Productid;
    private int _Position;
    private int _Section;

	public SectionData()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public SectionData(int Id)
    {
        Connection connect = new Connection();
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@int_Id", Id));
        using (DataSet ds = connect.GetDataset("SELECT * FROM hotitem WHERE id=@int_Id", param))
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                HasValue = true;
                _Id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                _Productid =int.Parse( ds.Tables[0].Rows[0]["productid"].ToString());
                _Position =int.Parse( ds.Tables[0].Rows[0]["position"].ToString());
                _Section = int.Parse(ds.Tables[0].Rows[0]["position"].ToString());
               
               
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

        param.Add(new MySqlParameter("@productid",_Productid));
        param.Add(new MySqlParameter("@position", _Position));
        param.Add(new MySqlParameter("@section", _Section));
    
        Connection connect = new Connection();
        connect.ExecStatement("INSERT INTO hotitem(productid,position,section) VALUES(@productid,@position,@section)", param);
        connect.Dispose();
        connect = null;
    }

    public void Update(int id)
    {
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@id", id));
        param.Add(new MySqlParameter("@productid", _Productid));
        param.Add(new MySqlParameter("@position", _Position));
        param.Add(new MySqlParameter("@section", _Section));
        Connection connect = new Connection();
        connect.ExecStatement("UPDATE hotitem SET productid=@productid,position=@position,section=@section WHERE id=@id", param);
        connect.Dispose();
        connect = null;
    }
    public DataSet getHotItem(String query)
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
        get { return _Productid; }
        set { _Productid = value; }
    }
    public int Position
    {
        get { return _Position; }
        set { _Position = value; }
    }
    public int Section
    {
        get { return _Section; }
        set { _Section = value; }
    }
   
    public bool HasValue
    {
        get;
        set;
    }
}