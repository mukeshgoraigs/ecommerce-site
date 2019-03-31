using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

/// <summary>
/// Summary description for SessionVeriables
/// </summary>
public class SessionVeriables
{
    public SessionVeriables()
    {

    }
    
    public static Boolean IsLogged
    {
        get
        {
            if (HttpContext.Current.Session["UserId"] != null)
                return true;
            else
                return false;
        }
        set
        {
            HttpContext.Current.Session["UserId"] = value;
        }
    }
    public static string UserName
    {
        get
        {
            if (HttpContext.Current.Session["UserName"] != null && !HttpContext.Current.Session["UserName"].ToString().Equals(""))
                return HttpContext.Current.Session["UserName"].ToString();
            else
                return "";
        }
        set
        {
            HttpContext.Current.Session["UserName"] = value;
        }
    }

    public static string SessionName
    {
        get
        {
            if (HttpContext.Current.Session["SessionName"] != null && !HttpContext.Current.Session["SessionName"].ToString().Equals(""))
                return HttpContext.Current.Session["SessionName"].ToString();
            else
                return "";
        }
        set
        {
            HttpContext.Current.Session["SessionName"] = value;
        }
    }

    public static string SessionID
    {
        get
        {
            if (HttpContext.Current.Session["SessionID"] != null && !HttpContext.Current.Session["SessionID"].ToString().Equals(""))
                return HttpContext.Current.Session["SessionID"].ToString();
            else
                return "";
        }
        set
        {
            HttpContext.Current.Session["SessionID"] = value;
        }
    }
    public static string SessionEmail
    {
        get
        {
            if (HttpContext.Current.Session["EmailAddress"] != null)
                return HttpContext.Current.Session["EmailAddress"].ToString();
            else
                return "";
        }
        set
        {
            HttpContext.Current.Session["EmailAddress"] = value;
        }
    }
    public static string Instruction
    {
        get
        {
            if (HttpContext.Current.Session["Instruction"] != null)
                return HttpContext.Current.Session["Instruction"].ToString();
            else
                return "";
        }
        set
        {
            HttpContext.Current.Session["Instruction"] = value;
        }
    }
    public static int UserId
    {
        get
        {
            if (HttpContext.Current.Session["UserId"] != null)
                return int.Parse(HttpContext.Current.Session["UserId"].ToString());
            else
                return 0;
        }
        set
        {
            HttpContext.Current.Session["UserId"] = value;
        }
    }

    public static bool IsAdmin
    {
        get
        {
            if (HttpContext.Current.Session["IsAdmin"] != null)
                return bool.Parse(HttpContext.Current.Session["IsAdmin"].ToString());
            else
                return false;
        }
        set
        {
            HttpContext.Current.Session["IsAdmin"] = value;
        }
    }
}