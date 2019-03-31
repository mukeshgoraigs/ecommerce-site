using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ViewOrder : System.Web.UI.Page
{
    static int orderid, adid;
    static double totalAmount;
    protected void Page_Load(object sender, EventArgs e)
    {
        orderid = int.Parse(Request.QueryString["orderid"]);       
        adid = int.Parse(Request.QueryString["adid"]);
        fillOrderItems();
        fillAddress();
        lblOrderNo.Text = orderid.ToString();
    }
    private void fillAddress()
    {
        CustomerData cdata = new CustomerData(SessionVeriables.SessionEmail);
        
        AddressData adata = new AddressData(adid, "myaddress");
        lblCity.Text = adata.City;
        lblArea.Text = adata.Area;
        lblPincode.Text = adata.Pincode;
        lblAddress1.Text = adata.Address1;
        lblAddress2.Text = adata.Address2;
        lblLandmark.Text = adata.Landmark;

        OrderHeaderData ohdata = new OrderHeaderData(orderid, "No use");
       
        if(ohdata.Status=="Canceled")
        {
            string orderAttribute = "<script>" +
        "$('.btnCancelOrder').css('display','none');" +
        "</script>";
            lblScript.Text = orderAttribute;
        }
    }
    private void fillOrderItems()
    {
        OrderLineData oldata = new OrderLineData();
        DataSet ds = oldata.getCart("select product.id,product.productName,product.image,orderline.id as ocid,orderline.quantity,orderline.newprice,orderline.totalamount from product inner join orderline on product.id=orderline.itemno where orderline.orderno=" + orderid);
        // lblTotalItems.Text = ds.Tables[0].Rows.Count.ToString();
        if (ds.Tables[0].Rows.Count > 0)
        {

            rpMyOrder.DataSource = ds;
            rpMyOrder.DataBind();
            calculate(ds);
            string orderAttribute = "<script>" +
        "$('.btnCancelOrder').attr('data-id','" + orderid + "');" +       
        "</script>";
            lblScript.Text =orderAttribute;

        }
        else
        {
            //lblTotalItems.Text = "No item In Cart";
        }

    }

    protected void calculate(DataSet ds)
    {
        totalAmount = 0;
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            totalAmount += double.Parse(ds.Tables[0].Rows[i]["totalamount"].ToString());

        }
        lblTotalAmount.Text = totalAmount.ToString();
    }
  
}