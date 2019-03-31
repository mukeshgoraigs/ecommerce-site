using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Product : System.Web.UI.Page
{
    static int subid;
    protected void Page_Load(object sender, EventArgs e)
    {
       
       
        if (Request.QueryString["subid"] != null)
        {
            string[] strsplitcomment = Request.QueryString["subid"].ToString().Split('?');
            subid = int.Parse(strsplitcomment[0]);
        }
        if (!IsPostBack)
        {
            getCnSn(subid);
            //fillProducts();

            fillFullProduct();
        }
    }
    private void getCnSn(int subid)
    {
        SubCData sdata = new SubCData(subid);
        lblSubCatName.Text = sdata.SubCategory;
        CategoryData cdata = new CategoryData(sdata.Catid);
        //lblCatName.Text = cdata.Category;

        MasterPage myMaster = (MasterPage)this.Master;
        myMaster.MetaTitle = sdata.PageTitle;
        myMaster.MetaDescription = sdata.MetaDescription;
        myMaster.MetaKeywords = sdata.MetaKeyes;

    }
    //private void fillProducts()
    //{
    //    try
    //    {
    //        ProductData pdata = new ProductData();
    //        DataSet ds = pdata.getProduct("select product.id,product.productName,product.description,product.code,product.price,product.newprice,product.discount,product.size,product.image,product.prodtype,cartdata.quantity from product left join cartdata on product.id=cartdata.productid and cartdata.sessionid='" + SessionVeriables.SessionID + "' where subcategoryid=" + subid);
    //        rpProduct.DataSource = ds;
    //        rpProduct.DataBind();
    //        //lblNumberOfPro.Text = ds.Tables[0].Rows.Count.ToString();
    //    }
    //    catch (Exception ex) { }
    //}
    private void fillFullProduct()
    {
        try
        {
            string mysession = SessionVeriables.SessionID;
            ProductData pdata = new ProductData();
            DataSet ds = pdata.getFullProduct(subid, mysession);
            rpProductMain.DataSource = ds.Tables["product"];

            Page.DataBind();
        }
        catch (Exception ex) { }
    }
}