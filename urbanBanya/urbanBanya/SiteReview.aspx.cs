using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SiteReview : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            fillReview();
        }
    }

    private void fillReview()
    {
        try
        {
            ReviewData rdata = new ReviewData();
            DataSet ds = rdata.getReviewes("select review.id,review.customerid,review.review,review.status,customer.F_name from review inner join customer on customer.id=review.customerid where review.status=1");
            rpReview.DataSource = ds;
            rpReview.DataBind();

        }
        catch (Exception ex) { }
    }
}