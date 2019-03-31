<%@ Page Title="" Language="C#" MasterPageFile="~/UrbanAdmin/AdminMasterPage.master" AutoEventWireup="true" CodeFile="TopCustomer.aspx.cs" Inherits="UrbanAdmin_TopCustomer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <div class="container">
        <div class="row">
            <div class="col-md-12 col-sm-12">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <h3>Urban Top Customer</h3>

                        <div class="panel-body">
                            <div class="row">

                                <div class="col-md-12">

                                    <div class="Compose-Message">
                                        <div class="panel panel-default">
                                            <div class="panel-heading">
                                                <div class="row">
                                                    <div class="col-md-3">
                                                        All Top Customer
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
                                                            <th>Total Purchase</th>
                                                            <th>Name</th>
                                                            <th>Email</th>
                                                            <th>Mobile</th>                                                            
                                                            <th>Goodies</th>
                                                           
                                                        </tr>
                                                    </thead>

                                                    <tfoot>
                                                        <tr>
                                                            <th>Customer no.</th>
                                                            <th>Total Purchase</th>
                                                            <th>Name</th>
                                                            <th>Email</th>
                                                            <th>Mobile</th>
                                                           
                                                            <th>Goodies</th>
                                                           
                                                        </tr>
                                                    </tfoot>

                                                    <tbody>

                                                        <asp:Repeater ID="rpTopCustomer" runat="server">
                                                            <ItemTemplate>
                                                                <tr>
                                                                    <td>
                                                                        <asp:Label ID="lblid" runat="server" Text='<%#Eval("id") %>'></asp:Label>
                                                                    </td>
                                                                     <td><%#Eval("total") %></td>
                                                                    <td><%#Eval("F_name") %></td>
                                                                    <td><%#Eval("email") %></td>
                                                                    <td><%#Eval("mobile") %></td>
                                                                  
                                                                    <td>
                                                                        <%#Eval("points") %>
                                                                  
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
         </div>
</asp:Content>
