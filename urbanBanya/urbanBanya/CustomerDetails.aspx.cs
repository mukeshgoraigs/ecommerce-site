using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class CustomerDetails : System.Web.UI.Page
{
    static int totalItems;
    static double totalAmount;
    static double totaldiscount;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            CustomerData cdata = new CustomerData(SessionVeriables.SessionEmail);
            AddressData adata = new AddressData(cdata.Id);
            if (adata.HasValue)
            {
                Response.Redirect("ShippingAddress.aspx");
            }
            else
            {
                email.Text = cdata.Email;
                mobile.Text = cdata.Mobile;
                fillCartItems();
            }
        }
    }
    public void fillCartItems()
    {
        MyCartData cdata = new MyCartData();
        DataSet ds = cdata.getCart("select product.id,product.productName,product.price,product.discount,product.newprice,product.size,product.image,cartdata.id as cid,cartdata.productid,cartdata.quantity,cartdata.sessionid,cartdata.userid from product inner join cartdata on product.id=cartdata.productid where sessionid='" + SessionVeriables.SessionID + "'");
        lblTotalItems.Text = ds.Tables[0].Rows.Count.ToString();
        if (ds.Tables[0].Rows.Count > 0)
        {

            calculateTotal(ds);
        }
        else
        {
            //lblTotalItems.Text = "No item In Cart";
        }

    }

    protected void calculateTotal(DataSet ds)
    {
        totalItems = 0;
        totalAmount = 0.0;
        totaldiscount = 0.0;
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            totalItems += int.Parse(ds.Tables[0].Rows[i]["quantity"].ToString());
            totalAmount += (double.Parse(ds.Tables[0].Rows[i]["newPrice"].ToString()) * double.Parse(ds.Tables[0].Rows[i]["quantity"].ToString()));
            totaldiscount += (double.Parse(ds.Tables[0].Rows[i]["price"].ToString()) - double.Parse(ds.Tables[0].Rows[i]["newprice"].ToString()));
        }
        lblTotalAmount.Text = totalAmount.ToString();

        lblTotalItems.Text = totalItems.ToString();
        lblTotalDiscount.Text = totaldiscount.ToString();

    }
}