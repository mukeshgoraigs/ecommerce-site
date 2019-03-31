<%@ Page Title="" Language="C#" MasterPageFile="~/UrbanAdmin/AdminMasterPage.master" AutoEventWireup="true" CodeFile="Reviews.aspx.cs" Inherits="UrbanAdmin_Reviews" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container">
        <div class="row">
            <div class="col-md-12 col-sm-12">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        Top Search Items
                    </div>
                    <div class="panel-body table-responsive">
                        <table id="example" class="table table-striped table-bordered " cellspacing="0" width="100%">
                            <thead>
                                <tr>
                                    <th>Review no.</th>
                                    <th>Customer</th>
                                    <th>Review</th>
                                    <th>Status</th>
                                    <th>Action</th>
                                </tr>
                            </thead>

                            <tfoot>
                                <tr>
                                    <th>Review no.</th>
                                    <th>Customer</th>
                                    <th>Review</th>
                                    <th>Status</th>
                                    <th>Action</th>
                                </tr>
                            </tfoot>

                            <tbody>
                                <asp:Repeater ID="rpReviews" runat="server" OnItemCommand="rpReviews_ItemCommand">
                                    <ItemTemplate>


                                        <tr>
                                            <th><asp:Label ID="lblid" runat="server" Text='<%#Eval("id") %>'></asp:Label></th>
                                            <th><%#Eval("F_name") %></th>
                                            <th><%#Eval("review") %></th>
                                            <th>
                                                <asp:DropDownList ID="cmbReviewStatus" DataTextField="status" DataValueField="status" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="cmbReviewStatus_SelectedIndexChanged">
                                                    <asp:ListItem Value="0">Block</asp:ListItem>
                                                    <asp:ListItem Value="1">Active</asp:ListItem>

                                                </asp:DropDownList>
                                            </th>
                                            <th>
                                                <asp:Button ID="btnDelete" runat="server" CommandName="delete" CommandArgument='<%#Eval("id") %>' Text="Delete" CssClass="btn btn-danger" /></th>
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

