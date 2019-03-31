using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Data;

/// <summary>
/// Summary description for SubCData
/// </summary>
public class SubCData
{
     private int _Id;
     private int _CatId;
    private string _SubCategory;
    private string _Date;
    private string _Image;   
    private string _Description;
    private string _PageTitle;
    private string _MetaKey;
    private string _MetaDescription;
	public SubCData()
	{
		//
		// TODO: Add constructor logic here
		//
	}




    public SubCData(int Id)
    {
        Connection connect = new Connection();
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@int_Id", Id));
        using (DataSet ds = connect.GetDataset("SELECT * FROM subcategory WHERE id=@int_Id", param))
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                HasValue = true;
                _Id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                _CatId = int.Parse(ds.Tables[0].Rows[0]["categoryid"].ToString());
                _SubCategory = ds.Tables[0].Rows[0]["subCategoryName"].ToString();
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
    public SubCData(string subcate)
    {
        Connection connect = new Connection();
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@subcate", subcate));
        using (DataSet ds = connect.GetDataset("SELECT * FROM subcategory WHERE subCategoryName=@subcate", param))
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                HasValue = true;
                _Id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                _CatId = int.Parse(ds.Tables[0].Rows[0]["categoryid"].ToString());
                _SubCategory = ds.Tables[0].Rows[0]["subCategoryName"].ToString();
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
    public SubCData(string image,string nousse)
    {
        Connection connect = new Connection();
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@image", image));
        using (DataSet ds = connect.GetDataset("SELECT * FROM subcategory WHERE image=@image", param))
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                HasValue = true;
                _Id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                _CatId = int.Parse(ds.Tables[0].Rows[0]["categoryid"].ToString());
                _SubCategory = ds.Tables[0].Rows[0]["subCategoryName"].ToString();
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
        param.Add(new MySqlParameter("@catid", _CatId));
        param.Add(new MySqlParameter("@subcategory", _SubCategory));
        param.Add(new MySqlParameter("@description", _Description));
       // param.Add(new MySqlParameter("@date", _Date));
        param.Add(new MySqlParameter("@image", _Image));
        param.Add(new MySqlParameter("@pagetitle", _PageTitle));
        param.Add(new MySqlParameter("@metakey", _MetaKey));
        param.Add(new MySqlParameter("@metadescription", _MetaDescription));
       
        Connection connect = new Connection();
        connect.ExecStatement("INSERT INTO subcategory(categoryid,subCategoryName,description,image,pagetitle,metakey,metadescription) VALUES(@catid,@subcategory,@description,@image,@pagetitle,@metakey,@metadescription)", param);
        connect.Dispose();
        connect = null;
        
    }

    public void Update(int id)
    {
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@id", id));
        param.Add(new MySqlParameter("@catid", _CatId));
        param.Add(new MySqlParameter("@subcategory", _SubCategory));
        param.Add(new MySqlParameter("@description", _Description));
        // param.Add(new MySqlParameter("@date", _Date));
        param.Add(new MySqlParameter("@image", _Image));
        param.Add(new MySqlParameter("@pagetitle", _PageTitle));
        param.Add(new MySqlParameter("@metakey", _MetaKey));
        param.Add(new MySqlParameter("@metadescription", _MetaDescription));
   
        Connection connect = new Connection();
        connect.ExecStatement("UPDATE subcategory SET categoryid=@catid,subCategoryName=@subcategory,description=@description,image=@image,pagetitle=@pagetitle,metakey=@metakey,metadescription=@metadescription WHERE id=@id", param);
        connect.Dispose();
        connect = null;
    }
    public DataSet getSubCategory(String query)
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
    public int Catid
    {
        get { return _CatId; }
        set { _CatId = value; }
    }

    public string SubCategory
    {
        get { return _SubCategory; }
        set { _SubCategory = value; }
    }
    public string Description
    {
        get { return _Description; }
        set { _Description = value; }
    }

    public string SubCatDate
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