<%@ Page Title="" Language="C#" MasterPageFile="~/ShippingMasterPage.master" AutoEventWireup="true" CodeFile="CustomerDetails.aspx.cs" Inherits="CustomerDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
     
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="detailsContainer">
        <div class="leftDetails">
            <div class="shippingAddress">

                <label>Email Address </label>
                <br />
                <asp:TextBox Enabled="false" class="texbox" runat="server" ID="email" placeholder="Email Id" required /><br />              
                <label>Mobile Number</label><br />
                <asp:TextBox class="texbox" runat="server" ID="mobile" placeholder="Mobile Number" required /><br />
                <label>City</label><br />
                <asp:DropDownList ID="cmbCity" CssClass="texbox" runat="server">
                    <asp:ListItem>Jaipur</asp:ListItem>
                </asp:DropDownList>
                <br />
                 <label>Area</label><br />
                <input type="text" class="texbox" id="area" placeholder="Your Area" required /><br />
                 <%--<label>Pin Code</label><br />
                <input type="text" class="texbox" id="pincode" placeholder="Your Pincode" /><br />--%>
                 <label>Address Line 1</label><br />
                <input type="text" class="texbox" id="address1" placeholder="Address Line 1" required /><br />
                 <label>Address Line 2</label><br />
                <input type="text" class="texbox" id="address2" placeholder="Address Line 2" /><br />
               
                 <label>Landmark</label><br />
                <input type="text" class="texbox" id="landmark" placeholder="Landmark" required /><br />
               

            </div>
        </div>
        <div class="productRight">
            
            <table class="detailTable">
                <tr>
                    <th style="font-weight: bold; color: #000000">Total Items</th>
                    <td>
                        <p style="text-align: justify">
                            <asp:Label ID="lblTotalItems" runat="server"></asp:Label></p>
                    </td>
                </tr>
                <tr>
                    <th style="font-weight: bold; color: #000000">Total Saving</th>
                    <td>
                        <p style="text-align: justify">
                            <asp:Label ID="lblTotalDiscount" runat="server"></asp:Label></p>
                    </td>
                </tr>
                <tr>
                    <th style="font-weight: bold; color: #000000">Pay Amount</th>
                    <td>
                        <p style="text-align: justify">
                            <asp:Label ID="lblTotalAmount" runat="server"></asp:Label></p>
                    </td>
                </tr>
                <tr>
                    <td>
                        <a href="UrbanCart.aspx">
                            <img src="img/shopping.png" /></a>
                    </td>
                    <td>
                        <a class="btnAddress">
                            <img src="img/address.png" /></a>
                    </td>
                </tr>
            </table>

        </div>
    </div>
    
</asp:Content>

