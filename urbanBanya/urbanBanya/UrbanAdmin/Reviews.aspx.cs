using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UrbanAdmin_Reviews : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            fillReview();
        }
    }
    protected void cmbReviewStatus_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList ddl = (DropDownList)sender;

        RepeaterItem ri = (RepeaterItem)ddl.NamingContainer;
        Label lblid = (Label)rpReviews.Items[ri.ItemIndex].FindControl("lblid");
        ReviewData rdata = new ReviewData(int.Parse(lblid.Text.ToString()));
        rdata.Status = int.Parse(ddl.SelectedValue.ToString());
        rdata.Update(int.Parse(lblid.Text.ToString()));
       
    }
    protected void setReviewStatus(DataSet ds)
    {
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            DropDownList cmbStatus = (DropDownList)rpReviews.Items[i].FindControl("cmbReviewStatus");
            cmbStatus.SelectedValue = ds.Tables[0].Rows[i]["status"].ToString();
        }
    }
    private void fillReview()
    {
        try
        {
            ReviewData rdata = new ReviewData();
            DataSet ds = rdata.getReviewes("select review.id,review.customerid,review.review,review.status,customer.F_name from review inner join customer on customer.id=review.customerid");
            rpReviews.DataSource = ds;
            rpReviews.DataBind();
            setReviewStatus(ds);
        }
        catch (Exception ex) { }
    }
    protected void rpReviews_ItemCommand(object source, RepeaterCommandEventArgs e)
    {

        string commandName = e.CommandName.ToString();
        if(commandName=="delete")
        {
            int id = int.Parse(e.CommandArgument.ToString());
            ReviewData rdata = new ReviewData();
            rdata.Delete("delete from review where id="+id);
            fillReview();
        }
    }
}