﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class HotItems : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            fillHotitem();
        }
    }
    private void fillHotitem()
    {

        ProductData cdata = new ProductData();
        DataSet ds = cdata.getProduct("select product.id,product.productName,product.description,product.code,product.price,product.newprice,product.discount,product.size,product.quantity as stock,product.image,product.prodtype,hotitem.id as hotid,hotitem.position,cartdata.quantity,discountproduct.amount,cartdata.selected from product inner join hotitem on product.id=hotitem.productid and product.status=1 and hotitem.section=3 left join discountproduct on product.id=discountproduct.productid left join cartdata on product.id=cartdata.productid and cartdata.sessionid='" + SessionVeriables.SessionID + "' order by hotitem.position ASC");
        if (ds.Tables[0].Rows.Count > 0)
        {
            rpHotItems.DataSource = ds;
            rpHotItems.DataBind();

        }


    }
}