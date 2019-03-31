using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for AdminData
/// </summary>
public class AdminData
{
    private int _Id;
    private string _Name;
    private string _Email;
    private string _Mobile;
    private string _Password;
	public AdminData()
	{
		//
		// TODO: Add constructor logic here
		//
	}
  
    public AdminData(int Id)
    {
        Connection connect = new Connection();
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@int_Id", Id));
        using (DataSet ds = connect.GetDataset("SELECT * FROM admin WHERE id=@int_Id", param))
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                HasValue = true;
                _Id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                _Name = ds.Tables[0].Rows[0]["name"].ToString();
                _Email = ds.Tables[0].Rows[0]["email"].ToString();
                _Mobile = ds.Tables[0].Rows[0]["mobile"].ToString();
               // _Date = ds.Tables[0].Rows[0]["noticedate"].ToString();
                _Password = ds.Tables[0].Rows[0]["apassword"].ToString();
             
               
            }
            else
            {
                HasValue = false;
            }
        }
        connect.Dispose();
        connect = null;
    }
    public AdminData(string email)
    {
        Connection connect = new Connection();
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@email", email));
        using (DataSet ds = connect.GetDataset("SELECT * FROM admin WHERE email=@email", param))
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                HasValue = true;
                _Id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                _Name = ds.Tables[0].Rows[0]["name"].ToString();
                _Email = ds.Tables[0].Rows[0]["email"].ToString();
                _Mobile = ds.Tables[0].Rows[0]["mobile"].ToString();
                // _Date = ds.Tables[0].Rows[0]["noticedate"].ToString();
                _Password = ds.Tables[0].Rows[0]["apassword"].ToString();


            }
            else
            {
                HasValue = false;
            }
        }
        connect.Dispose();
        connect = null;
    }
    public AdminData(string email, string pass)
    {
        Connection connect = new Connection();
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@email", email));
        param.Add(new MySqlParameter("@apassword", pass));
        using (DataSet ds = connect.GetDataset("select * from admin where email=@email and apassword=@apassword", param))
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                HasValue = true;
                _Id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                _Name = ds.Tables[0].Rows[0]["name"].ToString();
                _Email = ds.Tables[0].Rows[0]["email"].ToString();
                _Mobile = ds.Tables[0].Rows[0]["mobile"].ToString();
                // _Date = ds.Tables[0].Rows[0]["noticedate"].ToString();
                _Password = ds.Tables[0].Rows[0]["apassword"].ToString();


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
        param.Add(new MySqlParameter("@email", _Email));        
       // param.Add(new MySqlParameter("@date", _Date));
        param.Add(new MySqlParameter("@apassword", _Password));
       
        Connection connect = new Connection();
        connect.ExecStatement("INSERT INTO admin(name,email,apassword) VALUES(@name,@email,@apassword)", param);
        connect.Dispose();
        connect = null;
    }

    public void Update(int id)
    {
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@id", id));
        param.Add(new MySqlParameter("@name", _Name));
        param.Add(new MySqlParameter("@email", _Email));
        param.Add(new MySqlParameter("@mobile", _Mobile));
        // param.Add(new MySqlParameter("@date", _Date));
        param.Add(new MySqlParameter("@apassword", _Password));
   
        Connection connect = new Connection();
        connect.ExecStatement("UPDATE admin SET name=@name,email=@email,mobile=@mobile,apassword=@apassword WHERE id=@id", param);
        connect.Dispose();
        connect = null;
    }
    public DataSet getCustomer(String query)
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

    public string Email
    {
        get { return _Email; }
        set { _Email = value; }
    }
    public string Mobile
    {
        get { return _Mobile; }
        set { _Mobile = value; }
    }
    public string Password
    {
        get { return _Password; }
        set { _Password = value; }
    }

   
   
    public bool HasValue
    {
        get;
        set;
    }
}