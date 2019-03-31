<%@ Page Title="" Language="C#" MasterPageFile="~/UrbanAdmin/AdminMasterPage.master" AutoEventWireup="true" CodeFile="GoodiesRules.aspx.cs" Inherits="UrbanAdmin_GoodiesRules" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container">
        <div class="row">
            <div class="col-md-12 col-sm-12">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <h3>Urban Goodies</h3>

                        <div class="panel-body">
                            <div class="row">

                                <div class="col-md-12">

                                    <div class="Compose-Message">
                                        <div class="panel panel-default">
                                            <div class="panel-heading">
                                                <div class="row">
                                                    <div class="col-md-3">
                                                        Goodies
                                                    </div>



                                                </div>


                                            </div>
                                            <div class="panel-body table-responsive">
                                                <div class="table-responsive">
                                                    <table>
                                                        <thead>
                                                            <tr>
                                                                <th>Goodies No</th>
                                                                <th>Amount</th>
                                                                <th>Goodies</th>
                                                                <th>Goodies Value</th>
                                                            </tr>
                                                        </thead>
                                                        <tbody>
                                                            <tr>
                                                                <td>
                                                                    <asp:Label ID="lblGoodiesID" runat="server" CssClass="form-control"></asp:Label></td>
                                                                <td>
                                                                    <asp:TextBox ID="txtAmount" runat="server" CssClass="form-control"></asp:TextBox></td>
                                                                <td>
                                                                    <asp:TextBox ID="txtGoodies" runat="server" CssClass="form-control"></asp:TextBox></td>
                                                                <td>
                                                                    <asp:TextBox ID="txtGoodiesValue" runat="server" CssClass="form-control"></asp:TextBox></td>
                                                                <td>
                                                                   
                                                                           
                                             <asp:Button ID="btnUpload" class="btn btn-success" runat="server" Text="Update" OnClick="btnUpload_Click" />
                                                                      
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                
                                                            </tr>

                                                        </tbody>
                                                    </table>

                                                </div>



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


