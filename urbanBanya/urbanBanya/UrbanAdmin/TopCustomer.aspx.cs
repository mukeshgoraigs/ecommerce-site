using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UrbanAdmin_TopCustomer : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            fillTopCustomer();
        }
    }

    private void fillTopCustomer()
    {
        OrderHeaderData ohdata = new OrderHeaderData();
        DataSet ds = ohdata.getOrderHeader("select sum(orderheader.ordertotal) as total,orderheader.userid as id,customer.F_name,customer.email,customer.mobile,customer.points from orderheader join customer on customer.id=orderheader.userid and orderheader.isconfirm=1 and orderheader.status='Completed' group by orderheader.userid order by total DESC");
        rpTopCustomer.DataSource = ds;
        rpTopCustomer.DataBind();
    }
}