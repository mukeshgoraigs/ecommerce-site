using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UrbanAdmin_Shipment : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            fillOrders();
        }
    }
    private void fillOrders()
    {
        OrderHeaderData ohdata = new OrderHeaderData();
        DataSet ds = ohdata.getOrderHeader("select id,userid,address,ordertotal,placedate,orderdate,ordertime,status from orderheader where isconfirm=1 and status='Shipped' order by id desc limit 10");
        rpShippedOrder.DataSource = ds;
        rpShippedOrder.DataBind();


    }
    protected void btnGetShipped_Click(object sender, EventArgs e)
    {

        string datef = datefrom.Text.ToString().Trim();
        string datet = dateto.Text.ToString().Trim();
        OrderHeaderData ohdata = new OrderHeaderData();
        DataSet ds = ohdata.getOrderHeader("select id,userid,address,ordertotal,placedate,orderdate,ordertime,status from orderheader where isconfirm=1 and status='Shipped' and placedate between '" + datef + "' and '" + datet + "'");
        rpShippedOrder.DataSource = ds;
        rpShippedOrder.DataBind();

    }
}