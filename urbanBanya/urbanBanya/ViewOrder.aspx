<%@ Page Title="" Language="C#" MasterPageFile="~/ShippingMasterPage.master" AutoEventWireup="true" CodeFile="ViewOrder.aspx.cs" Inherits="ViewOrder" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <div class="detailsContainer">
                    <div class="leftDetails">
                    
                       <div class="box">
                               <b>
                    <label>Shipping Address  <a href="MyAccount.aspx" class="btn">My Account</a></label></b><br /> <br /><hr />
                <br />
               
                <br />
                <div class="rightBox">
                    <div class="header">Shipping Address</div>
                    <hr />
                    <div class="content">
                        <table>
                            <tr>
                                <th>Address :</th>
                                <td><span class="street">
                                    <asp:Label ID="lblAddress1" runat="server" Text=""></asp:Label>,&nbsp;</span><span class="building"><asp:Label ID="lblAddress2" runat="server" Text=""></asp:Label></span></td>
                            </tr>
                            <tr>
                                <th>Area:</th>
                                <td><span class="area">
                                    <asp:Label ID="lblArea" runat="server" Text=""></asp:Label></span></td>
                            </tr>
                            <tr>
                                <th>Pin :</th>
                                <td><span class="pin">
                                    <asp:Label ID="lblPincode" runat="server" Text=""></asp:Label></span></td>
                            </tr>
                            <tr>
                                <th>Landmark</th>
                                <td><span class="landmark">
                                    <asp:Label ID="lblLandmark" runat="server" Text=""></asp:Label></span></td>
                            </tr>
                            <tr>
                                <th>City</th>
                                <td><span class="city">
                                    <asp:Label ID="lblCity" runat="server" Text=""></asp:Label></span></td>
                            </tr>
                        </table>

                    </div>
                </div>

                        </div><br />
                        
                        <div class="row">
                            <br />
                            <br />
                        <div class="form-group">
                                    <a class="btnCancelOrder btn">Cancel Order</a>
                                </div>
                        </div>
                    </div>
                    <div class="productRight">
                        

                       
                        <div class="box">
                            <h2><label> Orders No. : <asp:Label ID="lblOrderNo" runat="server"></asp:Label></label></h2><hr />
                           <table id="example" class="table table-striped table-bordered " cellspacing="0" width="100%">
                                                <thead>
                                                    <tr>
                                                        <th>Product</th>
                                                        <th>Image</th>
                                                        <th>Price</th>
                                                        <th>Quantity</th>
                                                        <th>Net Price</th>
                                                        
                                                    </tr>
                                                </thead>

                                                <tfoot>
                                                    <tr class="btn-success">
                                                         <th colspan="4" style="text-align:right">Total Amount </th>
                                                       
                                                        <th><asp:Label ID="lblTotalAmount" runat="server"></asp:Label></th>
                                                    </tr>
                                                </tfoot>

                                                <tbody>

                                                    <asp:Repeater ID="rpMyOrder" runat="server">
                                                        <ItemTemplate>
                                                            <tr>
                                                                <td><%#Eval("productName") %></td>
                                                        <td><img width="40px" height="40px" src="UrbanAdmin/product/small/<%#Eval("image") %>" /></td>
                                                        <td><%#Eval("newprice") %></td>
                                                        <td><%#Eval("quantity") %></td>
                                                        <td><%#Eval("totalamount") %></td>
                                                            </tr>
                                                        </ItemTemplate>
                                                    </asp:Repeater>


                                                    

                                                </tbody>
                                            </table>
                        </div>
                       
                    </div>
                </div>
      <asp:Literal ID="lblScript" runat="server"></asp:Literal>
</asp:Content>

