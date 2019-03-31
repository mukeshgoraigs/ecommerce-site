using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UrbanAdmin_GoodiesRules : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            fillGoodies();
        }
    }

    private void fillGoodies()
    {
        try
        {
            GoodiesRulesData grdata = new GoodiesRulesData(1);
            lblGoodiesID.Text = grdata.Id.ToString();
            txtAmount.Text = grdata.Amount.ToString();
            txtGoodies.Text = grdata.Goodies.ToString();
            txtGoodiesValue.Text = grdata.GoodiesValue.ToString();

        }
        catch (Exception ex) { }
    }
    protected void btnUpload_Click(object sender, EventArgs e)
    {
        try
        {
            GoodiesRulesData grdata = new GoodiesRulesData();
            grdata.Amount =double.Parse(txtAmount.Text.ToString());
            grdata.Goodies = int.Parse(txtGoodies.Text.ToString());
            grdata.GoodiesValue = double.Parse(txtGoodiesValue.Text.ToString());
            grdata.Update(int.Parse(lblGoodiesID.Text.ToString()));

            fillGoodies();

        }
        catch (Exception ex) { }
    }
}