using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UrbanAdmin_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        try
        {
            string userid = txtUserId.Text;
            string password = txtPassword.Text;
            AdminData adata = new AdminData(userid, password);
            if (adata.HasValue)
            {
                SessionVeriables.IsLogged = true;
                SessionVeriables.IsAdmin = true;
                Response.Redirect("Home.aspx");
            }
            else
            {
                lblMessage.Text = "Invalid User-Id And Password :(";
            }

        }
        catch (Exception ex) { }
    }
}