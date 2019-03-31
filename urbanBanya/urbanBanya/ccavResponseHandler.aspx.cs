using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.Collections.Specialized;
using CCA.Util;
using System.Web.Configuration;

    
public partial class ResponseHandler : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
             string wkey = WebConfigurationManager.AppSettings["workingkey"];

             string workingKey = wkey;//put in the 32bit alpha numeric key in the quotes provided here
            CCACrypto ccaCrypto = new CCACrypto();
            string encResponse = ccaCrypto.Decrypt(Request.Form["encResp"],workingKey);
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
                OrderHeaderData ohdata = new OrderHeaderData(int.Parse(Params["order_id"]));
                int userid = ohdata.UserId;
                clearCart(userid);
                ohdata.OrderStatus = Params["order_status"];
                ohdata.TrackingId = Params["tracking_id"];
                ohdata.BankRefNo = Params["bank_ref_no"];
                ohdata.PaymentMode = Params["payment_mode"];
                ohdata.CardName = Params["card_name"];
                ohdata.UpdateOrder(int.Parse(Params["order_id"]));
                ohdata.Update(int.Parse(Params["order_id"]));

                Response.Redirect("MyAccount.aspx");
            }

            //for (int i = 0; i < Params.Count; i++)
            //{
            //    Response.Write(Params.Keys[i] + " = " + Params[i] + "<br>");
            //}
           
           
         }
        public void clearCart(int id)
        {

            MyCartData mcadat = new MyCartData();
            mcadat.Delete("delete from cartdata where userid=" + id);
        }
    }
