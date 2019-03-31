using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using System.IO;
using System.Text;

public partial class UrbanAdmin_OrderDetails : System.Web.UI.Page
{
    static int orderid,userid,adid;
    static double totalAmount;
    protected void Page_Load(object sender, EventArgs e)
    {
        orderid = int.Parse(Request.QueryString["orderid"]);
        userid = int.Parse(Request.QueryString["userid"]);
        adid = int.Parse(Request.QueryString["adid"]);
        fillOrderItems();
        fillAddress();
    }
    private void fillAddress()
    {
        CustomerData cdata = new CustomerData(userid);
        lblName.Text = cdata.FirstName;
        lblMobile.Text = cdata.Mobile;
        AddressData adata = new AddressData(adid,"myaddress");
        lblCity.Text = adata.City;
        lblArea.Text = adata.Area;
        lblPincode.Text = adata.Pincode;
        lblAddress1.Text = adata.Address1;
        lblAddress2.Text = adata.Address2;
        lblLandmark.Text = adata.Landmark;

        OrderHeaderData ohdata = new OrderHeaderData(orderid, "No use");
        txtReq.Text = ohdata.Instruction;
    }
    private void fillOrderItems()
    {
        OrderLineData oldata = new OrderLineData();
        DataSet ds = oldata.getCart("select product.id,product.productName,product.image,orderline.id as ocid,orderline.quantity,orderline.newprice,orderline.totalamount from product inner join orderline on product.id=orderline.itemno where orderline.orderno=" + orderid);
        // lblTotalItems.Text = ds.Tables[0].Rows.Count.ToString();
        if (ds.Tables[0].Rows.Count > 0)
        {

            rpOrderItems.DataSource = ds;
            rpOrderItems.DataBind();
            calculate(ds);
        }
        else
        {
            //lblTotalItems.Text = "No item In Cart";
        }

    }

    protected void calculate(DataSet ds)
    {
        totalAmount=0;
        for(int i=0;i<ds.Tables[0].Rows.Count;i++)
        {
            totalAmount += double.Parse(ds.Tables[0].Rows[i]["totalamount"].ToString());

        }
        lblTotalAmount.Text = totalAmount.ToString();
        OrderHeaderData ohdata = new OrderHeaderData(orderid,"");
        lblDeliveryCharge.Text = ohdata.DeliveryCharge.ToString();
    }
    protected void generateOrderBill()
    {
        string products = "";
        string items = "";
        double totalAmountWithoutTax = 0;
        double totalTax = 0;

        OrderHeaderData ohdata = new OrderHeaderData(orderid, "No use");
        CustomerData cdata = new CustomerData(ohdata.UserId);
        AddressData adata = new AddressData(adid, "myaddress");
        DataSet ds = OrderItems(orderid);
        if (ds.Tables[0].Rows.Count > 0)
        {
            OrderLineData olData = new OrderLineData();
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {

                olData.ItemNo = int.Parse(ds.Tables[0].Rows[i]["id"].ToString());
                olData.ItemName = ds.Tables[0].Rows[i]["productName"].ToString();
                olData.Size = ds.Tables[0].Rows[i]["size"].ToString();
                olData.Quantity = int.Parse(ds.Tables[0].Rows[i]["quantity"].ToString());
                olData.Price = float.Parse(ds.Tables[0].Rows[i]["price"].ToString());
                olData.NewPrice = float.Parse(ds.Tables[0].Rows[i]["newprice"].ToString());
                olData.TotalAmount = ((float.Parse(ds.Tables[0].Rows[i]["newprice"].ToString())) * (float.Parse(ds.Tables[0].Rows[i]["quantity"].ToString())));

                double amountWithoutTax = (((float.Parse(ds.Tables[0].Rows[i]["newprice"].ToString())) * 100) / (100 + (float.Parse(ds.Tables[0].Rows[i]["tax"].ToString()))));
                items += "<tr><td>" + olData.ItemName + "</td><td>" + olData.Quantity + "</td><td>" + olData.NewPrice + "</td><td>" + olData.TotalAmount + "</td></tr>";

                totalAmountWithoutTax += (amountWithoutTax * olData.Quantity);
                totalTax += (olData.TotalAmount - (amountWithoutTax * olData.Quantity));
            }

            string address = cdata.FirstName + " " + cdata.LastName + "<br/>" + adata.Address1 + "," + adata.Address2 + "<br/>" + adata.Area + "<br/>" + adata.City + "-" + adata.Pincode + "<br/>Landmark : " + adata.Landmark + "<br/>Mobile : " + cdata.Mobile;
            string invodate = ohdata.PlacedDate;
            string total = totalAmount.ToString();



            string htmlbody = System.IO.File.ReadAllText(System.Web.HttpContext.Current.Server.MapPath("pdf/billing.html"));

            htmlbody = htmlbody.Replace("_address_", address);
            htmlbody = htmlbody.Replace("_invoice_", orderid.ToString());
            htmlbody = htmlbody.Replace("_invoicedate_", invodate);
            htmlbody = htmlbody.Replace("_items_", items);
            htmlbody = htmlbody.Replace("_timeSlot_", ohdata.OrderTime);
            htmlbody = htmlbody.Replace("_totalwithouttax_",Math.Round(totalAmountWithoutTax,1).ToString());
            htmlbody = htmlbody.Replace("_totaltax_",Math.Round(totalTax,1).ToString());
            htmlbody = htmlbody.Replace("_total_", total);
            htmlbody = htmlbody.Replace("_delivery_", ohdata.DeliveryCharge);
            htmlbody = htmlbody.Replace("_goodiesamount_", ohdata.Goodeis.ToString());
            htmlbody = htmlbody.Replace("_urbancoupon_", ohdata.Coupon);
            htmlbody = htmlbody.Replace("_amount_", ohdata.OrderTotal.ToString());
            htmlbody = htmlbody.Replace("_paymentmethod_", ohdata.PaymentOption);


            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            StringBuilder sb = new StringBuilder(htmlbody);
           
            StringReader sr = new StringReader(sb.ToString());
            Document pdfDoc = new Document(PageSize.A4, 25f, 25f, 0f, 0f);
            HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
            PdfWriter writer = PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
            pdfDoc.Open();
            htmlparser.Parse(sr);
            pdfDoc.Close();
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;filename=bill_" + ohdata.Id + ".pdf");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Write(pdfDoc);
            Response.End();


        }
    }

    public DataSet OrderItems(int orderno)
    {
        MyCartData cdata = new MyCartData();
        DataSet ds = cdata.getCart("select product.id,product.productName,product.image,product.tax,orderline.id as cid,orderline.itemno,orderline.size,orderline.price,orderline.newPrice,orderline.quantity from product inner join orderline on product.id=orderline.itemno where orderline.orderno=" + orderno);

       

        return ds;
    }
protected void btnGenarateBill_Click(object sender, EventArgs e)
{
    generateOrderBill();
}
}