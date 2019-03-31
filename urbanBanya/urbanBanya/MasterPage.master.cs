using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPage : System.Web.UI.MasterPage
{
    static int totalItems;
    static double totalAmount;
    static double totaldiscount;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            fillMainMenu();
            fillReview();
            //if (SessionVeriables.SessionID == "")
            //{
            //    SessionVeriables.SessionID = Session.SessionID;
            //    hdnsessionid.Value = SessionVeriables.SessionID;
            //}
            if (hdnsessionid.Value == "")
            {
                hdnsessionid.Value = Session.SessionID;
                SessionVeriables.SessionID = Session.SessionID;
            }

        }
        fillCartItems();

    }
    private void fillMainMenu()
    {
        try
        {
            CategoryData cdata = new CategoryData();
            DataSet ds = cdata.getFullCategory();
            rpMainMenu.DataSource = ds.Tables["category"];
            rpMobile.DataSource = ds.Tables["category"];
            Page.DataBind();
        }
        catch (Exception ex) { }
    }
    public void fillCartItems()
    {
        MyCartData cdata = new MyCartData();
        DataSet ds = cdata.getCart("select product.id,product.productName,product.discount,product.image,cartdata.id as cid,cartdata.productid,cartdata.size,cartdata.price,cartdata.newprice,cartdata.quantity,cartdata.sessionid,cartdata.userid from product inner join cartdata on product.id=cartdata.productid where sessionid='" + SessionVeriables.SessionID + "'");
         lblTotalItems.Text = ds.Tables[0].Rows.Count.ToString();
        if (ds.Tables[0].Rows.Count > 0)
        {

            rpCartS.DataSource = ds;
            rpCartS.DataBind();
            rpCartFull.DataSource = ds;
            rpCartFull.DataBind();
            calculateTotal(ds);
        }
        else
        {
            //lblTotalItems.Text = "No item In Cart";
        }

    }
    private void fillReview()
    {
        try
        {
            ReviewData rdata = new ReviewData();
            DataSet ds = rdata.getReviewes("select review.id,review.customerid,review.review,review.status,customer.F_name from review inner join customer on customer.id=review.customerid where review.status=1");
            rpReview.DataSource = ds;
            rpReview.DataBind();
           
        }
        catch (Exception ex) { }
    }
    protected void calculateTotal(DataSet ds)
    {
        totalItems = 0;
        totalAmount = 0.0;
        totaldiscount = 0.0;
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            totalItems+=int.Parse( ds.Tables[0].Rows[i]["quantity"].ToString());
            totalAmount +=( double.Parse(ds.Tables[0].Rows[i]["newPrice"].ToString()) * double.Parse(ds.Tables[0].Rows[i]["quantity"].ToString()));
            totaldiscount += ((double.Parse(ds.Tables[0].Rows[i]["price"].ToString()) - double.Parse(ds.Tables[0].Rows[i]["newprice"].ToString())) * double.Parse(ds.Tables[0].Rows[i]["quantity"].ToString()));
        }
        lblTotalAmount.Text = totalAmount.ToString();
        lblTotalAmounts.Text = totalAmount.ToString();
        lblTotalItems.Text = totalItems.ToString();
        lblTotalDiscount.Text = totaldiscount.ToString();
        lblTotalSaving.Text = totaldiscount.ToString();
    }
    public string MetaTitle
    {
        get
        {
            return PageTitle.Text;
        }
        set
        {
            PageTitle.Text = value;
        }
    }
    public string MetaKeywords
    {
        get
        {
            return PageKeywords.Content;
        }
        set
        {
            PageKeywords.Content = value;
        }
    }
    public string MetaDescription
    {
        get
        {
            return PageDescription.Content;
        }
        set
        {
            PageDescription.Content = value;
        }
    }
}

