<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script src="js/jssor.slider.js"></script>
    <script src="js/jssor.js"></script>
    <script src="js/carousel.js"></script>
    <script type="text/javascript" src="js/slider.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div id="slider1_container">

        <!-- Slides Container -->
        <div u="slides" id="slides">
            <asp:Repeater ID="rpSlider" runat="server">
                <ItemTemplate>
                    <div>
                        <a href="<%#Eval("link")%>"></a>
                        <img style="width: 100%" src="UrbanAdmin/slider/<%#Eval("imagename") %>" />
                        <div u="thumb"><%#Eval("offer") %></div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>



        </div>

        <!-- ThumbnailNavigator Skin Begin -->
        <div u="thumbnavigator" id="thumbnavigator" class="jssort14">
            <!-- Thumbnail Item Skin Begin -->

            <div u="slides" id="slidemove">
                <div u="prototype" id="prototype" class="p">
                    <div class="w">
                        <div u="thumbnailtemplate" id="thumbnailtemplate" class="c"></div>
                    </div>
                </div>
            </div>
        </div>
        <!-- Thumbnail Item Skin End -->

    </div>


    <div class="productListing " style="margin-top: 15px">



        <a href="HotItems.aspx">
            <h3 class="mysection">Hot Items</h3>
        </a>



        <div class="clearFix jsProductContainer" data-count="212">
            <div id="slider2_container" style="position: relative; top: 0px; left: 0px; width: 1200px; height: 230px; overflow: hidden;">

                <!-- Loading Screen -->
                <div u="loading" style="position: absolute; top: 0px; left: 0px;">
                    <div style="filter: alpha(opacity=70); opacity: 0.7; position: absolute; display: block; background-color: #000; top: 0px; left: 0px; width: 100%; height: 100%;">
                    </div>
                    <div style="position: absolute; display: block; background: url(../img/loading.gif) no-repeat center center; top: 0px; left: 0px; width: 100%; height: 100%;">
                    </div>
                </div>

                <!-- Slides Container -->
                <div u="slides" style="cursor: move; position: absolute; left: 0px; top: 0px; width: 1200px; height: 230px; overflow: hidden;">
                    <asp:Repeater ID="rpHotItem" runat="server">
                        <ItemTemplate>
                            <div>
                                <div class="productData">
                                    <div class="productIn">
                                        <asp:PlaceHolder ID="discountPlaceHolder" runat="server" Visible='<%#Eval("discount").ToString() !="0%"  %>'>
                                            <div class="offer1">

                                                <%#Eval("discount") %> Off
                                                
                                            </div>
                                        </asp:PlaceHolder>
                                        <div class="productImg">
                                            <a class="itemLink" href="DetailsPage.aspx?pid=<%# Eval("id") %>&price=<%# Eval("price") %>&pron=<%# Eval("productName") %>&dis=<%# Eval("discount") %>">
                                                <img style="width: 54%; height: 82%; transform: none" src="UrbanAdmin/product/large/<%#Eval("image")%>" />
                                            </a>
                                        </div>
                                        <div class='itemControl <%#Eval("selected") %>'>



                                            <a class="deleteButton" data-img="<%#Eval("image") %>" data-size="<%# Eval("size") %>" data-id="<%# Eval("id") %>" data-price="<%#Eval("newprice") %>" data-discount="<%# Eval("discount") %>" style="display: inline-block"></a></li>
                                        <input type="text" style="display: inline-block; width: 20px; font-size: 12px" class="itemCount count" name="itemCount" value="<%# Eval("quantity") %>" readonly>
                                            <a class="addButton enabled" data-slock="<%#Eval("stock") %>" data-img="<%#Eval("image") %>" data-size="<%# Eval("size") %>" data-id="<%# Eval("id") %>" data-oldprice="<%#Eval("price") %>" data-price="<%#Eval("newprice") %>" data-discount="<%# Eval("discount") %>">Out of Stock</a>





                                        </div>
                                        <%--<div class='myButton <%#Eval("selected") %>'><a class="addButton enabled" data-slock="<%#Eval("stock") %>" data-img="<%#Eval("image") %>" data-size="<%# Eval("size") %>" data-id="<%# Eval("id") %>" data-oldprice="<%#Eval("price") %>" data-price="<%#Eval("newprice") %>" data-discount="<%# Eval("discount") %>">Out of Stock</a></div>--%>
                                        <div class="productDet">
                                            <p><%#Eval("size") %></p>
                                            <div class="productPrice">
                                                <div class="newPrice"><i class="fa fa-inr"></i><%#Eval("newprice") %></div>
                                                <div class="oldPrice">
                                                    <asp:PlaceHolder ID="PlaceHolder1" runat="server" Visible='<%#Eval("discount").ToString() !="0%"  %>'><i class="fa fa-inr"></i><%#Eval("price") %></asp:PlaceHolder>
                                                </div>

                                            </div>
                                            <div class="productName">
                                                <%#Eval("productName") %>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>

                        </ItemTemplate>
                    </asp:Repeater>




                </div>

                <!-- Bullet Navigator Skin Begin -->

                <!-- bullet navigator container -->
                <div u="navigator" class="jssorb03" style="position: absolute; bottom: 4px; right: 6px;">
                    <!-- bullet navigator item prototype -->
                    <div u="prototype" style="position: absolute; width: 21px; height: 21px; text-align: center; line-height: 21px; color: white; font-size: 12px;">
                        <div u="numbertemplate"></div>
                    </div>
                </div>
                <!-- Bullet Navigator Skin End -->

                <!-- Arrow Navigator Skin Begin -->

                <!-- Arrow Left -->
                <span u="arrowleft" class="jssora03l" style="width: 55px; height: 55px; top: 123px; left: 8px;"></span>
                <!-- Arrow Right -->
                <span u="arrowright" class="jssora03r" style="width: 55px; height: 55px; top: 123px; right: 8px"></span>
                <!-- Arrow Navigator Skin End -->

            </div>




            <div class="clearFix"></div>
        </div>
        <div class="loadingtext js-loadingtext" style="display: none;">Loading…</div>
    </div>


    <div class="productListing " style="margin-top: 15px">



        <h3 class="mysection">New Offers</h3>



        <div class="clearFix jsProductContainer" data-count="212">
            <div id="slider5_container" style="position: relative; top: 0px; left: 0px; width: 1200px; height: 230px; overflow: hidden;">

                <!-- Loading Screen -->
                <div u="loading" style="position: absolute; top: 0px; left: 0px;">
                    <div style="filter: alpha(opacity=70); opacity: 0.7; position: absolute; display: block; background-color: #000; top: 0px; left: 0px; width: 100%; height: 100%;">
                    </div>
                    <div style="position: absolute; display: block; background: url(../img/loading.gif) no-repeat center center; top: 0px; left: 0px; width: 100%; height: 100%;">
                    </div>
                </div>

                <!-- Slides Container -->
                <div u="slides" style="cursor: move; position: absolute; left: 0px; top: 0px; width: 1200px; height: 230px; overflow: hidden;">

                    <asp:Repeater ID="rpNewOffer" runat="server">
                        <ItemTemplate>
                            <div>
                                <div style="width: 100%; height: 200px;">
                                    <a href="<%#Eval("link") %>">
                                        <img style="width: 100%; height: 200px" src="UrbanAdmin/newoffer/<%#Eval("image")%>" alt="<%#Eval("aboutoffer") %>" />
                                    </a>
                                </div>
                            </div>

                        </ItemTemplate>
                    </asp:Repeater>





                </div>

                <!-- Bullet Navigator Skin Begin -->

                <!-- bullet navigator container -->
                <div u="navigator" class="jssorb03" style="position: absolute; bottom: 4px; right: 6px;">
                    <!-- bullet navigator item prototype -->
                    <div u="prototype" style="position: absolute; width: 21px; height: 21px; text-align: center; line-height: 21px; color: white; font-size: 12px;">
                        <div u="numbertemplate"></div>
                    </div>
                </div>
                <!-- Bullet Navigator Skin End -->

                <!-- Arrow Navigator Skin Begin -->

                <!-- Arrow Left -->
                <span u="arrowleft" class="jssora03l" style="width: 55px; height: 55px; top: 123px; left: 8px;"></span>
                <!-- Arrow Right -->
                <span u="arrowright" class="jssora03r" style="width: 55px; height: 55px; top: 123px; right: 8px"></span>
                <!-- Arrow Navigator Skin End -->

            </div>




            <div class="clearFix"></div>
        </div>
        <div class="loadingtext js-loadingtext" style="display: none;">Loading…</div>
    </div>



    <div class="productListing " style="margin-top: 25px">



        <a href="NewItems.aspx">
            <h2 class="mysection">New Items</h2>
        </a>



        <div class="clearFix jsProductContainer" data-count="212">
            <div id="slider3_container" style="position: relative; top: 0px; left: 0px; width: 1200px; height: 230px; overflow: hidden;">

                <!-- Loading Screen -->
                <div u="loading" style="position: absolute; top: 0px; left: 0px;">
                    <div style="filter: alpha(opacity=70); opacity: 0.7; position: absolute; display: block; background-color: #000; top: 0px; left: 0px; width: 100%; height: 100%;">
                    </div>
                    <div style="position: absolute; display: block; background: url(../img/loading.gif) no-repeat center center; top: 0px; left: 0px; width: 100%; height: 100%;">
                    </div>
                </div>

                <!-- Slides Container -->
                <div u="slides" style="cursor: move; position: absolute; left: 0px; top: 0px; width: 1200px; height: 230px; overflow: hidden;">
                    <asp:Repeater ID="rpNewItem" runat="server">
                        <ItemTemplate>
                            <div>
                                <div class="productData">
                                    <div class="productIn">
                                        <asp:PlaceHolder ID="discountPlaceHolder" runat="server" Visible='<%#Eval("discount").ToString() !="0%"  %>'>
                                            <div class="offer1">
                                                <%#Eval("discount") %> Off
                                            </div>
                                        </asp:PlaceHolder>
                                        <div class="productImg">
                                            <a class="itemLink" href="DetailsPage.aspx?pid=<%# Eval("id") %>&price=<%# Eval("price") %>&pron=<%# Eval("productName") %>&dis=<%# Eval("discount") %>">
                                                <img style="width: 54%; height: 82%" src="UrbanAdmin/product/large/<%#Eval("image")%>" />
                                            </a>
                                        </div>
                                        <div class='itemControl <%#Eval("selected") %>'>



                                            <a class="deleteButton" data-img="<%#Eval("image") %>" data-size="<%# Eval("size") %>" data-id="<%# Eval("id") %>" data-price="<%#Eval("newprice") %>" data-discount="<%# Eval("discount") %>" style="display: inline-block"></a></li>
                                        <input type="text" style="display: inline-block; width: 20px; font-size: 12px" class="itemCount count" name="itemCount" value="<%# Eval("quantity") %>" readonly>
                                            <a class="addButton enabled" data-slock="<%#Eval("stock") %>" data-img="<%#Eval("image") %>" data-size="<%# Eval("size") %>" data-id="<%# Eval("id") %>" data-oldprice="<%#Eval("price") %>" data-price="<%#Eval("newprice") %>" data-discount="<%# Eval("discount") %>">Out of Stock</a>





                                        </div>
                                        <%-- <div class='myButton <%#Eval("selected") %>'><a class="addButton enabled" data-slock="<%#Eval("stock") %>" data-img="<%#Eval("image") %>" data-size="<%# Eval("size") %>" data-id="<%# Eval("id") %>" data-oldprice="<%#Eval("price") %>" data-price="<%#Eval("newprice") %>" data-discount="<%# Eval("discount") %>">Out of Stock</a></div>--%>
                                        <div class="productDet">
                                            <p><%#Eval("size") %></p>
                                            <div class="productPrice">
                                                <div class="newPrice"><i class="fa fa-inr"></i><%#Eval("newprice")%></div>
                                                <div class="oldPrice">
                                                    <asp:PlaceHolder ID="PlaceHolder2" runat="server" Visible='<%#Eval("discount").ToString() !="0%"  %>'><i class="fa fa-inr"></i><%#Eval("price") %></asp:PlaceHolder>
                                                </div>

                                            </div>
                                            <div class="productName">
                                                <%#Eval("productName") %>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>



                </div>

                <!-- Bullet Navigator Skin Begin -->

                <!-- bullet navigator container -->
                <div u="navigator" class="jssorb03" style="position: absolute; bottom: 4px; right: 6px;">
                    <!-- bullet navigator item prototype -->
                    <div u="prototype" style="position: absolute; width: 21px; height: 21px; text-align: center; line-height: 21px; color: white; font-size: 12px;">
                        <div u="numbertemplate"></div>
                    </div>
                </div>
                <!-- Bullet Navigator Skin End -->

                <!-- Arrow Navigator Skin Begin -->

                <!-- Arrow Left -->
                <span u="arrowleft" class="jssora03l" style="width: 55px; height: 55px; top: 123px; left: 8px;"></span>
                <!-- Arrow Right -->
                <span u="arrowright" class="jssora03r" style="width: 55px; height: 55px; top: 123px; right: 8px"></span>
                <!-- Arrow Navigator Skin End -->

            </div>




            <div class="clearFix"></div>
        </div>
        <div class="loadingtext js-loadingtext" style="display: none;">Loading…</div>
    </div>
    <div class="productListing " style="margin-top: 25px">



        <a href="UrbanBargains.aspx">
            <h3 class="mysection">Urban Bargains</h3>
        </a>



        <div class="clearFix jsProductContainer" data-count="212">
            <div id="slider4_container" style="position: relative; top: 0px; left: 0px; width: 1200px; height: 230px; overflow: hidden;">

                <!-- Loading Screen -->
                <div u="loading" style="position: absolute; top: 0px; left: 0px;">
                    <div style="filter: alpha(opacity=70); opacity: 0.7; position: absolute; display: block; background-color: #000; top: 0px; left: 0px; width: 100%; height: 100%;">
                    </div>
                    <div style="position: absolute; display: block; background: url(../img/loading.gif) no-repeat center center; top: 0px; left: 0px; width: 100%; height: 100%;">
                    </div>
                </div>

                <!-- Slides Container -->
                <div u="slides" style="cursor: move; position: absolute; left: 0px; top: 0px; width: 1200px; height: 230px; overflow: hidden;">
                    <asp:Repeater ID="rpBargains" runat="server">
                        <ItemTemplate>
                            <div>
                                <div class="productData">
                                    <div class="productIn">
                                        <asp:PlaceHolder ID="discountPlaceHolder" runat="server" Visible='<%#Eval("discount").ToString() !="0%"  %>'>
                                            <div class="offer1">
                                                <%#Eval("discount") %> Off
                                            </div>
                                        </asp:PlaceHolder>
                                        <div class="productImg">
                                            <a class="itemLink" href="DetailsPage.aspx?pid=<%# Eval("id") %>&price=<%# Eval("price") %>&pron=<%# Eval("productName") %>&dis=<%# Eval("discount") %>">
                                                <img style="width: 54%; height: 82%" src="UrbanAdmin/product/large/<%#Eval("image")%>" />
                                            </a>
                                        </div>
                                        <div class='itemControl <%#Eval("selected") %>'>



                                            <a class="deleteButton" data-img="<%#Eval("image") %>" data-size="<%# Eval("size") %>" data-id="<%# Eval("id") %>" data-price="<%#Eval("newprice") %>" data-discount="<%# Eval("discount") %>" style="display: inline-block"></a></li>
                                        <input type="text" style="display: inline-block; width: 20px; font-size: 12px" class="itemCount count" name="itemCount" value="<%# Eval("quantity") %>" readonly>
                                            <a class="addButton enabled" data-slock="<%#Eval("stock") %>" data-img="<%#Eval("image") %>" data-size="<%# Eval("size") %>" data-id="<%# Eval("id") %>" data-oldprice="<%#Eval("price") %>" data-price="<%#Eval("newprice") %>" data-discount="<%# Eval("discount") %>">Out of Stock</a>





                                        </div>
                                        <%-- <div class='myButton <%#Eval("selected") %>'><a class="addButton enabled" data-slock="<%#Eval("stock") %>" data-img="<%#Eval("image") %>" data-size="<%# Eval("size") %>" data-id="<%# Eval("id") %>" data-oldprice="<%#Eval("price") %>" data-price="<%#Eval("newprice") %>" data-discount="<%# Eval("discount") %>">Out of Stock</a></div>--%>
                                        <div class="productDet">
                                            <p><%#Eval("size") %></p>
                                            <div class="productPrice">
                                                <div class="newPrice"><i class="fa fa-inr"></i><%#Eval("newprice") %></div>
                                                <div class="oldPrice">
                                                    <asp:PlaceHolder ID="PlaceHolder3" runat="server" Visible='<%#Eval("discount").ToString() !="0%"  %>'><i class="fa fa-inr"></i><%#Eval("price") %></asp:PlaceHolder>
                                                </div>

                                            </div>
                                            <div class="productName">
                                                <%#Eval("productName") %>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>

                </div>

                <!-- Bullet Navigator Skin Begin -->

                <!-- bullet navigator container -->
                <div u="navigator" class="jssorb03" style="position: absolute; bottom: 4px; right: 6px;">
                    <!-- bullet navigator item prototype -->
                    <div u="prototype" style="position: absolute; width: 21px; height: 21px; text-align: center; line-height: 21px; color: white; font-size: 12px;">
                        <div u="numbertemplate"></div>
                    </div>
                </div>
                <!-- Bullet Navigator Skin End -->

                <!-- Arrow Navigator Skin Begin -->

                <!-- Arrow Left -->
                <span u="arrowleft" class="jssora03l" style="width: 55px; height: 55px; top: 123px; left: 8px;"></span>
                <!-- Arrow Right -->
                <span u="arrowright" class="jssora03r" style="width: 55px; height: 55px; top: 123px; right: 8px"></span>
                <!-- Arrow Navigator Skin End -->

            </div>




            <div class="clearFix"></div>
        </div>
        <div class="loadingtext js-loadingtext" style="display: none;">Loading…</div>
    </div>
</asp:Content>

