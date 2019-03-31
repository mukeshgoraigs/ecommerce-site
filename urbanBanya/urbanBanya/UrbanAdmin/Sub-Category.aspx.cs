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

public partial class Sub_Category : System.Web.UI.Page
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
           
            tvCategores.CollapseAll();
            fillCategory();
            fillSubCategory();
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
                child.Text = sds.Tables[0].Rows[ch][2].ToString() + " -<span class='badge'>" + pds.Tables[0].Rows.Count + "</span>";
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
        DataSet ds= cdata.getCategory("select * from category");
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

        cmbCategoryExcel.DataSource = ds;
        cmbCategoryExcel.DataTextField = "categoryName";
        cmbCategoryExcel.DataValueField = "id";
        cmbCategoryExcel.DataBind();
        cmbCategoryExcel.Items.Insert(0, "Select Category");
        cmbCategoryExcel.SelectedIndex = 0;


        cmbCategoryExUp.DataSource = ds;
        cmbCategoryExUp.DataTextField = "categoryName";
        cmbCategoryExUp.DataValueField = "id";
        cmbCategoryExUp.DataBind();
        cmbCategoryExUp.Items.Insert(0, "Select Category");
        cmbCategoryExUp.SelectedIndex = 0;
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            if (subCategoryImg.HasFile)
            {
                extension = String.Empty;

                extension = subCategoryImg.FileName.Substring(subCategoryImg.FileName.LastIndexOf("."));

                string FileName = subCategoryImg.FileName;

                // categoryImg.SaveAs(HttpContext.Current.Server.MapPath("~/UrbanAdmin/category/" + FileName));

                ImageCompress imgCompress = ImageCompress.GetImageCompressObject;
                imgCompress.GetImage = new System.Drawing.Bitmap(subCategoryImg.FileContent);
                imgCompress.Height = 108;
                imgCompress.Width = 108;
                imgCompress.Save(subCategoryImg.FileName, HttpContext.Current.Server.MapPath("~/UrbanAdmin/subcategory/small/"));
                imgCompress.Height = 224;
                imgCompress.Width = 224;
                imgCompress.Save(subCategoryImg.FileName, HttpContext.Current.Server.MapPath("~/UrbanAdmin/subcategory/medium/"));
                imgCompress.Height = 300;
                imgCompress.Width = 300;
                imgCompress.Save(subCategoryImg.FileName, HttpContext.Current.Server.MapPath("~/UrbanAdmin/subcategory/large/"));
                imgCompress.Height = 500;
                imgCompress.Width = 500;
                imgCompress.Save(subCategoryImg.FileName, HttpContext.Current.Server.MapPath("~/UrbanAdmin/subcategory/xlarge/"));

                SubCData data = new SubCData();
                data.Catid =int.Parse( cmbCategory.SelectedValue.ToString());
                data.SubCategory = txtSubCategory.Text.ToString();
                data.Description = txtSubDescription.Text.ToString();
                data.Image = FileName;
                data.PageTitle = txtTitle.Text.ToString();
                data.MetaKeyes = txtMetaKey.Text.ToString();
                data.MetaDescription = txtMetaDescription.Text.ToString();

                data.Save();
                fillSubCategory();
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

    private void reset()
    {
        cmbCategory.SelectedIndex = 0;
        txtSubCategory.Text = "";
        txtSubDescription.Text = "";
        txtTitle.Text = "";
        txtMetaKey.Text = "";
        txtMetaDescription.Text = "";
    }

    private void fillSubCategory()
    {
        SubCData cdata = new SubCData();
        DataSet ds = cdata.getSubCategory("select * from subcategory");
        if (ds.Tables[0].Rows.Count > 0)
        {
            rpSubCategory.DataSource = ds;
            rpSubCategory.DataBind();

        }
        else
        {

        }
    }
    protected void tvCategores_SelectedNodeChanged(object sender, EventArgs e)
    {
        var selectedNode = tvCategores.SelectedNode;
        if (selectedNode.Parent == null)
        {
            viewPanel.Visible = true;
            updatePanel.Visible = false;
            string[] node = tvCategores.SelectedValue.ToString().Split('-');
            CategoryData cdata = new CategoryData(node[0].ToString().Trim());
            SubCData scData = new SubCData();
            DataSet ds = scData.getSubCategory("select * from subcategory where categoryid="+cdata.Id);
            if (ds.Tables[0].Rows.Count > 0)
            {
                rpSubCategory.DataSource = ds;
                rpSubCategory.DataBind();

            }
            else
            {
               
            }


        }
        else
        {
            string[] node = tvCategores.SelectedValue.ToString().Split('-');
            SubCData scdata = new SubCData(node[0].ToString().Trim());
            idup = scdata.Id;
            cmbCategoryUp.SelectedValue = scdata.Catid.ToString();
            txtSubCateUp.Text = scdata.SubCategory;
            txtSubCatDesUp.Text = scdata.Description;
            subCatImg.ImageUrl = "~/UrbanAdmin/subcategory/small/" + scdata.Image;
            FileNameUp = scdata.Image;
            txtTitleUp.Text = scdata.PageTitle;
            txtMetaKeyUp.Text = scdata.MetaKeyes;
            txtMetaDescriptionUp.Text = scdata.MetaDescription;
            


            viewPanel.Visible = false;
            updatePanel.Visible = true;
        }
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            string FileName;
            if (subCatImgUp.HasFile)
            {
                extension = String.Empty;

                extension = subCatImgUp.FileName.Substring(subCatImgUp.FileName.LastIndexOf("."));

                FileName = subCatImgUp.FileName;

                // categoryImg.SaveAs(HttpContext.Current.Server.MapPath("~/UrbanAdmin/category/" + FileName));

                ImageCompress imgCompress = ImageCompress.GetImageCompressObject;
                imgCompress.GetImage = new System.Drawing.Bitmap(subCatImgUp.FileContent);
                imgCompress.Height = 108;
                imgCompress.Width = 108;
                imgCompress.Save(subCatImgUp.FileName, HttpContext.Current.Server.MapPath("~/UrbanAdmin/subcategory/small/"));
                imgCompress.Height = 224;
                imgCompress.Width = 224;
                imgCompress.Save(subCatImgUp.FileName, HttpContext.Current.Server.MapPath("~/UrbanAdmin/subcategory/medium/"));
                imgCompress.Height = 300;
                imgCompress.Width = 300;
                imgCompress.Save(subCatImgUp.FileName, HttpContext.Current.Server.MapPath("~/UrbanAdmin/subcategory/large/"));
                imgCompress.Height = 500;
                imgCompress.Width = 500;
                imgCompress.Save(subCatImgUp.FileName, HttpContext.Current.Server.MapPath("~/UrbanAdmin/subcategory/xlarge/"));
            }
            else
            {
                FileName = FileNameUp;
            }

            SubCData scdata = new SubCData();
            scdata.Catid =int.Parse( cmbCategoryUp.SelectedValue.ToString());
            scdata.SubCategory = txtSubCateUp.Text;
            scdata.Description = txtSubCatDesUp.Text;
            scdata.Image = FileName;
            scdata.PageTitle = txtTitleUp.Text;
            scdata.MetaKeyes = txtMetaKeyUp.Text;
            scdata.MetaDescription = txtMetaDescriptionUp.Text;
            scdata.Update(idup);
            fillSubCategory();
            fillTree();
            viewPanel.Visible = true;
            updatePanel.Visible = false;

        }

        catch(Exception ex){ }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        viewPanel.Visible = true;
        updatePanel.Visible = false;
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        for (int i = 0; i < rpSubCategory.Items.Count; i++)
        {
            CheckBox chk = (CheckBox)rpSubCategory.Items[i].FindControl("subcateid");
            if (chk.Checked)
            {
              
                ProductData pdata = new ProductData();
                pdata.Delete("delete from subcategory where id=" + chk.Text);

            }
        }
        fillSubCategory();
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
                SubCData sdata = new SubCData();
                dt = ReadExcelFile.ReadAsDataTable(FileName);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    sdata.Catid = int.Parse(cmbCategoryExcel.SelectedValue.ToString());
                    sdata.SubCategory = dt.Rows[i][0].ToString();
                    sdata.Description = dt.Rows[i][1].ToString();
                    sdata.Image = dt.Rows[i][2].ToString();
                    sdata.PageTitle = dt.Rows[i][3].ToString();
                    sdata.MetaKeyes = dt.Rows[i][4].ToString();
                    sdata.MetaDescription = dt.Rows[i][5].ToString();
                    sdata.Save();
                    fillSubCategory();
                    fillTree();


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
            if (uploadSubImage.HasFile)
            {
                foreach (HttpPostedFile postedFile in uploadSubImage.PostedFiles)
                {


                    string fileName = postedFile.FileName;
                    //  postedFile.SaveAs(HttpContext.Current.Server.MapPath("~/admin/images/"+ fileName));

                    SubCData pdata = new SubCData(fileName,"image");

                    if (pdata.HasValue)
                    {
                        ImageCompress imgCompress = ImageCompress.GetImageCompressObject;
                        imgCompress.GetImage = new System.Drawing.Bitmap(postedFile.InputStream);
                        imgCompress.Height = 108;
                        imgCompress.Width = 108;
                        imgCompress.Save(postedFile.FileName, HttpContext.Current.Server.MapPath("~/UrbanAdmin/subcategory/small/"));
                        imgCompress.Height = 224;
                        imgCompress.Width = 224;
                        imgCompress.Save(postedFile.FileName, HttpContext.Current.Server.MapPath("~/UrbanAdmin/subcategory/medium/"));
                        imgCompress.Height = 300;
                        imgCompress.Width = 300;
                        imgCompress.Save(postedFile.FileName, HttpContext.Current.Server.MapPath("~/UrbanAdmin/subcategory/large/"));
                        imgCompress.Height = 500;
                        imgCompress.Width = 500;
                        imgCompress.Save(postedFile.FileName, HttpContext.Current.Server.MapPath("~/UrbanAdmin/subcategory/xlarge/"));
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
    protected void btnExcelExport_Click(object sender, EventArgs e)
    {
        string filename = "SubCategory"+cmbCategoryExUp.SelectedItem.ToString();
        int id = int.Parse(cmbCategoryExUp.SelectedValue.ToString());
        CategoryData cdata = new CategoryData();
        DataSet ds = cdata.getCategory("select id,subCategoryName,description,image,pagetitle,metakey,metadescription from subcategory where categoryid=" + id);
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
                    SubCData scdata = new SubCData(int.Parse(dt.Rows[i][0].ToString()));
                    scdata.Catid = int.Parse(cmbCategoryExUp.SelectedValue.ToString());
                    scdata.SubCategory = dt.Rows[i][1].ToString();
                    scdata.Description = dt.Rows[i][2].ToString();
                    scdata.Image = dt.Rows[i][3].ToString();
                    scdata.PageTitle = dt.Rows[i][4].ToString();
                    scdata.MetaKeyes = dt.Rows[i][5].ToString();
                    scdata.MetaDescription = dt.Rows[i][6].ToString();
                    scdata.Update(scdata.Id);
                }
                fillCategory();
                fillSubCategory();
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