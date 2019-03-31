using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UrbanAdmin_Orders : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            fillOrders();
        }
    }
    private void fillOrders()
    {
        OrderHeaderData ohdata = new OrderHeaderData();
        DataSet ds = ohdata.getOrderHeader("select id,userid,address,ordertotal,payamount,placedate,orderdate,ordertime,status from orderheader where isconfirm=1 order by id desc");
        rpTopOrer.DataSource = ds;
        rpTopOrer.DataBind();

        setOrderStatus(ds);
    }
    protected void setOrderStatus(DataSet ds)
    {
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            DropDownList cmbStatus = (DropDownList)rpTopOrer.Items[i].FindControl("cmbOrderStatus");
            cmbStatus.SelectedValue = ds.Tables[0].Rows[i]["status"].ToString();
        }
    }
    protected void cmbOrderStatus_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList ddl = (DropDownList)sender;

        RepeaterItem ri = (RepeaterItem)ddl.NamingContainer;
        Label lblid = (Label)rpTopOrer.Items[ri.ItemIndex].FindControl("lblid");
        OrderHeaderData ohdata = new OrderHeaderData();
        ohdata.Status = ddl.SelectedValue;
        ohdata.UpdateStatus(int.Parse(lblid.Text.ToString()));
    }
    protected void btnGetReport_Click(object sender, EventArgs e)
    {
        if(cmbOrderStatusd.SelectedIndex!=0)
        { 
        string datef = datefrom.Text.ToString().Trim();
        string datet = dateto.Text.ToString().Trim();
        OrderHeaderData ohdata = new OrderHeaderData();
        DataSet ds = ohdata.getOrderHeader("select id,userid,address,ordertotal,placedate,orderdate,ordertime,status from orderheader where isconfirm=1 and status='"+ cmbOrderStatusd.SelectedValue.ToString()+ "' and placedate between '" + datef + "' and '" + datet + "' order by id desc");
        rpTopOrer.DataSource = ds;
        rpTopOrer.DataBind();
            setOrderStatus(ds);
        }
        else
        {
            showmsg.Text= "<script>alert('Please Select the Status !');</script>";
        }
    }


}