using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UrbanAdmin_Section : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            fillCategory();
        }
    }

    private void fillProduct(string p)
    {
        ProductData pdata = new ProductData();
       DataSet ds= pdata.getProduct(p);
       if (ds.Tables[0].Rows.Count != 0)
       {
           rpProduct.DataSource = ds;
           rpProduct.DataBind();
       }
    }
    protected void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillSubCategory();
    }
    protected void cmbSubCategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        int id=int.Parse(cmbSubCategory.SelectedValue.ToString());
        fillProduct("select * from product where subcategoryid="+id);
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
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        for (int i = 0; i < rpProduct.Items.Count; i++)
        {
            CheckBox chk = (CheckBox)rpProduct.Items[i].FindControl("productid");
            if (chk.Checked)
            {

                SectionData sdata = new SectionData();
                sdata.ProductId = int.Parse(chk.Text);
                sdata.Position = 0;
                sdata.Section =int.Parse(cmbSection.SelectedValue.ToString());
                sdata.Save();
                chk.Checked = false;
               
            }
        }
    }
    protected void cmbSectionUp_SelectedIndexChanged(object sender, EventArgs e)
    {
        int sec =int.Parse( cmbSectionUp.SelectedValue.ToString());
        fillSection(sec);
    }

    private void fillSection(int section)
    {

        ProductData cdata = new ProductData();
        DataSet ds = cdata.getProduct("select product.id,product.productName,product.price,product.discount,product.size,product.code,product.image,hotitem.id as hotid,hotitem.position from product inner join hotitem on product.id=hotitem.productid and hotitem.section=" + section + " order by hotitem.position ASC");
        if (ds.Tables[0].Rows.Count > 0)
        {
            rpSection.DataSource = ds;
            rpSection.DataBind();
        }
        else
        {
           
        }
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        for (int i = 0; i < rpSection.Items.Count; i++)
        {
            CheckBox chk = (CheckBox)rpSection.Items[i].FindControl("sectionid");
            if (chk.Checked)
            {

                SectionData sdata = new SectionData();
                sdata.Delete("delete from hotitem where id=" + chk.Text);
                fillSection(int.Parse(cmbSectionUp.SelectedValue.ToString()));

            }
        }
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        for (int i = 0; i < rpSection.Items.Count; i++)
        {
            CheckBox chk = (CheckBox)rpSection.Items[i].FindControl("sectionid");
            if (chk.Checked)
            {
                TextBox txtPosi =(TextBox) rpSection.Items[i].FindControl("txtPosition");
                SectionData sdata = new SectionData(int.Parse(chk.Text));
                sdata.Position = int.Parse(txtPosi.Text);
                sdata.Section = int.Parse(cmbSectionUp.SelectedValue.ToString());
                sdata.Update(int.Parse(chk.Text));
                chk.Checked = false;

            }
        }
    }
}