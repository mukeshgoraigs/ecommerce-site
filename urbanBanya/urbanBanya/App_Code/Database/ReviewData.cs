using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ReviewData
/// </summary>
public class ReviewData
{
     private int _Id;
   private int _CustomerId;
     private string _Review;
     private int _Status;
    public ReviewData()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public ReviewData(int Id)
    {
        Connection connect = new Connection();
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@int_Id", Id));
        using (DataSet ds = connect.GetDataset("SELECT * FROM review WHERE id=@int_Id", param))
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                HasValue = true;
                _Id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                _CustomerId = int.Parse(ds.Tables[0].Rows[0]["customerid"].ToString());
                _Review = ds.Tables[0].Rows[0]["review"].ToString();
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

        param.Add(new MySqlParameter("@customerid", _CustomerId));
        param.Add(new MySqlParameter("@review", _Review));      
       

        Connection connect = new Connection();
        connect.ExecStatement("INSERT INTO review(customerid,review) VALUES(@customerid,@review)", param);
        connect.Dispose();
        connect = null;
    }

    public void Update(int id)
    {
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@id", id));
        param.Add(new MySqlParameter("@customerid", _CustomerId));
        param.Add(new MySqlParameter("@review", _Review));
        param.Add(new MySqlParameter("@status", _Status)); 

        Connection connect = new Connection();
        connect.ExecStatement("UPDATE review SET customerid=@customerid,review=@review,status=@status  WHERE id=@id", param);
        connect.Dispose();
        connect = null;
    }
    public DataSet getReviewes(String query)
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
        set {_CustomerId = value; }
    }

    public string Review
    {
        get { return _Review; }
        set { _Review = value; }
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