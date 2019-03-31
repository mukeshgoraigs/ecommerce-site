using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UrbanAdmin_TaxReport : System.Web.UI.Page
{
    static double totaltax;
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnGetTax_Click(object sender,EventArgs e)
    {
        totaltax = 0;
        string datef = datefrom.Text.ToString().Trim();
        string datet = dateto.Text.ToString().Trim();

        OrderLineData oddata = new OrderLineData();
        DataSet ds = oddata.getCart("select sum(totalamount),itemno from orderline where orderno in (select id from orderheader where status='Completed' and placedate between '" + datef+"' and '"+datet+"') group by itemno");

        DataTable dt = new DataTable();
        //Create DataTable columns

        dt.Columns.Add(new DataColumn("item", typeof(string)));
        dt.Columns.Add(new DataColumn("sales", typeof(string)));
        dt.Columns.Add(new DataColumn("tax", typeof(string)));
        dt.Columns.Add(new DataColumn("paytax", typeof(string)));
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            ProductData pdata = new ProductData(int.Parse(ds.Tables[0].Rows[i][1].ToString()));
            DataRow dr = null;
            //Create Row for each columns
            dr = dt.NewRow();

            dr["item"] = pdata.Product;
            dr["sales"] = ds.Tables[0].Rows[i][0].ToString();
            dr["tax"] = pdata.Tax;
            dr["paytax"] = ((double.Parse(ds.Tables[0].Rows[i][0].ToString()))*(double.Parse(pdata.Tax.ToString())))/100;
            dt.Rows.Add(dr);
            totaltax+= ((double.Parse(ds.Tables[0].Rows[i][0].ToString())) * (double.Parse(pdata.Tax.ToString()))) / 100;
        }
        //Store the DataTable in ViewState for future reference
        ViewState["CurrentTable"] = dt;

        //Bind the Repeater with the DataTable
        rpTaxReport.DataSource = dt;
        rpTaxReport.DataBind();
        lblTotalTax.Text ="Total = "+totaltax.ToString();
    }
}