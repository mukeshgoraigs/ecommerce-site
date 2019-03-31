<%@ Page Title="" Language="C#" MasterPageFile="~/ShippingMasterPage.master" AutoEventWireup="true" CodeFile="UrbanCart.aspx.cs" Inherits="UrbanCart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
        <div class="detailsContainer">
             <div id="test1">
                <div id="test2">
                    <div class="leftDetails" style="overflow-y: auto;max-height:420px;">
                        
                       <table style="background-color:#EFEFEF;">
                           <tr style="background-color:green;color:#ffffff"><th>Product</th><th>Size</th><th>Image</th><th>Price</th><th>Quantity</th><th>Total</th><td>Delete</td></tr>
                           <asp:Repeater ID="rpCartFull" runat="server">
                               <ItemTemplate>
                                    <tr>
                               <td><%#Eval("productName") %></td>
                                         <td><%#Eval("size") %></td>
                               <td><img width="35px" height="35px" src="UrbanAdmin/product/small/<%#Eval("image") %>" /></td>
                               <td><%#Eval("newprice") %></td>
                               <td style="width:150px;padding:0px"><a href="#" class="cdeleteButton data-img="<%#Eval("image") %>" data-size="<%# Eval("size") %>" data-id="<%# Eval("id") %>" data-price="<%#Eval("newprice") %>" data-discount="<%# Eval("discount") %>" enabled" style="display:inline-block">-</a><input type="text" style="width:30px"  value="<%#Eval("quantity") %>" readonly /><a data-img="<%#Eval("image") %>" data-size="<%# Eval("size") %>" data-id="<%# Eval("id") %>" data-price="<%#Eval("newprice") %>" data-discount="<%# Eval("discount") %>" href="#" class="caddButton">+</a></td>
                               <td><%#Convert.ToInt32(Eval("newprice"))*Convert.ToInt32(Eval("quantity")) %></td>
                                        <td><a class="del" data-id="<%#Eval("productid") %>" data-size="<%#Eval("size") %>" href="#">X</a></td>
                           </tr>
                               </ItemTemplate>
                           </asp:Repeater>
                          
                       </table> 
                    </div>
                     
       
                    <div class="productRight">
                        <table class="detailTable">
                            <tr>
                                <th style="font-weight: bold; color: #000000">Total Items</th>
                                <td><p style="text-align: justify"><asp:Label ID="lblTotalItems" runat="server"></asp:Label></p></td>
                            </tr>
                            <tr>
                                <th style="font-weight: bold; color: #000000">Total Saving</th>
                                <td>
                                    <p style="text-align: justify"><asp:Label ID="lblTotalDiscount" runat="server"></asp:Label></p>
                                </td>
                            </tr>
                            <tr>
                                <th style="font-weight: bold; color: #000000">Pay Amount</th>
                                <td>
                                    <p style="text-align: justify"><asp:Label ID="lblTotalAmount" runat="server"></asp:Label></p>
                                </td>
                                </tr>
                            <tr>
                                <td>
                                    <a href="Default.aspx">
                                        <img src="img/shopping.png" /></a>
                                </td>
                                 <td>
                                    <a href="CustomerDetails.aspx">
                                        <img src="img/checkout.png" /></a>
                                </td>
                            </tr>
                        </table>
                       
                    </div>
                    </div>
                        </div>
                </div>
</asp:Content>

