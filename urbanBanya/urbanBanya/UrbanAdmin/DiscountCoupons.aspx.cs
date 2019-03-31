using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UrbanAdmin_DiscountCoupons : System.Web.UI.Page
{
    int ch = 0;
    static int cupid;
    static string CouponFile;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            fillTree();
            fillTreeUp();
            fillCoupons();
            updatePanel.Visible = false;
           
        }
    }

    private void fillCoupons()
    {
        try
        {
            CouponsData cdata = new CouponsData();
            DataSet ds = cdata.getCoupons("select * from coupons");
            rpCoupons.DataSource = ds;
            rpCoupons.DataBind();
        }
        catch (Exception ex) { }
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
                DataSet pds = pdata.getProduct("select * from product where subcategoryid=" + int.Parse(sds.Tables[0].Rows[ch][0].ToString()));
                TreeNode child = new TreeNode();
                child.Text = sds.Tables[0].Rows[ch][2].ToString() + " -<span class='badge'>" + pds.Tables[0].Rows.Count + "</span>";
                root.ChildNodes.Add(child);
                ch++;
            }

            tvCategores.Nodes.Add(root);

        }
        tvCategores.CollapseAll();

    }
    private void fillTreeUp()
    {

        CategoryData cdata = new CategoryData();
        DataSet cds = cdata.getCategory("select * from category");

        tvCategoresUp.Nodes.Clear();
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
                DataSet pds = pdata.getProduct("select * from product where subcategoryid=" + int.Parse(sds.Tables[0].Rows[ch][0].ToString()));
                TreeNode child = new TreeNode();
                child.Text = sds.Tables[0].Rows[ch][2].ToString() + " -<span class='badge'>" + pds.Tables[0].Rows.Count + "</span>";
                root.ChildNodes.Add(child);
                ch++;
            }


            tvCategoresUp.Nodes.Add(root);
        }

        tvCategoresUp.CollapseAll();
    }
    protected void tvCategores_SelectedNodeChanged(object sender, EventArgs e)
    {
        var selectedNode = tvCategores.SelectedNode;
        if (selectedNode.Parent == null)
        {
            viewPanel.Visible = true;
            // updatePanel.Visible = false;
            string[] node = tvCategores.SelectedValue.ToString().Split('-');
            CategoryData cdata = new CategoryData(node[0].ToString().Trim());
            SubCData scData = new SubCData();
            DataSet ds = scData.getSubCategory("select * from subcategory where categoryid=" + cdata.Id);
            if (ds.Tables[0].Rows.Count > 0)
            {
                rpSubCategory.DataSource = ds;
                rpSubCategory.DataBind();

            }
            else
            {

            }


        }

    }


    protected void btnGenerateCoupon_Click(object sender, EventArgs e)
    {
        string subcategory = "";
        for (int i = 0; i < rpSubCategory.Items.Count; i++)
        {
            CheckBox chk = (CheckBox)rpSubCategory.Items[i].FindControl("subcateid");
            if (chk.Checked)
            {
                if (subcategory == "")
                {
                    subcategory += chk.Text;
                }
                else
                {
                    subcategory += "," + chk.Text;
                }
            }
        }

        string FileName = couponImage.FileName;
        ImageResizeNew rmg = new ImageResizeNew();

        rmg.GenerateThumbnails(0.5, couponImage.PostedFile.InputStream, HttpContext.Current.Server.MapPath("~/UrbanAdmin/coupon/" + couponImage.FileName), 500, 500);

        CouponsData cdata = new CouponsData();
        cdata.Name = txtCouponName.Text;
        cdata.MinimumAmount = double.Parse(txtMinimumAmount.Text.ToString());
        cdata.Discount = txtDiscount.Text.ToString();
        cdata.SubCategory = subcategory;
        cdata.DiscountType = 1;
        cdata.StartDate = datefrom.Text.ToString();
        cdata.EndDate = dateto.Text.ToString();
        cdata.Description = txtDescription.Text.ToString();
        cdata.Image = FileName;
        cdata.Save();




    }
    protected void rpCoupons_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        try
        {


            string command = e.CommandName.ToString();
            int couponid = int.Parse(e.CommandArgument.ToString());
            if (command == "delete")
            {
                CouponsData cdata = new CouponsData();
                cdata.Delete("delete from coupons where id=" + couponid);
                fillCoupons();
            }
            else
            {
                CouponsData cdata = new CouponsData(couponid);


                string[] fdate = cdata.StartDate.ToString().Replace(" 12:00:00 AM", "").Split('/');
                string[] tdate = cdata.EndDate.ToString().Replace(" 12:00:00 AM", "").Split('/');

                cupid = cdata.Id;
                CouponFile = cdata.Image;
                txtCouponNameUp.Text = cdata.Name;
                txtMinimumAmountUp.Text = cdata.MinimumAmount.ToString();
                txtDiscountUp.Text = cdata.Discount.ToString();
                txtFromUp.Text = fdate[2] + "-" + fdate[0] + "-" + fdate[1];
                txtToUp.Text = tdate[2] + "-" + tdate[0] + "-" + tdate[1];
                txtDescriptionUp.Text = cdata.Description;
                SubCData scdata = new SubCData();
                DataSet ds = scdata.getSubCategory("select * from subcategory where id in (" + cdata.SubCategory + ")");
                rpSubCategoryUp.DataSource = ds;
                rpSubCategoryUp.DataBind();

                for (int i = 0; i < rpSubCategoryUp.Items.Count; i++)
                {
                    CheckBox chk = (CheckBox)rpSubCategoryUp.Items[i].FindControl("subcateid");
                    chk.Checked = true;
                }


                viewPanel.Visible = false;
                updatePanel.Visible = true;
               
            }
        }
        catch (Exception ex) { }
    }
    protected void btnCancelCouponUpdate_Click(object sender, EventArgs e)
    {
        viewPanel.Visible = true;
        updatePanel.Visible = false;
    }
    protected void btnUpdateCoupon_Click(object sender, EventArgs e)
    {
        try 
        {

        string FileName;
        string subcategory = "";
        for (int i = 0; i < rpSubCategoryUp.Items.Count; i++)
        {
            CheckBox chk = (CheckBox)rpSubCategoryUp.Items[i].FindControl("subcateid");
            if (chk.Checked)
            {
                if (subcategory == "")
                {
                    subcategory += chk.Text;
                }
                else
                {
                    subcategory += "," + chk.Text;
                }
            }
        }

        if (couponImageUp.HasFile)
        {
            FileName = couponImageUp.FileName;
            ImageResizeNew rmg = new ImageResizeNew();

            rmg.GenerateThumbnails(0.5, couponImageUp.PostedFile.InputStream, HttpContext.Current.Server.MapPath("~/UrbanAdmin/coupon/" + couponImageUp.FileName), 500, 500);
        }
        else
        {
            FileName = CouponFile;
        }



        CouponsData cdata = new CouponsData();
        cdata.Name = txtCouponNameUp.Text;
        cdata.MinimumAmount = double.Parse(txtMinimumAmountUp.Text.ToString());
        cdata.Discount = txtDiscountUp.Text;
        cdata.Image = FileName;
        cdata.StartDate = txtFromUp.Text;
        cdata.EndDate = txtToUp.Text;
        cdata.SubCategory = subcategory;
        cdata.Description = txtDescriptionUp.Text;
        cdata.Update(cupid);
        updatePanel.Visible = false;
            viewPanel.Visible=true;
           
            fillCoupons();
        }
        catch (Exception ex) { }

    }
    protected void tvCategoresUp_SelectedNodeChanged(object sender, EventArgs e)
    {
        var selectedNode = tvCategoresUp.SelectedNode;
        if (selectedNode.Parent == null)
        {
           
            string[] node = tvCategoresUp.SelectedValue.ToString().Split('-');
            CategoryData cdata = new CategoryData(node[0].ToString().Trim());
            SubCData scData = new SubCData();
            DataSet ds = scData.getSubCategory("select * from subcategory where categoryid=" + cdata.Id);
            if (ds.Tables[0].Rows.Count > 0)
            {
                rpSubCategoryUp.DataSource = ds;
                rpSubCategoryUp.DataBind();

            }
            else
            {

            }


        }
    }
}