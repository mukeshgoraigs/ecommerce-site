using CCA.Util;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ThankYou : System.Web.UI.Page
{
    static int totalItems;
    static double totalAmount;
    static double totaldiscount;
    static double totalAmountWithoutTax;
    static double totalTax;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string wkey = WebConfigurationManager.AppSettings["workingkey"];
            string workingKey = wkey;//put in the 32bit alpha numeric key in the quotes provided here
            CCACrypto ccaCrypto = new CCACrypto();
            string encResponse = ccaCrypto.Decrypt(Request.Form["encResp"], workingKey);
            NameValueCollection Params = new NameValueCollection();
            string[] segments = encResponse.Split('&');
            foreach (string seg in segments)
            {
                string[] parts = seg.Split('=');
                if (parts.Length > 0)
                {
                    string Key = parts[0].Trim();
                    string Value = parts[1].Trim();
                    Params.Add(Key, Value);
                }
            }

            if (Params["order_status"] == "Success")
            {


               

                OrderHeaderData ohdata = new OrderHeaderData(int.Parse(Params["order_id"].ToString().Trim()));
                int userid = ohdata.UserId;
                clearCart(userid);
                ohdata.OrderStatus = Params["order_status"];
                ohdata.TrackingId = Params["tracking_id"];
                ohdata.BankRefNo = Params["bank_ref_no"];
                ohdata.PaymentMode = Params["payment_mode"];
                ohdata.CardName = Params["card_name"];
                ohdata.UpdateOrder(int.Parse(Params["order_id"].ToString().Trim()));
                ohdata.Update(int.Parse(Params["order_id"].ToString().Trim()));

                sendOrderMail(int.Parse(Params["order_id"].ToString().Trim()));

                Response.Redirect("paymentdone.html");
            }
            else
            {
                Response.Redirect("paymentproblem.html");
            }

            //for (int i = 0; i < Params.Count; i++)
            //{
            //    Response.Write(Params.Keys[i] + " = " + Params[i] + "<br>");
            //}
        }   
    }

    private void sendOrderMail(int orderid)
    {
        string msg = "";
        double goodiesAmount = 0;

        string adminMsg = "";

        GoodiesRulesData grdata = new GoodiesRulesData(1);



        DateTime now = DateTime.Now;
        string items = "";
        string day = now.Day.ToString();
        // month = now.ToString("MMM");
        string month = now.Month.ToString();
        string year = now.Year.ToString();
        String days = now.DayOfWeek.ToString();
        OrderHeaderData ohdata1 = new OrderHeaderData(orderid, "");
        CustomerData cdata = new CustomerData(ohdata1.UserId);
        AddressData adata = new AddressData(ohdata1.Address, "myaddress");
        AreaData arData = new AreaData(adata.Area);

        DataSet ds = CartItems(orderid);
        // lblTotalItems.Text = ds.Tables[0].Rows.Count.ToString();
        if (ds.Tables[0].Rows.Count > 0)
        {
            OrderLineData olData = new OrderLineData();
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {

                olData.OrderId = ohdata1.Id;
                olData.ItemNo = int.Parse(ds.Tables[0].Rows[i]["id"].ToString());
                olData.ItemName = ds.Tables[0].Rows[i]["productName"].ToString();
                olData.Size = ds.Tables[0].Rows[i]["size"].ToString();
                olData.Quantity = int.Parse(ds.Tables[0].Rows[i]["quantity"].ToString());
                olData.Price = float.Parse(ds.Tables[0].Rows[i]["price"].ToString());
                olData.NewPrice = float.Parse(ds.Tables[0].Rows[i]["newprice"].ToString());
                olData.TotalAmount = ((float.Parse(ds.Tables[0].Rows[i]["newprice"].ToString())) * (float.Parse(ds.Tables[0].Rows[i]["quantity"].ToString())));
                //olData.Save();

                double amountWithoutTax = (((float.Parse(ds.Tables[0].Rows[i]["newprice"].ToString())) * 100) / (100 + (float.Parse(ds.Tables[0].Rows[i]["tax"].ToString()))));
                items += "<tr><td>" + olData.ItemName + "</td><td>" + olData.Quantity + "</td><td>" + olData.NewPrice + "</td><td>" + olData.TotalAmount + "</td></tr>";

                totalAmountWithoutTax += (amountWithoutTax * olData.Quantity);
                totalTax += (olData.TotalAmount - (amountWithoutTax * olData.Quantity));
            }

            string address = cdata.FirstName + " " + cdata.LastName + "<br/>" + adata.Address1 + "," + adata.Address2 + "<br/>" + adata.Area + "<br/>" + adata.City + "-" + adata.Pincode + "<br/>Landmark : " + adata.Landmark + "<br/>Mobile : " + cdata.Mobile;
            string invodate = days + "-" + day + "-" + month + "-" + year;
            string total = totalAmount.ToString();

            if ((ohdata1.Goodeis) >= grdata.Goodies)
            {
                goodiesAmount = ((double.Parse(ohdata1.Goodeis.ToString())) / grdata.Goodies) * grdata.GoodiesValue;
                cdata.Points -= ohdata1.Goodeis;
                cdata.UpdatePoints(cdata.Id);
            }
            else
            {
                goodiesAmount = 0;
            }


           


            string totalbill = ((totalAmount - goodiesAmount - (ohdata1.CouponAmount)) + arData.Extera).ToString();

            string ur_goodies = ((int)((double.Parse(totalbill)) / grdata.Amount)).ToString();
            string invoice = ohdata1.Id.ToString();
            cdata.Points += int.Parse(ur_goodies);
            cdata.UpdatePoints(cdata.Id);

            ohdata1.PayAmount = double.Parse(totalbill);
            ohdata1.UpdatePayAmount(ohdata1.Id);

            adminMsg = "You have got new order, Order id is " + ohdata1.Id + " And order Amount is Rs. " + totalbill + " And Delivery Slot is " + ohdata1.OrderDate + " " + ohdata1.OrderTime;
            msg = "Thanks for shopping with us,your order has been placed successfully.Your order no " + ohdata1.Id + " amount of Rs " + totalbill + " will be delivered as per your time slot\nUrban Banya";
            SendMessageData.sendMessage(msg, cdata.Mobile);
            SendMessageData.sendMessage(adminMsg, "9462822505");
            string coupon = ohdata1.CouponAmount + " (" + ohdata1.Coupon + ")";
            MailManager mail = new MailManager();
            mail.SendBillingMail(cdata, invoice, invodate,ohdata1.OrderDate, address, total, arData.Extera.ToString(), goodiesAmount.ToString(),coupon, totalbill, items, ohdata1.PaymentOption, ohdata1.OrderTime, Math.Round(totalAmountWithoutTax, 1).ToString(), Math.Round(totalTax, 1).ToString());
        }
    }
    public void clearCart(int id)
    {

        MyCartData mcadat = new MyCartData();
        mcadat.Delete("delete from cartdata where userid=" + id);
    }
     public DataSet CartItems(int orderno)
    {
        MyCartData cdata = new MyCartData();
        DataSet ds = cdata.getCart("select product.id,product.productName,product.image,product.tax,orderline.id as cid,orderline.itemno,orderline.size,orderline.price,orderline.newPrice,orderline.quantity from product inner join orderline on product.id=orderline.itemno where orderline.orderno=" + orderno);

        if (ds.Tables[0].Rows.Count > 0)
        {

            calculateTotal(ds);
        }
        else
        {
            //lblTotalItems.Text = "No item In Cart";
        }

        return ds;
    }
     protected void calculateTotal(DataSet ds)
    {
        totalItems = 0;
        totalAmount = 0.0;
        totaldiscount = 0.0;
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            totalItems += int.Parse(ds.Tables[0].Rows[i]["quantity"].ToString());
            totalAmount += (double.Parse(ds.Tables[0].Rows[i]["newprice"].ToString()) * double.Parse(ds.Tables[0].Rows[i]["quantity"].ToString()));
            totaldiscount += ((double.Parse(ds.Tables[0].Rows[i]["price"].ToString()) - double.Parse(ds.Tables[0].Rows[i]["newprice"].ToString())) * double.Parse(ds.Tables[0].Rows[i]["quantity"].ToString()));
        }

    }
}