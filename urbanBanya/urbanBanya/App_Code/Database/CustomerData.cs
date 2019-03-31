using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Data;

/// <summary>
/// Summary description for CustomerData
/// </summary>
public class CustomerData
{
    private int _Id;
    private string _FName;
    private string _LName;
    private string _Gender;
    private string _Dob;
    private string _Otp;
   
    private string _Email;
    private string _Mobile;
    private string _Username;
    private string _Password;
    private int _Points;
    private int _Status;
    private int _Verified;
    private string _LoginBy;
	public CustomerData()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public CustomerData(string email)
    {
        Connection connect = new Connection();
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@email", email));
        using (DataSet ds = connect.GetDataset("SELECT * FROM customer WHERE email=@email", param))
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                HasValue = true;
                _Id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                _FName = ds.Tables[0].Rows[0]["F_name"].ToString();
                _LName = ds.Tables[0].Rows[0]["L_name"].ToString();
                _Gender = ds.Tables[0].Rows[0]["gender"].ToString();
                _Dob = ds.Tables[0].Rows[0]["dob"].ToString();
                _Otp = ds.Tables[0].Rows[0]["otp"].ToString();
                _Email = ds.Tables[0].Rows[0]["email"].ToString();
                _Username = ds.Tables[0].Rows[0]["username"].ToString();
                _Mobile = ds.Tables[0].Rows[0]["mobile"].ToString();
                _Password = ds.Tables[0].Rows[0]["cpassword"].ToString();
                _Points = int.Parse(ds.Tables[0].Rows[0]["points"].ToString());
                _Status = int.Parse(ds.Tables[0].Rows[0]["status"].ToString());
                _Verified = int.Parse(ds.Tables[0].Rows[0]["verified"].ToString());
                _LoginBy = ds.Tables[0].Rows[0]["loginby"].ToString();



            }
            else
            {
                HasValue = false;
            }
        }
        connect.Dispose();
        connect = null;
    }

    public CustomerData(int Id)
    {
        Connection connect = new Connection();
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@int_Id", Id));
        using (DataSet ds = connect.GetDataset("SELECT * FROM customer WHERE id=@int_Id", param))
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                HasValue = true;
                _Id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                _FName = ds.Tables[0].Rows[0]["F_name"].ToString();
                _LName = ds.Tables[0].Rows[0]["L_name"].ToString();
                _Gender = ds.Tables[0].Rows[0]["gender"].ToString();
                _Dob = ds.Tables[0].Rows[0]["dob"].ToString();
                _Otp = ds.Tables[0].Rows[0]["otp"].ToString();
                _Email = ds.Tables[0].Rows[0]["email"].ToString();
                _Username = ds.Tables[0].Rows[0]["username"].ToString();
                _Mobile = ds.Tables[0].Rows[0]["mobile"].ToString();
                _Password = ds.Tables[0].Rows[0]["cpassword"].ToString();
                _Points = int.Parse(ds.Tables[0].Rows[0]["points"].ToString());
                _Status = int.Parse(ds.Tables[0].Rows[0]["status"].ToString());
                _Verified = int.Parse(ds.Tables[0].Rows[0]["verified"].ToString());
                _LoginBy = ds.Tables[0].Rows[0]["loginby"].ToString();

            }
            else
            {
                HasValue = false;
            }
        }
        connect.Dispose();
        connect = null;
    }
    public CustomerData(string email,string pass)
    {
        Connection connect = new Connection();
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@email", email));
        param.Add(new MySqlParameter("@cpassword", pass));
        using (DataSet ds = connect.GetDataset("select * from customer where email=@email and cpassword=@cpassword", param))
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                HasValue = true;
                _Id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                _FName = ds.Tables[0].Rows[0]["F_name"].ToString();
                _LName = ds.Tables[0].Rows[0]["L_name"].ToString();
                _Gender = ds.Tables[0].Rows[0]["gender"].ToString();
                _Dob = ds.Tables[0].Rows[0]["dob"].ToString();
                _Otp = ds.Tables[0].Rows[0]["otp"].ToString();
                _Email = ds.Tables[0].Rows[0]["email"].ToString();
                _Username = ds.Tables[0].Rows[0]["username"].ToString();
                _Mobile = ds.Tables[0].Rows[0]["mobile"].ToString();
                _Password = ds.Tables[0].Rows[0]["cpassword"].ToString();
                _Points = int.Parse(ds.Tables[0].Rows[0]["points"].ToString());
                _Status = int.Parse(ds.Tables[0].Rows[0]["status"].ToString());
                _Verified = int.Parse(ds.Tables[0].Rows[0]["verified"].ToString());
                _LoginBy = ds.Tables[0].Rows[0]["loginby"].ToString();

            }
            else
            {
                HasValue = false;
            }
        }
        connect.Dispose();
        connect = null;
    }

    public void verifyOtp(string email, string otp)
    {
        Connection connect = new Connection();
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@email", email));
        param.Add(new MySqlParameter("@otp", otp));
        using (DataSet ds = connect.GetDataset("select * from customer where email=@email and otp=@otp", param))
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                HasValue = true;
                _Id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                _FName = ds.Tables[0].Rows[0]["F_name"].ToString();
                _LName = ds.Tables[0].Rows[0]["L_name"].ToString();
                _Gender = ds.Tables[0].Rows[0]["gender"].ToString();
                _Dob = ds.Tables[0].Rows[0]["dob"].ToString();
                _Otp = ds.Tables[0].Rows[0]["otp"].ToString();
                _Email = ds.Tables[0].Rows[0]["email"].ToString();
                _Username = ds.Tables[0].Rows[0]["username"].ToString();
                _Mobile = ds.Tables[0].Rows[0]["mobile"].ToString();
                _Password = ds.Tables[0].Rows[0]["cpassword"].ToString();
                _Points = int.Parse(ds.Tables[0].Rows[0]["points"].ToString());
                _Status = int.Parse(ds.Tables[0].Rows[0]["status"].ToString());
                _Verified = int.Parse(ds.Tables[0].Rows[0]["verified"].ToString());
                _LoginBy = ds.Tables[0].Rows[0]["loginby"].ToString();
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
        param.Add(new MySqlParameter("@F_name", _FName));
        param.Add(new MySqlParameter("@email", _Email));
       param.Add(new MySqlParameter("@mobile", _Mobile));
        param.Add(new MySqlParameter("@cpassword", _Password));
        param.Add(new MySqlParameter("@otp", _Otp));
        param.Add(new MySqlParameter("@loginby", _LoginBy));
       
        Connection connect = new Connection();
        connect.ExecStatement("INSERT INTO customer(F_name,email,mobile,cpassword,otp,loginby) VALUES(@F_name,@email,@mobile,@cpassword,@otp,@loginby)", param);
        connect.Dispose();
        connect = null;
    }

    public void Update(int id)
    {
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@id", id));
        param.Add(new MySqlParameter("@fname", _FName));
        param.Add(new MySqlParameter("@lname", _LName));
        param.Add(new MySqlParameter("@gender", _Gender));
        param.Add(new MySqlParameter("@email", _Email));
        param.Add(new MySqlParameter("@dob", _Dob));
        param.Add(new MySqlParameter("@mobile", _Mobile));
        param.Add(new MySqlParameter("@username", _Username));
        param.Add(new MySqlParameter("@password", _Password));
        
   
        Connection connect = new Connection();
        connect.ExecStatement("UPDATE customer SET F_name=@fname,L_name=@lname,gender=@gender,email=@email,mobile=@mobile,dob=@dob,username=@username,cpassword=@password WHERE id=@id", param);
        connect.Dispose();
        connect = null;
    }
    public void UpdateStatus(int id)
    {
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@id", id));
        param.Add(new MySqlParameter("@status", _Status));
       


        Connection connect = new Connection();
        connect.ExecStatement("UPDATE customer SET status=@status WHERE id=@id", param);
        connect.Dispose();
        connect = null;
    }
    public void UpdateVerified(int id)
    {
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@id", id));
        param.Add(new MySqlParameter("@verified", _Verified));

        Connection connect = new Connection();
        connect.ExecStatement("UPDATE customer SET verified=@verified WHERE id=@id", param);
        connect.Dispose();
        connect = null;
    }
    public void UpdatePoints(int id)
    {
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@id", id));
        param.Add(new MySqlParameter("@points", _Points));
        Connection connect = new Connection();
        connect.ExecStatement("UPDATE customer SET points=@points WHERE id=@id", param);
        connect.Dispose();
        connect = null;
    }

    public void ChangePassword(int id)
    {
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@id", id));
        param.Add(new MySqlParameter("@pass", _Password));
        Connection connect = new Connection();
        connect.ExecStatement("UPDATE customer SET cpassword=@pass WHERE id=@id", param);
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
    public string FirstName
    {
        get { return _FName; }
        set { _FName = value; }
    }
    public string LastName
    {
        get { return _LName; }
        set { _LName = value; }
    }
    public string Gender
    {
        get { return _Gender; }
        set { _Gender = value; }
    }
    public string DOB
    {
        get { return _Dob; }
        set { _Dob = value; }
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
    public string Username
    {
        get { return _Username; }
        set { _Username = value; }
    }

    public string Password
    {
        get { return _Password; }
        set { _Password = value; }
    }
    public int Points
    {
        get { return _Points; }
        set { _Points = value; }
    }
    public int Status
    {
        get { return _Status; }
        set { _Status = value; }
    }
    public string OTP
    {
        get { return _Otp; }
        set { _Otp = value; }
    }
    public string LoginBy
    {
        get { return _LoginBy; }
        set { _LoginBy = value; }
    }
    public int Verified
    {
        get { return _Verified; }
        set { _Verified = value; }
    }
    public bool HasValue
    {
        get;
        set;
    }


}