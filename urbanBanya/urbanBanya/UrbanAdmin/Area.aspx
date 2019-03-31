<%@ Page Title="" Language="C#" MasterPageFile="~/UrbanAdmin/AdminMasterPage.master" AutoEventWireup="true" CodeFile="Area.aspx.cs" Inherits="UrbanAdmin_Area" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <div class="container">
        <div class="row">
            <div class="col-md-12 col-sm-12">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <h3>Area Management</h3>
                    </div>
                    <div class="panel-body">
                        <ul class="nav nav-tabs">

                            <li class="active"><a href="#update" data-toggle="tab">All Areaes</a>
                            </li>
                            <li class=""><a href="#addnew" data-toggle="tab">Add Area</a>
                            </li>
                            <li class=""><a href="#uploadExcel" data-toggle="tab">Upload Excel</a>
                            </li>
                            <li class=""><a href="#updateExcel" data-toggle="tab">Update Excel</a>
                            </li>
                           
                        </ul>

                        <div class="tab-content">

                            <div class="tab-pane fade active in" id="update">
                                <h4>All Areaes</h4>
                              
                                <div class="col-md-12">
                                    <!--    Hover Rows  -->
                                    <asp:Panel ID="viewPanel" runat="server">
                                    <div class="panel panel-default">
                                        <div class="panel-heading">
                                            Area
                                             <div class="pull-right"><asp:Button ID="btnDelete" runat="server" Text="Delete" CssClass="btn btn-danger" OnClick="btnDelete_Click" /></div>
                                        </div>
                                        
                                            <div class="panel-body">
                                                <div class="table-responsive">
                                                    <table id="example" class="table table-striped table-bordered" cellspacing="0" width="100%">
                                                        <thead>
                                                            <tr>
                                                                <th>S.No</th>
                                                                <th>City</th>
                                                                <th>City Zone</th>
                                                                <th>Area Name</th>
                                                                <th>Pincode</th>
                                                                <th>Extera</th>
                                                               <th>Update</th>
                                                            </tr>
                                                        </thead>

                                                        <tfoot>
                                                            <tr>
                                                                  <th>S.No</th>
                                                                <th>City</th>
                                                                <th>City Zone</th>
                                                                <th>Area Name</th>
                                                                <th>Pincode</th>
                                                                <th>Extera</th>
                                                                <th>Update</th>
                                                            </tr>
                                                        </tfoot>

                                                        <tbody>
                                                            <asp:Repeater ID="rpArea" runat="server" OnItemCommand="rpArea_ItemCommand">
                                                                <ItemTemplate>
                                                                    <tr>
                                                                        <td><asp:CheckBox ID="areaid" runat="server" Text='<%# Eval("id") %>' /></td>
                                                                        <td><%#Eval("city") %></td>
                                                                        <td>
                                                                           <asp:DropDownList Enabled="false"  runat="server" CssClass="form-control" ID="cmbAreaZone">
                                                <asp:ListItem Value="0">--Select Area Zone--</asp:ListItem>
                                                <asp:ListItem Value="1">West</asp:ListItem>
                                                <asp:ListItem Value="2">East</asp:ListItem>
                                            </asp:DropDownList>
                                                                        </td>
                                                                        <td><%#Eval("areaname") %></td>
                                                                        <td><%#Eval("pincode") %></td>
                                                                        <td><%#Eval("extera") %></td>
                                                                        <td>
                                                                              <asp:Button ID="btnEdit" runat="server" Text="Edit  " CommandArgument='<%# Eval("id") %>' CommandName="edit" CssClass="btn btn-warning btn-sm" />
                                                                        </td>
                                                                    </tr>
                                                                </ItemTemplate>
                                                            </asp:Repeater>



                                                        </tbody>
                                                    </table>
                                                </div>
                                            </div>
                                        
                                      
                                    </div>
                                    <!-- End  Hover Rows  -->
                                </asp:Panel>
                                      <asp:Panel ID="updatePanel" runat="server">
                                              <div class="panel panel-default">
                                    <div class="panel-heading">
                                        Area Details For Update
                                    </div>
                                    <div class="panel-body">
                                         <div class="col-md-6">
                                   
                                    
                                         <div class="form-group">
                                            <label>City Name</label>
                                            <asp:TextBox ID="txtCityUp" runat="server" class="form-control"></asp:TextBox>
                                            
                                        </div>
                                      <div class="form-group">
                                            <label>Area Zone :</label>
                                            <asp:DropDownList runat="server" CssClass="form-control" ID="cmbAreaZoneUp">
                                                <asp:ListItem Value="0">--Select Area Zone--</asp:ListItem>
                                                <asp:ListItem Value="1">West</asp:ListItem>
                                                <asp:ListItem Value="2">East</asp:ListItem>
                                            </asp:DropDownList>
                                            
                                        </div>
                                         <div class="form-group">
                                            <label>Area</label>
                                            <asp:TextBox ID="txtAreaUp" runat="server" class="form-control" TextMode="MultiLine" Rows="2"></asp:TextBox>
                                            
                                        </div>
                                      
                                       <div class="form-group">
                                            <label>Pincode</label>
                                          <asp:TextBox ID="txtPincodeUp" runat="server" class="form-control"></asp:TextBox>
                                        </div>
                                      <div class="form-group">
                                            <label>Extera Amount</label>
                                          <asp:TextBox ID="txtExAmountUp" runat="server" class="form-control"></asp:TextBox>
                                        </div>
                                         
                                         <div class="form-group">

                                             <asp:Button ID="btnUpdate" class="btn btn-success" runat="server" Text="Update" onclick="btnUpdate_Click" 
                                                  />
                                             
                                        </div>

                                    
                                  
                                </div>
                                      
                                    </div>
                                    <div class="panel-footer text-muted">
                                    </div>
                                </div>
 
                                        </asp:Panel>
                                </div>


                            </div>





                            <div class="tab-pane fade" id="addnew">
                                <h4>Add Area</h4>
                                <div class="panel panel-default">
                                    <div class="panel-heading">
                                        Area Details
                                    </div>
                                    <div class="panel-body">
 <div class="col-md-6">
                                   
                                    
                                        <div class="form-group">
                                            <label>City Name</label>
                                            <asp:TextBox ID="txtCityName" runat="server" class="form-control"></asp:TextBox>
                                            
                                        </div>
                                     <div class="form-group">
                                            <label>Area Zone :</label>
                                            <asp:DropDownList  runat="server" CssClass="form-control" ID="cmbAreaZone">
                                                <asp:ListItem Value="0">--Select Area Zone--</asp:ListItem>
                                                <asp:ListItem Value="1">West</asp:ListItem>
                                                <asp:ListItem Value="2">East</asp:ListItem>
                                            </asp:DropDownList>
                                            
                                        </div>
                                         <div class="form-group">
                                            <label>Area</label>
                                            <asp:TextBox ID="txtArea" runat="server" class="form-control" TextMode="MultiLine" Rows="2"></asp:TextBox>
                                            
                                        </div>
                                      
                                       <div class="form-group">
                                            <label>Pincode</label>
                                          <asp:TextBox ID="txtPincode" runat="server" class="form-control"></asp:TextBox>
                                        </div>
                                      <div class="form-group">
                                            <label>Extra Amount</label>
                                          <asp:TextBox ID="txtExtera" runat="server" class="form-control"></asp:TextBox>
                                        </div>
                                         
                                         <div class="form-group">

                                             <asp:Button ID="btnUpload" class="btn btn-success" runat="server" Text="Upload" 
                                                 onclick="btnUpload_Click" />
                                              <asp:Button ID="Button1" class="btn btn-danger" runat="server" Text="Reset" 
                                                 onclick="btnReset_Click" />
                                        </div>

                                    
                                  
                                </div>
                                      
                                    </div>
                                    <div class="panel-footer text-muted">
                                    </div>
                                </div>
                                
                            </div>



                            <div class="tab-pane fade" id="uploadExcel">
                                <h4>Upload All Areaes Using Excel</h4>
                                <div class="panel panel-default">
                                    <div class="panel-heading">
                                        Excel Area Upload
                                    </div>

                                    <div class="panel-body">
                                        <div class="col-md-4">
                                            <div class="form-group">
                                                <label for="exampleInputEmail1">Select Excel File </label>
                                                <asp:FileUpload ID="excelUpload" CssClass="form-control" runat="server" />

                                            </div>
                                            <div class="form-group">
                                                <asp:Button ID="btnUploadExcel" runat="server" Text="Upload Excel" CssClass="btn btn-success" OnClick="btnUploadExcel_Click" />
                                            </div>
                                        </div>
                                    </div>

                                </div>
                            </div>
                            <div class="tab-pane fade" id="updateExcel">
                                <h4>Update All Areaes Using Excel</h4>
                                <div class="panel panel-default">
                                    <div class="panel-heading">
                                        Excel Area Update
                                    </div>

                                    <div class="panel-body">
                                        <div class="col-md-4">
                                            <div class="form-group">
                                               
                                                <asp:Button ID="btnExcelExport" runat="server" Text="Export Excel File" OnClick="btnExcelExport_Click" CssClass="btn btn-success" />

                                            </div>
                                            <div class="form-group">
                                                <label for="exampleInputEmail1">Select Excel File</label>
                                                <asp:FileUpload ID="excelUpdate" CssClass="form-control" runat="server" />

                                            </div>
                                            <div class="form-group">
                                                <asp:Button ID="btnExcelUpdate" runat="server" Text="Update Excel" OnClick="btnExcelUpdate_Click" CssClass="btn btn-success" />
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
    <asp:Literal ID="lblShowMessage" runat="server"></asp:Literal>
</asp:Content>

