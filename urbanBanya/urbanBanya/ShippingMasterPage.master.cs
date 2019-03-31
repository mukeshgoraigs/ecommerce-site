using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ShippingMasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            fillMainMenu();

            if (SessionVeriables.IsLogged)
            {
                

                userName.Text = "Hi " + SessionVeriables.SessionName;
                hdnsessionid.Value = SessionVeriables.SessionID;
                hdemail.Value = SessionVeriables.SessionEmail;
            }
            else
            {
                Response.Redirect("Default.aspx");
            }
        }

    }
    private void fillMainMenu()
    {
        try
        {
            CategoryData cdata = new CategoryData();
            DataSet ds = cdata.getFullCategory();
            rpMainMenu.DataSource = ds.Tables["category"];

            Page.DataBind();
        }
        catch (Exception ex) { }
    }
}
