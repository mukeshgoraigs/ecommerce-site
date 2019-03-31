using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UrbanAdmin_CustomerReport : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            fillCustomer("select * from customer");
        }

    }
    private void fillCustomer(string query)
    {
        OrderHeaderData ohdata = new OrderHeaderData();
        DataSet ds = ohdata.getOrderHeader(query);
        rpCustomer.DataSource = ds;
        rpCustomer.DataBind();

        setCustomerStatus(ds);
    }
    protected void setCustomerStatus(DataSet ds)
    {
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            DropDownList cmbStatus = (DropDownList)rpCustomer.Items[i].FindControl("cmbCustomerStatus");
            cmbStatus.SelectedValue = ds.Tables[0].Rows[i]["status"].ToString();
        }
    }
 
    protected void cmbCustomerStatusTop_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (cmbCustomerStatusTop.SelectedValue.ToString() != "select")
        {
            fillCustomer("select * from customer where status=" + cmbCustomerStatusTop.SelectedValue.ToString());
        }
        else
        {
            fillCustomer("select * from customer");
        }

    }
}