using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for OrderHeaderData
/// </summary>
public class OrderHeaderData
{
    private int _Id;
    private int _UserId;
    private int _Address;
    private string _OrderTotal;
    private double _PayAmount;
    private int _Goodies;
    private string _Coupon;
    private double _CouponAmount;
    private string _DeliveryCharge;
    private string _OrderPlaced;
    private string _OrderDate;
    private string _OrderTime;
    private string _Instruction;
    private int _IsPlaced;
    private string _PaymentOption;
    private string _Status;

    private string _OrderStatus;
    private string _TrackingId;
    private string _BankRefNo;
    private string _PaymentMode;
    private string _CardName;
  
	public OrderHeaderData()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public OrderHeaderData(int Id,string str)
    {
        Connection connect = new Connection();
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@int_Id", Id));
        using (DataSet ds = connect.GetDataset("SELECT * FROM orderheader WHERE id=@int_Id", param))
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                
                HasValue = true;
                _Id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                _UserId = int.Parse(ds.Tables[0].Rows[0]["userid"].ToString());
                _Address = int.Parse(ds.Tables[0].Rows[0]["address"].ToString());
                _Goodies = int.Parse(ds.Tables[0].Rows[0]["goodeis"].ToString());
                _PayAmount = double.Parse(ds.Tables[0].Rows[0]["payamount"].ToString());
                _OrderTotal = ds.Tables[0].Rows[0]["ordertotal"].ToString();
                _DeliveryCharge = ds.Tables[0].Rows[0]["delivery"].ToString();
                _OrderPlaced = ds.Tables[0].Rows[0]["placedate"].ToString();
                _OrderDate = ds.Tables[0].Rows[0]["orderdate"].ToString();
                _OrderTime = ds.Tables[0].Rows[0]["ordertime"].ToString();
                _Instruction = ds.Tables[0].Rows[0]["instruction"].ToString();
                _IsPlaced = int.Parse(ds.Tables[0].Rows[0]["IsPlaced"].ToString());
                _PaymentOption = ds.Tables[0].Rows[0]["paymentoption"].ToString();
                _Status = ds.Tables[0].Rows[0]["status"].ToString();

                _OrderStatus = ds.Tables[0].Rows[0]["orderstatus"].ToString();
                _TrackingId = ds.Tables[0].Rows[0]["trackingid"].ToString();
                _BankRefNo = ds.Tables[0].Rows[0]["bankrefno"].ToString();
                _PaymentMode = ds.Tables[0].Rows[0]["paymentmode"].ToString();
                _CardName = ds.Tables[0].Rows[0]["cardname"].ToString();
                _Coupon = ds.Tables[0].Rows[0]["coupon"].ToString();
                _CouponAmount =double.Parse(ds.Tables[0].Rows[0]["couponamount"].ToString());


            }
            else
            {
                HasValue = false;
            }
        }
        connect.Dispose();
        connect = null;
    }

    public void CheckCoupon(int userid, string coupon)
    {
        Connection connect = new Connection();
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@userid", userid));
        param.Add(new MySqlParameter("@coupon", coupon));
        using (DataSet ds = connect.GetDataset("SELECT * FROM orderheader WHERE userid=@userid and coupon=@coupon", param))
        {
            if (ds.Tables[0].Rows.Count > 0)
            {

                HasValue = true;
                _Id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                _UserId = int.Parse(ds.Tables[0].Rows[0]["userid"].ToString());
                _Address = int.Parse(ds.Tables[0].Rows[0]["address"].ToString());
                _Goodies = int.Parse(ds.Tables[0].Rows[0]["goodeis"].ToString());
                _PayAmount = double.Parse(ds.Tables[0].Rows[0]["payamount"].ToString());
                _OrderTotal = ds.Tables[0].Rows[0]["ordertotal"].ToString();
                _DeliveryCharge = ds.Tables[0].Rows[0]["delivery"].ToString();
                _OrderPlaced = ds.Tables[0].Rows[0]["placedate"].ToString();
                _OrderDate = ds.Tables[0].Rows[0]["orderdate"].ToString();
                _OrderTime = ds.Tables[0].Rows[0]["ordertime"].ToString();
                _Instruction = ds.Tables[0].Rows[0]["instruction"].ToString();
                _IsPlaced = int.Parse(ds.Tables[0].Rows[0]["IsPlaced"].ToString());
                _PaymentOption = ds.Tables[0].Rows[0]["paymentoption"].ToString();
                _Status = ds.Tables[0].Rows[0]["status"].ToString();

                _OrderStatus = ds.Tables[0].Rows[0]["orderstatus"].ToString();
                _TrackingId = ds.Tables[0].Rows[0]["trackingid"].ToString();
                _BankRefNo = ds.Tables[0].Rows[0]["bankrefno"].ToString();
                _PaymentMode = ds.Tables[0].Rows[0]["paymentmode"].ToString();
                _CardName = ds.Tables[0].Rows[0]["cardname"].ToString();
                _Coupon = ds.Tables[0].Rows[0]["coupon"].ToString();
                _CouponAmount = double.Parse(ds.Tables[0].Rows[0]["couponamount"].ToString());


            }
            else
            {
                HasValue = false;
            }
        }
        connect.Dispose();
        connect = null;
    }
  


    public OrderHeaderData(int Id)
    {
        Connection connect = new Connection();
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@int_Id", Id));
        using (DataSet ds = connect.GetDataset("SELECT * FROM orderheader WHERE userid=@int_Id and isconfirm=0", param))
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                HasValue = true;
                _Id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                _UserId = int.Parse(ds.Tables[0].Rows[0]["userid"].ToString());
                _Address = int.Parse(ds.Tables[0].Rows[0]["address"].ToString());
                _Goodies = int.Parse(ds.Tables[0].Rows[0]["goodeis"].ToString());
                _PayAmount = double.Parse(ds.Tables[0].Rows[0]["payamount"].ToString());
                _OrderTotal = ds.Tables[0].Rows[0]["ordertotal"].ToString();
                _DeliveryCharge = ds.Tables[0].Rows[0]["delivery"].ToString();
                _OrderPlaced = ds.Tables[0].Rows[0]["placedate"].ToString();
                _OrderDate =ds.Tables[0].Rows[0]["orderdate"].ToString();
                _OrderTime = ds.Tables[0].Rows[0]["ordertime"].ToString();
                _Instruction = ds.Tables[0].Rows[0]["instruction"].ToString();
                _IsPlaced = int.Parse(ds.Tables[0].Rows[0]["IsPlaced"].ToString());
                _PaymentOption = ds.Tables[0].Rows[0]["paymentoption"].ToString();
                _Status = ds.Tables[0].Rows[0]["status"].ToString();
                _OrderStatus = ds.Tables[0].Rows[0]["orderstatus"].ToString();
                _TrackingId = ds.Tables[0].Rows[0]["trackingid"].ToString();
                _BankRefNo = ds.Tables[0].Rows[0]["bankrefno"].ToString();
                _PaymentMode = ds.Tables[0].Rows[0]["paymentmode"].ToString();
                _CardName = ds.Tables[0].Rows[0]["cardname"].ToString();
                _Coupon = ds.Tables[0].Rows[0]["coupon"].ToString();
                _CouponAmount = double.Parse(ds.Tables[0].Rows[0]["couponamount"].ToString());
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
        
        param.Add(new MySqlParameter("@userid", _UserId));
        param.Add(new MySqlParameter("@address", _Address));
        param.Add(new MySqlParameter("@goodeis", _Goodies));
        param.Add(new MySqlParameter("@coupon", _Coupon));
        param.Add(new MySqlParameter("@couponamount", _CouponAmount));
        param.Add(new MySqlParameter("@ordertotal", _OrderTotal));
        param.Add(new MySqlParameter("@delivery", _DeliveryCharge));
        param.Add(new MySqlParameter("@placedate", _OrderPlaced));
        param.Add(new MySqlParameter("@orderdate", _OrderDate));
        param.Add(new MySqlParameter("@ordertime", _OrderTime));
        param.Add(new MySqlParameter("@instruction", _Instruction));
        param.Add(new MySqlParameter("@paymentoption", _PaymentOption));
        param.Add(new MySqlParameter("@status", _Status));
        Connection connect = new Connection();
        connect.ExecStatement("INSERT INTO orderheader(userid,address,ordertotal,goodeis,coupon,couponamount,delivery,placedate,orderdate,ordertime,instruction,paymentoption,status) VALUES(@userid,@address,@ordertotal,@goodeis,@coupon,@couponamount,@delivery,@placedate,@orderdate,@ordertime,@instruction,@paymentoption,@status)", param);
        connect.Dispose();
        connect = null;
    }
    public void UpdateOrder(int id)
    {

        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@id", id));
        param.Add(new MySqlParameter("@orderstatus", _OrderStatus));
        param.Add(new MySqlParameter("@trackingid", _TrackingId));
        param.Add(new MySqlParameter("@bankrefno", _BankRefNo));
        param.Add(new MySqlParameter("@paymentmode", _PaymentMode));
        param.Add(new MySqlParameter("@cardname", _CardName));


        Connection connect = new Connection();
        connect.ExecStatement("UPDATE orderheader SET orderstatus=@orderstatus,trackingid=@trackingid,bankrefno=@bankrefno,paymentmode=@paymentmode,cardname=@cardname WHERE id=@id", param);
        connect.Dispose();
        connect = null;
    }

    public void Update(int id)
    {
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@id", id));   


        Connection connect = new Connection();
        connect.ExecStatement("UPDATE orderheader SET isconfirm=1 WHERE id=@id", param);
        connect.Dispose();
        connect = null;
    }
    public void UpdateStatus(int id)
    {
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@id", id));
        param.Add(new MySqlParameter("@status", _Status));



        Connection connect = new Connection();
        connect.ExecStatement("UPDATE orderheader SET status=@status WHERE id=@id", param);
        connect.Dispose();
        connect = null;
    }
    public void UpdatePayAmount(int id)
    {
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@id", id));
        param.Add(new MySqlParameter("@payamount", _PayAmount));



        Connection connect = new Connection();
        connect.ExecStatement("UPDATE orderheader SET payamount=@payamount WHERE id=@id", param);
        connect.Dispose();
        connect = null;
    }
    public void Delivered(int id)
    {
        List<MySqlParameter> param = new List<MySqlParameter>();
        param.Add(new MySqlParameter("@id", id));



        Connection connect = new Connection();
        connect.ExecStatement("UPDATE orderheader SET IsPlaced=1 WHERE id=@id", param);
        connect.Dispose();
        connect = null;
    }
    public DataSet getOrderHeader(String query)
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
    public int UserId
    {
        get { return _UserId; }
        set { _UserId = value; }
    }

    public int Address
    {
        get { return _Address; }
        set { _Address = value; }
    }
    public int Goodeis
    {
        get { return _Goodies; }
        set { _Goodies = value; }
    }
    public string Coupon
    {
        get { return _Coupon; }
        set { _Coupon = value; }
    }
    public double CouponAmount
    {
        get { return _CouponAmount; }
        set { _CouponAmount = value; }
    }
    public double PayAmount
    {
        get { return _PayAmount; }
        set { _PayAmount = value; }
    }
    public string OrderTotal
    {
        get { return _OrderTotal; }
        set { _OrderTotal = value; }
    }
    public string DeliveryCharge
    {
        get { return _DeliveryCharge; }
        set { _DeliveryCharge = value; }
    }
    public string PlacedDate
    {
        get { return _OrderPlaced; }
        set { _OrderPlaced = value; }
    }
    public string OrderDate
    {
        get { return _OrderDate; }
        set { _OrderDate = value; }
    }
    public string OrderTime
    {
        get { return _OrderTime; }
        set { _OrderTime = value; }
    }
    public string Instruction
    {
        get { return _Instruction; }
        set { _Instruction = value; }
    }
    public int IsPlaced
    {
        get { return _IsPlaced; }
        set { _IsPlaced = value; }
    }
    public string PaymentOption
    {
        get { return _PaymentOption; }
        set { _PaymentOption = value; }
    }
    public string OrderStatus
    {
        get { return _OrderStatus; }
        set { _OrderStatus = value; }
    }

    public string TrackingId
    {
        get { return _TrackingId; }
        set { _TrackingId = value; }
    }
    public string BankRefNo
    {
        get { return _BankRefNo; }
        set { _BankRefNo = value; }
    }
    public string PaymentMode
    {
        get { return _PaymentMode; }
        set { _PaymentMode = value; }
    }
    public string CardName
    {
        get { return _CardName; }
        set { _CardName = value; }
    }
    public string Status
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