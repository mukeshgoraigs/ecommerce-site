using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Configuration;
using System.Web.Script.Serialization;
using System.Web.Services;

/// <summary>
/// Summary description for WebService
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
[System.Web.Script.Services.ScriptService]
public class WebService : System.Web.Services.WebService
{
    static int totalItems;
    static double totalAmount;
    static double totaldiscount;
    static double totalAmountWithoutTax;
    static double totalTax;
    public WebService()
    {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public string saveData(string dataid, string oldprice, string newprice, string sessionid, string size)
    {


        try
        {
            MyCartData cdatach = new MyCartData(int.Parse(dataid), sessionid, size);

            if (!cdatach.HasValue)
            {
                int status = 1;
                MyCartData cdata = new MyCartData();
                cdata.ProductId = int.Parse(dataid);
                cdata.Size = size;
                cdata.Quantity = 1;
                cdata.IsCheckout = true;
                cdata.Price = double.Parse(oldprice);
                cdata.NewPrice = double.Parse(newprice);
                cdata.UserId = 0;
                cdata.SessionId = sessionid;
                cdata.DiscountId = 0;
                cdata.Save();

            }




        }
        catch (Exception ex)
        {

        }
        return "aman";
    }


    [WebMethod]
    public void removeData(int dataid, float price, string sessionid, string size)
    {
        DataSet ds = null;

        try
        {
            MyCartData cdatach = new MyCartData(dataid, sessionid, size);
            if (cdatach.HasValue && cdatach.Quantity == 2)
            {
                cdatach.Delete("delete from cartdata where id=" + cdatach.Id);
            }
            if (cdatach.HasValue && cdatach.Quantity > 2)
            {
                int status = 1;

                cdatach.ProductId = dataid;
                cdatach.Quantity = cdatach.Quantity - 2;
                cdatach.Update(cdatach.Id);

            }




        }
        catch (Exception ex)
        {

        }

    }
    [WebMethod]
    public void deleteItem(int id, string sessionid, string size)
    {
        DataSet ds = null;

        try
        {
            MyCartData cdatach = new MyCartData(id, sessionid, size);
            if (cdatach.HasValue)
            {
                cdatach.Delete("delete from cartdata where id=" + cdatach.Id);
            }

        }
        catch (Exception ex)
        {

        }

    }
    [WebMethod]
    public void clearCart(string sessionid)
    {
        DataSet ds = null;

        try
        {
            MyCartData cdatach = new MyCartData();

            cdatach.Delete("delete from cartdata where sessionid='" + sessionid + "'");

        }
        catch (Exception ex)
        {

        }

    }
    [WebMethod]
    public void reSendOtp(string email)
    {

        try
        {
            Random r = new Random();
            int otp = r.Next(1000, 9999);
            string msg = "Use " + otp + " as OTP to verify your identity , please don't share to anyone . \n Urban Banya";
            CustomerData cdata = new CustomerData(email);
            SendMessageData.sendMessage(msg, cdata.Mobile);
        }
        catch (Exception ex)
        {

        }

    }
    [WebMethod]
    public string checkCart(string sessionid)
    {
        DataSet ds = null;
        string res = "";
        try
        {
            MyCartData cdatach = new MyCartData();

            ds = cdatach.getCart("select * from cartdata where sessionid='" + sessionid + "'");
            if (ds.Tables[0].Rows.Count == 0)
            {
                res = "no";
            }
            else
            {
                res = "yes";
            }

        }
        catch (Exception ex)
        {

        }
        return res;
    }
    [WebMethod]
    public void saveAddressP(string email, string city, string area, string address1, string address2, string landmark)
    {
        try
        {
            CustomerData cdata = new CustomerData(email);

            cdata.Update(cdata.Id);
            AreaData ardata = new AreaData(area);
            AddressData adata = new AddressData();
            adata.CustomerId = cdata.Id;
            adata.City = city;
            adata.CityZone = ardata.CityZone;
            adata.Area = area;
            adata.Pincode = ardata.Pincode;
            adata.Address1 = address1;
            adata.Address2 = address2;
            adata.FlatNo = "";
            adata.Landmark = landmark;
            adata.IsPrimary = true;
            adata.Save();

        }
        catch (Exception ex)
        {

        }

    }
    [WebMethod]
    public void saveAddress(string email, string city, string area, string address1, string address2, string landmark)
    {
        try
        {
            CustomerData cdata = new CustomerData(email);
            AreaData ardata = new AreaData(area);
            AddressData adata = new AddressData();

            adata.CustomerId = cdata.Id;
            adata.City = city;
            adata.CityZone = ardata.CityZone;
            adata.Area = area;
            adata.Pincode = ardata.Pincode;
            adata.Address1 = address1;
            adata.Address2 = address2;
            adata.FlatNo = "";
            adata.Landmark = landmark;
            adata.IsPrimary = false;
            adata.Save();

        }
        catch (Exception ex)
        {

        }

    }
    [WebMethod]
    public AddressData getAddress(string id)
    {
        int adid = int.Parse(id);

        AddressData adata = new AddressData(adid, "for adderss");

        return adata;
    }
    [WebMethod]
    public AreaData getExtera(string area)
    {


        AreaData adata = new AreaData(area);

        return adata;
    }

    [WebMethod]
    public string[] GetArea(string area)
    {

        SubCData adata = new SubCData();
        DataSet ds = adata.getSubCategory("select * from area where areaname LIKE '%" + area + "%'");
        string[] arr = new string[ds.Tables[0].Rows.Count];
        if (ds.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                arr[i] = ds.Tables[0].Rows[i]["areaname"].ToString();
            }

        }

        //  jstring = JsonConvert.SerializeObject(ds, Formatting.Indented);


        return arr;
    }
    [WebMethod]
    public string GetProduct(string product)
    {

        SubCData adata = new SubCData();
        List<ProductSearch> plist = new List<ProductSearch>();
        DataSet ds = adata.getSubCategory("select id,productName,image,newprice,price,size,discount from product where productName LIKE '%" + product + "%'");
        string[] arr = new string[ds.Tables[0].Rows.Count];
        if (ds.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                ProductSearch pdata = new ProductSearch();
                pdata.Id = Convert.ToInt32(ds.Tables[0].Rows[i]["id"].ToString());
                pdata.Product = ds.Tables[0].Rows[i]["productName"].ToString();
                pdata.Image = ds.Tables[0].Rows[i]["image"].ToString();
                pdata.NewPrice = Convert.ToDouble(ds.Tables[0].Rows[i]["newprice"].ToString());
                pdata.OldPrice = Convert.ToDouble(ds.Tables[0].Rows[i]["price"].ToString());
                pdata.Size = ds.Tables[0].Rows[i]["size"].ToString();
                pdata.Discount = ds.Tables[0].Rows[i]["discount"].ToString();
                plist.Add(pdata);

            }

        }

        JavaScriptSerializer js = new JavaScriptSerializer();
        string str = js.Serialize(plist);

        // Context.Response.Write(str);
        return str;


    }

    [WebMethod]
    public void searchAppProduct(string product)
    {

        SubCData adata = new SubCData();
        List<ProductSearch> plist = new List<ProductSearch>();
        ResponseData rsData = new ResponseData();
        string responce = "";


        DataSet ds = adata.getSubCategory("select id,productName,image,newprice,price,size,discount from product where productName LIKE '%" + product + "%'");
        string[] arr = new string[ds.Tables[0].Rows.Count];
        if (ds.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                ProductSearch pdata = new ProductSearch();
                pdata.Id = Convert.ToInt32(ds.Tables[0].Rows[i]["id"].ToString());
                pdata.Product = ds.Tables[0].Rows[i]["productName"].ToString();
                pdata.Image = ds.Tables[0].Rows[i]["image"].ToString();
                pdata.NewPrice = Convert.ToDouble(ds.Tables[0].Rows[i]["newprice"].ToString());
                pdata.OldPrice = Convert.ToDouble(ds.Tables[0].Rows[i]["price"].ToString());
                pdata.Size = ds.Tables[0].Rows[i]["size"].ToString();
                pdata.Discount = ds.Tables[0].Rows[i]["discount"].ToString();
                plist.Add(pdata);



            }

        }

        rsData.Message = "success";
        rsData.Description = "successfully got Products";
        rsData.Data = plist;
        JavaScriptSerializer js = new JavaScriptSerializer();
        responce = js.Serialize(plist);

        Context.Response.Clear();
        Context.Response.ContentType = "application/json";
        Context.Response.AddHeader("content-length", responce.Length.ToString());
        Context.Response.Flush();

        Context.Response.Write(responce);

    }
    public void clearCart(int id)
    {

        MyCartData mcadat = new MyCartData();
        mcadat.Delete("delete from cartdata where userid=" + id);
    }

    [WebMethod]
    public string confirm(string myslot, string adid, string mydate, string payoption, string email, string goodies, string coupon, string instruction)
    {
        string url = "";
        string msg = "";
        string adminMsg = "";
        string couponName = "";
        string couponAmount = "0";
        double goodiesAmount = 0;
        totalAmountWithoutTax = 0;
        totalTax = 0;
        try
        {

            DateTime now = DateTime.Now;
            string items = "";
            string day = now.Day.ToString();
            // month = now.ToString("MMM");
            string month = now.Month.ToString();
            string year = now.Year.ToString();
            String days = now.DayOfWeek.ToString();
            CustomerData cdata = new CustomerData(email);
            DataSet ds = CartItems(cdata.Id);
            AddressData adata = new AddressData(int.Parse(adid), "myaddress");
            AreaData arData = new AreaData(adata.Area);
            GoodiesRulesData grdata = new GoodiesRulesData(1);
            OrderHeaderData ohdataToCheck = new OrderHeaderData(cdata.Id);

            if (coupon != "")
            {
                string date = year + "-" + month + "-" + day;
                CouponsData cpdata = new CouponsData(coupon, date);
                if (cpdata.HasValue)
                {
                    OrderHeaderData ohdatacoupontest = new OrderHeaderData();
                    ohdatacoupontest.CheckCoupon(cdata.Id, coupon);

                    if (!ohdatacoupontest.HasValue)
                    {

                        couponAmount = cpdata.Discount;
                        couponName = cpdata.Name;
                    }

                }
            }
                else
                {
                    couponName = "no Coupon";
                    couponAmount = "0";
                }


                if (ohdataToCheck.HasValue)
                {
                    clearIncompleteOrder(ohdataToCheck.Id);
                }


                OrderHeaderData ohdata = new OrderHeaderData();
                ohdata.UserId = cdata.Id;
                ohdata.Address = int.Parse(adid);
                ohdata.OrderTotal = totalAmount.ToString();
                ohdata.DeliveryCharge = arData.Extera.ToString();
                ohdata.Goodeis = int.Parse(goodies);
                ohdata.Coupon = couponName;
                ohdata.CouponAmount = double.Parse(couponAmount);
                ohdata.PlacedDate = year + "-" + month + "-" + day;
                ohdata.OrderDate = mydate;
                ohdata.OrderTime = myslot;
                ohdata.Instruction = instruction;
                ohdata.PaymentOption = payoption;
                ohdata.Status = "Pending";
                ohdata.Save();
                OrderHeaderData ohdata1 = new OrderHeaderData(cdata.Id);

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
                        olData.Save();

                        double amountWithoutTax = (((float.Parse(ds.Tables[0].Rows[i]["newprice"].ToString())) * 100) / (100 + (float.Parse(ds.Tables[0].Rows[i]["tax"].ToString()))));
                        items += "<tr><td>" + olData.ItemName + "</td><td>" + olData.Quantity + "</td><td>" + olData.NewPrice + "</td><td>" + olData.TotalAmount + "</td></tr>";
                        totalAmountWithoutTax += (amountWithoutTax * olData.Quantity);
                        totalTax += (olData.TotalAmount - (amountWithoutTax * olData.Quantity));

                    }



                    if (payoption == "COD")
                    {

                        ohdata1.Update(ohdata1.Id);
                        string address = cdata.FirstName + " " + cdata.LastName + "<br/>" + adata.Address1 + "," + adata.Address2 + "<br/>" + adata.Area + "<br/>" + adata.City + "-" + adata.Pincode + "<br/>Landmark : " + adata.Landmark + "<br/>Mobile : " + cdata.Mobile;
                        string invodate = days + "-" + day + "-" + month + "-" + year;
                        string total = totalAmount.ToString();
                        if ((int.Parse(goodies)) >= grdata.Goodies)
                        {
                            goodiesAmount = ((double.Parse(goodies)) / grdata.Goodies) * grdata.GoodiesValue;
                            cdata.Points -= int.Parse(goodies);
                            cdata.UpdatePoints(cdata.Id);
                        }
                        else
                        {
                            goodiesAmount = 0;
                        }





                        string totalbill = ((totalAmount - goodiesAmount - (double.Parse(couponAmount))) + arData.Extera).ToString();

                        string ur_goodies = ((int)((double.Parse(totalbill)) / grdata.Amount)).ToString();
                        string invoice = ohdata1.Id.ToString();
                        cdata.Points += int.Parse(ur_goodies);
                        cdata.UpdatePoints(cdata.Id);

                        ohdata1.PayAmount = double.Parse(totalbill);
                        ohdata1.UpdatePayAmount(ohdata1.Id);

                        adminMsg = "You have got new order, Order id is " + ohdata1.Id + " And order Amount is Rs. " + totalbill + " And Delivery Slot is " + ohdata1.OrderTime;
                        msg = "Thanks for shopping with us,your order has been placed successfully.Your order no " + ohdata1.Id + " amount of Rs " + totalbill + " will be delivered as per your time slot\nUrban Banya";
                        SendMessageData.sendMessage(msg, cdata.Mobile);
                        SendMessageData.sendMessage(adminMsg, "9462822505");
                        string coupon1 = ohdata1.CouponAmount + " (" + ohdata1.Coupon + ")";
                        MailManager mail = new MailManager();
                        mail.SendBillingMail(cdata, invoice, invodate, ohdata1.OrderDate, address, total, arData.Extera.ToString(), goodiesAmount.ToString(), coupon1, totalbill, items, payoption, ohdata1.OrderTime, Math.Round(totalAmountWithoutTax, 1).ToString(), Math.Round(totalTax, 1).ToString());

                        clearCart(cdata.Id);
                        url = "myaccount";
                    }
                    else
                    {

                        url = "PayOnline.aspx?orderid=" + ohdata1.Id + "&totalamount=" + totalAmount + "&name=" + cdata.FirstName + "&area=" + adata.Area + "&pincode=" + adata.Pincode + "&city=" + adata.City + "&mobile=" + cdata.Mobile + "&email=" + cdata.Email;
                        //postData(ohdata1.Id, totalAmount, cdata.FirstName, adata.Area, adata.Pincode, adata.City, cdata.Mobile, cdata.Email);
                        //MailManager mail = new MailManager();
                        //mail.SendBillingMail(cdata, invoice, invodate, address, total, ardata.Extera, items);
                        //ohdata1.Update(ohdata1.Id);
                        //clearCart(cdata.Id);
                    }


                }
                else
                {
                    //lblTotalItems.Text = "No item In Cart";
                }

            }
        
        catch (Exception ex)
        {

        }
        return url;
    
    }

    private void clearIncompleteOrder(int orderid)
    {
        OrderLineData oldata = new OrderLineData();
        oldata.Delete("delete from orderline where orderno=" + orderid);
        OrderHeaderData ohdata = new OrderHeaderData();
        ohdata.Delete("delete from orderheader where id=" + orderid);

    }

    public DataSet CartItems(int Id)
    {
        MyCartData cdata = new MyCartData();
        DataSet ds = cdata.getCart("select product.id,product.productName,product.image,product.tax,cartdata.id as cid,cartdata.productid,cartdata.size,cartdata.price,cartdata.newPrice,cartdata.quantity,cartdata.sessionid,cartdata.userid from product inner join cartdata on product.id=cartdata.productid where cartdata.userid=" + Id);

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
    [WebMethod]
    public MoreSizeData getSizeData(string id)
    {
        int adid = int.Parse(id);

        MoreSizeData msdata = new MoreSizeData(adid);

        return msdata;
    }
    [WebMethod]
    public string cancelOrder(int id)
    {
        DataSet ds = null;
        string responce = "";
        try
        {
            OrderHeaderData ohdata = new OrderHeaderData(id, "no use");
            if (ohdata.Status == "Pending")
            {
                ohdata.Status = "Canceled";
                ohdata.UpdateStatus(id);
                responce = "Canceled";
            }
            else
            {
                responce = "no";
            }

        }
        catch (Exception ex)
        {

        }
        return responce;
    }
    [WebMethod]
    public void getAllCoupon()
    {
        List<CouponsData> clist = new List<CouponsData>();
        CouponsData cdata = new CouponsData();
        ResponseData rsData = new ResponseData();
        string responce;
        try
        {
            DataSet ds = cdata.getCoupons("select * from coupons");
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                int cid = int.Parse(ds.Tables[0].Rows[i][0].ToString());
                CouponsData cdata1 = new CouponsData(cid);
                clist.Add(cdata1);
            }

            rsData.Message = "coupons";
            rsData.Description = "got coupons";
            rsData.Data = clist;


        }
        catch (Exception ex)
        {

        }
        JavaScriptSerializer js = new JavaScriptSerializer();
        responce = js.Serialize(rsData);
        Context.Response.Clear();
        Context.Response.ContentType = "application/json";
        Context.Response.AddHeader("content-length", responce.Length.ToString());
        Context.Response.Flush();

        Context.Response.Write(responce);
    }

    [WebMethod]
    public void getCoupon(string email,string coupon, double amount, string orderJson)
    {
        double validCouponAmount = 0;
        DateTime now = DateTime.Now;
        string items = "";
        string day = now.Day.ToString();
        // month = now.ToString("MMM");
        string month = now.Month.ToString();
        string year = now.Year.ToString();
        String days = now.DayOfWeek.ToString();
        DataSet ds = null;
        string responce = "";
        string date = year + "-" + month + "-" + day;

        double subcategoryAmount = 0;

        try
        {
            List<CouponsData> clist = new List<CouponsData>();
            CouponsData cdata = new CouponsData(coupon, date);
            ResponseData rsData = new ResponseData();

            if (cdata.HasValue)
            {
                CustomerData csdata = new CustomerData(email);
                OrderHeaderData ohdata = new OrderHeaderData();
                ohdata.CheckCoupon(csdata.Id, coupon);

                if (!ohdata.HasValue)
                {


                    if (cdata.MinimumAmount <= amount)
                    {


                        JavaScriptSerializer ser = new JavaScriptSerializer();
                        var products = ser.Deserialize<List<OrderJson>>(orderJson);
                        int[] subcategory = Array.ConvertAll(cdata.SubCategory.ToString().Split(','), int.Parse);
                        foreach (var product in products)
                        {
                            for (int i = 0; i < subcategory.Length; i++)
                            {
                                if (subcategory[i] == product.SubcategoryId)
                                {
                                    subcategoryAmount += (product.Newprice * product.Quantity);
                                }
                            }
                        }

                        if (subcategoryAmount >= cdata.MinimumAmount)
                        {
                            rsData.Message = "success";
                            rsData.Description = "successfully got Coupon Info";
                            clist.Add(cdata);
                            rsData.Data = clist;
                            JavaScriptSerializer js = new JavaScriptSerializer();
                            responce = js.Serialize(rsData);
                        }
                        else
                        {
                            rsData.Message = "notforthese";
                            rsData.Description = "Coupon is not Valid for your Cart Items";
                            clist.Add(cdata);
                            JavaScriptSerializer js = new JavaScriptSerializer();
                            responce = js.Serialize(rsData);
                        }

                    }
                    else
                    {
                        rsData.Message = "amountless";
                        rsData.Description = "Minimum amount should be " + cdata.MinimumAmount;
                        clist.Add(cdata);
                        rsData.Data = clist;
                        JavaScriptSerializer js = new JavaScriptSerializer();
                        responce = js.Serialize(rsData);
                    }
                }
                else
                {
                    rsData.Message = "alreadyused";
                    rsData.Description = "You Have Already Used " + cdata.Name;
                    clist.Add(cdata);
                    rsData.Data = clist;
                    JavaScriptSerializer js = new JavaScriptSerializer();
                    responce = js.Serialize(rsData);
                }

            }
            else
            {
                rsData.Message = "not found";
                rsData.Description = "not found Coupon Info";
                clist.Add(cdata);
                rsData.Data = clist;
                JavaScriptSerializer js = new JavaScriptSerializer();
                responce = js.Serialize(rsData);
            }

        }
        catch (Exception ex)
        {

        }
        Context.Response.Clear();
        Context.Response.ContentType = "application/json";
        Context.Response.AddHeader("content-length", responce.Length.ToString());
        Context.Response.Flush();

        Context.Response.Write(responce);

    }

    [WebMethod]
    public string applyCoupon(string email,string coupon, string sessionid)
    {
        double validCouponAmount = 0;
        DateTime now = DateTime.Now;
        string items = "";
        string day = now.Day.ToString();
        // month = now.ToString("MMM");
        string month = now.Month.ToString();
        string year = now.Year.ToString();
        String days = now.DayOfWeek.ToString();
        DataSet ds = null;
        string responce = "";
        string date = year + "-" + month + "-" + day; ;

        try
        {
            CouponsData cdata = new CouponsData(coupon, date);
            if (cdata.HasValue)
            {
                CustomerData csdata = new CustomerData(email);
                OrderHeaderData ohdata = new OrderHeaderData();
                ohdata.CheckCoupon(csdata.Id, coupon);

                if (!ohdata.HasValue)
                {
                MyCartData mcdata = new MyCartData();
                DataSet dsCart = mcdata.getCart("select product.id,product.subcategoryid,product.productName,product.discount,product.image,cartdata.id as cid,cartdata.productid,cartdata.size,cartdata.price,cartdata.newprice,cartdata.quantity,cartdata.sessionid,cartdata.userid from product inner join cartdata on product.id=cartdata.productid where sessionid='" + sessionid + "' and product.subcategoryid IN (" + cdata.SubCategory + ")");
                if (dsCart.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < dsCart.Tables[0].Rows.Count; i++)
                    {

                        validCouponAmount += (double.Parse(dsCart.Tables[0].Rows[i]["newprice"].ToString()) * double.Parse(dsCart.Tables[0].Rows[i]["quantity"].ToString()));
                    }

                    if (validCouponAmount >= cdata.MinimumAmount)
                    {
                        responce = "Coupon Applied Rs. ," + cdata.Discount;
                    }
                    else
                    {
                        responce = "Coupon is valid on Minimum Amount of " + cdata.MinimumAmount + " for Offer Subcategories";
                    }

                }
                else
                {
                    responce = "Not Valid for These Cart Items !";
                }

            }
                else{
                    responce = "You Have Already Used "+cdata.Name;
                }
            }
            else
            {
                responce = "no";
            }

        }
        catch (Exception ex)
        {

        }
        return responce;
    }
    [WebMethod]
    public string myGoodies(string email, string goodies)
    {
        DataSet ds = null;
        double redeemAmount = 0;
        string responce = "";
        try
        {
            int rgoodies = int.Parse(goodies);
            CustomerData cdata = new CustomerData(email);
            GoodiesRulesData grdata = new GoodiesRulesData(1);
            if (cdata.Points >= rgoodies)
            {

                redeemAmount = ((double.Parse(goodies)) / grdata.Goodies) * grdata.GoodiesValue;

                responce = "yes,Redeem Successful ," + redeemAmount;
            }
            else
            {
                responce = "no,Invalid amount ! You have ," + cdata.Points;
            }



        }
        catch (Exception ex)
        {

        }
        return responce;
    }

    [WebMethod]
    public void myAppGoodies(string email, string goodies)
    {
        DataSet ds = null;
        double redeemAmount = 0;
        string responce = "";
        try
        {
            int rgoodies = int.Parse(goodies);
            CustomerData cdata = new CustomerData(email);
            GoodiesRulesData grdata = new GoodiesRulesData(1);
            if (cdata.Points >= rgoodies)
            {

                redeemAmount = ((double.Parse(goodies)) / grdata.Goodies) * grdata.GoodiesValue;

                responce = "yes,Redeem Successful ," + redeemAmount;
            }
            else
            {
                responce = "no,Invalid amount ! You have ," + cdata.Points;
            }



        }
        catch (Exception ex)
        {

        }
        JavaScriptSerializer js = new JavaScriptSerializer();
        responce = js.Serialize(responce);


        Context.Response.Clear();
        Context.Response.ContentType = "application/json";
        Context.Response.AddHeader("content-length", responce.Length.ToString());
        Context.Response.Flush();

        Context.Response.Write(responce);

    }

    [WebMethod]
    public void calculateGoodies(int orderid)
    {
        List<OrderHeaderData> ohlist = new List<OrderHeaderData>();
        ResponseData rsData = new ResponseData();

        double goodiesAmount = 0;
        DataSet ds = null;
        double redeemAmount = 0;
        int goodies;
        string responce = "";
        try
        {
            GoodiesRulesData grdata = new GoodiesRulesData(1);
            OrderHeaderData ohdata = new OrderHeaderData(orderid, "");
            CustomerData cdata = new CustomerData(ohdata.UserId);
            goodies = ohdata.Goodeis;
            if (goodies >= grdata.Goodies)
            {
                goodiesAmount = ((goodies) / grdata.Goodies) * grdata.GoodiesValue;
                cdata.Points -= goodies;
                cdata.UpdatePoints(cdata.Id);
            }
            else
            {
                goodiesAmount = 0;
            }


            string ur_goodies = ((int)((ohdata.PayAmount) / grdata.Amount)).ToString();
            string invoice = ohdata.Id.ToString();
            cdata.Points += int.Parse(ur_goodies);
            cdata.UpdatePoints(cdata.Id);

            rsData.Message = "success";
            rsData.Description = "successfully goodies added";
            ohlist.Add(ohdata);
            rsData.Data = ohdata;
            sendOrderMail(orderid);
        }
        catch (Exception ex)
        {

        }

        JavaScriptSerializer js = new JavaScriptSerializer();
        responce = js.Serialize(rsData);

        Context.Response.Clear();
        Context.Response.ContentType = "application/json";
        Context.Response.AddHeader("content-length", responce.Length.ToString());
        Context.Response.Flush();

        Context.Response.Write(responce);

    }


    private void sendOrderMail(int orderid)
    {
        string msg = "";
        double goodiesAmount = 0;
        totalAmountWithoutTax = 0;
        totalTax = 0;
        string adminMsg = "";

        try
        {


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

            DataSet ds = OrderItems(orderid);
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

                }
                else
                {
                    goodiesAmount = 0;
                }


                string ur_goodies = ((int)((totalAmount - goodiesAmount) / grdata.Amount)).ToString();
                string invoice = ohdata1.Id.ToString();
                cdata.Points += int.Parse(ur_goodies);



                string totalbill = ((totalAmount - goodiesAmount - (ohdata1.CouponAmount)) + arData.Extera).ToString();

                ohdata1.PayAmount = double.Parse(totalbill);

                adminMsg = "You have got new order, Order id is " + ohdata1.Id + " And order Amount is Rs. " + totalbill + " And Delivery Slot is "+ohdata1.OrderDate+" "+ ohdata1.OrderTime;
                msg = "Thanks for shopping with us,your order has been placed successfully.Your order no " + ohdata1.Id + " amount of Rs " + totalbill + " will be delivered as per your time slot\nUrban Banya";
                SendMessageData.sendMessage(msg, cdata.Mobile);
                SendMessageData.sendMessage(adminMsg, "9462822505");

                string coupon = ohdata1.CouponAmount + " (" + ohdata1.Coupon + ")";

                MailManager mail = new MailManager();
                mail.SendBillingMail(cdata, invoice, invodate,ohdata1.OrderDate, address, total, arData.Extera.ToString(), goodiesAmount.ToString(),coupon, totalbill, items, ohdata1.PaymentOption, ohdata1.OrderTime, Math.Round(totalAmountWithoutTax, 1).ToString(), Math.Round(totalTax, 1).ToString());
            }
        }
        catch (Exception ex) { }
    }


    public DataSet OrderItems(int orderno)
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


    [WebMethod]
    public string sendReview(string email, string review)
    {
        string responce = "";
        try
        {
            CustomerData cdata = new CustomerData(email);
            ReviewData rdata = new ReviewData();
            rdata.CustomerId = cdata.Id;
            rdata.Review = review;
            rdata.Save();

        }
        catch (Exception ex)
        {

        }
        return responce;
    }
    [WebMethod]
    public string forgetPassword(string email)
    {
        string responce = "";
        try
        {
            CustomerData cdata = new CustomerData(email);
            if (cdata.HasValue)
            {
                responce = "ok";
                MailManager mail = new MailManager();
                mail.SendForgetPassMail(cdata);
            }
            else
            {
                responce = "no";
            }
        }
        catch (Exception ex)
        {

        }
        return responce;
    }
    [WebMethod]
    public void testCall(string email)
    {

        List<ResponseData> rlist = new List<ResponseData>();

        ResponseData rdata = new ResponseData();
        rdata.Message = "testing";

        rlist.Add(rdata);

        JavaScriptSerializer js = new JavaScriptSerializer();
        string str = js.Serialize(rlist);

        Context.Response.Clear();
        Context.Response.ContentType = "application/json";
        Context.Response.AddHeader("content-length", str.Length.ToString());
        Context.Response.Flush();

        Context.Response.Write(str);
        // Context.Response.Write(str);

    }
    [WebMethod]
    public void getProfile(int userid)
    {
        List<CustomerData> clist = new List<CustomerData>();
        ResponseData rsdata = new ResponseData();
        try
        {
            CustomerData cdata = new CustomerData(userid);
            clist.Add(cdata);
            rsdata.Message = "success";
            rsdata.Description = "User Profile";
            rsdata.Data = clist;

        }
        catch (Exception ex) { }
        JavaScriptSerializer js = new JavaScriptSerializer();
        string str = js.Serialize(rsdata);

        Context.Response.Clear();
        Context.Response.ContentType = "application/json";
        Context.Response.AddHeader("content-length", str.Length.ToString());
        Context.Response.Flush();

        Context.Response.Write(str);
    }

    [WebMethod]
    public void checkUserExist(string email)
    {
        string response = "";
        List<CustomerData> clist = new List<CustomerData>();
        ResponseData rsdata = new ResponseData();
        try
        {
            CustomerData cdata = new CustomerData(email);
            if (cdata.HasValue)
            {
                if (cdata.Status == 1)
                {
                    if (cdata.LoginBy == "facebook")
                    {
                        response = "got";
                        clist.Add(cdata);
                        rsdata.Data = clist;

                    }
                    else
                    {
                        response = "website";
                    }
                }
                else
                {
                    response = "block";
                }

            }
            else
            {
                response = "no";
            }

        }
        catch (Exception ex)
        {

        }
        rsdata.Message = response;
        rsdata.Description = "User Profile";

        JavaScriptSerializer js = new JavaScriptSerializer();
        string str = js.Serialize(rsdata);



        Context.Response.Clear();
        Context.Response.ContentType = "application/json";
        Context.Response.AddHeader("content-length", str.Length.ToString());
        Context.Response.Flush();

        Context.Response.Write(str);
    }

    [WebMethod]
    public void deserializeJson(string strjson)
    {
        try
        {
            JavaScriptSerializer ser = new JavaScriptSerializer();
            var wrapper = ser.Deserialize<List<OrderJson>>(strjson);
        }
        catch (Exception ex) { }



    }
    [WebMethod]
    public void sendWelcomeMail(int userid)
    {
        ResponseData rsdata = new ResponseData();
        try
        {
            CustomerData cdata = new CustomerData(userid);

            MailManager mail = new MailManager();
            mail.SendOtpMail(cdata);           
            mail.SendRegisterMail(cdata);
            rsdata.Message = "success";
            rsdata.Description = "User Profile";
            rsdata.Data = cdata;
        }
        catch (Exception ex) { }

        JavaScriptSerializer js = new JavaScriptSerializer();
        string str = js.Serialize(rsdata);

        Context.Response.Clear();
        Context.Response.ContentType = "application/json";
        Context.Response.AddHeader("content-length", str.Length.ToString());
        Context.Response.Flush();

        Context.Response.Write(str);

    }
}
