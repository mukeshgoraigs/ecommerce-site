<%@ Page Title="" Language="C#" MasterPageFile="~/ShippingMasterPage.master" AutoEventWireup="true" CodeFile="MyAccount.aspx.cs" Inherits="MyAccount" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
      <script type="text/javascript">
          function mychange(event, object) {

              var id = $("#dlAddress").val();

              $.ajax({
                  type: "POST",
                  url: 'WebService.asmx/getAddress',
                  data: "{id:'" + id + "'}",
                  contentType: "application/json",
                  datatype: "json",
                  async: "true",
                  success: function (response) {
                      $("#<%=lblstreet.ClientID %>").text(response.d.Address1);
                    $("#<%=lblBuilding.ClientID %>").text(response.d.Address2);
                    $("#<%=lblFlatNo.ClientID %>").text(response.d.FlatNo);
                    $("#<%=lblArea.ClientID %>").text(response.d.Area);
                    $("#<%=lblPin.ClientID %>").text(response.d.Pincode);
                    $("#<%=lblLandMark.ClientID %>").text(response.d.Landmark);
                    $("#<%=lblCity.ClientID %>").text(response.d.City);
                   

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
                    <div style="width:35%" class="leftDetails">
                     <ul><%--<li><a class="btn btnProfile">Profile</a></li>--%><li><a class="btn btnMyAddress">Address</a></li><li><a class="btn btnGoodies">Goodies</a></li><li><a class="btn btnOrders">Track Order</a></li></ul>
                        <br /> <br /> <br />

                        <table style="width:65%;">
                            <tr >
                                <th> Name</th><th style="text-align:left;"><asp:Label ID="lblName" runat="server" Text="Aman"></asp:Label></th>
                            </tr>
                             <tr>
                                <th> Contact</th><th style="text-align:left"><asp:Label ID="lblMobile" runat="server" Text="Aman"></asp:Label></td>
                            </tr>
                             <tr>
                                <th> Email </th><th style="text-align:left"><asp:Label ID="lblEmail" runat="server" Text="Aman"></asp:Label></td>
                            </tr>
                        </table>
                        <br />
                        <a href="UrbanCart.aspx" class="btn">My Shopping Cart</a>
                    </div>
                    <div style="width:60%" class="productRight">
                        <div class="addressBox box">
                               <b>
                    <label>Shipping Address</label></b><hr />
                <br />
                <select id="dlAddress" onchange="mychange(event,this);">
                    <asp:Repeater ID="rpAddress" runat="server">
                        <ItemTemplate>
                            <option value="<%#Eval("id") %>"><%#Eval("area") %></option>
                        </ItemTemplate>
                    </asp:Repeater>


                </select><br />
                <br />
                <div class="rightBox">
                    <div class="header">Shipping Address</div>
                    <hr />
                    <div class="content">
                        <table>
                            <tr>
                                <th>Address :</th>
                                <td><span class="street">
                                    <asp:Label ID="lblstreet" runat="server" Text=""></asp:Label>,&nbsp;</span><span class="building"><asp:Label ID="lblBuilding" runat="server" Text=""></asp:Label>,&nbsp;</span><span class="Flat"><asp:Label ID="lblFlatNo" runat="server" Text=""></asp:Label></span></td>
                            </tr>
                            <tr>
                                <th>Area:</th>
                                <td><span class="area">
                                    <asp:Label ID="lblArea" runat="server" Text=""></asp:Label></span></td>
                            </tr>
                            <tr>
                                <th>Pin :</th>
                                <td><span class="pin">
                                    <asp:Label ID="lblPin" runat="server" Text=""></asp:Label></span></td>
                            </tr>
                            <tr>
                                <th>Landmark</th>
                                <td><span class="landmark">
                                    <asp:Label ID="lblLandMark" runat="server" Text=""></asp:Label></span></td>
                            </tr>
                            <tr>
                                <th>City</th>
                                <td><span class="city">
                                    <asp:Label ID="lblCity" runat="server" Text=""></asp:Label></span></td>
                            </tr>
                        </table>

                    </div>
                </div>

                        </div>

                        <div class="goodiesbox box">
                           <h1><label> Hi <asp:Label ID="lblAcName" runat="server"></asp:Label></label></h1><hr />
                              <h2>Your Goodies Amount : <asp:Label ID="lblGoodies" runat="server"></asp:Label> </h2>

                        </div>
                        <div class="orderBox box">
                            <h2><label>Your Orders</label></h2><hr />
                           <table id="example" class="table table-striped table-bordered "  cellspacing="0" width="100%">
                                                <thead>
                                                    <tr>
                                                        <th>Order no.</th>
                                                        <th>Total Amount</th>
                                                        <th>Placed Date</th>
                                                        <th>Order Date</th>
                                                        <th>Order Time</th>
                                                        <th>Status</th>
                                                        <th>View Order</th>
                                                    </tr>
                                                </thead>


                                                <tbody>

                                                    <asp:Repeater ID="rpMyOrder" runat="server">
                                                        <ItemTemplate>
                                                            <tr>
                                                                <td style="padding-top:10px"><asp:Label ID="lblid" runat="server" Text='<%#Eval("id") %>'></asp:Label> </td>
                                                                <td style="padding-top:10px"><%#Eval("ordertotal") %></td>
                                                                <td style="padding-top:10px"><%#Eval("placedate").ToString().Replace("12:00:00 AM","") %></td>
                                                                <td style="padding-top:10px"><%#Eval("orderdate") %></td>
                                                                <td style="padding-top:10px"><%#Eval("ordertime") %></td>
                                                                <td style="padding-top:10px">
                                                                    <%#Eval("status") %>                                                                  
                                                                </td>
                                                                <td style="padding-top:10px"><a href="ViewOrder.aspx?orderid=<%#Eval("id") %>&adid=<%#Eval("address") %>" class="mybtn">View</a></td>
                                                            </tr>
                                                        </ItemTemplate>
                                                    </asp:Repeater>




                                                </tbody>
                                            </table>
                        </div>
                       
                    </div>
                </div>
</asp:Content>

