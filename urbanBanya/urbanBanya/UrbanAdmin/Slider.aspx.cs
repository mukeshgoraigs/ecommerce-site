using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UrbanAdmin_SliderData : System.Web.UI.Page
{
   
    string extension;
    static string FileNameUp, widthup, heightup;
    static int idup;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            updatePanel.Visible = false;
            fillSlider();

        }
    }

    private void fillSlider()
    {
        SliderData sdata = new SliderData();
        DataSet ds = sdata.getSlider("select * from slider");
        if (ds.Tables[0].Rows.Count > 0)
        {
            rpSilder.DataSource = ds;
            rpSilder.DataBind();

        }
    }
    protected void btnUpload_Click(object sender,EventArgs e)
    {
        try
        {

            if (sliderUpload.HasFile)
            {
                extension = String.Empty;

                extension = sliderUpload.FileName.Substring(sliderUpload.FileName.LastIndexOf("."));

                string FileName = sliderUpload.FileName;

                sliderUpload.SaveAs(HttpContext.Current.Server.MapPath("~/UrbanAdmin/slider/" + FileName));
                System.Drawing.Image im = System.Drawing.Image.FromStream(sliderUpload.PostedFile.InputStream);
                SliderData sdata = new SliderData();
                sdata.ImageName = FileName;
                sdata.Offer = txtOffer.Text.ToString();
                sdata.AboutOffer = txtAboutOffer.Text.ToString();
                sdata.Link = txtUrl.Text.ToString().Trim();
                sdata.ImageWidth = im.PhysicalDimension.Width.ToString();
                sdata.ImageHeight = im.PhysicalDimension.Height.ToString();
                sdata.IsVisible = chkIsVisible.Checked;


                sdata.Save();
                fillSlider();
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
        txtOffer.Text = "";
        txtAboutOffer.Text = "";
        txtUrl.Text = "";
        chkIsVisible.Checked = false;
    }
    protected void rpProduct_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        updatePanel.Visible = true;
        viewPanel.Visible = false;
        SliderData sdata = new SliderData(int.Parse(e.CommandArgument.ToString()));
        sliderImage.ImageUrl = "~/UrbanAdmin/slider/"+sdata.ImageName;
        chkVisibleUp.Checked = sdata.IsVisible;
        txtLinkUp.Text = sdata.Link;
        txtOfferUp.Text = sdata.Offer;
        txtAboutOfferUp.Text = sdata.AboutOffer;
        FileNameUp = sdata.ImageName;
        idup = sdata.Id;


    }
    protected void rpProduct_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {

    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            string FileName, width, height;
            if (sliderUploadUp.HasFile)
            {
                extension = String.Empty;
                extension = sliderUploadUp.FileName.Substring(sliderUploadUp.FileName.LastIndexOf("."));
                FileName = sliderUploadUp.FileName;

                sliderUploadUp.SaveAs(HttpContext.Current.Server.MapPath("~/UrbanAdmin/slider/" + FileName));
                System.Drawing.Image im = System.Drawing.Image.FromStream(sliderUploadUp.PostedFile.InputStream);
                width = im.PhysicalDimension.Width.ToString();
                height = im.PhysicalDimension.Height.ToString();
            }
            else
            {
                FileName = FileNameUp;
                width = widthup;
                height = heightup;
            }

            SliderData sdata = new SliderData();
            sdata.ImageName = FileName;
            sdata.Offer = txtOfferUp.Text.ToString();
            sdata.AboutOffer = txtAboutOfferUp.Text.ToString();
            sdata.Link = txtLinkUp.Text.ToString().Trim();
            sdata.ImageWidth = width;
            sdata.ImageHeight = height;
            sdata.IsVisible = chkVisibleUp.Checked;
            sdata.Update(idup);
           
            resetup();
            updatePanel.Visible = false;
            viewPanel.Visible = true;
            fillSlider();

        }
        catch (Exception ex)
        { }
    }

    private void resetup()
    {
        chkVisibleUp.Checked = false;
        txtLinkUp.Text = "";
        txtOfferUp.Text = "";
        txtAboutOfferUp.Text = "";
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        resetup();
        updatePanel.Visible = false;
        viewPanel.Visible = true;
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        for (int i = 0; i < rpSilder.Items.Count; i++)
        {
            CheckBox chk = (CheckBox)rpSilder.Items[i].FindControl("sliderid");
            if (chk.Checked)
            {

                SliderData sdata = new SliderData();
                sdata.Delete("delete from slider where id=" + chk.Text);

            }
        }
        fillSlider();
        Response.Redirect("Slider.aspx");
    }
}