using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Data;

/// <summary>
/// Summary description for ProductDiscountData
/// </summary>
public class ProductDiscountData
{
    private int _Id;
    private int _DiscountId;
    private int _ProductId;
    private int _DiscountType;
    private float _Amount;

	public ProductDiscountData()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public ProductDiscountData(int Id)
    {
        Connection connect = new Connection();
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@int_Id", Id));
        using (DataSet ds = connect.GetDataset("SELECT * FROM discountproduct WHERE id=@int_Id", param))
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                HasValue = true;
                _Id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                _DiscountId = int.Parse(ds.Tables[0].Rows[0]["discountid"].ToString());
                _ProductId = int.Parse(ds.Tables[0].Rows[0]["productid"].ToString());
                _DiscountType = int.Parse(ds.Tables[0].Rows[0]["discountType"].ToString());
                _Amount = float.Parse(ds.Tables[0].Rows[0]["amount"].ToString());
               
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

        param.Add(new MySqlParameter("@discountid", _DiscountId));
        param.Add(new MySqlParameter("@productid", _ProductId));
        param.Add(new MySqlParameter("@discountType", _DiscountType));
        param.Add(new MySqlParameter("@amount", _Amount));
    
        Connection connect = new Connection();
        connect.ExecStatement("INSERT INTO discountproduct(discountid,productid,discountType,amount) VALUES(@discountid,@productid,@discountType,@amount)", param);
        connect.Dispose();
        connect = null;
    }

    public void Update(int id)
    {
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@id",id));
        param.Add(new MySqlParameter("@discountid", _DiscountId));
        param.Add(new MySqlParameter("@productid", _ProductId));
        param.Add(new MySqlParameter("@discountType", _DiscountType));
        param.Add(new MySqlParameter("@amount", _Amount));

        Connection connect = new Connection();
        connect.ExecStatement("UPDATE discountproduct SET discountid=@discountid,productid=@productid,discountType=@discountType,amount=@amount WHERE id=@id", param);
        connect.Dispose();
        connect = null;
    }
    public void getProductData(int id)
    {
        Connection connect = new Connection();
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@int_Id", id));
        using (DataSet ds = connect.GetDataset("select * from discountproduct where discountid=@int_Id", param))
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                HasValue = true;
                _Id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                _DiscountId = int.Parse(ds.Tables[0].Rows[0]["discountid"].ToString());
                _ProductId = int.Parse(ds.Tables[0].Rows[0]["productid"].ToString());
                _DiscountType = int.Parse(ds.Tables[0].Rows[0]["discountType"].ToString());
                _Amount = float.Parse(ds.Tables[0].Rows[0]["amount"].ToString());

            }
            else
            {
                HasValue = false;
            }
        }
        connect.Dispose();
        connect = null;
    }
    public DataSet getDiscountProduct(String query)
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


    public int DiscountId
    {
        get { return _DiscountId; }
        set { _DiscountId = value; }
    }
    public int ProductId
    {
        get { return _ProductId; }
        set { _ProductId = value; }
    }
    public int DiscountType
    {
        get { return _DiscountType; }
        set { _DiscountType = value; }
    }

    public float Amount
    {
        get { return _Amount; }
        set { _Amount = value; }
    }
   
    public bool HasValue
    {
        get;
        set;
    }
}