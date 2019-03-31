using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UrbanAdmin_NewOffer : System.Web.UI.Page
{
    string extension;
    static string FileNameUp;
    static int idup;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            updatePanel.Visible = false;
            fillNewOffer();

        }
    }
    private void fillNewOffer()
    {
        NewOfferData ndata = new NewOfferData();
        DataSet ds = ndata.getNewOffer("select * from newoffer");
        if (ds.Tables[0].Rows.Count > 0)
        {
            rpOffers.DataSource = ds;
            rpOffers.DataBind();

        }
    }
    protected void btnUpload_Click(object sender, EventArgs e)
    {
        try
        {

            if (offerUpload.HasFile)
            {
                extension = String.Empty;

                extension = offerUpload.FileName.Substring(offerUpload.FileName.LastIndexOf("."));

                string FileName = offerUpload.FileName;

                offerUpload.SaveAs(HttpContext.Current.Server.MapPath("~/UrbanAdmin/newoffer/" + FileName));
              
                NewOfferData ndata = new NewOfferData();
                ndata.ImageName = FileName;
              
                ndata.AboutOffer = txtAboutOffer.Text.ToString();
                ndata.Link = txtUrl.Text.ToString().Trim();
                ndata.Position = 0;
                ndata.IsVisible = chkIsVisible.Checked;


                ndata.Save();
                fillNewOffer();
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
        
        txtAboutOffer.Text = "";
        txtUrl.Text = "";
        chkIsVisible.Checked = false;
    }
    protected void rpProduct_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        updatePanel.Visible = true;
        viewPanel.Visible = false;
        NewOfferData ndata = new NewOfferData(int.Parse(e.CommandArgument.ToString()));
        offerImage.ImageUrl = "~/UrbanAdmin/newoffer/" + ndata.ImageName;
        chkVisibleUp.Checked = ndata.IsVisible;
        txtLinkUp.Text = ndata.Link;
        txtPositionUp.Text = ndata.Position.ToString();
        txtAboutOfferUp.Text = ndata.AboutOffer;
        FileNameUp = ndata.ImageName;
        idup = ndata.Id;


    }
    protected void rpProduct_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {

    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            string FileName;
            if (offerUploadUp.HasFile)
            {
                extension = String.Empty;
                extension = offerUploadUp.FileName.Substring(offerUploadUp.FileName.LastIndexOf("."));
                FileName = offerUploadUp.FileName;

                offerUploadUp.SaveAs(HttpContext.Current.Server.MapPath("~/UrbanAdmin/newoffer/" + FileName));
               
            }
            else
            {
                FileName = FileNameUp;
                
            }

            NewOfferData ndata = new NewOfferData();
            ndata.ImageName = FileName;

            ndata.AboutOffer = txtAboutOfferUp.Text.ToString();
            ndata.Link = txtLinkUp.Text.ToString().Trim();
            ndata.Position = int.Parse(txtPositionUp.Text.ToString().Trim());
            ndata.IsVisible = chkVisibleUp.Checked;
            ndata.Update(idup);

            resetup();
            updatePanel.Visible = false;
            viewPanel.Visible = true;
            fillNewOffer();

        }
        catch (Exception ex)
        { }
    }

    private void resetup()
    {
        chkVisibleUp.Checked = false;
        txtLinkUp.Text = "";
        txtPositionUp.Text = "";
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
        for (int i = 0; i < rpOffers.Items.Count; i++)
        {
            CheckBox chk = (CheckBox)rpOffers.Items[i].FindControl("offerid");
            if (chk.Checked)
            {

                SliderData sdata = new SliderData();
                sdata.Delete("delete from newoffer where id=" + chk.Text);

            }
        }
        fillNewOffer();
        Response.Redirect("NewOffer.aspx");
    }
}