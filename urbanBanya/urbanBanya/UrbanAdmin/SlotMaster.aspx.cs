using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UrbanAdmin_SlotMaster : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            loadWest();
            loadEast();
        }

    }
    protected void btnUpload_Click(object sender, EventArgs e)
    {
        UpdateWest();
        UpdateEast();
    }
    public void UpdateWest()
    {
        SlotData sdata = new SlotData();
        sdata.Slot1 = txtwestslot1.Text;
        sdata.Slot2 = txtwestslot2.Text;
        sdata.Slot3 = txtwestslot3.Text;
        sdata.Slot4 = txtwestslot4.Text;
        sdata.Slot5 = txtwestslot5.Text;
        sdata.Slot6 = txtwestslot6.Text;
        sdata.Update(1);

    }
    public void UpdateEast()
    {
        SlotData sdata = new SlotData();
        sdata.Slot1 = txteastslot1.Text;
        sdata.Slot2 = txteastslot2.Text;
        sdata.Slot3 = txteastslot3.Text;
        sdata.Slot4 = txteastslot4.Text;
        sdata.Slot5 = txteastslot5.Text;
        sdata.Slot6 = txteastslot6.Text;
        sdata.Update(2);

    }
    public void loadWest()
    {
        SlotData sdata = new SlotData(1);
        txtwestslot1.Text = sdata.Slot1;
        txtwestslot2.Text = sdata.Slot2;
        txtwestslot3.Text = sdata.Slot3;
        txtwestslot4.Text = sdata.Slot4;
        txtwestslot5.Text = sdata.Slot5;
        txtwestslot6.Text = sdata.Slot6;

    }
    public void loadEast()
    {
        SlotData sdata = new SlotData(2);
        txteastslot1.Text = sdata.Slot1;
        txteastslot2.Text = sdata.Slot2;
        txteastslot3.Text = sdata.Slot3;
        txteastslot4.Text = sdata.Slot4;
        txteastslot5.Text = sdata.Slot5;
        txteastslot6.Text = sdata.Slot6;
    }
}