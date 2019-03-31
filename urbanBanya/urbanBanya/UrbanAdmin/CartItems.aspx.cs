using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UrbanAdmin_CartItems : System.Web.UI.Page
{
    static int userid;
    protected void Page_Load(object sender, EventArgs e)
    {
        userid = int.Parse(Request.QueryString["userid"]);
        fillCartItems();
    }
    public void fillCartItems()
    {
        MyCartData cdata = new MyCartData();
        DataSet ds = cdata.getCart("select product.id,product.productName,product.discount,product.image,cartdata.id as cid,cartdata.productid,cartdata.price,cartdata.newprice,cartdata.size,cartdata.quantity,cartdata.sessionid,cartdata.userid from product inner join cartdata on product.id=cartdata.productid where userid=" + userid);
       
        if (ds.Tables[0].Rows.Count > 0)
        {


            rpCartItems.DataSource = ds;
            rpCartItems.DataBind();
            
        }
        else
        {
            //lblTotalItems.Text = "No item In Cart";
        }

    }
}