using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.IO;

/// <summary>
/// Summary description for MailAlerts
/// </summary>
public class MailSend
{
    private string _smtpserver = string.Empty;
    private string _Port = string.Empty;
    private string _Authenticate = string.Empty;
    private string _UserName = string.Empty;
    private string _ePassword = string.Empty;
    private string _UseSSL = string.Empty;
    private string _EmailFrom = string.Empty;

    public MailSend(string data)
    {
        string myEmailCredentials = System.Configuration.ConfigurationManager.AppSettings[data].ToString();
        // Get from the configration settings in web config.
        //<add key="MailAlerts" value="smtpserver=smtp.gmail.com;Port=465;Authenticate=1;UserName=abc@gmail.com;ePassword=abc@123;UseSSL=True;EmailFrom=abc@gmail.com;"/>
        string[] settings = myEmailCredentials.Split(';');

        _smtpserver = GetValue(settings, "smtpserver");
        _Port = GetValue(settings, "Port");
        _Authenticate = GetValue(settings, "Authenticate");
        _UserName = GetValue(settings, "UserName");
        _ePassword = GetValue(settings, "ePassword");
        _UseSSL = GetValue(settings, "UseSSL");
        _EmailFrom = GetValue(settings, "EmailFrom");
    }

    public bool SendMail(string MailTO, string EmailSubject, string EmailBody, string AttachmentFile)
    {
        try
        {
            System.Web.Mail.MailMessage Mail = new System.Web.Mail.MailMessage();
            Mail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpserver", _smtpserver);//"smtp.gmail.com"
            Mail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpserverport", _Port);//"465";
            Mail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendusing", "2");
            Mail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpauthenticate", _Authenticate);//"1"
            // Edit username & password
            Mail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendusername", _UserName); //"username";
            Mail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendpassword", _ePassword);//"PASSWORD";
            Mail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpusessl", _UseSSL);//"true"
            Mail.To = MailTO;
            Mail.From = _EmailFrom;
            Mail.Subject = EmailSubject;
            Mail.Body = EmailBody;
            Mail.BodyFormat = System.Web.Mail.MailFormat.Html;

            if (AttachmentFile != null)
            {
                if (File.Exists(System.Web.HttpContext.Current.Server.MapPath(AttachmentFile)))
                {
                    System.Web.Mail.MailAttachment Attachment = new System.Web.Mail.MailAttachment(System.Web.HttpContext.Current.Server.MapPath(AttachmentFile));
                    Mail.Attachments.Add(Attachment);
                }
            }
            //System.Web.Mail.SmtpMail.SmtpServer = _HostEmailAddress; ;
            System.Web.Mail.SmtpMail.Send(Mail);
            return true;
        }
        catch (Exception ex)
        {
          //  Utils.FetchError.WriteError(ex.StackTrace);
            return false;
        }
    }

    public bool SendMail(string MailTO, string EmailSubject, string EmailBody)
    {
        try
        {
            System.Web.Mail.MailMessage Mail = new System.Web.Mail.MailMessage();
            Mail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpserver", _smtpserver);//"smtp.gmail.com"
            Mail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpserverport", _Port);//"465";
            Mail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendusing", "2");
            Mail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpauthenticate", _Authenticate);//"1"
            // Edit username & password
            Mail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendusername", _UserName); //"username";
            Mail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendpassword", _ePassword);//"PASSWORD";
            Mail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpusessl", _UseSSL);//"true"
            Mail.To = MailTO;
            Mail.From = _EmailFrom;
            Mail.Subject = EmailSubject;
            Mail.Body = EmailBody;
            Mail.BodyFormat = System.Web.Mail.MailFormat.Html;


            //System.Web.Mail.SmtpMail.SmtpServer = _HostEmailAddress; ;
            System.Web.Mail.SmtpMail.Send(Mail);
            return true;
        }
        catch (Exception ex)
        {
           // Utils.FetchError.WriteError(ex.StackTrace);
            return false;
        }
    }
    private string GetValue(string[] settings, string configsettingcontain)
    {
        string value = string.Empty;

        configsettingcontain = settings.Where(C => C.Contains(configsettingcontain)).SingleOrDefault();

        value = configsettingcontain.Substring(configsettingcontain.LastIndexOf("=") + 1);

        return value;
    }
}
