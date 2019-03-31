using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for SlotData
/// </summary>
public class SlotData
{
    private int _Id;
    private string _Slot1;
    private string _Slot2;
    private string _Slot3;
    private string _Slot4;
    private string _Slot5;
    private string _Slot6;
    private int _CityZone;
   
   
	public SlotData()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public SlotData(int Id)
    {
        Connection connect = new Connection();
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@int_Id", Id));
        using (DataSet ds = connect.GetDataset("SELECT * FROM slot WHERE id=@int_Id", param))
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                HasValue = true;
                _Id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                _Slot1 = ds.Tables[0].Rows[0]["slot1"].ToString();
                _Slot2 = ds.Tables[0].Rows[0]["slot2"].ToString();
                _Slot3 = ds.Tables[0].Rows[0]["slot3"].ToString();
                _Slot4 = ds.Tables[0].Rows[0]["slot4"].ToString();
                _Slot5 = ds.Tables[0].Rows[0]["slot5"].ToString();
                _Slot6 = ds.Tables[0].Rows[0]["slot6"].ToString();
                _CityZone = int.Parse(ds.Tables[0].Rows[0]["cityzone"].ToString());
               

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

        param.Add(new MySqlParameter("@slot1", _Slot1));
        param.Add(new MySqlParameter("@slot2", _Slot2));
        param.Add(new MySqlParameter("@slot3", _Slot3));
        param.Add(new MySqlParameter("@slot4", _Slot4));
        param.Add(new MySqlParameter("@slot5", _Slot5));
        param.Add(new MySqlParameter("@slot6", _Slot6));
        param.Add(new MySqlParameter("@cityzone", _CityZone));
       

        Connection connect = new Connection();
        connect.ExecStatement("INSERT INTO slot(slot1,slot2,slot3,slot4,slot5,slot6,cityzone) VALUES(@slot1,@slot2,@slot3,@slot4,@slot5,@slot6,@cityzone  )", param);
        connect.Dispose();
        connect = null;
    }

    public void Update(int id)
    {
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@id", id));
        param.Add(new MySqlParameter("@slot1", _Slot1));
        param.Add(new MySqlParameter("@slot2", _Slot2));
        param.Add(new MySqlParameter("@slot3", _Slot3));
        param.Add(new MySqlParameter("@slot4", _Slot4));
        param.Add(new MySqlParameter("@slot5", _Slot5));
        param.Add(new MySqlParameter("@slot6", _Slot6));
        

        Connection connect = new Connection();
        connect.ExecStatement("UPDATE slot SET slot1=@slot1,slot2=@slot2,slot3=@slot3,slot4=@slot4,slot5=@slot5,slot6=@slot6 WHERE id=@id", param);
        connect.Dispose();
        connect = null;
    }
    public DataSet getSlots(String query)
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

    public string Slot1
    {
        get { return _Slot1; }
        set { _Slot1 = value; }
    }
    public string Slot2
    {
        get { return _Slot2; }
        set { _Slot2 = value; }
    }
    public string Slot3
    {
        get { return _Slot3; }
        set { _Slot3 = value; }
    }

    public string Slot4
    {
        get { return _Slot4; }
        set { _Slot4 = value; }
    }
    public string Slot5
    {
        get { return _Slot5; }
        set { _Slot5 = value; }
    }
    public string Slot6
    {
        get { return _Slot6; }
        set { _Slot6 = value; }
    }

    public bool HasValue
    {
        get;
        set;
    }
}