<%@ Page Title="" Language="C#" MasterPageFile="~/ShippingMasterPage.master" AutoEventWireup="true" CodeFile="ShippingAddress.aspx.cs" Inherits="ShippingAddress" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
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
                    setExtera(response.d.Area);

                },
                error: function (response) {
                    alert(response.status);
                }
            });
        }
        function setExtera(area) {
            $.ajax({
                type: "POST",
                url: 'WebService.asmx/getExtera',
                data: "{area:'" + area + "'}",
                contentType: "application/json",
                datatype: "json",
                async: "true",
                success: function (response) {
                    $("#<%=lblDeliveryCharge.ClientID %>").text(response.d.Extera);

                    var total = parseFloat($("#<%=lblTotalAmount.ClientID %>").text());
                    var extra = parseFloat($("#<%=lblDeliveryCharge.ClientID %>").text());
                    $("#<%=lblTotalPayAmount.ClientID %>").text(total + extra);
                },
                error: function (response) {
                    alert(response.status);
                }
            });
        }
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="urbanAnother">

        <a class="abtnclose">X</a>
        <img style="float: left" width="150px" height="40px" src="img/logo.png" /><br />



        <asp:DropDownList ID="ecmbCity" CssClass="texbox" runat="server">
            <asp:ListItem>Jaipur</asp:ListItem>
        </asp:DropDownList>
        <br />

        <input type="text" class="texbox" id="earea" placeholder="Your Area" /><br />
        <input type="text" class="texbox" id="eaddress1" placeholder="Address Line 1" /><br />

        <input type="text" class="texbox" id="eaddress2" placeholder="Address Line 2" /><br />

        <input type="text" class="texbox" id="elandmark" placeholder="Landmark" /><br />
        <br />

        <a class="btnSubmitAn">Submit</a><br />
        <br />
    </div>



    <div class="urbanFast">

        <a class="fbtnclose abtnclose">X</a>

        <div class="productRight">
            <br />
            <br />
            <label>Delivery Instruction</label>
            <textarea id="txtInstruction" placeholder="Write Your Delivery Instrucyions and Delivery Timing "></textarea><br />
            <a class="btnGoToSlot">
                <img src="img/order.png" /></a><br />
            <br />
        </div>
        <div class="leftDetails">
            <label>Terms n conditions urban banya</label>
            <textarea id="txtConditions" placeholder="Write Your Delivery Instrucyions and Delivery Timing " readonly>Pricing:-

Products which are listed on Urbanbanya.com will be sold at MRP unless otherwise specified. The 

prices mentioned at the time applicable prices at the time of placing an order. Although prices of most of 

the products do not fluctuate on a daily basis but some of the commodities and fresh food do change on 

a daily basis which would be updated almost immediately on the portal.

Cancellation Policy:-

As a customer you can cancel the order anytime before  the cut-off time of the slot for which you 

have placed an order by calling our customer care number. In such a case we will refund any 

payments already made by you for the order in form of goodies. If we suspect any fraudulent 

transaction by any customer or any transaction which defies the terms & conditions of using the 

website, we at our sole discretion could cancel such orders. We will maintain a negative list of all 

fraudulent transactions and customers and would deny access to them or cancel any orders placed 

by them.

Returns & Refunds:-

We have a "no questions asked return and refund policy" which entitles all our members to return 

the product at the time of delivery if due to some reason they are not satisfied with the quality or 

freshness of the product. We will take the returned product back with us and issue a credit note 

for the value of the return products which will be credited to your Urbanbanya Account . This can 

be used to pay your subsequent shopping bills.</textarea><br />
            <table style="width: 70%">
                <tr>
                    <td>I agree with Trems and Conditions </td>
                    <td>
                        <input style="width: 15px; height: 15px" type="checkbox" id="terms" /></td>
                </tr>
            </table>
        </div>




    </div>

    <div class="shippingContainer">
        <div class="leftDetails">
            <div class="shippingAddress">

                <b>
                    <label>Choose Your Shipping Address</label></b><br />
                <br />
                <select id="dlAddress" onchange="mychange(event,this);">
                    <asp:Repeater ID="rpAddress" runat="server">
                        <ItemTemplate>
                            <option value="<%#Eval("id") %>"><%#Eval("area") %></option>
                        </ItemTemplate>
                    </asp:Repeater>


                </select><a class="btnNewAddress"> Add Another Address</a><br />
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
                <div class="row clearFix">
                    <label class=""></label>
                    <div class="promotionCoupon">
                        <label>Payment Option</label>
                        <select class="urbanPayment">
                            <option value="no">---Payment Option---</option>
                            <option value="COD">Cash On Delivery</option>
                            <option value="Online">Pay Online</option>
                        </select>
                        <div class="third">
                        </div>
                        <div class="third">
                        </div>
                      
                    </div>
                </div>

            </div>
        </div>
        <div class="productRight">

            <table class="detailTable">
                <tr>
                    <th style="font-weight: bold; color: #000000">Total Items</th>
                    <td>
                        <p style="text-align: justify">
                            <asp:Label ID="lblTotalItems" runat="server"></asp:Label>
                        </p>
                    </td>
                </tr>
                <tr>
                    <th style="font-weight: bold; color: #000000">Total Amount</th>
                    <td>
                        <p style="text-align: justify">
                            <asp:Label ID="lblTotalAmount" runat="server"></asp:Label>
                        </p>
                    </td>
                </tr>
                <tr>
                    <th style="font-weight: bold; color: #000000">Total Saving</th>
                    <td>
                        <p style="text-align: justify">
                            <asp:Label ID="lblTotalDiscount" runat="server"></asp:Label>
                        </p>
                    </td>
                </tr>
                <tr>
                    <th style="font-weight: bold; color: #000000">Delivery Charge</th>
                    <td>
                        <p style="text-align: justify">
                            <asp:Label ID="lblDeliveryCharge" runat="server" Text="00.00"></asp:Label>
                        </p>
                    </td>
                </tr>
                <tr>
                    <th style="font-weight: bold; color: #000000">Pay Amount</th>
                    <td>
                        <p style="text-align: justify">
                            <asp:Label ID="lblTotalPayAmount" runat="server"></asp:Label>
                        </p>
                    </td>
                </tr>
                <tr style="background-color: #E8E5E5; color: #000000">
                    <th style="font-weight: bold;">

                        <input type="search" class="fullWidth textbox txtcoupon" placeholder="Add Coupon Code" id="coupon-input" autocomplete="off" />

                    </th>
                    <td>
                        <p style="text-align: justify">

                            <a href="#" style="width:180px" class="bigButton active btnApplyCoupon" id="coupon-btn">Apply Coupon</a>

                        </p>
                    </td>
                </tr>
                <tr style="background-color: #E8E5E5; color: #000000">
                    <th colspan="2" style="font-weight: bold;">
                          <label style="color: orange; font-weight: bolder; display: none" class="validCoupon"></label>
                        <label style="color: red; font-weight: bolder; display: none" class="invalidCoupon">Invalid Coupon</label>
                        </th>
                    </tr>
                <tr style="background-color: #E8E5E5; color: #ffffff">                    
                    <td>
                       
                            <input class="fullWidth textbox" type="search" id="goodies" placeholder="Redeem Goodies" />
                     
                    </td>
                    <th style="font-weight: bold;">
                        <a href="#" style="margin-left: -18px;" class="bigButton active btnRedeemGoodies" id="redeem-btn">  Redeem Now  </a>
                    </th>
                </tr>
                 <tr style="background-color: #E8E5E5; color: #000000">
                    <th colspan="2" style="font-weight: bold;">
                          <label style="color: orange; font-weight: bolder; display: none" class="validRedeem"></label>
                        <label style="color: red; font-weight: bolder; display: none" class="invalidRedeem">Invalid Coupon</label>
                        </th>
                    </tr>
                <tr>
                    <td>
                        <a href="UrbanCart.aspx">
                            <img src="img/cart.png" /></a>
                    </td>
                    <td>
                        <a class="btnPlaceOrder">
                            <img src="img/order.png" /></a>
                    </td>
                </tr>
            </table>

        </div>
    </div>
    <div class="shippingContainer">

        <div style="width: 40%" class="leftDetails">
        </div>

    </div>
    <div id="moveMeHere"></div>
    <div class="shippingContainer">
        <asp:UpdatePanel ID="updatePanels" runat="server">
            <ContentTemplate>
                <table class="slots_table" width="100%" border="2" bordercolor="#EBEBE9" style="border-collapse: collapse; background-color: #EFEFEF; color: #000000" cellspacing="0" cellpadding="6">
                    <tbody>
                        <tr align="center" class="header">
                            <td height="20px" style="vertical-align: middle" class="col1">Day/Date</td>
                            <td colspan="6" class="tslot_header">
                                <table border="0" width="100%">
                                    <tbody>
                                        <tr>
                                            <td width="346px" height="20px" style="text-align: center">
                                                <h3>Time Slots</h3>
                                            </td>
                                            <td width="131" style="text-align: right">
                                                <asp:Button BackColor="#4cb649" ForeColor="#ffffff" ID="nextweek" CssClass="delprod" runat="server" Text="Next Week" OnClick="nextweek_Click" /><asp:Button BackColor="#4cb649" ForeColor="#ffffff" ID="btnPrevious" CssClass="delprod" runat="server" Visible="false" Text="Previous Week" OnClick="btnPrevious_Click" /></td>
                                        </tr>
                                    </tbody>
                                </table>
                            </td>
                        </tr>
                        <asp:Repeater ID="rpSlot" runat="server">
                            <ItemTemplate>
                                <tr class="evenRow" style="color: #847A7A">
                                    <td class="col1">
                                        <%#Eval("date") %>					</td>
                                    <td width="15%" class="normaltd">
                                        <asp:PlaceHolder ID="ntvalidslot" runat="server" Visible='<%#(Eval("slot1").ToString().Trim()!="" && Eval ("s1").ToString().Trim() == "1")%>'>
                                            <label style="text-decoration: line-through; color: red; cursor: not-allowed" class="label">
                                                <input id="Radio7" type="radio" disabled="disabled" class="btnradio" rel="<%#Eval("date") %>" name="radio" value="<%#Eval("slot1") %>">
                                                <%#Eval("slot1") %>
                                            </label>
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

                                        </asp:PlaceHolder>
                                        <asp:PlaceHolder ID="slotis" runat="server" Visible='<%#(Eval("slot1").ToString().Trim()!="" && Eval ("s1").ToString().Trim() != "1") %>'>
                                            <label class="label">
                                                <input id="slot" type="radio" class="btnradio" rel="<%#Eval("date") %>" name="radio" value="<%#Eval("slot1") %>">
                                                <%#Eval("slot1") %>
                                            </label>
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

                                        </asp:PlaceHolder>
                                        <asp:PlaceHolder ID="noslot" runat="server" Visible='<%#Eval("slot1").ToString().Trim()==""  %>'>
                                            <label class="label">
                                                <input id="Radio2" type="radio" disabled="disabled" class="btnradio" rel="<%#Eval("date") %>" name="radio" value="<%#Eval("slot1") %>">
                                                No Slot</label>
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

                                        </asp:PlaceHolder>
                                    </td>
                                    <td width="15%" class="normaltd">

                                        <asp:PlaceHolder ID="PlaceHolder11" runat="server" Visible='<%#(Eval("slot2").ToString().Trim()!="" && Eval ("s2").ToString().Trim() == "1")%>'>
                                            <label style="text-decoration: line-through; color: red; cursor: not-allowed" class="label">
                                                <input id="Radio8" type="radio" disabled="disabled" class="btnradio" rel="<%#Eval("date") %>" name="radio" value="<%#Eval("slot2") %>">
                                                <%#Eval("slot2") %>
                                            </label>
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

                                        </asp:PlaceHolder>



                                        <asp:PlaceHolder ID="PlaceHolder1" runat="server" Visible='<%#(Eval("slot2").ToString().Trim()!="" && Eval ("s2").ToString().Trim() != "1")%>'>
                                            <label class="label">
                                                <input id="stot" type="radio" class="btnradio" rel="<%#Eval("date") %>" name="radio" value="<%#Eval("slot2") %>">
                                                <%#Eval("slot2") %>
                                            </label>

                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                        </asp:PlaceHolder>
                                        <asp:PlaceHolder ID="PlaceHolder2" runat="server" Visible='<%#Eval("slot2").ToString().Trim()==""  %>'>
                                            <label class="label">
                                                <input id="Radio1" type="radio" disabled="disabled" class="btnradio" rel="<%#Eval("date") %>" name="radio" value="<%#Eval("slot2") %>">
                                                No Slot</label>
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

                                        </asp:PlaceHolder>
                                    </td>
                                    <td width="15%" class="normaltd">

                                        <asp:PlaceHolder ID="PlaceHolder12" runat="server" Visible='<%#(Eval("slot3").ToString().Trim()!="" && Eval ("s3").ToString().Trim() == "1")%>'>
                                            <label style="text-decoration: line-through; color: red; cursor: not-allowed" class="label">
                                                <input id="Radio9" type="radio" disabled="disabled" class="btnradio" rel="<%#Eval("date") %>" name="radio" value="<%#Eval("slot3") %>">
                                                <%#Eval("slot3") %>
                                            </label>
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

                                        </asp:PlaceHolder>


                                        <asp:PlaceHolder ID="PlaceHolder3" runat="server" Visible='<%#(Eval("slot3").ToString().Trim()!="" && Eval ("s3").ToString().Trim() != "1")%>'>
                                            <label class="label">
                                                <input id="Radio3" type="radio" class="btnradio" rel="<%#Eval("date") %>" name="radio" value="<%#Eval("slot3") %>">
                                                <%#Eval("slot3") %>
                                            </label>
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                        </asp:PlaceHolder>
                                        <asp:PlaceHolder ID="PlaceHolder4" runat="server" Visible='<%#Eval("slot3").ToString().Trim()==""  %>'>
                                            <label class="label">
                                                <input id="Radio4" type="radio" disabled="disabled" class="btnradio" rel="<%#Eval("date") %>" name="radio" value="<%#Eval("slot3") %>">
                                                No Slot</label>
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

                                        </asp:PlaceHolder>

                                    </td>
                                    <td width="15%" class="normaltd">

                                        <asp:PlaceHolder ID="PlaceHolder13" runat="server" Visible='<%#(Eval("slot4").ToString().Trim()!="" && Eval ("s4").ToString().Trim() == "1")%>'>
                                            <label style="text-decoration: line-through; color: red; cursor: not-allowed" class="label">
                                                <input id="Radio10" type="radio" disabled="disabled" class="btnradio" rel="<%#Eval("date") %>" name="radio" value="<%#Eval("slot4") %>">
                                                <%#Eval("slot4") %>
                                            </label>
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

                                        </asp:PlaceHolder>



                                        <asp:PlaceHolder ID="PlaceHolder5" runat="server" Visible='<%#(Eval("slot4").ToString().Trim()!="" && Eval ("s4").ToString().Trim() != "1")%>'>
                                            <label class="label">
                                                <input id="Radio5" type="radio" class="btnradio" rel="<%#Eval("date") %>" name="radio" value="<%#Eval("slot4") %>">
                                                <%#Eval("slot4") %>
                                            </label>
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                        </asp:PlaceHolder>
                                        <asp:PlaceHolder ID="PlaceHolder6" runat="server" Visible='<%#Eval("slot4").ToString().Trim()==""  %>'>
                                            <label class="label">
                                                <input id="Radio6" type="radio" disabled="disabled" class="btnradio" rel="<%#Eval("date") %>" name="radio" value="<%#Eval("slot4") %>">
                                                No Slot</label>
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

                                        </asp:PlaceHolder>
                                    </td>
                                    <td width="15%" class="normaltd">

                                        <asp:PlaceHolder ID="PlaceHolder14" runat="server" Visible='<%#(Eval("slot5").ToString().Trim()!="" && Eval ("s5").ToString().Trim() == "1")%>'>
                                            <label style="text-decoration: line-through; color: red; cursor: not-allowed" class="label">
                                                <input id="Radio11" type="radio" disabled="disabled" class="btnradio" rel="<%#Eval("date") %>" name="radio" value="<%#Eval("slot5") %>">
                                                <%#Eval("slot5") %>
                                            </label>
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

                                        </asp:PlaceHolder>


                                        <asp:PlaceHolder ID="PlaceHolder7" runat="server" Visible='<%#(Eval("slot5").ToString().Trim()!="" && Eval ("s5").ToString().Trim() != "1")%>'>
                                            <label class="label">
                                                <input id="Radio12" type="radio" class="btnradio" rel="<%#Eval("date") %>" name="radio" value="<%#Eval("slot5") %>">
                                                <%#Eval("slot5") %>
                                            </label>
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                        </asp:PlaceHolder>
                                        <asp:PlaceHolder ID="PlaceHolder8" runat="server" Visible='<%#Eval("slot5").ToString().Trim()==""  %>'>
                                            <label class="label">
                                                <input id="Radio13" type="radio" disabled="disabled" class="btnradio" rel="<%#Eval("date") %>" name="radio" value="<%#Eval("slot5") %>">
                                                No Slot</label>
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

                                        </asp:PlaceHolder>
                                    </td>
                                    <td width="15%" class="normaltd">

                                        <asp:PlaceHolder ID="PlaceHolder15" runat="server" Visible='<%#(Eval("slot6").ToString().Trim()!="" && Eval ("s6").ToString().Trim() == "1")%>'>
                                            <label style="text-decoration: line-through; color: red; cursor: not-allowed" class="label">
                                                <input id="Radio14" type="radio" disabled="disabled" class="btnradio" rel="<%#Eval("date") %>" name="radio" value="<%#Eval("slot6") %>">
                                                <%#Eval("slot6") %>
                                            </label>
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

                                        </asp:PlaceHolder>

                                        <asp:PlaceHolder ID="PlaceHolder9" runat="server" Visible='<%#(Eval("slot6").ToString().Trim()!="" && Eval ("s6").ToString().Trim() != "1")%>'>
                                            <label class="label">
                                                <input id="Radio15" type="radio" class="btnradio" rel="<%#Eval("date") %>" name="radio" value="<%#Eval("slot6") %>">
                                                <%#Eval("slot6") %>
                                            </label>
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                        </asp:PlaceHolder>
                                        <asp:PlaceHolder ID="PlaceHolder10" runat="server" Visible='<%#Eval("slot6").ToString().Trim()==""  %>'>
                                            <label class="label">
                                                <input id="Radio16" type="radio" disabled="disabled" class="btnradio" rel="<%#Eval("date") %>" name="radio" value="<%#Eval("slot6") %>">
                                                No Slot</label>
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

                                        </asp:PlaceHolder>
                                    </td>
                                </tr>
                            </ItemTemplate>

                        </asp:Repeater>



                        <!-- NEW DELIVERY MODE -->
                    </tbody>
                </table>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="nextweek" EventName="Click" />
                <asp:AsyncPostBackTrigger ControlID="btnPrevious" EventName="Click" />
            </Triggers>
        </asp:UpdatePanel>





    </div>

</asp:Content>

