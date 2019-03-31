<%@ Page Title="" Language="C#" MasterPageFile="~/UrbanAdmin/AdminMasterPage.master" AutoEventWireup="true" CodeFile="CartReport.aspx.cs" Inherits="UrbanAdmin_CartReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
      <div class="container">
        <div class="row">
            <div class="col-md-12 col-sm-12">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <h3>Urban Customer Cart</h3>

                        <div class="panel-body">
                            <div class="row">

                                <div class="col-md-12">

                                    <div class="Compose-Message">
                                        <div class="panel panel-default">
                                            <div class="panel-heading">
                                                <div class="row">
                                                    <div class="col-md-3">
                                                         Customer Cart
                                                    </div>
                                                    <div class="col-md-3 pull-right">
                                                        

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
                                                           <th>Action</th>
                                                        </tr>
                                                    </thead>

                                                    <tfoot>
                                                        <tr>
                                                            <th>Customer no.</th>
                                                            <th>Name</th>
                                                            <th>Email</th>
                                                            <th>Mobile</th>
                                                           <th>Action</th>
                                                        </tr>
                                                    </tfoot>

                                                    <tbody>

                                                        <asp:Repeater ID="rpCartCustomer" runat="server">
                                                            <ItemTemplate>
                                                                <tr>
                                                                    <td>
                                                                        <asp:Label ID="lblid" runat="server" Text='<%#Eval("id") %>'></asp:Label>
                                                                    </td>
                                                                    <td><%#Eval("F_name") %></td>
                                                                    <td><%#Eval("email") %></td>
                                                                    <td><%#Eval("mobile") %></td>
                                                                    <td><a href="CartItems.aspx?userid=<%#Eval("id") %>" class="btn btn-success">View Cart</a></td>
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

