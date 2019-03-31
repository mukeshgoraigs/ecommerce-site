using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MyAccount : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            setProfile();
        }
    }

    private void setProfile()
    {
        CustomerData cdata = new CustomerData(SessionVeriables.SessionEmail);
        lblName.Text = cdata.FirstName;
        lblMobile.Text = cdata.Mobile;
        lblEmail.Text = cdata.Email;
        lblGoodies.Text = cdata.Points.ToString();
        lblAcName.Text = cdata.FirstName;
        fillAddress(cdata.Id);

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
            

        }
        fillOrders(cdata.Id);
    }
    private void fillAddress(int cid)
    {
        AddressData adata = new AddressData();
        DataSet ds = adata.getAddress("select * from address where customerid=" + cid);
        rpAddress.DataSource = ds;

        rpAddress.DataBind();
    }
    private void fillOrders(int id)
    {
        OrderHeaderData ohdata = new OrderHeaderData();
        DataSet ds = ohdata.getOrderHeader("select id,userid,address,ordertotal,placedate,orderdate,ordertime,status from orderheader where isconfirm=1 and userid=" + id + " order by id desc LIMIT 10");
        rpMyOrder.DataSource = ds;
        rpMyOrder.DataBind();

       
    }

}