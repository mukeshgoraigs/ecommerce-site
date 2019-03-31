using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for GoodiesRulesData
/// </summary>
public class GoodiesRulesData
{
    private int _Id;
    private double _Amount;
    private int _Goodies;
    private double _GoodiesValue;

    public GoodiesRulesData()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public GoodiesRulesData(int Id)
    {
        Connection connect = new Connection();
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@int_Id", Id));
        using (DataSet ds = connect.GetDataset("SELECT * FROM goodies_rule WHERE id=@int_Id", param))
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                HasValue = true;
                _Id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());               
                _Amount = double.Parse(ds.Tables[0].Rows[0]["amount"].ToString());
                _Goodies = int.Parse(ds.Tables[0].Rows[0]["goodies"].ToString());
                _GoodiesValue = double.Parse(ds.Tables[0].Rows[0]["goodiesvalue"].ToString());

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

        param.Add(new MySqlParameter("@amount", _Amount));
        param.Add(new MySqlParameter("@goodies", _Goodies));
        param.Add(new MySqlParameter("@goodiesvalue", _GoodiesValue));      

        Connection connect = new Connection();
        connect.ExecStatement("INSERT INTO goodies_rule(amount,goodies,goodiesvalue) VALUES(@amount,@goodies,@goodiesvalue)", param);
        connect.Dispose();
        connect = null;
    }

    public void Update(int id)
    {
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@id", id));
        param.Add(new MySqlParameter("@amount", _Amount));
        param.Add(new MySqlParameter("@goodies", _Goodies));
        param.Add(new MySqlParameter("@goodiesvalue", _GoodiesValue));       

        Connection connect = new Connection();
        connect.ExecStatement("UPDATE goodies_rule SET amount=@amount,goodies=@goodies,goodiesvalue=@goodiesvalue WHERE id=@id", param);
        connect.Dispose();
        connect = null;
    }
    public DataSet getGoodiesRules(String query)
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

    public double Amount
    {
        get { return _Amount; }
        set { _Amount = value; }
    }
    public int Goodies
    {
        get { return _Goodies; }
        set { _Goodies = value; }
    }
    public double GoodiesValue
    {
        get { return _GoodiesValue; }
        set { _GoodiesValue = value; }
    }
    public bool HasValue
    {
        get;
        set;
    }
}