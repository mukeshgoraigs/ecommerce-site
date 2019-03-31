<%@ Page Title="" Language="C#" MasterPageFile="~/UrbanAdmin/AdminMasterPage.master" AutoEventWireup="true" CodeFile="Home.aspx.cs" Inherits="Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    
    <div class="container">
        <div class="row">
            <div class="col-md-12 col-sm-12">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <h3>Dashboard</h3>
                    </div>
                    <div class="panel-body">
                        <div class="row">
                            <div class="col-md-4">
                                <div class="notice-board">
                                    <div class="panel panel-default">
                                        <div class="panel-heading">
                                            Lifetime Sales
                                <div class="pull-right">
                                    <div class="dropdown">
                                        <button class="btn btn-success dropdown-toggle btn-xs" type="button" id="dropdownMenu1" data-toggle="dropdown" aria-expanded="true">
                                            <span class="glyphicon glyphicon-cog"></span>
                                            <span class="caret"></span>
                                        </button>
                                        <ul class="dropdown-menu" role="menu" aria-labelledby="dropdownMenu1">
                                            <li role="presentation"><a role="menuitem" tabindex="-1" href="#">Refresh</a></li>
                                            <li role="presentation"><a role="menuitem" tabindex="-1" href="#">Logout</a></li>
                                        </ul>
                                    </div>
                                </div>
                                        </div>
                                        <div class="panel-body text-center">
                                            Rs. 25685454/-
                                        </div>
                                        <div class="panel-footer">
                                            Average Orders
                                        </div>
                                        <div class="panel-body text-center">
                                            Rs. 256/-
                                        </div>
                                    </div>
                                </div>
                                <div class="panel panel-default">
                                        <div class="panel-heading">
                                            Top Search Items
                                        </div>
                                        <div class="panel-body table-responsive">
                                            <table id="example" class="table table-striped table-bordered " cellspacing="0" width="100%">
                                                <thead>
                                                    <tr>
                                                        <th>Product no.</th>
                                                        <th>Product</th>
                                                        <th>Image</th>
                                                        
                                                    </tr>
                                                </thead>

                                                <tfoot>
                                                    <tr>
                                                        <th>Product no.</th>
                                                        <th>Product</th>
                                                        <th>Image</th>
                                                        
                                                    </tr>
                                                </tfoot>

                                                <tbody>

                                                  <tr>
                                                         <th>Product no.</th>
                                                        <th>Product</th>
                                                        <th>Image</th>
                                                        
                                                    </tr>

                                                </tbody>
                                            </table>

                                        </div>
                                        <div class="panel-footer text-muted">
                                        </div>
                                    </div>

                            </div>
                            <div class="col-md-8">

                                <div class="Compose-Message">
                                    <div class="panel panel-default">
                                        <div class="panel-heading">
                                            Last 10 Orders
                                        </div>
                                        <div class="panel-body table-responsive">
                                            <table id="example" class="table table-striped table-bordered " cellspacing="0" width="100%">
                                                <thead>
                                                    <tr>
                                                        <th>Order no.</th>
                                                        <th>Total Amount</th>
                                                        <th>Placed Date</th>
                                                        <th>Order Date</th>
                                                        <th>Order Time</th>
                                                        <th>View Order</th>
                                                    </tr>
                                                </thead>

                                                <tfoot>
                                                    <tr>
                                                        <th>Order no.</th>
                                                        <th>Total Amount</th>
                                                        <th>Placed Date</th>
                                                        <th>Order Date</th>
                                                        <th>Order Time</th>
                                                        <th>View Order</th>
                                                    </tr>
                                                </tfoot>

                                                <tbody>

                                                    <asp:Repeater ID="rpTopOrer" runat="server">
                                                        <ItemTemplate>
 <tr>
                                                        <td><%#Eval("id") %></td>
                                                        <td><%#Eval("ordertotal") %></td>
                                                        <td><%#Eval("placedate") %></td>
                                                        <td><%#Eval("orderdate") %></td>
                                                        <td><%#Eval("ordertime") %></td>
                                                        <td><a href="OrderDetails.aspx?orderid=<%#Eval("id") %>&userid=<%#Eval("userid") %>&adid=<%#Eval("address") %>" class="btn btn-success">View</a></td>
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

                    </div>
                </div>
            </div>
        </div>
    </div>
    <asp:Literal ID="lblShowMessage" runat="server"></asp:Literal>
</asp:Content>

