using ClosedXML.Excel;
using HelperClass;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Category : System.Web.UI.Page
{
   
    int ch = 0;
    string extension;
    static string FileNameUp;
    static int idup;
    static DataTable dt = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            
            fillCategory();
            fillTree();
            updatePanel.Visible = false;
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
                DataSet pds = pdata.getProduct("select * from product where subcategoryid=" + int.Parse(sds.Tables[0].Rows[ch][0].ToString()));
                TreeNode child = new TreeNode();
                child.Text = sds.Tables[0].Rows[ch][2].ToString() + " -<span class='badge active'>" + pds.Tables[0].Rows.Count + "</span>";
                root.ChildNodes.Add(child);
                ch++;
            }

            tvCategores.Nodes.Add(root);
        }
        tvCategores.CollapseAll();
    }
    protected void btnReset_Click(object sender, EventArgs e)
    {
        reset();
    }
    protected void btnUpload_Click(object sender, EventArgs e)
    {
        try
        {
            if (categoryImg.HasFile)
            {
                extension = String.Empty;

                extension = categoryImg.FileName.Substring(categoryImg.FileName.LastIndexOf("."));

                string FileName = categoryImg.FileName;

               // categoryImg.SaveAs(HttpContext.Current.Server.MapPath("~/UrbanAdmin/category/" + FileName));

              

                ImageResizeNew rmg = new ImageResizeNew();
                rmg.GenerateThumbnails(0.5, categoryImg.PostedFile.InputStream, HttpContext.Current.Server.MapPath("~/UrbanAdmin/category/small/" + categoryImg.FileName), 108, 108);
                rmg.GenerateThumbnails(0.5, categoryImg.PostedFile.InputStream, HttpContext.Current.Server.MapPath("~/UrbanAdmin/category/medium/" + categoryImg.FileName), 224, 224);
                rmg.GenerateThumbnails(0.5, categoryImg.PostedFile.InputStream, HttpContext.Current.Server.MapPath("~/UrbanAdmin/category/large/" + categoryImg.FileName), 300, 300);
                rmg.GenerateThumbnails(0.5, categoryImg.PostedFile.InputStream, HttpContext.Current.Server.MapPath("~/UrbanAdmin/category/xlarge/" + categoryImg.FileName), 500, 500);


                CategoryData data = new CategoryData();
                data.Category = txtCategory.Text.ToString();
                data.Description = txtDescription.Text.ToString();
                data.Image = FileName;
                data.PageTitle = txtTitle.Text.ToString();
                data.MetaKeyes = txtMetaKey.Text.ToString();
                data.MetaDescription = txtMetaDescription.Text.ToString();

                data.Save();
                fillCategory();
                fillTree();
                reset();
            }
            else
            {
                //Label1.Text = "Select Your Image first";
            }
        }
        catch (Exception ex)
        { }
    }
    public void fillCategory()
    {
        CategoryData cdata = new CategoryData();
        DataSet ds = cdata.getCategory("select * from category");
        if (ds.Tables[0].Rows.Count > 0)
        {
            rpCategory.DataSource = ds;
            rpCategory.DataBind();

        }
        else
        {
            
        }
    }
    public void reset()
    {
        txtCategory.Text = "";
        txtDescription.Text = "";
        txtTitle.Text = "";
        txtMetaKey.Text = "";
        txtMetaDescription.Text = "";

    }
    protected void tvCategores_SelectedNodeChanged(object sender, EventArgs e)
    {
        var selectedNode=tvCategores.SelectedNode;
        if (selectedNode.Parent == null)
        {
            string[] node = tvCategores.SelectedValue.ToString().Split('-');
            CategoryData cdata = new CategoryData(node[0].ToString().Trim());
            idup = cdata.Id;
            txtCategoryUp.Text = cdata.Category;
            txtDescriptionUp.Text = cdata.Description;
            txtPageTitleUp.Text = cdata.PageTitle;
            txtMetaKeyUp.Text = cdata.MetaKeyes;
            txtMetaDescriptionUp.Text = cdata.MetaDescription;
            catimgup.ImageUrl = "~/UrbanAdmin/category/small/" + cdata.Image;
            FileNameUp = cdata.Image;
            updatePanel.Visible = true;
            addPanel.Visible = false;
        }
        else
        {
           
        }
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {

            string FileName;
            if (categoryImgUp.HasFile)
            {
                extension = String.Empty;

                extension = categoryImgUp.FileName.Substring(categoryImgUp.FileName.LastIndexOf("."));

                FileName = categoryImgUp.FileName;

                // categoryImg.SaveAs(HttpContext.Current.Server.MapPath("~/UrbanAdmin/category/" + FileName));



                ImageResizeNew rmg = new ImageResizeNew();
                rmg.GenerateThumbnails(0.5, categoryImgUp.PostedFile.InputStream, HttpContext.Current.Server.MapPath("~/UrbanAdmin/category/small/" + categoryImgUp.FileName), 108, 108);
                rmg.GenerateThumbnails(0.5, categoryImgUp.PostedFile.InputStream, HttpContext.Current.Server.MapPath("~/UrbanAdmin/category/medium/" + categoryImgUp.FileName), 224, 224);
                rmg.GenerateThumbnails(0.5, categoryImgUp.PostedFile.InputStream, HttpContext.Current.Server.MapPath("~/UrbanAdmin/category/large/" + categoryImgUp.FileName), 300, 300);
                rmg.GenerateThumbnails(0.5, categoryImgUp.PostedFile.InputStream, HttpContext.Current.Server.MapPath("~/UrbanAdmin/category/xlarge/" + categoryImgUp.FileName), 500, 500);
            }
            else
            {
                FileName = FileNameUp;
            }


            CategoryData cdata = new CategoryData();
            cdata.Category = txtCategoryUp.Text.ToString();
            cdata.Description = txtDescriptionUp.Text.ToString();
            cdata.PageTitle = txtPageTitleUp.Text.ToString();
            cdata.MetaKeyes = txtMetaKeyUp.Text.ToString();
            cdata.MetaDescription = txtMetaDescriptionUp.Text.ToString();
            cdata.Image = FileName;
            cdata.Update(idup);
            fillCategory();
            fillTree();
            updatePanel.Visible = false;
            addPanel.Visible = true;
            tvCategores.SelectedNode.Selected = false;
        }
        catch (Exception ex) { }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        addPanel.Visible = true;
        updatePanel.Visible = false;
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        for (int i = 0; i < rpCategory.Items.Count; i++)
        {
            CheckBox chk = (CheckBox)rpCategory.Items[i].FindControl("categoryid");
            if (chk.Checked)
            {
               
                ProductData pdata = new ProductData();
                pdata.Delete("delete from category where id=" + chk.Text);

            }
        }
        fillCategory();
        fillTree();
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
                CategoryData cdata = new CategoryData();
                dt = ReadExcelFile.ReadAsDataTable(FileName);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    cdata.Category = dt.Rows[i][0].ToString();
                    cdata.Description = dt.Rows[i][1].ToString();
                    cdata.Image = dt.Rows[i][2].ToString();
                    cdata.PageTitle = dt.Rows[i][3].ToString();
                    cdata.MetaKeyes = dt.Rows[i][4].ToString();
                    cdata.MetaDescription = dt.Rows[i][5].ToString();
                    cdata.Save();



                }
                fillCategory();
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

    protected void btnImageUpload_Click(object sender, EventArgs e)
    {
        try
        {
            if (uploadCatImage.HasFile)
            {
                foreach (HttpPostedFile postedFile in uploadCatImage.PostedFiles)
                {


                    string fileName = postedFile.FileName;
                    //  postedFile.SaveAs(HttpContext.Current.Server.MapPath("~/admin/images/"+ fileName));

                    CategoryData cdata = new CategoryData(fileName,"image");

                    if (cdata.HasValue)
                    {


                        ImageResizeNew rmg = new ImageResizeNew();
                        rmg.GenerateThumbnails(0.5, categoryImg.PostedFile.InputStream, HttpContext.Current.Server.MapPath("~/UrbanAdmin/category/small/" + categoryImg.FileName), 108, 108);
                        rmg.GenerateThumbnails(0.5, categoryImg.PostedFile.InputStream, HttpContext.Current.Server.MapPath("~/UrbanAdmin/category/medium/" + categoryImg.FileName), 224, 224);
                        rmg.GenerateThumbnails(0.5, categoryImg.PostedFile.InputStream, HttpContext.Current.Server.MapPath("~/UrbanAdmin/category/large/" + categoryImg.FileName), 300, 300);
                        rmg.GenerateThumbnails(0.5, categoryImg.PostedFile.InputStream, HttpContext.Current.Server.MapPath("~/UrbanAdmin/category/xlarge/" + categoryImg.FileName), 500, 500);
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
    protected void btnExcelExport_Click(object sender,EventArgs e)
    {
        string filename = "UrbanCategory";
        CategoryData cdata = new CategoryData();
        DataSet ds = cdata.getCategory("select * from category");
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
    protected void btnExcelUpdate_Click(object sender,EventArgs e)
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
                    CategoryData cdata = new CategoryData(int.Parse(dt.Rows[i][0].ToString()));
                    cdata.Category= dt.Rows[i][1].ToString();
                    cdata.Description= dt.Rows[i][2].ToString();
                    cdata.Image = dt.Rows[i][3].ToString();
                    cdata.PageTitle = dt.Rows[i][4].ToString();
                    cdata.MetaKeyes = dt.Rows[i][5].ToString();
                    cdata.MetaDescription = dt.Rows[i][6].ToString();
                    cdata.Update(cdata.Id);
                }
                fillCategory();
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