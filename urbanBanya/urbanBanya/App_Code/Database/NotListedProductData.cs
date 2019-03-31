using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for NotListedProductData
/// </summary>
public class NotListedProductData
{
    private int _Id;
    private string _ProductName;
    private string _EmailId;

	public NotListedProductData()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public NotListedProductData(int Id)
    {
        Connection connect = new Connection();
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@int_Id", Id));
        using (DataSet ds = connect.GetDataset("SELECT * FROM notlistedproduct WHERE id=@int_Id", param))
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                HasValue = true;
                _Id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                _ProductName = ds.Tables[0].Rows[0]["productName"].ToString();
                _EmailId = ds.Tables[0].Rows[0]["emailid"].ToString();
               
               
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

        param.Add(new MySqlParameter("@productName", _ProductName));
        param.Add(new MySqlParameter("@emailid", _EmailId));
       
    
        Connection connect = new Connection();
        connect.ExecStatement("INSERT INTO notlistedproduct(productName,emailid) VALUES(@productName,@emailid)", param);
        connect.Dispose();
        connect = null;
    }

   
    public DataSet getNotListed(String query)
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


    public string ProductName
    {
        get { return _ProductName; }
        set { _ProductName = value; }
    }
    public string EmailId
    {
        get { return _EmailId; }
        set { _EmailId = value; }
    }
  
   
    public bool HasValue
    {
        get;
        set;
    }
}