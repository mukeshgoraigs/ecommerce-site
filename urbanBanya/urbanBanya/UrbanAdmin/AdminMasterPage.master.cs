﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

public partial class AdminMasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //if (!SessionVeriables.IsAdmin && !SessionVeriables.IsLogged)
        //{
        //    Response.Redirect("Default.aspx");
        //}
    }
  
}
