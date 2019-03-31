<%@ Page Title="" Language="C#" MasterPageFile="~/UrbanAdmin/AdminMasterPage.master" AutoEventWireup="true" CodeFile="OrderDetails.aspx.cs" Inherits="UrbanAdmin_OrderDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    <div class="container">
        <div class="row">
            <div class="col-md-12 col-sm-12">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <h3>Order Details</h3>
                    </div>
                    <div class="panel-body">
                        <div class="row">
                            <div class="col-md-5">
                                <div class="notice-board">
                                    <div class="panel panel-default">
                                        <div class="panel-heading">
                                            Shipping Address
                              
                                        </div>
                                        <div class="panel-body">
                                            <table style="width:98%" class="table-bordered table-hover table-condensed table-responsive">
                                                <tr>
                                                    <td>Name </td><td><asp:Label ID="lblName" runat="server"></asp:Label></td>
                                                </tr>
                                                <tr>
                                                    <td> Contact </td><td>  <asp:Label ID="lblMobile" runat="server"></asp:Label></td>
                                                </tr>
                                                <tr>
                                                    <td> Address  </td><td> <asp:Label ID="lblAddress1" runat="server"></asp:Label></td>
                                                </tr>
                                                <tr>
                                                    <td>&nbsp&nbsp&nbsp&nbsp</td><td> <asp:Label ID="lblAddress2" runat="server"></asp:Label></td>
                                                </tr>
                                                <tr>
                                                    <td>City  </td><td> <asp:Label ID="lblCity" runat="server"></asp:Label></td>
                                                </tr>
                                                <tr>
                                                    <td>  Area </td><td> <asp:Label ID="lblArea" runat="server"></asp:Label></td>
                                                </tr>
                                                <tr>
                                                    <td>  Pincode </td><td> <asp:Label ID="lblPincode" runat="server"></asp:Label></td>
                                                </tr>
                                                  <tr>
                                                    <td>   Landmark</td><td>  <asp:Label ID="lblLandmark" runat="server"></asp:Label></td>
                                                </tr>
                                            </table>
                                            <div class="form-group">
                                    <label>Special Requirement</label>
                                    <asp:TextBox ID="txtReq" Rows="5" Enabled="false" runat="server" TextMode="MultiLine" CssClass="form-control"></asp:TextBox>
                                </div>
                                        </div>
                                        
                                    </div>
                                </div>


                            </div>
                            <div class="col-md-7">

                                <div class="Compose-Message">
                                    <div class="panel panel-default">
                                        <div class="panel-heading">
                                            Order Items
                                        </div>
                                        <div class="panel-body table-responsive">
                                            <table id="example" class="table table-striped table-bordered" cellspacing="0" width="100%">
                                                <thead>
                                                    <tr>
                                                        <th>Product</th>
                                                        <th>Image</th>
                                                        <th>Price</th>
                                                        <th>Quantity</th>
                                                        <th>Net Price</th>
                                                       
                                                    </tr>
                                                </thead>

                                                <tfoot >
                                                    <tr class="btn-success">
                                                         <th colspan="4" style="text-align:right">Total Amount </th>
                                                       
                                                        <th><asp:Label ID="lblTotalAmount" runat="server"></asp:Label></th>
                                                    </tr>
                                                    <tr class="btn-danger">
                                                         <th colspan="4" style="text-align:right">Delivery Charge</th>
                                                       
                                                        <th><asp:Label ID="lblDeliveryCharge" runat="server"></asp:Label></th>
                                                    </tr>
                                                </tfoot>

                                                <tbody>

                                                    <asp:Repeater ID="rpOrderItems" runat="server">
                                                        <ItemTemplate>
 <tr>
                                                        <td><%#Eval("productName") %></td>
                                                        <td><img width="40px" height="40px" src="product/small/<%#Eval("image") %>" /></td>
                                                        <td><%#Eval("newprice") %></td>
                                                        <td><%#Eval("quantity") %></td>
                                                        <td><%#Eval("totalamount") %></td>
                                                        
                                                    </tr>
                                                        </ItemTemplate>
                                                    </asp:Repeater>
                                                   
                                                    
                                                  

                                                </tbody>
                                            </table>

                                        </div>
                                        <div class="panel-footer text-muted">
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-10">
                               <asp:Button ID="btnGenarateBill" runat="server" OnClick="btnGenarateBill_Click" Text="Genarate Bill" CssClass="btn btn-success" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
   
</asp:Content>

