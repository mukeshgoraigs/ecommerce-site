using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ShippingAddress : System.Web.UI.Page
{
    static int day, month, year, cityzone;
    static DateTime now;
    static int totalItems;
    static double totalAmount;
    static double totaldiscount;
    protected void Page_Load(object sender, EventArgs e)
    {
        CustomerData cdata = new CustomerData(SessionVeriables.SessionEmail);
      
        AddressData adata = new AddressData(cdata.Id);

        if (adata.HasValue)
        {
            lblstreet.Text = adata.Address1;
            lblBuilding.Text = adata.Address2;
            lblFlatNo.Text = adata.FlatNo;
            lblArea.Text = adata.Area;
            lblPin.Text = adata.Pincode;
            lblLandMark.Text = adata.Landmark;
            lblCity.Text = adata.City;
            AreaData ardata = new AreaData(adata.Area);
          lblDeliveryCharge.Text = ardata.Extera.ToString();

        }
       
        fillAddress(cdata.Id);
        fillCartItems();

        now = DateTime.Now;
        now = now.AddHours(12);
        now = now.AddMinutes(31);
        day = now.Day;
        // month = now.ToString("MMM");
        month = now.Month;
        year = now.Year;

        String days = now.DayOfWeek.ToString();
        cityzone = 1;
       
        if (!IsPostBack)
        {
            //lblTest.Text = day + " " + month + " " + days + " " + now.Hour+" "+now.Minute;
            fillSlot(day, month, year, days, cityzone, now, true);
        }


    }
    private void fillAddress(int cid)
    {
        AddressData adata = new AddressData();
        DataSet ds = adata.getAddress("select * from address where customerid=" + cid);
        rpAddress.DataSource = ds;

        rpAddress.DataBind();
    }
    public void fillCartItems()
    {
        MyCartData cdata = new MyCartData();
        DataSet ds = cdata.getCart("select product.id,product.productName,product.discount,product.size,product.image,cartdata.id as cid,cartdata.productid,cartdata.price,cartdata.newprice,cartdata.quantity,cartdata.sessionid,cartdata.userid from product inner join cartdata on product.id=cartdata.productid where sessionid='" + SessionVeriables.SessionID + "'");
        lblTotalItems.Text = ds.Tables[0].Rows.Count.ToString();
        if (ds.Tables[0].Rows.Count > 0)
        {

            calculateTotal(ds);
        }
        else
        {
            //lblTotalItems.Text = "No item In Cart";
        }

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
        lblTotalAmount.Text = totalAmount.ToString();

        lblTotalItems.Text = totalItems.ToString();
        lblTotalDiscount.Text = totaldiscount.ToString();
        lblTotalPayAmount.Text = (totalAmount + double.Parse(lblDeliveryCharge.Text.ToString())).ToString();
    }


    private void fillSlot(int day1, int month1, int year1, string days1, int cityzone, DateTime now, bool from)
    {
        string s1 = "0", s2 = "0", s3 = "0", s4 = "0", s5 = "0", s6 = "0";

        if (now.Hour >= 6 && now.Hour <= 9 && from)
        {
            s1 = "1"; s2 = "0"; s3 = "0"; s4 = "0"; s5 = "0"; s6 = "0";

        }
        if (now.Hour >= 9 && now.Hour <= 12 && from)
        {
            s1 = "1"; s2 = "1"; s3 = "0"; s4 = "0"; s5 = "0"; s6 = "0";
        }
        if (now.Hour >= 12 && now.Hour <= 15 && from)
        {
            s1 = "1"; s2 = "1"; s3 = "1"; s4 = "0"; s5 = "0"; s6 = "0";
        }
        if (now.Hour >= 15 && now.Hour <= 18 && from)
        {
            s1 = "1"; s2 = "1"; s3 = "1"; s4 = "1"; s5 = "0"; s6 = "0";
        }
        if (now.Hour >= 18 && now.Hour <= 21 && from)
        {
            s1 = "1"; s2 = "1"; s3 = "1"; s4 = "1"; s5 = "1"; s6 = "0";
        }
        if (now.Hour >= 21 && now.Hour <= 22 && from)
        {
            s1 = "1"; s2 = "1"; s3 = "1"; s4 = "1"; s5 = "1"; s6 = "1";
        }
        if (now.Hour >= 22 && from)
        {
            s1 = "1"; s2 = "1"; s3 = "1"; s4 = "1"; s5 = "1"; s6 = "1";
        }

        SlotData sdata = new SlotData();
        DataSet ds = sdata.getSlots("select * from slot where cityzone=" + cityzone);
        string slot1 = ds.Tables[0].Rows[0]["slot1"].ToString();
        string slot2 = ds.Tables[0].Rows[0]["slot2"].ToString();
        string slot3 = ds.Tables[0].Rows[0]["slot3"].ToString();
        string slot4 = ds.Tables[0].Rows[0]["slot4"].ToString();
        string slot5 = ds.Tables[0].Rows[0]["slot5"].ToString();
        string slot6 = ds.Tables[0].Rows[0]["slot6"].ToString();

        if (int.Parse(ds.Tables[0].Rows[0]["status1"].ToString()) == 0)
        {
            s1 = "1";
        }
        if (int.Parse(ds.Tables[0].Rows[0]["status2"].ToString()) == 0)
        {
            s2 = "1";
        }
        if (int.Parse(ds.Tables[0].Rows[0]["status3"].ToString()) == 0)
        {
            s3 = "1";
        }
        if (int.Parse(ds.Tables[0].Rows[0]["status4"].ToString()) == 0)
        {
            s4 = "1";
        }
        if (int.Parse(ds.Tables[0].Rows[0]["status5"].ToString()) == 0)
        {
            s5 = "1";
        }
        if (int.Parse(ds.Tables[0].Rows[0]["status6"].ToString()) == 0)
        {
            s6 = "1";
        }




        DataTable dt = new DataTable();
        dt.Columns.AddRange(new DataColumn[13] { new DataColumn("date", typeof(string)),
                            new DataColumn("slot1", typeof(string)),
                            new DataColumn("slot2",typeof(string)), 
                            new DataColumn("slot3",typeof(string)),
                            new DataColumn("slot4",typeof(string)),
                            new DataColumn("slot5",typeof(string)),
                            new DataColumn("slot6",typeof(string)),
                            new DataColumn("s1", typeof(string)),
                            new DataColumn("s2",typeof(string)), 
                            new DataColumn("s3",typeof(string)),
                            new DataColumn("s4",typeof(string)),
                            new DataColumn("s5",typeof(string)),
                            new DataColumn("s6",typeof(string))
        });


        for (int i = 1; i <= 7; i++)
        {
           
            string mydate = "";
            if (month1 == 1 || month1 == 3 || month1 == 5 || month1 == 7 || month1 == 8 || month1 == 10 || month1 == 12)
            {
                if (day1 <= 31)
                {
                    mydate = day1.ToString() + "-" + month1.ToString() + "-" + year1.ToString();
                }
                else if (day1 > 31 && month1 == 12)
                {
                    day1 = 1;
                    month1 = 1;
                    year1 += 1;
                    mydate = day1.ToString() + "-" + month1.ToString() + "-" + year1.ToString();
                }
                else
                {
                    day1 = 1;
                    month1 += 1;
                    mydate = day1.ToString() + "-" + month1.ToString() + "-" + year1.ToString();
                }
            }
            if (month1 == 4 || month1 == 6 || month1 == 9 || month1 == 11)
            {
                if (day1 <= 30)
                {
                    mydate = day1.ToString() + "-" + month1.ToString() + "-" + year1.ToString();
                }

                else
                {
                    day1 = 1;
                    month1 += 1;
                    mydate = day1.ToString() + "-" + month1.ToString() + "-" + year1.ToString();
                }
            }
            if (month1 == 2 && year1 % 4 == 0)
            {
                if (day1 <= 29)
                {
                    mydate = day1.ToString() + "-" + month1.ToString() + "-" + year1.ToString();
                }

                else
                {
                    day1 = 1;
                    month1 += 1;
                    mydate = day1.ToString() + "-" + month1.ToString() + "-" + year1.ToString();
                }
            }
            if (month1 == 2)
            {
                if (day1 <= 28)
                {
                    mydate = day1.ToString() + "-" + month1.ToString() + "-" + year1.ToString();
                }

                else
                {
                    day1 = 1;
                    month1 += 1;
                    mydate = day1.ToString() + "-" + month1.ToString() + "-" + year1.ToString();
                }
            }

            DateTime dateValue = new DateTime(year1, month1, day1);
            string today = dateValue.ToString("ddd");
            if (i == 1)
            {
                dt.Rows.Add(today + "-" + mydate, slot1, slot2, slot3, slot4, slot5, slot6, s1, s2, s3, s4, s5, s6);
            }
            else
            {
                s1 = "0"; s2 = "0"; s3 = "0"; s4 = "0"; s5 = "0"; s6 = "0";

                if (int.Parse(ds.Tables[0].Rows[0]["status1"].ToString()) == 0)
                {
                    s1 = "1";
                }
                if (int.Parse(ds.Tables[0].Rows[0]["status2"].ToString()) == 0)
                {
                    s2 = "1";
                }
                if (int.Parse(ds.Tables[0].Rows[0]["status3"].ToString()) == 0)
                {
                    s3 = "1";
                }
                if (int.Parse(ds.Tables[0].Rows[0]["status4"].ToString()) == 0)
                {
                    s4 = "1";
                }
                if (int.Parse(ds.Tables[0].Rows[0]["status5"].ToString()) == 0)
                {
                    s5 = "1";
                }
                if (int.Parse(ds.Tables[0].Rows[0]["status6"].ToString()) == 0)
                {
                    s6 = "1";
                }


                dt.Rows.Add(today + "-" + mydate, slot1, slot2, slot3, slot4, slot5, slot6, s1, s2, s3, s4, s5, s6);
            }
            day1 += 1;
        }



        rpSlot.DataSource = dt;
        rpSlot.DataBind();

    }
    protected void nextweek_Click(object sender, EventArgs e)
    {
        nextweek.Visible = false;
        btnPrevious.Visible = true;
        DateTime now = DateTime.Now;
        now = now.AddHours(12);
        now = now.AddMinutes(31);
        day = now.Day + 7;
        // month = now.ToString("MMM");
        month = now.Month;
        year = now.Year;
        String days = now.DayOfWeek.ToString();
        fillSlot(day, month, year, days, cityzone, now, false);
    }
    protected void btnPrevious_Click(object sender, EventArgs e)
    {
        btnPrevious.Visible = false;
        nextweek.Visible = true;
        DateTime now = DateTime.Now;
        now = now.AddHours(12);
        now = now.AddMinutes(31);
        day = now.Day;
        // month = now.ToString("MMM");
        month = now.Month;
        year = now.Year;
        String days = now.DayOfWeek.ToString();
        fillSlot(day, month, year, days, cityzone, now, true);
    }
}