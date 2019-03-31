using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Configuration;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    static int totalItems;
    static double totalAmount;
    static double totaldiscount;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            fillSlider();
            fillBargainsitem();
            fillHotitem();
            fillNewitem();
            fillOffers();
            setMeta();
        }
    }
    protected void setMeta()
    {
        MasterPage myMaster = (MasterPage)this.Master;
        myMaster.MetaTitle = "UrbanBanya delivers grocery within 3 hours in Jaipur";
        myMaster.MetaDescription = "UrbanBanya delivers grocery within 3 hours in Jaipur. UrbanBanya is the largest grocery hypermarket in India. UrbanBanya sells all brands of Deodorant items";
        myMaster.MetaKeywords = "UrbanBanya, Online Grocery, Grocery, Hypermarket, Supermarket, Buy Online, Deodorant";
    }
    private void fillOffers()
    {
        NewOfferData ndata = new NewOfferData();
        DataSet ds =ndata.getNewOffer("select * from newoffer where isvisible=true");
        if (ds.Tables[0].Rows.Count > 0)
        {
            rpNewOffer.DataSource = ds;
            rpNewOffer.DataBind();

        }
    }

    private void fillSlider()
    {
        SliderData sdata = new SliderData();
        DataSet ds = sdata.getSlider("select * from slider where isvisible=true");
        if (ds.Tables[0].Rows.Count > 0)
        {
            rpSlider.DataSource = ds;
            rpSlider.DataBind();

        }
    }
    private void fillBargainsitem()
    {

        ProductData cdata = new ProductData();
        DataSet ds = cdata.getProduct("select product.id,product.productName,product.description,product.code,product.price,product.newprice,product.discount,product.size,product.quantity as stock,product.image,product.prodtype,hotitem.id as hotid,hotitem.position,cartdata.quantity,cartdata.selected from product inner join hotitem on product.id=hotitem.productid and product.status=1 and hotitem.section=1 left join cartdata on product.id=cartdata.productid and cartdata.sessionid='" + SessionVeriables.SessionID + "' order by hotitem.position ASC");
        if (ds.Tables[0].Rows.Count > 0)
        {
            rpBargains.DataSource = ds;
            rpBargains.DataBind();

        }

    }


    private void fillNewitem()
    {

        ProductData cdata = new ProductData();
        DataSet ds = cdata.getProduct("select product.id,product.productName,product.description,product.code,product.price,product.newprice,product.discount,product.size,product.quantity as stock,product.image,product.prodtype,hotitem.id as hotid,hotitem.position,cartdata.quantity,cartdata.selected from product inner join hotitem on product.id=hotitem.productid and product.status=1 and hotitem.section=2 left join cartdata on product.id=cartdata.productid and cartdata.sessionid='" + SessionVeriables.SessionID + "' order by hotitem.position ASC");
        if (ds.Tables[0].Rows.Count > 0)
        {
            rpNewItem.DataSource = ds;
            rpNewItem.DataBind();

        }

    }
    private void fillHotitem()
    {

        ProductData cdata = new ProductData();
        DataSet ds = cdata.getProduct("select product.id,product.productName,product.description,product.code,product.price,product.newprice,product.discount,product.size,product.quantity as stock,product.image,product.prodtype,hotitem.id as hotid,hotitem.position,cartdata.quantity,cartdata.selected from product inner join hotitem on product.id=hotitem.productid and product.status=1 and hotitem.section=3 left join cartdata on product.id=cartdata.productid and cartdata.sessionid='" + SessionVeriables.SessionID + "' order by hotitem.position ASC");
        if (ds.Tables[0].Rows.Count > 0)
        {
            rpHotItem.DataSource = ds;
            rpHotItem.DataBind();

        }


    }
    [WebMethod]
    public static string register(string name, string email, string mobile, string password,string loginby)
    {
        Random r = new Random();
        int otp=r.Next(1000,9999);
        string msg = "Use "+otp+" as OTP to verify your identity , please don't share to anyone . \n Urban Banya";
        string response = "";
        try
        {
            CustomerData cdata = new CustomerData(email);
            if (!cdata.HasValue)
            {
                cdata.FirstName = name;
                cdata.Email = email;
                cdata.Mobile = mobile;
                cdata.Password = password;
                cdata.OTP = otp.ToString();
                cdata.LoginBy = loginby;
                cdata.Save();
                SendMessageData.sendMessage(msg, mobile);
                MailManager mail = new MailManager();
                mail.SendOtpMail(cdata);
                response =email;
                //SessionVeriables.SessionEmail = email;
                //SessionVeriables.SessionName = name;
                //SessionVeriables.IsLogged = true;
                //CustomerData ccdata = new CustomerData(email);

                //MyCartData mdata = new MyCartData(SessionVeriables.SessionID,ccdata.Id);
                //if (mdata.HasValue)
                //{
                //    mdata.UserId = ccdata.Id;
                //    mdata.Update(SessionVeriables.SessionID);
                //    mdata.SessionId = SessionVeriables.SessionID;
                //    mdata.UpdateByUser(cdata.Id);

                //}
            }
            else
            {
                response = "no";
            }

        }
        catch (Exception ex)
        {

        }
        return response;
    }

    [WebMethod]
    public static string checkUserExist(string email)
    {
        string response = "";
        try
        {
            CustomerData cdata = new CustomerData(email);
            if (cdata.HasValue)
            {
                if (cdata.Status == 1)
                {
                    if (cdata.LoginBy == "facebook")
                    {
                        response = cdata.FirstName;
                        SessionVeriables.SessionEmail = email;
                        SessionVeriables.SessionName = cdata.FirstName;
                        SessionVeriables.IsLogged = true;
                        MyCartData mdata = new MyCartData(SessionVeriables.SessionID, cdata.Id);
                        if (mdata.HasValue)
                        {
                            mdata.UserId = cdata.Id;
                            mdata.Update(SessionVeriables.SessionID);
                            mdata.SessionId = SessionVeriables.SessionID;
                            mdata.UpdateByUser(cdata.Id);
                        }
                    }
                    else
                    {
                        response = "website";
                    }
                }
                else
                {
                    response = "block";
                }

            }
            else
            {
                response = "no";
            }

        }
        catch (Exception ex)
        {

        }
        return response;
    }

    [WebMethod]
    public static string login(string email, string password)
    {
        string response = "";
        try
        {
            CustomerData cdata = new CustomerData(email, password);
            if (cdata.HasValue)
            {
                if(cdata.Status==1)
                { 
                response = cdata.FirstName;
                SessionVeriables.SessionEmail = email;
                SessionVeriables.SessionName = cdata.FirstName;
                SessionVeriables.IsLogged = true;
                MyCartData mdata = new MyCartData(SessionVeriables.SessionID,cdata.Id);
                if (mdata.HasValue)
                {
                    mdata.UserId = cdata.Id;
                    mdata.Update(SessionVeriables.SessionID);
                    mdata.SessionId = SessionVeriables.SessionID;
                    mdata.UpdateByUser(cdata.Id);
                }
                }
                else
                {
                    response = "block";
                }

            }
            else
            {
                response = "no";
            }

        }
        catch (Exception ex)
        {

        }
        return response;
    }
    [WebMethod]
    public static string checklogin()
    {
        string response = "";
        try
        {

            if (SessionVeriables.IsLogged)
            {

                response = SessionVeriables.SessionName;

            }
            else
            {
                response = "no";
            }

        }
        catch (Exception ex)
        {

        }
        return response;
    }


    [WebMethod]
    public static string verifyOtp(string email, string otp)
    {
        string msg = "";
        string response = "";
        try
        {
            CustomerData cdata = new CustomerData();
            cdata.verifyOtp(email,otp);
            if (cdata.HasValue)
            {
                msg = "Welcome\n" + cdata.FirstName + " to Urban Banya now you have access to the online shopping,feel free to contact with us any time at our website and mobile application";
                cdata.Verified = 1;
                cdata.UpdateVerified(cdata.Id);
                SendMessageData.sendMessage(msg,cdata.Mobile);
                MailManager mail = new MailManager();
                mail.SendRegisterMail(cdata);

                if (cdata.Status == 1)
                {
                    response = cdata.FirstName;
                    SessionVeriables.SessionEmail = email;
                    SessionVeriables.SessionName = cdata.FirstName;
                    SessionVeriables.IsLogged = true;
                    MyCartData mdata = new MyCartData(SessionVeriables.SessionID, cdata.Id);
                    if (mdata.HasValue)
                    {
                        mdata.UserId = cdata.Id;
                        mdata.Update(SessionVeriables.SessionID);
                        mdata.SessionId = SessionVeriables.SessionID;
                        mdata.UpdateByUser(cdata.Id);
                    }
                }
                else
                {
                    response = "block";
                }

            }
            else
            {
                response = "invalid";
            }

        }
        catch (Exception ex)
        {

        }
        return response;
    }


}