using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Data;

/// <summary>
/// Summary description for CategoryData
/// </summary>
public class CategoryData
{
     private int _Id;
    private string _Category;
    private string _Description;
    private string _Date;
    private string _Image;
    private string _PageTitle;
    private string _MetaKey;
    private string _MetaDescription;
  
	public CategoryData()
	{
		//
		// TODO: Add constructor logic here
		//
	}


    public CategoryData(int Id)
    {
        Connection connect = new Connection();
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@int_Id", Id));
        using (DataSet ds = connect.GetDataset("SELECT * FROM category WHERE id=@int_Id", param))
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                HasValue = true;
                _Id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                _Category = ds.Tables[0].Rows[0]["categoryName"].ToString();
                _Description = ds.Tables[0].Rows[0]["description"].ToString();
               // _Date = ds.Tables[0].Rows[0]["noticedate"].ToString();
                _Image = ds.Tables[0].Rows[0]["image"].ToString();
                _PageTitle = ds.Tables[0].Rows[0]["pagetitle"].ToString();
                _MetaKey = ds.Tables[0].Rows[0]["metakey"].ToString();
                _MetaDescription = ds.Tables[0].Rows[0]["metadescription"].ToString();
            }
            else
            {
                HasValue = false;
            }
        }
        connect.Dispose();
        connect = null;
    }
    public CategoryData(string category)
    {
        Connection connect = new Connection();
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@cate", category));
        using (DataSet ds = connect.GetDataset("SELECT * FROM category WHERE categoryName=@cate", param))
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                HasValue = true;
                _Id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                _Category = ds.Tables[0].Rows[0]["categoryName"].ToString();
                _Description = ds.Tables[0].Rows[0]["description"].ToString();
                // _Date = ds.Tables[0].Rows[0]["noticedate"].ToString();
                _Image = ds.Tables[0].Rows[0]["image"].ToString();
                _PageTitle = ds.Tables[0].Rows[0]["pagetitle"].ToString();
                _MetaKey = ds.Tables[0].Rows[0]["metakey"].ToString();
                _MetaDescription = ds.Tables[0].Rows[0]["metadescription"].ToString();
            }
            else
            {
                HasValue = false;
            }
        }
        connect.Dispose();
        connect = null;
    }
    public CategoryData(string image,string nouse)
    {
        Connection connect = new Connection();
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@image", image));
        using (DataSet ds = connect.GetDataset("SELECT * FROM category WHERE image=@image", param))
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                HasValue = true;
                _Id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                _Category = ds.Tables[0].Rows[0]["categoryName"].ToString();
                _Description = ds.Tables[0].Rows[0]["description"].ToString();
                // _Date = ds.Tables[0].Rows[0]["noticedate"].ToString();
                _Image = ds.Tables[0].Rows[0]["image"].ToString();
                _PageTitle = ds.Tables[0].Rows[0]["pagetitle"].ToString();
                _MetaKey = ds.Tables[0].Rows[0]["metakey"].ToString();
                _MetaDescription = ds.Tables[0].Rows[0]["metadescription"].ToString();
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

        param.Add(new MySqlParameter("@category", _Category));
        param.Add(new MySqlParameter("@description", _Description));
       // param.Add(new MySqlParameter("@date", _Date));
        param.Add(new MySqlParameter("@image", _Image));
        param.Add(new MySqlParameter("@pagetitle", _PageTitle));
        param.Add(new MySqlParameter("@metakey", _MetaKey));
        param.Add(new MySqlParameter("@metadescription", _MetaDescription));
    
        Connection connect = new Connection();
        connect.ExecStatement("INSERT INTO category(categoryName,description,image,pagetitle,metakey,metadescription) VALUES(@category,@description,@image,@pagetitle,@metakey,@metadescription)", param);
        connect.Dispose();
        connect = null;
    }

    public void Update(int id)
    {
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@id", id));
        param.Add(new MySqlParameter("@category", _Category));
        param.Add(new MySqlParameter("@description", _Description));
        // param.Add(new MySqlParameter("@date", _Date));
        param.Add(new MySqlParameter("@image", _Image));
        param.Add(new MySqlParameter("@pagetitle", _PageTitle));
        param.Add(new MySqlParameter("@metakey", _MetaKey));
        param.Add(new MySqlParameter("@metadescription", _MetaDescription));

        Connection connect = new Connection();
        connect.ExecStatement("UPDATE category SET categoryName=@category,description=@description,image=@image,pagetitle=@pagetitle,metakey=@metakey,metadescription=@metadescription WHERE id=@id", param);
        connect.Dispose();
        connect = null;
    }
    public DataSet getCategory(String query)
    {
        Connection connect = new Connection();
        List<MySqlParameter> param = new List<MySqlParameter>();

        DataSet ds = connect.GetDataset(query);
        return ds;
    }
    public DataSet getFullCategory()
    {
        string conn = System.Configuration.ConfigurationManager.ConnectionStrings["mySQLconn"].ConnectionString;
        MySqlConnection cnn = new MySqlConnection(conn);
        MySqlDataAdapter cmd1 = new MySqlDataAdapter("select * from category", cnn);

        //Create and fill the DataSet.
        DataSet ds = new DataSet();
        cmd1.Fill(ds, "category");

        //Create a second DataAdapter for the Titles table.
        MySqlDataAdapter cmd2 = new MySqlDataAdapter("select * from subcategory", cnn);
        cmd2.Fill(ds, "subcategory");

        //Create the relation bewtween the Category and Sub-Category tables.
        ds.Relations.Add("myrelation",
        ds.Tables["category"].Columns["id"],
        ds.Tables["subcategory"].Columns["categoryid"]);
       
        return ds;
        cnn.Close();
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


    public string Category
    {
        get { return _Category; }
        set { _Category = value; }
    }
    public string Description
    {
        get { return _Description; }
        set { _Description = value; }
    }
    public string CategoryDate
    {
        get { return _Date; }
        set { _Date = value; }
    }

    public string Image
    {
        get { return _Image; }
        set { _Image = value; }
    }
    public string PageTitle
    {
        get { return _PageTitle; }
        set { _PageTitle = value; }
    }
    public string MetaKeyes
    {
        get { return _MetaKey; }
        set { _MetaKey = value; }
    }
    public string MetaDescription
    {
        get { return _MetaDescription; }
        set { _MetaDescription = value; }
    }
    public bool HasValue
    {
        get;
        set;
    }
}