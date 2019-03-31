<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Product.aspx.cs" Inherits="Product" %>
<%@Import Namespace="System.Data"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <div class="productListing " style="margin-top:0px">

                  <%--  <div class="switchModule nomobile">
                        <ul>
                            <li class="switch-grid selected" data-size="s">
                                <img src="//sn.zopnow.com/css/images/small.png" alt="Show Smaller Images" width="22" height="22" id="switch_small"></li>
                            <li class="switch-grid " data-size="l">
                                <img src="//sn.zopnow.com/css/images/large.png" alt="Show Large Images" width="22" height="22" id="switch_large"></li>
                            <div class="clearFix"></div>
                        </ul>
                    </div>--%>
                    <!-- this is used to switch the view -->

                    <!--<div class="filterModule" >
        <ul>
            <li class="selected">Sort by: Your Buying Pattern</li>
            <li>Lowest Price First</li>
            <li>Popularity</li>
            <li>Newest First</li>
        </ul>
    </div>-->
                    <!--this is the filter by dropdown-->

                   <%-- <div class="filterModule brands">
                        <ul>
                            <li class="selected">Brand: </li>
                            <!--<li><a href="#">Reset</a></li>
                <li><input type="checkbox" /> All Brands</li>-->
                            <li><a href="/deodorant/green-label-b.php">Jovan</a></li>
                            <li><a href="/deodorant/lux-b.php">Lux</a></li>
                            <li><a href="/deodorant/cinthol-b.php">Cinthol</a></li>
                            <li><a href="/deodorant/dove-b.php">Dove</a></li>
                            <li><a href="/deodorant/santoor-b.php">Santoor</a></li>
                            <li><a href="/deodorant/gillette-b.php">Gillette</a></li>
                            <li><a href="/deodorant/axe-b.php">Axe</a></li>
                            <li><a href="/deodorant/park-avenue-b.php">Park Avenue</a></li>
                            <li><a href="/deodorant/adidas-b.php">Adidas</a></li>
                            <li><a href="/deodorant/spinz-b.php">Spinz</a></li>
                            <li><a href="/deodorant/secret-temptation-b.php">Secret Temptation</a></li>
                            <li><a href="/deodorant/garnier-b.php">Garnier</a></li>
                            <li><a href="/deodorant/old-spice-b.php">Old Spice</a></li>
                            <li><a href="/deodorant/himalaya-b.php">Himalaya</a></li>
                            <li><a href="/deodorant/nivea-b.php">Nivea</a></li>
                            <li><a href="/deodorant/kama-sutra-b.php">Kama Sutra</a></li>
                            <li><a href="/deodorant/yardley-b.php">Yardley</a></li>
                            <li><a href="/deodorant/set-wet-b.php">Set Wet</a></li>
                            <li><a href="/deodorant/fa-b.php">Fa</a></li>
                            <li><a href="/deodorant/playboy-b.php">Playboy</a></li>
                            <li><a href="/deodorant/brut-b.php">Brut</a></li>
                            <li><a href="/deodorant/wild-stone-b.php">Wild Stone</a></li>
                            <li><a href="/deodorant/zatak-b.php">Zatak</a></li>
                            <li><a href="/deodorant/aramusk-b.php">Aramusk</a></li>
                            <li><a href="/deodorant/jovan-b.php">Jovan</a></li>
                            <li><a href="/deodorant/suremen-b.php">Sure</a></li>
                            <li><a href="/deodorant/fogg-b.php">Fogg</a></li>
                            <li><a href="/deodorant/eva-b.php">Eva</a></li>
                            <li><a href="/deodorant/gatsby-b.php">Gatsby</a></li>
                            <li><a href="/deodorant/provogue-b.php">Provogue</a></li>
                            <li><a href="/deodorant/barbie-b.php">Barbie</a></li>
                            <li><a href="/deodorant/engage-b.php">Engage</a></li>
                            <li><a href="/deodorant/jungle-b.php">Jungle</a></li>
                            <li><a href="/deodorant/police-b.php">Police</a></li>
                            <li><a href="/deodorant/one-man-show-b.php">One Man Show</a></li>
                            <li><a href="/deodorant/nike-b.php">Nike</a></li>
                            <li><a href="/deodorant/lotto-b.php">Lotto</a></li>
                            <li><a href="/deodorant/pino-b.php">Pino</a></li>
                            <li><a href="/deodorant/carlos-moya-b.php">Carlos Moya</a></li>
                            <li><a href="/deodorant/conino-lamborghini-b.php">Conino Lamborghini</a></li>
                            <li><a href="/deodorant/cavallini-b.php">Cavallini</a></li>
                        </ul>
                    </div>--%>
                    <!-- this is the filter by dropdown -->

                    <h2>Products in <asp:Label ID="lblSubCatName" runat="server"></asp:Label></h2>
                    <div class="clearFix jsProductContainer" data-count="212">

                        <asp:Repeater ID="rpProductMain" runat="server">
                            <ItemTemplate>
                                <div class="hilight">
                                <div id="productadded" class='product jsProduct' data-display="grid" data-stock="30" data-item-id="3692" data-var-id="10025456" data-item-name="Nivea Cool Kick For Men Deodorant">
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
                                        <a href="#"><%#Eval("productName") %>  <span class="item-quantity"><%#Eval("size") %></span></a></h4>
                                   <asp:PlaceHolder ID="PlaceHolder2" runat="server" Visible='<%#Eval("variants").ToString() !="0"  %>'> 
                                       <p class="greyText">See <%#Eval("variants") %> other variants</p>
                                       </asp:PlaceHolder>
                                </div>
                                <div class="itemVariants">
                                    <ul>
                                         <asp:Repeater ID="rpChCategory" DataSource='<%# ((DataRowView)Container.DataItem).Row.GetChildRows("prorelation") %>' runat="server">
                                                <ItemTemplate>
                                        <li class="js-variant " data-id="<%# DataBinder.Eval(Container.DataItem, "[\"id\"]")%>" data-name="<%# DataBinder.Eval(Container.DataItem, "[\"vsize\"]")%>" data-link="#" data-mrp="<%# DataBinder.Eval(Container.DataItem, "[\"vprice\"]")%>" data-image="UrbanAdmin/product/medium/<%# DataBinder.Eval(Container.DataItem, "[\"vimage\"]")%>"  data-stock="<%# DataBinder.Eval(Container.DataItem, "[\"vquantity\"]")%>" data-discount="<%# DataBinder.Eval(Container.DataItem, "[\"vdiscount\"]")%>" data-sticker=""><a data-img="<%# DataBinder.Eval(Container.DataItem, "[\"vimage\"]")%>" data-id="<%# DataBinder.Eval(Container.DataItem, "[\"productid\"]")%>" data-size="<%# DataBinder.Eval(Container.DataItem, "[\"vsize\"]")%>" data-oldprice="<%# DataBinder.Eval(Container.DataItem, "[\"vprice\"]")%>" data-price="<%# DataBinder.Eval(Container.DataItem, "[\"vnewprice\"]")%>" class="addButton enabled"></a><a><strong class="price">₹ <%# DataBinder.Eval(Container.DataItem, "[\"vnewprice\"]")%></strong> / <span class="item-quantity"><%# DataBinder.Eval(Container.DataItem, "[\"vsize\"]")%></span></a></li>
                                                   
                                                    </ItemTemplate>
                                             </asp:Repeater>
                                       </ul>
                                </div>
                            </div>
                        </div>
                                    </div>
                            </ItemTemplate>
                        </asp:Repeater>




                        
                        
                     
                        <div class="clearFix"></div>
                    </div>
                   
                </div>
</asp:Content>

