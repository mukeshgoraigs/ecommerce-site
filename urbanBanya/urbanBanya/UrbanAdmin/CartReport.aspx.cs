using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UrbanAdmin_CartReport : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            fillCartReport();
        }
    }

    private void fillCartReport()
    {
        MyCartData mcdata = new MyCartData();
        DataSet ds = mcdata.getCart("select * from customer where id in(select DISTINCT userid from cartdata where userid !=0)");
        rpCartCustomer.DataSource = ds;
        rpCartCustomer.DataBind();
    }
}