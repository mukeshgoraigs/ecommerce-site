<%@ Page Title="" Language="C#" MasterPageFile="~/UrbanAdmin/AdminMasterPage.master" AutoEventWireup="true" CodeFile="Customer.aspx.cs" Inherits="UrbanAdmin_Customer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container">
        <div class="row">
            <div class="col-md-12 col-sm-12">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <h3>Urban Customer</h3>

                        <div class="panel-body">
                            <div class="row">

                                <div class="col-md-12">

                                    <div class="Compose-Message">
                                        <div class="panel panel-default">
                                            <div class="panel-heading">
                                                <div class="row">
                                                    <div class="col-md-3">
                                                        All Customer
                                                    </div>
                                                    <div class="col-md-3 pull-right">
                                                        <asp:DropDownList ID="cmbCustomerStatusTop" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="cmbCustomerStatusTop_SelectedIndexChanged">
                                                            <asp:ListItem Value="select">---Select Status---</asp:ListItem>
                                                            <asp:ListItem Value="0">Block</asp:ListItem>
                                                            <asp:ListItem Value="1">Active</asp:ListItem>

                                                        </asp:DropDownList>

                                                    </div>


                                                </div>


                                            </div>
                                            <div class="panel-body table-responsive">
                                                <table id="example" class="table table-striped table-bordered " cellspacing="0" width="100%">
                                                    <thead>
                                                        <tr>
                                                            <th>Customer no.</th>
                                                            <th>Name</th>
                                                            <th>Email</th>
                                                            <th>Mobile</th>
                                                            <th>Password</th>
                                                            <th>Goodies</th>
                                                            <th>Status</th>
                                                        </tr>
                                                    </thead>

                                                    <tfoot>
                                                        <tr>
                                                            <th>Customer no.</th>
                                                            <th>Name</th>
                                                            <th>Email</th>
                                                            <th>Mobile</th>
                                                            <th>Password</th>
                                                            <th>Goodies</th>
                                                            <th>Status</th>
                                                        </tr>
                                                    </tfoot>

                                                    <tbody>

                                                        <asp:Repeater ID="rpCustomer" runat="server">
                                                            <ItemTemplate>
                                                                <tr>
                                                                    <td>
                                                                        <asp:Label ID="lblid" runat="server" Text='<%#Eval("id") %>'></asp:Label>
                                                                    </td>
                                                                    <td><%#Eval("F_name") %></td>
                                                                    <td><%#Eval("email") %></td>
                                                                    <td><%#Eval("mobile") %></td>
                                                                    <td><%#Eval("cpassword") %></td>
                                                                    <td>
                                                                        <%#Eval("points") %>
                                                                  
                                                                    </td>
                                                                    <td>
                                                                        <asp:DropDownList ID="cmbCustomerStatus" DataTextField="status" DataValueField="status" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="cmbCustomerStatus_SelectedIndexChanged">
                                                                            <asp:ListItem Value="0">Block</asp:ListItem>
                                                                            <asp:ListItem Value="1">Active</asp:ListItem>

                                                                        </asp:DropDownList>
                                                                    </td>
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
</asp:Content>

