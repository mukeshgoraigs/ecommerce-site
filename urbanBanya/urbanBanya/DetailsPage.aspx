<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="DetailsPage.aspx.cs" Inherits="DetailsPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script src="js/jssor.slider.js"></script>
    <script src="js/jssor.js"></script>  
    <script src="js/carousel.js"></script>
    <script type="text/javascript" src="js/slider.js"></script>
     <script type="text/javascript" src="js/detailspd.js"></script>
     <script>
    function mychange(event, object) {

        var id = $("#psize").val();

            $.ajax({
                type: "POST",
                url: 'WebService.asmx/getSizeData',
                data: "{id:'" + id + "'}",
                contentType: "application/json",
                datatype: "json",
                async: "true",
                success: function (response) {
                    $("#<%=lblOldPrice.ClientID %>").text(response.d.Price);
                    $("#<%=lblProductPrice.ClientID %>").text(response.d.NewPrice);
                    $(".myAdd").attr("data-img", response.d.Image);
                    $(".myAdd").attr("data-size", response.d.Size);
                    $(".myAdd").attr("data-oldprice", response.d.Price);
                    $(".myAdd").attr("data-price", response.d.NewPrice);
                    $(".myAdd").attr("data-discount", response.d.Discount);
                },
                error: function (response) {
                    alert(response.status);
                }
            });
    }

    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
      
     <div class="detailsContainer">
                    <div class="leftDetails">
                        <div class="productNames">
                            <p><asp:Label ID="lblProductNameTop" runat="server"/></p>
                        </div>
                        <div class="productImage">
                            <a id="mylink" class="workspace" runat="server">
                               
                               <img runat="server" id="productImg" style="width: 300px;" />

                            </a>
                        </div>
                        <div class="productAtri">
                            <p style="color: #aed44d; font-size: 20px"><strong>
                                 Size : <select id="psize" onchange="mychange(event,this);">       
                                     <option value="0">--Select Size--</option>                              
                                     <asp:Repeater ID="rpSize" runat="server">
                                         <ItemTemplate>
                                              <option value="<%#Eval("id") %>"><%#Eval("vsize") %></option>
                                         </ItemTemplate>
                                     </asp:Repeater>
                                   
                                    </select>

                                                                       </strong></p>
                            <br />
                            <p class="proPrice"><strong>Offer Price : <asp:Label ID="lblProductPrice" runat="server"/>/-</strong></p>
                            <br />
                            <asp:Panel ID="pnlOldPrice" runat="server"><p style="text-decoration: line-through">MRP Price : <asp:Label ID="lblOldPrice" runat="server"/>/-</p></asp:Panel>
                            <p style="text-decoration: line-through"><a  class="myAdd enabled">Out of Stock</a></p>
                        </div>
                    
                    </div>
                    <div class="productRight">
                        <table class="detailTable" >
                            <tr>
                                <th style="font-weight: bold; color: #000000;padding-top:15px">Brand</th>
                                <td style="padding-top:15px"><asp:Label ID="lblProductName" runat="server"></asp:Label></td>
                            </tr>
                            <tr>
                                <th style="font-weight: bold; color: #000000">About Product</th>
                                <td>
                                    <p style="text-align: justify"><asp:Label ID="lblProductDescription" runat="server"></asp:Label></p>
                                </td>
                            </tr>
                        </table>
                       
                    </div>
                </div>
    <div class="productListing " style="margin-top:15px">

    
    
        <p class="mysection">Similar Product</p>



    <div class="clearFix jsProductContainer" data-count="212">
     <div id="slider2_container" style="position: relative; top: 0px; left: 0px; width: 1200px; height: 230px; overflow: hidden;">

        <!-- Loading Screen -->
        <div u="loading" style="position: absolute; top: 0px; left: 0px;">
            <div style="filter: alpha(opacity=70); opacity:0.7; position: absolute; display: block;
                background-color: #000; top: 0px; left: 0px;width: 100%;height:100%;">
            </div>
            <div style="position: absolute; display: block; background: url(../img/loading.gif) no-repeat center center;
                top: 0px; left: 0px;width: 100%;height:100%;">
            </div>
        </div>

        <!-- Slides Container -->
        <div u="slides" style="cursor: move; position: absolute; left: 0px; top: 0px; width: 1200px; height: 230px; overflow: hidden;">
            
                 <asp:Repeater ID="rpSimilar" runat="server">
                        <ItemTemplate>
                            <div>
                                <div class="productData">
                                    <div class="productIn">
                                        <asp:PlaceHolder ID="discountPlaceHolder" runat="server" Visible='<%#Eval("discount").ToString() !="0"  %>'>
                                         <div class="offer1">
                                    <%#Eval("discount") %> Off
                                </div>
                                            </asp:PlaceHolder>
                                        <div class="productImg">
                                            <a class="itemLink" href="DetailsPage.aspx?pid=<%# Eval("id") %>&price=<%# Eval("price") %>&pron=<%# Eval("productName") %>&dis=<%# Eval("discount") %>">
                                                <img style="width: 54%; height: 82%" src="UrbanAdmin/product/large/<%#Eval("image")%>" />
                                            </a>
                                        </div>
                                        <div class="myButton"><a class="addButton enabled" data-img="<%#Eval("image") %>" data-size="<%# Eval("size") %>" data-id="<%# Eval("id") %>" data-oldprice="<%#Eval("price") %>" data-price="<%#Eval("newprice") %>" data-discount="<%# Eval("discount") %>">Out of Stock</a></div>
                                        <div class="productDet">
                                             <p><%#Eval("size") %></p>
                                            <div class="productPrice">
                                                <div class="newPrice"><i class="fa fa-inr"></i>  <%#Eval("newprice") %></div>
                                                <div class="oldPrice"><asp:PlaceHolder ID="PlaceHolder1" runat="server" Visible='<%#Eval("discount").ToString() !="0%"  %>'><i class="fa fa-inr"></i> <%#Eval("price") %></asp:PlaceHolder></div>

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
           
               
             
            </div>
        </div>
        
        <!-- Bullet Navigator Skin Begin -->
      
        <!-- bullet navigator container -->
        <div u="navigator" class="jssorb03" style="position: absolute; bottom: 4px; right: 6px;">
            <!-- bullet navigator item prototype -->
            <div u="prototype" style="position: absolute; width: 21px; height: 21px; text-align:center; line-height:21px; color:white; font-size:12px;"><div u="numbertemplate"></div></div>
        </div>
        <!-- Bullet Navigator Skin End -->
        
        <!-- Arrow Navigator Skin Begin -->
       
        <!-- Arrow Left -->
        <span u="arrowleft" class="jssora03l" style="width: 55px; height: 55px; top: 123px; left: 8px;">
        </span>
        <!-- Arrow Right -->
        <span u="arrowright" class="jssora03r" style="width: 55px; height: 55px; top: 123px; right: 8px">
        </span>
        <!-- Arrow Navigator Skin End -->
        
    </div> 
        
        
        
   
        <div class="clearFix"></div>
    </div>
    <div class="loadingtext js-loadingtext" style="display: none;">Loading…</div>
</div>	
    <asp:Literal ID="lblScript" runat="server"></asp:Literal>
</asp:Content>

