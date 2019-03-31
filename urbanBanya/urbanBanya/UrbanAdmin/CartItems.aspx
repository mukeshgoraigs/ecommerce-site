<%@ Page Title="" Language="C#" MasterPageFile="~/UrbanAdmin/AdminMasterPage.master" AutoEventWireup="true" CodeFile="CartItems.aspx.cs" Inherits="UrbanAdmin_CartItems" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="container">
        <div class="row text-center">
            <div class="col-md-8">

           
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
                                                        
                                                    </tr>
                                                </thead>

                                             

                                                <tbody>

                                                    <asp:Repeater ID="rpCartItems" runat="server">
                                                        <ItemTemplate>
 <tr>
                                                        <td><%#Eval("productName") %></td>
                                                        <td><img width="40px" height="40px" src="product/small/<%#Eval("image") %>" /></td>
                                                        <td><%#Eval("newprice") %></td>
                                                        <td><%#Eval("quantity") %></td>
                                                       
                                                        
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
</asp:Content>

