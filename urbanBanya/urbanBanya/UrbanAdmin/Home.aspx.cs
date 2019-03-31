using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Home : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        fillOrders();  
       
    }
    private void fillOrders()
    {
        OrderHeaderData ohdata = new OrderHeaderData();
        DataSet ds = ohdata.getOrderHeader("select id,userid,address,ordertotal,placedate,orderdate,ordertime from orderheader where isconfirm=1 order by id desc limit 10");
        rpTopOrer.DataSource = ds;
        rpTopOrer.DataBind();
    }
}