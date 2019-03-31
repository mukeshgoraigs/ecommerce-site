using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UrbanCart : System.Web.UI.Page
{
    static int totalItems;
    static double totalAmount;
    static double totaldiscount;
    protected void Page_Load(object sender, EventArgs e)
    {
 fillCartItems();
 updateShopping();

    }

    private void updateShopping()
    {
        CustomerData cdata = new CustomerData(SessionVeriables.SessionEmail);

        MyCartData mdata = new MyCartData(SessionVeriables.SessionID, cdata.Id);
        if (mdata.HasValue)
        {
            mdata.UserId = cdata.Id;
            mdata.Update(SessionVeriables.SessionID);
            mdata.SessionId = SessionVeriables.SessionID;
            mdata.UpdateByUser(cdata.Id);
        }
    }
    public void fillCartItems()
    {
        MyCartData cdata = new MyCartData();
        DataSet ds = cdata.getCart("select product.id,product.productName,product.discount,product.image,cartdata.id as cid,cartdata.productid,cartdata.price,cartdata.newprice,cartdata.size,cartdata.quantity,cartdata.sessionid,cartdata.userid from product inner join cartdata on product.id=cartdata.productid where sessionid='" + SessionVeriables.SessionID + "'");
        lblTotalItems.Text = ds.Tables[0].Rows.Count.ToString();
        if (ds.Tables[0].Rows.Count > 0)
        {


            rpCartFull.DataSource = ds;
            rpCartFull.DataBind();
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
            totalAmount += (double.Parse(ds.Tables[0].Rows[i]["newprice"].ToString()) * double.Parse(ds.Tables[0].Rows[i]["quantity"].ToString()));
            totaldiscount +=( (double.Parse(ds.Tables[0].Rows[i]["price"].ToString()) - double.Parse(ds.Tables[0].Rows[i]["newprice"].ToString()))*double.Parse(ds.Tables[0].Rows[i]["quantity"].ToString()));
        }
        lblTotalAmount.Text = totalAmount.ToString();

        lblTotalItems.Text = totalItems.ToString();
        lblTotalDiscount.Text = totaldiscount.ToString();

    }
}