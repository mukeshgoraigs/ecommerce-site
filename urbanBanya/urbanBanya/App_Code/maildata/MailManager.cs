using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for MailManager
/// </summary>
public class MailManager
{
    public MailManager()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    #region OTP mail

    public bool SendOtpMail(CustomerData User)
    {
        bool IsSuccess = false;
        try
        {
            MailSend mail = new MailSend("InfoMail");

            //****Mail sent to User
            IsSuccess = mail.SendMail(User.Email, "OTP Verification Urban Banya", GetEmailOtpBody(User.FirstName + " " + User.LastName,User.OTP));
            // if (!IsSuccess)
            // Utils.FetchError.WriteError("Email Sending failed on email : " + User.EmailId);

        }
        catch (Exception Ex)
        {
            //  Utils.FetchError.WriteError(Ex.StackTrace);
        }
        return IsSuccess;
    }


    private string GetEmailOtpBody(string UserName,string otp)
    {
        string EmailBody = System.IO.File.ReadAllText(System.Web.HttpContext.Current.Server.MapPath("~/Webdata/email/otp.html"));
        EmailBody = EmailBody.Replace("__username__", UserName);
        EmailBody = EmailBody.Replace("__otp__", otp);       
        return EmailBody;
    }

    #endregion

    #region Billing mail

    public bool SendBillingMail(CustomerData User, string invoice, string invoicedate,string orderdate,string address, string total, string deliveryCharge, string goodiesamount, string urbanCoupon, string totalBill, string item, string payment, string timeStol,string totalWithoutTax,string totalTax)
    {
        bool IsSuccess = false;
        try
        {
            MailSend mail = new MailSend("SalesMail");

            //****Mail sent to User
            IsSuccess = mail.SendMail(User.Email, "Bill For Your Order at Urban Banya", GetEmailBillBody(User.FirstName + " " + User.LastName, invoice, invoicedate,orderdate, address, total, deliveryCharge, goodiesamount, urbanCoupon, totalBill, item, payment,timeStol,totalWithoutTax,totalTax));
            IsSuccess = mail.SendMail("info@urbanbanya.com", "Bill For Your Order at Urban Banya", GetEmailBillBody(User.FirstName + " " + User.LastName, invoice, invoicedate, orderdate, address, total, deliveryCharge, goodiesamount, urbanCoupon, totalBill, item, payment, timeStol, totalWithoutTax, totalTax));
           // if (!IsSuccess)
               // Utils.FetchError.WriteError("Email Sending failed on email : " + User.EmailId);

        }
        catch (Exception Ex)
        {
          //  Utils.FetchError.WriteError(Ex.StackTrace);
        }
        return IsSuccess;
    }


    private string GetEmailBillBody(string UserName, string invoice, string invoicedate,string orderdate,string address, string total, string deliveryCharge, string goodiesamount, string urbanCoupon, string totalBill, string item, string payment, string timeStol,string totalWithoutTax,string totalTax)
    {
        string EmailBody = System.IO.File.ReadAllText(System.Web.HttpContext.Current.Server.MapPath("~/Webdata/email/billing.html"));
        EmailBody = EmailBody.Replace("_address_", address);
        EmailBody = EmailBody.Replace("_invoice_", invoice);
        EmailBody = EmailBody.Replace("_invoicedate_", invoicedate);
        EmailBody = EmailBody.Replace("_orderdate_", orderdate);
        EmailBody = EmailBody.Replace("_items_", item);
        EmailBody = EmailBody.Replace("_timeSlot_", timeStol);
        EmailBody = EmailBody.Replace("_totalwithouttax_", totalWithoutTax);
        EmailBody = EmailBody.Replace("_totaltax_", totalTax);
        EmailBody = EmailBody.Replace("_total_", total);
        EmailBody = EmailBody.Replace("_delivery_", deliveryCharge);
        EmailBody = EmailBody.Replace("_goodiesamount_", goodiesamount);
        EmailBody = EmailBody.Replace("_urbancoupon_", urbanCoupon);
        EmailBody = EmailBody.Replace("_amount_", totalBill);
        EmailBody = EmailBody.Replace("_paymentmethod_", payment);
        return EmailBody;
    }

    #endregion

    #region Register mail

    public bool SendRegisterMail(CustomerData User)
    {
        bool IsSuccess = false;
        try
        {
            MailSend mail = new MailSend("AccountMail");

            //****Mail sent to User
            IsSuccess = mail.SendMail(User.Email, "Welcome to Urban Banya ", GetEmailRegisterBody(User.FirstName));
            // if (!IsSuccess)
            // Utils.FetchError.WriteError("Email Sending failed on email : " + User.EmailId);

        }
        catch (Exception Ex)
        {
            //  Utils.FetchError.WriteError(Ex.StackTrace);
        }
        return IsSuccess;
    }


    private string GetEmailRegisterBody(string username)
    {
        string EmailBody = System.IO.File.ReadAllText(System.Web.HttpContext.Current.Server.MapPath("~/Webdata/email/register.html"));
        EmailBody = EmailBody.Replace("__username__", username);
       
        return EmailBody;
    }

    #endregion

    #region Forget Password mail

    public bool SendForgetPassMail(CustomerData User)
    {
        bool IsSuccess = false;
        try
        {
            MailSend mail = new MailSend("InfoMail");

            //****Mail sent to User
            IsSuccess = mail.SendMail(User.Email, "Your Urban Banya Password", GetForgetPassBody(User));
            // if (!IsSuccess)
            // Utils.FetchError.WriteError("Email Sending failed on email : " + User.EmailId);

        }
        catch (Exception Ex)
        {
            //  Utils.FetchError.WriteError(Ex.StackTrace);
        }
        return IsSuccess;
    }


    private string GetForgetPassBody(CustomerData User)
    {
        string EmailBody = System.IO.File.ReadAllText(System.Web.HttpContext.Current.Server.MapPath("~/Webdata/email/forget_password.html"));
        EmailBody = EmailBody.Replace("_Name_", User.FirstName);
        EmailBody = EmailBody.Replace("_email_", User.Email);
        EmailBody = EmailBody.Replace("_password_", User.Password);
        return EmailBody;
    }

    #endregion

}

public class Feedback
{
    public string Name;
    public string Email;
    public string Subject;
    public string Message;
}