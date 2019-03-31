using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class PayOnline : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
      
       
        int orderid =int.Parse( Request.QueryString["orderid"]);
        double totalamount = double.Parse(Request.QueryString["totalamount"]);
        string name = Request.QueryString["name"];
        string area = Request.QueryString["area"];
        string pincode = Request.QueryString["pincode"];
        string city = Request.QueryString["city"];
        string mobile = Request.QueryString["mobile"];
        string email = Request.QueryString["email"];
       
       
        if(!IsPostBack)
        {
            postData(orderid,totalamount,name,area,pincode,city,mobile,email);
        }
    }
    private void postData(int orderid, double amount, string name, string area, string pincode, string city, string mobile, string email)
    {
        string mid = WebConfigurationManager.AppSettings["merchantid"];
        string redirect_url = WebConfigurationManager.AppSettings["redirect_url"];
        string cancel_url = WebConfigurationManager.AppSettings["cancel_url"];
        NameValueCollection collections = new NameValueCollection();
        collections.Add("merchant_id", mid);
        collections.Add("order_id", orderid.ToString());
        collections.Add("amount", amount.ToString());
        collections.Add("currency", "INR");
        collections.Add("redirect_url", redirect_url);
        collections.Add("cancel_url", cancel_url);
        collections.Add("billing_name", name);
        collections.Add("billing_address", area);
        collections.Add("billing_city", city);
        collections.Add("billing_zip", pincode);
        collections.Add("billing_tel", mobile);
        collections.Add("billing_email", email);
        string remoteUrl = "ccavRequestHandler.aspx";

        string html = "<html><head>";
        html += "</head><body onload='document.forms[0].submit()'>";
        html += string.Format("<form name='customerData' method='POST' action='{0}'>", remoteUrl);
        foreach (string key in collections.Keys)
        {
            html += string.Format("<input name='{0}' type='text' value='{1}'>", key, collections[key]);
        }
        html += "</form></body></html>";

        Response.Clear();
        Response.ContentEncoding = Encoding.GetEncoding("ISO-8859-1");
        Response.HeaderEncoding = Encoding.GetEncoding("ISO-8859-1");
        Response.Charset = "ISO-8859-1";
        Response.Write(html);
        HttpContext.Current.Response.End();
    }
}