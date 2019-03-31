using ClosedXML.Excel;
using HelperClass;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Product : System.Web.UI.Page
{

    string extension;
    static string FileNameUp;
    static int idup;
    int ch = 0;
    static DataTable dt = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            updatePanel.Visible = false;
            fillTree();
            fillCategory();
            fillProduct("select * from product where status=1");
            sizePanel.Visible = false;
        }
    }

    private void fillProduct(string p)
    {
        ProductData pdata = new ProductData();
        DataSet ds = pdata.getProduct(p);
        if (ds.Tables[0].Rows.Count > 0)
        {
            rpProduct.DataSource = ds;
            rpProduct.DataBind();

        }
        else
        {

        }
    }
    private void fillTree()
    {

        CategoryData cdata = new CategoryData();
        DataSet cds = cdata.getCategory("select * from category");
        tvCategores.Nodes.Clear();
        for (int cate = 0; cate < cds.Tables[0].Rows.Count; cate++)
        {
            SubCData scdata = new SubCData();
            DataSet sds = scdata.getSubCategory("select * from subcategory where categoryid=" + int.Parse(cds.Tables[0].Rows[cate][0].ToString()));
            TreeNode root = new TreeNode();
            root.Text = cds.Tables[0].Rows[cate][1].ToString() + " -<span class='badge active'>" + sds.Tables[0].Rows.Count + "</span>";

            ch = 0;
            while (ch < sds.Tables[0].Rows.Count)
            {
                ProductData pdata = new ProductData();
                DataSet pds = pdata.getProduct("select * from product where status=1 and subcategoryid=" + int.Parse(sds.Tables[0].Rows[ch][0].ToString()));
                TreeNode child = new TreeNode();
                child.Text = sds.Tables[0].Rows[ch][2].ToString() + " -<span class='badge active'>" + pds.Tables[0].Rows.Count + "</span>";
                root.ChildNodes.Add(child);
                ch++;
            }

            tvCategores.Nodes.Add(root);
        }
        tvCategores.CollapseAll();
    }
    private void fillCategory()
    {
        CategoryData cdata = new CategoryData();
        DataSet ds = cdata.getCategory("select * from category");
        cmbCategory.DataSource = ds;
        cmbCategory.DataTextField = "categoryName";
        cmbCategory.DataValueField = "id";
        cmbCategory.DataBind();
        cmbCategory.Items.Insert(0, "Select Category");
        cmbCategory.SelectedIndex = 0;

        cmbCategoryUp.DataSource = ds;
        cmbCategoryUp.DataTextField = "categoryName";
        cmbCategoryUp.DataValueField = "id";
        cmbCategoryUp.DataBind();
        cmbCategoryUp.Items.Insert(0, "Select Category");
        cmbCategoryUp.SelectedIndex = 0;

        cmbCategoryEx.DataSource = ds;
        cmbCategoryEx.DataTextField = "categoryName";
        cmbCategoryEx.DataValueField = "id";
        cmbCategoryEx.DataBind();
        cmbCategoryEx.Items.Insert(0, "Select Category");
        cmbCategoryEx.SelectedIndex = 0;

        cmbCategoryExUp.DataSource = ds;
        cmbCategoryExUp.DataTextField = "categoryName";
        cmbCategoryExUp.DataValueField = "id";
        cmbCategoryExUp.DataBind();
        cmbCategoryExUp.Items.Insert(0, "Select Category");
        cmbCategoryExUp.SelectedIndex = 0;
    }
    private void fillSubCategory()
    {
        int id = int.Parse(cmbCategory.SelectedValue.ToString());
        SubCData cdata = new SubCData();
        cmbSubCategory.DataSource = cdata.getSubCategory("select * from subcategory where categoryid=" + id);
        cmbSubCategory.DataTextField = "subCategoryName";
        cmbSubCategory.DataValueField = "id";
        cmbSubCategory.DataBind();
        cmbSubCategory.Items.Insert(0, "Select Sub-Category");
        cmbSubCategory.SelectedIndex = 0;
    }
    protected void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillSubCategory();
    }
    protected void txtDiscount_TextChanged(object sender, EventArgs e)
    {
        txtDiscount.Text = getDiscount(txtPrice.Text.ToString(), txtDiscountPr.Text.ToString()).ToString()+"%";
    }
    protected void txtNewPriceUp_Changed(object sender,EventArgs e)
    {
        txtDiscountUp.Text= getDiscount(txtPriceUp.Text.ToString(), txtNewPriceUp.Text).ToString() + "%";
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
           

            if (ProductImg.HasFile)
            {
                extension = String.Empty;

                extension = ProductImg.FileName.Substring(ProductImg.FileName.LastIndexOf("."));

                string FileName = ProductImg.FileName;

                // categoryImg.SaveAs(HttpContext.Current.Server.MapPath("~/UrbanAdmin/category/" + FileName));

                ImageResizeNew rmg = new ImageResizeNew();
                rmg.GenerateThumbnails(0.5, ProductImg.PostedFile.InputStream, HttpContext.Current.Server.MapPath("~/UrbanAdmin/product/small/" + ProductImg.FileName), 108, 108);
                rmg.GenerateThumbnails(0.5, ProductImg.PostedFile.InputStream, HttpContext.Current.Server.MapPath("~/UrbanAdmin/product/medium/" + ProductImg.FileName), 224, 224);
                rmg.GenerateThumbnails(0.5, ProductImg.PostedFile.InputStream, HttpContext.Current.Server.MapPath("~/UrbanAdmin/product/large/" + ProductImg.FileName), 300, 300);
                rmg.GenerateThumbnails(0.5, ProductImg.PostedFile.InputStream, HttpContext.Current.Server.MapPath("~/UrbanAdmin/product/xlarge/" + ProductImg.FileName), 500, 500);

                ProductData pdata = new ProductData();
                pdata.Catid =int.Parse(cmbCategory.SelectedValue.ToString());
                pdata.SubCatId = int.Parse(cmbSubCategory.SelectedValue.ToString().Trim());
                pdata.Product = txtProductName.Text.ToString();
                pdata.Price = double.Parse(txtPrice.Text.ToString());


               


                pdata.Discount = getDiscount(txtPrice.Text.ToString(), txtDiscountPr.Text.ToString()).ToString() + "%";
                pdata.NewPrice = double.Parse(txtDiscountPr.Text.ToString());
                pdata.Tax = double.Parse(txtTax.Text.ToString());
                pdata.ProductType = int.Parse(cmbProductType.SelectedValue.ToString());
                pdata.Description = txtProductDescription.Text.ToString();
                pdata.Code = txtCode.Text.ToString().Trim();
                pdata.Size = txtSize.Text.ToString().Trim();
                pdata.Quantity =int.Parse(txtQuantity.Text.ToString());
                pdata.Image = FileName;
                pdata.PageTitle = txtTitle.Text.ToString();
                pdata.MetaKeyes = txtMetaKey.Text.ToString();
                pdata.MetaDescription = txtMetaDescription.Text.ToString();
                pdata.Save();



                DataSet ds = pdata.getProduct("select max(id) from product");
                MoreSizeData msdata = new MoreSizeData();
                msdata.ProductId = int.Parse(ds.Tables[0].Rows[0][0].ToString());
                msdata.SubCatId = int.Parse(cmbSubCategory.SelectedValue.ToString().Trim());
                msdata.Size = txtSize.Text.ToString().Trim();
                msdata.Price = double.Parse(txtPrice.Text.ToString());
                msdata.Discount = getDiscount(txtPrice.Text.ToString(), txtDiscountPr.Text.ToString()).ToString() + "%";
                msdata.NewPrice = double.Parse(txtDiscountPr.Text.ToString());
                msdata.Quantity = int.Parse(txtQuantity.Text.ToString());
                msdata.Image = FileName;
                msdata.Save();
               


                
                fillSubCategory();
                fillTree();
                fillProduct("select * from product where status=1");
                reset();
               
            }
            else
            {
                //Label1.Text = "Select Your Image first";
            }
        }
        catch (Exception ex) { }
    }

    private void reset()
    {
        cmbCategory.SelectedIndex = 0;
        cmbSubCategory.SelectedIndex=0;
            txtProductName.Text="";
            txtPrice.Text = "";
            txtDiscount.Text="";
        txtDiscountPr.Text="";
        txtTax.Text = "";
        txtProductDescription.Text="";
        txtCode.Text="";
        txtSize.Text="";
        txtQuantity.Text="";
        txtTitle.Text="";
        txtMetaKey.Text="";
        txtMetaDescription.Text="";
        
    }

    private double getDiscount(string price,string discount)
    {
        //string exdiscount = discount;
        //double newPrice = 0;

        //if (exdiscount.EndsWith("%"))
        //{
        //    if(exdiscount.Contains("-"))
        //    {

        //    }
        //    else
        //    {
        //        int len = exdiscount.Length - 1;
        //        exdiscount = exdiscount.Insert(len, "-");
        //    }
        //    double dis = double.Parse(exdiscount.Substring(0, exdiscount.Length - 2));
        //    newPrice = ((double.Parse(price)) - (((double.Parse(price)) * dis) / 100));

        //}
        //else if (exdiscount == "")
        //{
        //    newPrice = double.Parse(price);
        //}
        //else
        //{
        //    newPrice = ((double.Parse(price)) - (double.Parse(exdiscount)));
        //}

        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
        double cprice = Convert.ToDouble(price);
        double cdiscount = Convert.ToDouble(discount);
        double per = ((cprice - cdiscount) * 100) / cprice;

      

        return Math.Round(per,1);
    }
    protected void btnReset_Click(object sender,EventArgs e)
    {
        reset();
    }
    protected void tvCategores_SelectedNodeChanged(object sender, EventArgs e)
    {
        var selectedNode = tvCategores.SelectedNode;
        if (selectedNode.Parent == null)
        {
           
            string[] node = tvCategores.SelectedValue.ToString().Split('-');
            CategoryData cdata = new CategoryData(node[0].ToString().Trim());
           
            fillProduct("select * from product where status=1 and categoryid=" + cdata.Id);


        }
        else
        {
            string[] node = tvCategores.SelectedValue.ToString().Split('-');
            SubCData scdata = new SubCData(node[0].ToString().Trim());
            fillProduct("select * from product where status=1 and subcategoryid=" + scdata.Id);
        }
    }
    protected void rpProduct_ItemCommand(object source, RepeaterCommandEventArgs e)
    {

        if (e.CommandName == "moresize")
        {
            ProductData pdata = new ProductData(int.Parse(e.CommandArgument.ToString()));
            txtProductNameSize.Text = pdata.Product;
            updatePanel.Visible = false;
            viewPanel.Visible = false;
            sizePanel.Visible = true;
            panelViewMore.Visible = true;
            panelAddMore.Visible = false;
            idup = pdata.Id;
            fillMoreSize(idup);
        }

        else
        {
            updatePanel.Visible = true;
            viewPanel.Visible = false;

            ProductData pdata = new ProductData(int.Parse(e.CommandArgument.ToString()));
            cmbCategoryUp.SelectedValue = pdata.Catid.ToString();
            fillSubCatUp();
            cmbSubCateUp.SelectedValue = pdata.SubCatId.ToString();
            txtProductUp.Text = pdata.Product;
            txtPriceUp.Text = pdata.Price.ToString();
            txtDiscountUp.Text = pdata.Discount;
            txtNewPriceUp.Text = pdata.NewPrice.ToString();
            txtTaxUp.Text = pdata.Tax.ToString();
            cmbProductTypeUp.SelectedValue = pdata.ProductType.ToString();
            txtDescriptionUp.Text = pdata.Description;
            txtCodeUp.Text = pdata.Code;
            txtSizeUp.Text = pdata.Size;
            txtQuantityUp.Text = pdata.Quantity.ToString();
            txtTitleUp.Text = pdata.PageTitle;
            txtMetaKeyUp.Text = pdata.MetaKeyes;
            txtMetaDesUp.Text = pdata.MetaDescription;
            productImgDis.ImageUrl = "~/UrbanAdmin/product/small/" + pdata.Image;
            idup = pdata.Id;
            FileNameUp = pdata.Image;
        }

    }

    private void fillMoreSize(int idup)
    {
        try
        {
            MoreSizeData msdata = new MoreSizeData();
            DataSet ds = msdata.getMoreSize("select * from productdetail where productid="+idup);
            rpMoreSizeView.DataSource = ds;
            rpMoreSizeView.DataBind();
        }
        catch (Exception ex) { 
        }
    }
    protected void rpProduct_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {

    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {

            string FileName;
            if (productImgUp.HasFile)
            {
                extension = String.Empty;

                extension = productImgUp.FileName.Substring(productImgUp.FileName.LastIndexOf("."));

                FileName = productImgUp.FileName;

              

                ImageResizeNew rmg = new ImageResizeNew();
                rmg.GenerateThumbnails(0.5, productImgUp.PostedFile.InputStream, HttpContext.Current.Server.MapPath("~/UrbanAdmin/product/small/" + productImgUp.FileName), 108, 108);
                rmg.GenerateThumbnails(0.5, productImgUp.PostedFile.InputStream, HttpContext.Current.Server.MapPath("~/UrbanAdmin/product/medium/" + productImgUp.FileName), 224, 224);
                rmg.GenerateThumbnails(0.5, productImgUp.PostedFile.InputStream, HttpContext.Current.Server.MapPath("~/UrbanAdmin/product/large/" + productImgUp.FileName), 300, 300);
                rmg.GenerateThumbnails(0.5, productImgUp.PostedFile.InputStream, HttpContext.Current.Server.MapPath("~/UrbanAdmin/product/xlarge/" + productImgUp.FileName), 500, 500);

            }
            else
            {
                FileName = FileNameUp;
            }


            ProductData pdata = new ProductData();
            pdata.Catid = int.Parse(cmbCategoryUp.SelectedValue.ToString());
            pdata.SubCatId = int.Parse(cmbSubCateUp.SelectedValue.ToString());
            pdata.Product = txtProductUp.Text;
            pdata.Price = double.Parse(txtPriceUp.Text.ToString());
            pdata.Discount = getDiscount(txtPriceUp.Text.ToString(), txtNewPriceUp.Text).ToString() + "%";
            pdata.NewPrice = double.Parse(txtNewPriceUp.Text.ToString());
            pdata.Tax = double.Parse(txtTaxUp.Text.ToString());
            pdata.ProductType = int.Parse(cmbProductTypeUp.SelectedValue.ToString());
            pdata.Description = txtDescriptionUp.Text.ToString();
            pdata.Code = txtCodeUp.Text.ToString();
            pdata.Size = txtSizeUp.Text.ToString();
            pdata.Quantity = int.Parse(txtQuantityUp.Text.ToString());
            pdata.PageTitle = txtTitleUp.Text.ToString();
            pdata.MetaKeyes = txtMetaKeyUp.Text.ToString();
            pdata.MetaDescription = txtMetaDesUp.Text.ToString();
            pdata.Image = FileName;
            pdata.Update(idup);
          
            fillProduct("select * from product where status=1");
            viewPanel.Visible = true;
            updatePanel.Visible = false;
            resetUp();
        }
        catch (Exception ex) { }

    }

    private void resetUp()
    {
        cmbCategoryUp.SelectedIndex = 0;
        cmbSubCateUp.SelectedIndex = 0;
        txtProductUp.Text = "";
        txtPriceUp.Text = "";
        txtDiscountUp.Text = "";
        txtNewPriceUp.Text = "";
        txtTaxUp.Text = "";
        cmbProductTypeUp.SelectedIndex = 0;
        txtDescriptionUp.Text = "";
        txtCodeUp.Text = "";
        txtSizeUp.Text = "";
        txtQuantityUp.Text = "";
        txtTitleUp.Text = "";
        txtMetaKeyUp.Text = "";
        txtMetaDesUp.Text = "";
        
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        viewPanel.Visible = true;
        updatePanel.Visible = false;
    }
    protected void cmbCategoryUp_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillSubCatUp();
    }
    private void fillSubCatUp()
    {
        int id = int.Parse(cmbCategoryUp.SelectedValue.ToString());
        SubCData cdata = new SubCData();
        cmbSubCateUp.DataSource = cdata.getSubCategory("select * from subcategory where categoryid=" + id);
        cmbSubCateUp.DataTextField = "subCategoryName";
        cmbSubCateUp.DataValueField = "id";
        cmbSubCateUp.DataBind();
        cmbSubCateUp.Items.Insert(0, "Select Sub-Category");
        cmbSubCateUp.SelectedIndex = 0;
    }
   

    protected void btnDelete_Click(object sender,EventArgs e)
    {
        for (int i = 0; i < rpProduct.Items.Count; i++)
        {
            CheckBox chk = (CheckBox)rpProduct.Items[i].FindControl("productid");
            if (chk.Checked)
            {
               
                ProductData pdata = new ProductData();
                pdata.Delete("update product set status=0 where id="+chk.Text);

            }
        }
        fillProduct("select * from product where status=1");
        fillTree();
    }

    protected void cmbNumberOfSize_IndexChange(object sender, EventArgs e)
    {
        int row = int.Parse(cmbNumberOfSize.SelectedValue.ToString());
        SetInitialRow(row);
    }
    private void SetInitialRow(int row )
    {
         DataTable dt = new DataTable();
         //Create DataTable columns
            
         dt.Columns.Add(new DataColumn("size", typeof(string)));
         dt.Columns.Add(new DataColumn("price", typeof(string)));
         dt.Columns.Add(new DataColumn("discountpr", typeof(string)));
         dt.Columns.Add(new DataColumn("quantity", typeof(string)));
         for (int i = 1; i <= row; i++)
         {

             DataRow dr = null;

             

             //Create Row for each columns
             dr = dt.NewRow();

             dr["size"] = string.Empty;
             dr["price"] = string.Empty;
             dr["discountpr"] = string.Empty;
             dr["quantity"] = string.Empty;
             dt.Rows.Add(dr);
         }
        //Store the DataTable in ViewState for future reference
        ViewState["CurrentTable"] = dt;

        //Bind the Repeater with the DataTable
        rpMySize.DataSource = dt;
        rpMySize.DataBind();

    }


    protected void btnAddMoreSize_Click(object sender, EventArgs e)
    {
        for (int i = 0; i < rpMySize.Items.Count; i++)
        {
            TextBox txtMoreSize = (TextBox)rpMySize.Items[i].FindControl("txtMoreSize");
            TextBox txtMorePrice = (TextBox)rpMySize.Items[i].FindControl("txtMorePrice");
            TextBox txtMoreDiscountPr = (TextBox)rpMySize.Items[i].FindControl("txtMoreDiscountPr");
            TextBox txtMoreQuantity = (TextBox)rpMySize.Items[i].FindControl("txtMoreQuantity");

            try
            {
               
                ProductData pdata = new ProductData(idup);
                MoreSizeData msdata = new MoreSizeData();
                msdata.ProductId = idup;
                msdata.SubCatId = pdata.SubCatId;
                msdata.Size = txtMoreSize.Text.ToString();
                msdata.Price = double.Parse(txtMorePrice.Text.ToString().Trim());
                msdata.Discount = getDiscount(txtMorePrice.Text.ToString().Trim(), txtMoreDiscountPr.Text.ToString().Trim()).ToString()+"%";
                msdata.NewPrice =double.Parse( txtMoreDiscountPr.Text.ToString());
                msdata.Quantity = int.Parse(txtMoreQuantity.Text.ToString().Trim());
                msdata.Image = pdata.Image;
                msdata.Save();
                txtMoreSize.Text = "";
                txtMorePrice.Text = "";
                txtMoreDiscountPr.Text = "";
                txtMoreQuantity.Text = "";

                DataSet ds = msdata.getMoreSize("select * from productdetail where productid="+idup);
               
                pdata.Variants = ds.Tables[0].Rows.Count;
                pdata.Update(idup);
            }
            catch (Exception ex) { }
        }
    }
    protected void btnCancelMoreSize_Click(object sender, EventArgs e)
    {
        txtProductNameSize.Text = "";
        cmbNumberOfSize.SelectedIndex = 0;
        DataTable dt1 = new DataTable();
        rpMySize.DataSource = dt1;
        rpMySize.DataBind();
        sizePanel.Visible = false;
        viewPanel.Visible = true;
    }
    protected void btnAddMore_Click(object sender, EventArgs e)
    {
        panelAddMore.Visible = true;
        panelViewMore.Visible = false;
    }
    protected void btnEditMore_Click(object sender, EventArgs e)
    {
        panelAddMore.Visible = false;
        panelViewMore.Visible = true;
    }

    protected void btnUpdateMore_Click(object sender, EventArgs e)
    {
        for (int i = 0; i < rpMoreSizeView.Items.Count; i++)
        {

            Label txtSizeId = (Label)rpMoreSizeView.Items[i].FindControl("lblSizeId");
            TextBox txtMoreSize = (TextBox)rpMoreSizeView.Items[i].FindControl("lblMoreSize");
            TextBox txtMorePrice = (TextBox)rpMoreSizeView.Items[i].FindControl("lblMorePrice");
            TextBox txtMoreDiscountPr = (TextBox)rpMoreSizeView.Items[i].FindControl("lblMoreDiscountPr");
            TextBox txtMoreQuantity = (TextBox)rpMoreSizeView.Items[i].FindControl("lblMoreQuantity");

            try
            {
                ProductData pdata = new ProductData(idup);
                MoreSizeData msdata = new MoreSizeData();
                msdata.ProductId = idup;
                msdata.Size = txtMoreSize.Text.ToString();
                msdata.Price = double.Parse(txtMorePrice.Text.ToString().Trim());
                msdata.Discount = getDiscount(txtMorePrice.Text.ToString().Trim(), txtMoreDiscountPr.Text.ToString().Trim()).ToString()+"%";
                msdata.NewPrice = double.Parse(txtMoreDiscountPr.Text.ToString()); 
                msdata.Quantity = int.Parse(txtMoreQuantity.Text.ToString().Trim());
                msdata.Image = pdata.Image;
                msdata.Update(int.Parse(txtSizeId.Text.ToString()));
               
            }
            catch (Exception ex) { }
        }
        
    }
    protected void btnCancelUpdateMore_Click(object sender, EventArgs e)
    {
        sizePanel.Visible = false;
        viewPanel.Visible = true;
    }
    protected void btnDeleteMore_Click(object sender, EventArgs e)
    {
        for (int i = 0; i < rpMoreSizeView.Items.Count; i++)
        {
            CheckBox chk = (CheckBox)rpMoreSizeView.Items[i].FindControl("chkSize");
            if (chk.Checked)
            {
                Label txtSizeId = (Label)rpMoreSizeView.Items[i].FindControl("lblSizeId");
                MoreSizeData msdata = new MoreSizeData();
                msdata.Delete("delete from productdetail where id=" + txtSizeId.Text);
                
            }
        }
        fillMoreSize(idup);
    }

    protected void btnUploadExcel_Click(object sender, EventArgs e)
    {

        try
        {
            if (excelUpload.HasFile)
            {
                extension = String.Empty;
                extension = excelUpload.FileName.Substring(excelUpload.FileName.LastIndexOf("."));

                string FileName = excelUpload.FileName;
                excelUpload.SaveAs(HttpContext.Current.Server.MapPath("excelfile/" + FileName));
                ProductData pdata = new ProductData();
                dt = ReadExcelFile.ReadAsDataTable(FileName);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    
                    pdata.Catid =int.Parse(cmbCategoryEx.SelectedValue.ToString());
                    pdata.SubCatId = int.Parse(cmbSubCateEx.SelectedValue.ToString());
                    pdata.Product = dt.Rows[i][0].ToString();
                    pdata.Price = double.Parse(dt.Rows[i][1].ToString());
                    pdata.Discount = getDiscount(dt.Rows[i][1].ToString(), dt.Rows[i][2].ToString()).ToString()+"%";
                    pdata.NewPrice = double.Parse(dt.Rows[i][2].ToString());
                    pdata.Quantity =int.Parse( dt.Rows[i][3].ToString());
                    pdata.Size = dt.Rows[i][4].ToString();
                    pdata.ProductType = int.Parse(dt.Rows[i][5].ToString());
                    pdata.Code = dt.Rows[i][6].ToString();
                    pdata.Description = dt.Rows[i][7].ToString();
                    pdata.Image = dt.Rows[i][8].ToString();
                    pdata.PageTitle = dt.Rows[i][9].ToString();
                    pdata.MetaKeyes = dt.Rows[i][10].ToString();
                    pdata.MetaDescription = dt.Rows[i][11].ToString();
                    pdata.Tax = double.Parse(dt.Rows[i][12].ToString());
                    pdata.Save();


                    DataSet ds = pdata.getProduct("select max(id) from product");
                    MoreSizeData msdata = new MoreSizeData();
                    msdata.ProductId = int.Parse(ds.Tables[0].Rows[0][0].ToString());
                    msdata.SubCatId = int.Parse(cmbSubCateEx.SelectedValue.ToString());
                    msdata.Size = dt.Rows[i][4].ToString();
                    msdata.Price = double.Parse(dt.Rows[i][1].ToString());
                    msdata.Discount = getDiscount(dt.Rows[i][1].ToString(), dt.Rows[i][2].ToString()).ToString() + "%";
                    msdata.NewPrice = double.Parse(dt.Rows[i][2].ToString());
                    msdata.Quantity = int.Parse(dt.Rows[i][3].ToString());
                    msdata.Image = dt.Rows[i][8].ToString();
                    msdata.Save();


                }

                fillProduct("select * from product  where status=1");
                fillTree();

            }
            else
            {
                //Label1.Text = "Select Your Image first";
            }
        }
        catch (Exception ex)
        { }
    }

    protected void cmbCategoryEx_IndexChange(object sender, EventArgs e)
    {
        int id = int.Parse(cmbCategoryEx.SelectedValue.ToString());
        SubCData cdata = new SubCData();
        cmbSubCateEx.DataSource = cdata.getSubCategory("select * from subcategory where categoryid=" + id);
        cmbSubCateEx.DataTextField = "subCategoryName";
        cmbSubCateEx.DataValueField = "id";
        cmbSubCateEx.DataBind();
        cmbSubCateEx.Items.Insert(0, "Select Sub-Category");
        cmbSubCateEx.SelectedIndex = 0;
    }
    protected void btnImageUpload_Click(object sender, EventArgs e)
    {
        try
        {
            if (uploadProImage.HasFile)
            {
                foreach (HttpPostedFile postedFile in uploadProImage.PostedFiles)
                {


                    string fileName = postedFile.FileName;
                    //  postedFile.SaveAs(HttpContext.Current.Server.MapPath("~/admin/images/"+ fileName));

                    ProductData pdata = new ProductData(fileName);

                    if (pdata.HasValue)
                    {
                        ImageResizeNew rmg = new ImageResizeNew();
                        rmg.GenerateThumbnails(0.5, postedFile.InputStream, HttpContext.Current.Server.MapPath("~/UrbanAdmin/product/small/" + postedFile.FileName), 108, 108);
                        rmg.GenerateThumbnails(0.5, postedFile.InputStream, HttpContext.Current.Server.MapPath("~/UrbanAdmin/product/medium/" + postedFile.FileName), 224, 224);
                        rmg.GenerateThumbnails(0.5, postedFile.InputStream, HttpContext.Current.Server.MapPath("~/UrbanAdmin/product/large/" + postedFile.FileName), 300, 300);
                        rmg.GenerateThumbnails(0.5, postedFile.InputStream, HttpContext.Current.Server.MapPath("~/UrbanAdmin/product/xlarge/" + postedFile.FileName), 500, 500);
                    }

                }
               
            }
            else
            {
                //Label1.Text = "Select Your Image first";
            }
        }
        catch (Exception ex)
        { }
    }

    protected void cmbCategoryExUp_SelectedIndexChanged(object sender,EventArgs e)
    {
        int id = int.Parse(cmbCategoryExUp.SelectedValue.ToString());
        SubCData cdata = new SubCData();
        cmbSubCateExUp.DataSource = cdata.getSubCategory("select * from subcategory where categoryid=" + id);
        cmbSubCateExUp.DataTextField = "subCategoryName";
        cmbSubCateExUp.DataValueField = "id";
        cmbSubCateExUp.DataBind();
        cmbSubCateExUp.Items.Insert(0, "Select Sub-Category");
        cmbSubCateExUp.SelectedIndex = 0;
    }
    protected void btnExcelExport_Click(object sender, EventArgs e)
    {
        string filename = "Product"+cmbSubCateExUp.SelectedItem.ToString();
        int id = int.Parse(cmbSubCateExUp.SelectedValue.ToString());
        CategoryData cdata = new CategoryData();
        DataSet ds = cdata.getCategory("select id,productName,price,newprice,quantity,size,prodtype,code,description,image,pagetitle,metakey,metadescription,tax from product where subcategoryid=" + id);
        DataTable dt1 = ds.Tables[0];

        using (XLWorkbook wb = new XLWorkbook())
        {
            wb.Worksheets.Add(dt1);

            Response.Clear();
            Response.Buffer = true;
            Response.Charset = "";
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            Response.AddHeader("content-disposition", "attachment;filename=" + filename + ".xlsx");
            using (MemoryStream MyMemoryStream = new MemoryStream())
            {
                wb.SaveAs(MyMemoryStream);
                MyMemoryStream.WriteTo(Response.OutputStream);
                Response.Flush();
                Response.End();
            }
        }

    }
    protected void btnExcelUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            if (excelUpdate.HasFile)
            {
                extension = String.Empty;
                extension = excelUpdate.FileName.Substring(excelUpdate.FileName.LastIndexOf("."));

                string FileName = excelUpdate.FileName;
                excelUpdate.SaveAs(HttpContext.Current.Server.MapPath("excelfile/" + FileName));

                dt = ReadExcelFile.ReadAsDataTable(FileName);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    ProductData pdata = new ProductData(int.Parse(dt.Rows[i][0].ToString()));
                    pdata.Catid = int.Parse(cmbCategoryExUp.SelectedValue.ToString());
                    pdata.SubCatId = int.Parse(cmbSubCateExUp.SelectedValue.ToString());                   
                  
                    pdata.Product = dt.Rows[i][1].ToString().Trim();

                    pdata.Price = int.Parse(dt.Rows[i][2].ToString());
                    pdata.Discount = getDiscount(dt.Rows[i][2].ToString(), dt.Rows[i][3].ToString()).ToString() + "%";

                    pdata.NewPrice = double.Parse(dt.Rows[i][3].ToString());

                    pdata.Quantity =int.Parse(dt.Rows[i][4].ToString());
                    pdata.Size = dt.Rows[i][5].ToString();
                    pdata.ProductType =int.Parse( dt.Rows[i][6].ToString());
                    pdata.Code = dt.Rows[i][7].ToString();
                    pdata.Description = dt.Rows[i][8].ToString();
                    pdata.Image = dt.Rows[i][9].ToString();
                    pdata.PageTitle = dt.Rows[i][10].ToString();
                    pdata.MetaKeyes = dt.Rows[i][11].ToString();
                    pdata.MetaDescription = dt.Rows[i][12].ToString();
                    pdata.Tax = double.Parse(dt.Rows[i][13].ToString());
                    pdata.Update(int.Parse(dt.Rows[i][0].ToString()));
                }
                fillProduct("select * from product  where status=1 and  subcategoryid=" + cmbSubCateExUp.SelectedValue.ToString());
                fillTree();
            }
            else
            {
                //Label1.Text = "Select Your Image first";
            }
        }
        catch (Exception ex)
        { }
    }
}