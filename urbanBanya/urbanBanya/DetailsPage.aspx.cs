using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class DetailsPage : System.Web.UI.Page
{
    static int productid;
    static float dis;
    static float price;
    static int subcatid;
    protected void Page_Load(object sender, EventArgs e)
    {
        
        productid = int.Parse(Request.QueryString["pid"]);
        //dis = float.Parse(Request.QueryString["dis"]);
        //if (dis == 0)
        //{
        //    pnlOldPrice.Visible = false;
        //}
        price = float.Parse(Request.QueryString["price"]);
        getCnSn(productid);

        if (!IsPostBack)
        {
            setData();
          fillSimilarItem();
            // lblDiscount.Text = dis.ToString();
          fillSize();
        }
    }
    private void getCnSn(int proid)
    {
        ProductData pdata = new ProductData(proid);
        lblProductNameTop.Text = pdata.Product;
        lblProductPrice.Text = pdata.NewPrice.ToString();
        lblOldPrice.Text = pdata.Price.ToString();
        subcatid = pdata.SubCatId;

        if(pdata.Price==pdata.NewPrice)
        {
            pnlOldPrice.Visible = false;
        }
        // lblDiscount.Text = pdata.Discount.ToString();
        //SubCData sdata = new SubCData(pdata.SubCatId);
        //lblSubCatName.Text = sdata.SubCategory;
        //CategoryData cdata = new CategoryData(sdata.Catid);
        //lblCatName.Text = cdata.Category;



        string productAttribute = "<script>" +
          "$('.myAdd').attr('data-id','" + pdata.Id + "');" +
          "$('.myAdd').attr('data-img','" + pdata.Image + "');" +
          "$('.myAdd').attr('data-size','" + pdata.Size + "');" +
          "$('.myAdd').attr('data-oldprice','" + pdata.Price + "');" +
          "$('.myAdd').attr('data-price','" + pdata.NewPrice + "');" +
          "$('.myAdd').attr('data-discount','" + pdata.Discount + "');" +
          "</script>";

        lblScript.Text = productAttribute;


    }
    protected void fillSize()
    {
        MoreSizeData msdata = new MoreSizeData();
        DataSet ds = msdata.getMoreSize("select * from productdetail where productid=" + productid);
        rpSize.DataSource = ds;
        rpSize.DataBind();
    }
    private void setData()
    {
        try
        {
            ProductData pdata = new ProductData();
            DataSet ds = pdata.getProduct("select * from product where id=" + productid);
            lblProductName.Text = ds.Tables[0].Rows[0]["productName"].ToString();
            //  lblProductPrice.Text = ds.Tables[0].Rows[0]["price"].ToString();
            productImg.Src = "~/UrbanAdmin/product/medium/" + ds.Tables[0].Rows[0]["image"].ToString();
            //   smProImg.ImageUrl = "~/admin/product/medium/" + ds.Tables[0].Rows[0]["image"].ToString();
            lblProductDescription.Text = ds.Tables[0].Rows[0]["description"].ToString();
            mylink.HRef = "~/UrbanAdmin/product/medium/" + ds.Tables[0].Rows[0]["image"].ToString();
            //MyCartData cdata = new MyCartData();
            //DataSet ds1 = cdata.getCart("select product.id,product.productName,product.price,product.image,cartdata.id as cid,cartdata.quantity,cartdata.sessionid,cartdata.userid from product inner join cartdata on product.id=cartdata.productid where cartdata.productid=" + productid + " and sessionid='" + SessionVeriables.SessionID + "'");
            //// lblTotalItems.Text = ds.Tables[0].Rows.Count.ToString();
            //if (ds.Tables[0].Rows.Count > 0)
            //{

            //    //txtNoItems.Text = ds1.Tables[0].Rows[0]["quantity"].ToString();

            //}
            //else
            //{
            //    //lblTotalItems.Text = "No item In Cart";
            //}

        }
        catch (Exception ex) { }
    }

    private void fillSimilarItem()
    {
        ProductData cdata = new ProductData();
        DataSet ds = cdata.getProduct("select * from product where subcategoryid="+subcatid+" limit 15");
        if (ds.Tables[0].Rows.Count > 0)
        {
            rpSimilar.DataSource = ds;
            rpSimilar.DataBind();

        }
    }
}