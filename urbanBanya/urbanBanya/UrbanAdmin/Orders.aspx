<%@ Page Title="" Language="C#" MasterPageFile="~/UrbanAdmin/AdminMasterPage.master" AutoEventWireup="true" CodeFile="Orders.aspx.cs" Inherits="UrbanAdmin_Orders" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script>
     $(document).ready(function () {
         $(".f-date-picker").datepicker({ dateFormat: 'yy-mm-dd' });
         $(".t-date-picker").datepicker({ dateFormat: 'yy-mm-dd' });
         
     });
 </script>
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
   
    <div class="container">
        <div class="row">
            <div class="col-md-12 col-sm-12">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <h3>Urban Orders</h3>
                     
                    <div class="panel-body">
                        <div class="row">

                            <div class="col-md-12">

                                <div class="Compose-Message">
                                    <div class="panel panel-default">
                                        <div class="panel-heading">
                                            <div class="row">
                                                <div class="col-md-3">
                                                        <asp:DropDownList ID="cmbOrderStatusd" CssClass="form-control"  runat="server" >
                                                             <asp:ListItem Value="0">---Select Status---</asp:ListItem>
                                                                        <asp:ListItem Value="Pending">Pending</asp:ListItem>
                                                                         <asp:ListItem Value="Canceled">Cancel</asp:ListItem>
                                                                         <asp:ListItem Value="OnHold">On Hold</asp:ListItem>
                                                                         <asp:ListItem Value="Processing">Processing</asp:ListItem>
                                                                         <asp:ListItem Value="Shipped">Shipped</asp:ListItem>
                                                                         <asp:ListItem Value="Completed">Completed</asp:ListItem>
                                                                    </asp:DropDownList>
                                                </div>
                                                <div class="col-md-3">
                                                    
                                             <div class="control-group pull-right">
      
        <div class="controls">
            <div class="input-group">
               <label for="datefrom" class="input-group-addon btn"><span class="glyphicon glyphicon-calendar"></span>

                </label>
                <asp:TextBox runat="server" id="datefrom" placeholder="Date from "  type="text" class="f-date-picker form-control" />
            </div>
        </div>
    </div>
                                                </div>
                                                 <div class="col-md-3">
                                                    
                                             <div class="control-group pull-right">
      
        <div class="controls">
            <div class="input-group">
                <label runat="server" for="dateto" class="input-group-addon btn"><span class="glyphicon glyphicon-calendar"></span>

                </label>
                <asp:TextBox runat="server" id="dateto" placeholder="Date To "  type="text" class="t-date-picker form-control" />
            </div>
        </div>
    </div>
                                                </div>
                                                <div class="col-md-3">
                                                    
                                                    <asp:Button ID="btnGetReport" runat="server" CssClass="btn btn-success" Text="Get Orders" OnClick="btnGetReport_Click" />
                                                    
                                                </div>
                                            </div>
                                           
                                            

                                        </div>
                                        <div class="panel-body table-responsive">
                                            <table id="example" class="table table-striped table-bordered " cellspacing="0" width="100%">
                                                <thead>
                                                    <tr>
                                                        <th>Order no.</th>
                                                        <th>Order Total</th>
                                                        <th>Paying Amount</th>
                                                        <th>Placed Date</th>
                                                        <th>Order Date</th>
                                                        <th>Order Time</th>
                                                        <th>Status</th>
                                                        <th>View Order</th>
                                                    </tr>
                                                </thead>

                                                <tfoot>
                                                    <tr>
                                                        <th>Order no.</th>
                                                        <th>Total Amount</th>
                                                         <th>Paying Amount</th>
                                                        <th>Placed Date</th>
                                                        <th>Order Date</th>
                                                        <th>Order Time</th>
                                                        <th>Status</th>
                                                        <th>View Order</th>
                                                    </tr>
                                                </tfoot>

                                                <tbody>

                                                    <asp:Repeater ID="rpTopOrer" runat="server">
                                                        <ItemTemplate>
                                                            <tr>
                                                                <td><asp:Label ID="lblid" runat="server" Text='<%#Eval("id") %>'></asp:Label> </td>
                                                                <td><%#Eval("ordertotal") %></td>
                                                                 <td><%#Eval("payamount") %></td>
                                                                <td><%#Eval("placedate") %></td>
                                                                <td><%#Eval("orderdate") %></td>
                                                                <td><%#Eval("ordertime") %></td>
                                                                <td>
                                                                    <asp:DropDownList ID="cmbOrderStatus" DataTextField="status" DataValueField="status" runat="server" AutoPostBack="true" OnSelectedIndexChanged="cmbOrderStatus_SelectedIndexChanged" >
                                                                        <asp:ListItem Value="Pending">Pending</asp:ListItem>
                                                                         <asp:ListItem Value="Canceled">Cancel</asp:ListItem>
                                                                         <asp:ListItem Value="OnHold">On Hold</asp:ListItem>
                                                                         <asp:ListItem Value="Processing">Processing</asp:ListItem>
                                                                         <asp:ListItem Value="Shipped">Shipped</asp:ListItem>
                                                                         <asp:ListItem Value="Completed">Completed</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </td>
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
    <asp:Literal ID="showmsg" runat="server"></asp:Literal>
</asp:Content>

