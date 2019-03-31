using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for NewOfferData
/// </summary>
public class NewOfferData
{
    private int _Id;

    private string _AboutOffer;
    private string _ImageName;
    private string _Link;
    private bool _IsVisible;
    private int _Position;
    public NewOfferData()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public NewOfferData(int Id)
    {
        Connection connect = new Connection();
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@int_Id", Id));
        using (DataSet ds = connect.GetDataset("SELECT * FROM newoffer WHERE id=@int_Id", param))
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                HasValue = true;
                _Id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                _ImageName = ds.Tables[0].Rows[0]["image"].ToString();
                _AboutOffer = ds.Tables[0].Rows[0]["aboutoffer"].ToString();
                _Link = ds.Tables[0].Rows[0]["link"].ToString();
                _Position = int.Parse(ds.Tables[0].Rows[0]["position"].ToString());
                _IsVisible = bool.Parse(ds.Tables[0].Rows[0]["isvisible"].ToString());

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

        param.Add(new MySqlParameter("@image", _ImageName));

        param.Add(new MySqlParameter("@aboutoffer", _AboutOffer));

        param.Add(new MySqlParameter("@link", _Link));
        param.Add(new MySqlParameter("@position", _Position));
        param.Add(new MySqlParameter("@isvisible", _IsVisible));

        Connection connect = new Connection();
        connect.ExecStatement("INSERT INTO newoffer(image,link,position,isvisible,aboutoffer) VALUES(@image,@link,@position,@isvisible,@aboutoffer)", param);
        connect.Dispose();
        connect = null;
    }

    public void Update(int id)
    {
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@id", id));
        param.Add(new MySqlParameter("@image", _ImageName));
       
        param.Add(new MySqlParameter("@aboutoffer", _AboutOffer));
        param.Add(new MySqlParameter("@link", _Link));
        param.Add(new MySqlParameter("@position", _Position));
        param.Add(new MySqlParameter("@isvisible", _IsVisible));

        Connection connect = new Connection();
        connect.ExecStatement("UPDATE newoffer SET image=@image,link=@link,position=@position,isvisible=@isvisible,aboutoffer=@aboutoffer WHERE id=@id", param);
        connect.Dispose();
        connect = null;
    }
    public DataSet getNewOffer(String query)
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
    public int Position { 
        get { return _Position; } 
        set { _Position=value;}
    }

    public string ImageName
    {
        get { return _ImageName; }
        set { _ImageName = value; }
    }
   
    public string AboutOffer
    {
        get { return _AboutOffer; }
        set { _AboutOffer = value; }
    }
    public string Link
    {
        get { return _Link; }
        set { _Link = value; }
    }
   
    public bool IsVisible
    {
        get { return _IsVisible; }
        set { _IsVisible = value; }
    }

    public bool HasValue
    {
        get;
        set;
    }
}