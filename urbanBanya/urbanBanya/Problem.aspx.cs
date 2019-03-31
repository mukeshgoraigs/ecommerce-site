using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Problem : System.Web.UI.Page
{
    static int oid;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            oid = int.Parse(Request.QueryString["ooiidd"]);
            //OrderHeaderData ohdata = new OrderHeaderData();
            //ohdata.Delete("delete from orderheader where id="+oid);
        }
    }
}