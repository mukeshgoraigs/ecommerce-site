<%@ Page Title="" Language="C#" MasterPageFile="~/UrbanAdmin/AdminMasterPage.master" AutoEventWireup="true" CodeFile="SlotMaster.aspx.cs" Inherits="UrbanAdmin_SlotMaster" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="container">
        <div class="row">
            <div class="col-md-12 col-sm-12">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <h3>Urban Slots</h3>

                        <div class="panel-body">
                            <div class="row">

                                <div class="col-md-12">

                                    <div class="Compose-Message">
                                        <div class="panel panel-default">
                                            <div class="panel-heading">
                                                <div class="row">
                                                    <div class="col-md-3">
                                                        All Slots
                                                    </div>
                                                   


                                                </div>


                                            </div>
                                            <div class="panel-body table-responsive">
                                              <div class="table-responsive">
                                            <table>
                                                <thead>
                                                   <tr> 
                                                       <th>Slot 1</th><th>Slot 2</th><th>Slot 3</th><th>Slot 4</th><th>Slot 5</th><th>Slot 6</th><th>City Zone</th>
                                                       </tr>
                                                </thead>
                                                <tbody>
                                                     <tr>
                                                        <td><asp:TextBox ID="txtwestslot1" runat="server" CssClass="form-control"></asp:TextBox></td>
                                                        <td><asp:TextBox ID="txtwestslot2" runat="server" CssClass="form-control"></asp:TextBox></td>
                                                        <td><asp:TextBox ID="txtwestslot3" runat="server" CssClass="form-control"></asp:TextBox></td>
                                                        <td><asp:TextBox ID="txtwestslot4" runat="server" CssClass="form-control"></asp:TextBox></td>
                                                        <td><asp:TextBox ID="txtwestslot5" runat="server" CssClass="form-control"></asp:TextBox></td>
                                                        <td><asp:TextBox ID="txtwestslot6" runat="server" CssClass="form-control"></asp:TextBox></td>
                                                          <td>
                                                             <asp:Label ID="lblEestSlot" runat="server" Text="West" CssClass="form-control"></asp:Label> 
                                                         </td>
                                                    </tr>
                                                   
                                                    <tr>
                                                        <td><asp:TextBox ID="txteastslot1" runat="server" CssClass="form-control"></asp:TextBox></td>
                                                        <td><asp:TextBox ID="txteastslot2" runat="server" CssClass="form-control"></asp:TextBox></td>
                                                        <td><asp:TextBox ID="txteastslot3" runat="server" CssClass="form-control"></asp:TextBox></td>
                                                        <td><asp:TextBox ID="txteastslot4" runat="server" CssClass="form-control"></asp:TextBox></td>
                                                        <td><asp:TextBox ID="txteastslot5" runat="server" CssClass="form-control"></asp:TextBox></td>
                                                        <td><asp:TextBox ID="txteastslot6" runat="server" CssClass="form-control"></asp:TextBox></td>
                                                         <td>
                                                             <asp:Label ID="lblEastSlot" runat="server" Text="East" CssClass="form-control"></asp:Label> 
                                                         </td>
                                                    </tr>
                                                    
                                                </tbody>
                                            </table>
                                            
                                        </div>
                                        
                                         
                                         <div class="form-group">

                                             <asp:Button ID="btnUpload" class="btn btn-success" runat="server" Text="Update" OnClick="btnUpload_Click" 
                                                 />
                                              <asp:Button ID="btnReset" class="btn btn-danger" runat="server" Text="Reset" 
                                                  />
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

