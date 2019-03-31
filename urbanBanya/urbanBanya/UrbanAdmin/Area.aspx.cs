using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UrbanAdmin_Area : System.Web.UI.Page
{
      static int upid;
    string extension;
    static string FileNameUp;
    static DataTable dt = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            fillArea();
            updatePanel.Visible = false;
        }
    }

    private void fillArea()
    {
        AreaData adata = new AreaData();
        DataSet ds = adata.getAreas("select * from area");
        rpArea.DataSource = ds;
        rpArea.DataBind();
        setAreaZone(ds);
    }
    protected void setAreaZone(DataSet ds)
    {
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            DropDownList cmbStatus = (DropDownList)rpArea.Items[i].FindControl("cmbAreaZone");
            cmbStatus.SelectedValue = ds.Tables[0].Rows[i]["cityzone"].ToString();
        }
    }

    protected void btnUpload_Click(object sender, EventArgs e)
    {
        try
        {
            AreaData adata = new AreaData();
            adata.City = txtCityName.Text.ToString();
            adata.CityZone = int.Parse(cmbAreaZone.SelectedValue.ToString());
            adata.Area = txtArea.Text.ToString()+"-"+txtPincode.Text.ToString();
            adata.Pincode = txtPincode.Text.ToString();
            adata.Extera = double.Parse(txtExtera.Text.ToString());
            adata.Save();
            txtArea.Text = "";
            txtPincode.Text = "";
            fillArea();
        }
        catch (Exception ex) { }
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            AreaData adata = new AreaData();
            adata.City = txtCityUp.Text.ToString();
            adata.CityZone = int.Parse(cmbAreaZoneUp.SelectedValue.ToString());
            adata.Area = txtAreaUp.Text.ToString() + "-" + txtPincodeUp.Text.ToString();
            adata.Pincode = txtPincodeUp.Text.ToString();
            adata.Extera = double.Parse(txtExAmountUp.Text.ToString());
            adata.Update(upid);
            fillArea();
            updatePanel.Visible = false;
            viewPanel.Visible = true;
           
        }
        catch (Exception ex) { }
    }
    protected void btnReset_Click(object sender, EventArgs e)
    {

    }
    protected void btnDelete_Click(object sender,EventArgs e)
    {

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
                AreaData adata = new AreaData();
                dt = ReadExcelFile.ReadAsDataTable(FileName);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                   adata.City = dt.Rows[i][0].ToString();
                    adata.CityZone =int.Parse( dt.Rows[i][1].ToString());
                    adata.Area = dt.Rows[i][2].ToString()+" - "+ dt.Rows[i][3].ToString();
                    adata.Pincode = dt.Rows[i][3].ToString();
                    adata.Extera =double.Parse( dt.Rows[i][4].ToString());                   
                    adata.Save();
                    
                }
                fillArea();
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
        string filename = "UrbanArea";
        AreaData adata = new AreaData();
        DataSet ds = adata.getAreas("select * from area");
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
                    AreaData adata = new AreaData(int.Parse(dt.Rows[i][0].ToString()));
                    adata.City = dt.Rows[i][1].ToString();
                    adata.CityZone = int.Parse(dt.Rows[i][2].ToString());
                    adata.Area = dt.Rows[i][3].ToString() + "-" + dt.Rows[i][4].ToString();
                    adata.Pincode = dt.Rows[i][4].ToString();
                    adata.Extera = double.Parse(dt.Rows[i][5].ToString());
                    adata.Update(adata.Id);
                }
                fillArea();
            }
            else
            {
                //Label1.Text = "Select Your Image first";
            }
        }
        catch (Exception ex)
        { }
    }
    protected void rpArea_ItemCommand(object source, RepeaterCommandEventArgs e)
    {

        if (e.CommandName == "edit")
        {
            int id = Convert.ToInt32(e.CommandArgument.ToString());
            updatePanel.Visible = true;
            viewPanel.Visible = false;
           
            AreaData adata = new AreaData(id);
            txtCityUp.Text = adata.City;
            cmbAreaZoneUp.SelectedValue = adata.CityZone.ToString();
            txtAreaUp.Text = adata.Area;
            txtPincodeUp.Text = adata.Pincode;
            txtExAmountUp.Text = adata.Extera.ToString();

            upid = adata.Id;
        }

    }
}