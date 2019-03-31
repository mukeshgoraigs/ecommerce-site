using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Data;

/// <summary>
/// Summary description for SpecificationData
/// </summary>
public class SpecificationData
{
    private int _Id;
    private int _Type;
    private string _Specification;
    
  
	public SpecificationData()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public SpecificationData(int Id)
    {
        Connection connect = new Connection();
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@int_Id", Id));
        using (DataSet ds = connect.GetDataset("SELECT * FROM specification WHERE id=@int_Id", param))
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                HasValue = true;
                _Id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                _Type = int.Parse(ds.Tables[0].Rows[0]["type"].ToString());
                _Specification = ds.Tables[0].Rows[0]["specification"].ToString();
                
               
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

        param.Add(new MySqlParameter("@type", _Type));
        param.Add(new MySqlParameter("@specification", _Specification));
      
    
        Connection connect = new Connection();
        connect.ExecStatement("INSERT INTO specification(specification,type) VALUES(@specification,@type)", param);
        connect.Dispose();
        connect = null;
    }

    public void Update(int id)
    {
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@id",id));
        param.Add(new MySqlParameter("@type", _Type));
        param.Add(new MySqlParameter("@specification", _Specification));

        Connection connect = new Connection();
        connect.ExecStatement("UPDATE specification SET specification=@specification,type=@type WHERE id=@id", param);
        connect.Dispose();
        connect = null;
    }
    public DataSet getSpecification(String query)
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


    public int Type
    {
        get { return _Type; }
        set { _Type = value; }
    }
    public string Specificatins
    {
        get { return _Specification; }
        set { _Specification = value; }
    }
   
    public bool HasValue
    {
        get;
        set;
    }
}