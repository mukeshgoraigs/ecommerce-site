using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UrbanAdmin_Invoice : System.Web.UI.Page
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
        DataSet ds = ohdata.getOrderHeader("select id,userid,address,ordertotal,placedate,orderdate,ordertime,status from orderheader where isconfirm=1 and status='Completed' order by id desc limit 10");
        rpTopOrer.DataSource = ds;
        rpTopOrer.DataBind();

       
    }
    protected void btnGetInvoice_Click(object sender, EventArgs e)
    {
      
            string datef = datefrom.Text.ToString().Trim();
            string datet = dateto.Text.ToString().Trim();
            OrderHeaderData ohdata = new OrderHeaderData();
            DataSet ds = ohdata.getOrderHeader("select id,userid,address,ordertotal,placedate,orderdate,ordertime,status from orderheader where isconfirm=1 and status='Completed' and placedate between '" + datef + "' and '" + datet + "'");
            rpTopOrer.DataSource = ds;
            rpTopOrer.DataBind();
           
    }
}