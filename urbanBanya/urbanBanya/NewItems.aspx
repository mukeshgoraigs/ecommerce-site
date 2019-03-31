<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="NewItems.aspx.cs" Inherits="NewItems" %>

   <%@ Import Namespace="System.Data" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <div class="productListing " style="margin-top:0px">

                 

                    <h2>Products in <asp:Label ID="lblSubCatName" Text="New Items" runat="server"></asp:Label></h2>
                    <div class="clearFix jsProductContainer" data-count="212">

                        <asp:Repeater ID="rpNewItems" runat="server">
                            <ItemTemplate>
                                <div class="product jsProduct " data-display="grid" data-stock="30" data-item-id="3692" data-var-id="10025456" data-item-name="Nivea Cool Kick For Men Deodorant">
                            <div class="product-inner">
                                <asp:PlaceHolder ID="discountPlaceHolder" runat="server" Visible='<%#Eval("discount").ToString() !="0%"  %>'>
                                <div class="offer">
                                    <%#Eval("discount") %> Off
                                </div>
                                    </asp:PlaceHolder>
                                <a class="itemLink" href="DetailsPage.aspx?pid=<%# Eval("id") %>&price=<%# Eval("price") %>&pron=<%# Eval("productName") %>&dis=<%# Eval("discount") %>">
                                    <div class="itemImage">
                                        <img class="js-item-image" src="UrbanAdmin/product/medium/<%#Eval("image") %>" alt="<%#Eval("productName") %>">
                                    </div>
                                </a>
                                <div class='itemControl <%#Eval("selected") %>'>
                                    
                                    
                                 
                                        <a class="deleteButton" data-img="<%#Eval("image") %>" data-size="<%# Eval("size") %>" data-id="<%# Eval("id") %>" data-price="<%#Eval("newprice") %>" data-discount="<%# Eval("discount") %>" style="display:inline-block" ></a></li>
                                        <input type="text" style="display:inline-block;width:20px;font-size:12px"  class="itemCount count" name="itemCount" value="<%# Eval("quantity") %>" readonly>
                                         <a class="addButton enabled" data-slock="<%#Eval("stock") %>" data-img="<%#Eval("image") %>" data-size="<%# Eval("size") %>" data-id="<%# Eval("id") %>" data-oldprice="<%#Eval("price") %>" data-price="<%#Eval("newprice") %>" data-discount="<%# Eval("discount") %>">Out of Stock</a>
                                 
                                
                                       
                                 
                                  
                                </div>
                               
                                <div class="itemDescription">
                                    <h4><strong style="float: right" class="price js-effective-mrp"><i class="fa fa-inr"></i> <%#Eval("newprice") %></strong>
                                        <del style="float: left" class="js-actual-mrp" style="display: block;"><asp:PlaceHolder ID="PlaceHolder1" runat="server" Visible='<%#Eval("discount").ToString() !="0%"  %>'><i class="fa fa-inr"></i> <%#Eval("price") %></asp:PlaceHolder></del>
                                        <br>
                                        <a href="#"><%#Eval("productName") %><span class="item-quantity"><%#Eval("size") %></span></a></h4>
                                   
                                </div>
                               
                            </div>
                        </div>
                            </ItemTemplate>
                        </asp:Repeater>




                        
                        
                     
                        <div class="clearFix"></div>
                    </div>
                    <div class="loadingtext js-loadingtext" style="display: none;">Loading…</div>
                </div>
</asp:Content>

