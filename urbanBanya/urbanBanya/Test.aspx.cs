using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SmsApi;

public partial class Test : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        CustomerData cdata = new CustomerData();
        cdata.FirstName = Name.Text;
        cdata.Mobile = Mobile.Text;
        cdata.Email = Email.Text;
        Random r = new Random();
        long otp = r.Next(10000, 999999);
        Sms.sendMessage("OTP : "+otp.ToString(), Mobile.Text.ToString().Trim());
    }
}