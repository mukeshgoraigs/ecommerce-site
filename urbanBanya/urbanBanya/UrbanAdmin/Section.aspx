<%@ Page Title="" Language="C#" MasterPageFile="~/UrbanAdmin/AdminMasterPage.master" AutoEventWireup="true" CodeFile="Section.aspx.cs" Inherits="UrbanAdmin_Section" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="container">
        <div class="row">
            <div class="col-md-12 col-sm-12">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <h3>Section Management</h3>
                    </div>
                    <div class="panel-body">
                        <ul class="nav nav-tabs">

                            <li class="active"><a href="#update" data-toggle="tab">Add Products In Section</a>
                            </li>
                            <li class=""><a href="#addnew" data-toggle="tab">Update Section</a>
                            </li>
                           
                        </ul>

                        <div class="tab-content">

                            <div class="tab-pane fade active in" id="update">
                                <h4>All Products </h4>
                                
                                <div class="col-md-12">
                                    <!--    Hover Rows  -->
                                    <asp:Panel ID="viewPanel" runat="server">
                                    <div class="panel panel-default">
                                        <div class="panel-heading">
                                            Products
                                             <div class="pull-right">
                                                 <asp:Button ID="btnSubmit" runat="server"  Text="Submit" CssClass="btn btn-success" OnClick="btnSubmit_Click"/>
                                             </div>
                                        </div>
                                        
                                            <div class="panel-body">
                                              
                                                <div class="row">
                                <div class="col-md-4">
                                   <div class="form-group">
                                            <label>Category Name</label>
                                          
                                        <asp:DropDownList ID="cmbCategory" class="form-control" runat="server" 
                                                AutoPostBack="True" 
                                                onselectedindexchanged="cmbCategory_SelectedIndexChanged" >
                                        </asp:DropDownList>
                                        </div>
                            
                                </div>

                                <div class="col-md-4">
                                <div class="form-form-group">
                                 <label>Sub-Category Name</label>
                                            <asp:DropDownList ID="cmbSubCategory" class="form-control" 
                                        runat="server" 
                                        onselectedindexchanged="cmbSubCategory_SelectedIndexChanged" 
                                        AutoPostBack="True">
                                        </asp:DropDownList>
                                </div>
                                </div>
                                 <div class="col-md-4">
                                <div class="form-form-group">
                                 <label>Page Section</label>
                                            <asp:DropDownList ID="cmbSection" class="form-control" 
                                        runat="server" 
                                       >
                                                <asp:ListItem Value="0">--Select Section--</asp:ListItem>
                                                 <asp:ListItem Value="1">Bargains Product</asp:ListItem>
                                                 <asp:ListItem Value="2">New Product</asp:ListItem>
                                                 <asp:ListItem Value="3">Hot Item Product</asp:ListItem>
                                                
                                        </asp:DropDownList>
                                </div>
                                </div>
                            </div>
                                                    
                                                <div class="table-responsive">
                                                    <table id="example" class="table table-striped table-bordered" cellspacing="0" width="100%">
                                                    <thead>
                                                        <tr>
                                                            <th>S.No</th>
                                                            <th>Product</th>
                                                            <th>Image</th>
                                                            <th>Price</th>
                                                            <th>Discount</th>
                                                            <th>Size</th>
                                                            <th>Quantity</th>
                                                            <th>Code</th>
                                                           
                                                        </tr>
                                                    </thead>

                                                    <tfoot>
                                                        <tr>
                                                             <th>S.No</th>
                                                            <th>Product</th>
                                                            <th>Image</th>
                                                            <th>Price</th>
                                                            <th>Discount</th>
                                                            <th>Size</th>
                                                            <th>Quantity</th>
                                                            <th>Code</th>
                                                            
                                                        </tr>
                                                    </tfoot>

                                                    <tbody>
                                                        <asp:Repeater ID="rpProduct" runat="server">
                                                            <ItemTemplate>
                                                        <tr>
                                                             <td><asp:CheckBox ID="productid" runat="server" Text='<%# Eval("id") %>' /></td>
                                                            <td><%#Eval("productName") %></td>
                                                            <td><img src="product/small/<%#Eval("image") %>" width="60px" height="60px"></td>
                                                            <td><%#Eval("price") %></td>
                                                            <td><%#Eval("discount") %></td>
                                                            <td><%#Eval("size") %></td>
                                                            <td><%#Eval("quantity") %></td>
                                                            <td><%#Eval("code") %></td>
                                                            
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
                                     
                                </div>


                            </div>





                            <div class="tab-pane fade" id="addnew">
                                <h4>Update Section</h4>
                                
                                <div class="col-md-10">
                                <div class="panel panel-default">
                                    <div class="panel-heading">
                                       Section
                                        <div class="pull-left">
                                            <asp:UpdatePanel ID="secUpdatePanel" runat="server">
                                                <ContentTemplate>
                                                       <asp:DropDownList ID="cmbSectionUp" class="form-control" runat="server" AutoPostBack="true" OnSelectedIndexChanged="cmbSectionUp_SelectedIndexChanged" >
                                                <asp:ListItem Value="0">--Select Section--</asp:ListItem>
                                                 <asp:ListItem Value="1">Bargains Product</asp:ListItem>
                                                 <asp:ListItem Value="2">New Product</asp:ListItem>
                                                 <asp:ListItem Value="3">Hot Item Product</asp:ListItem>
                                                
                                        </asp:DropDownList>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                           
                                        </div>
                                         <div class="pull-right">
                                             <asp:UpdatePanel ID="btnUpdatePanel" runat="server">
                                                 <ContentTemplate>
                                                      <asp:Button ID="btnDelete" runat="server"  Text="Delete" CssClass="btn btn-danger" OnClick="btnDelete_Click"/>
                                            <asp:Button ID="btnUpdate" runat="server"  Text="Update" CssClass="btn btn-success" OnClick="btnUpdate_Click" />
                                                 </ContentTemplate>
                                                 <Triggers>
                                                     <asp:AsyncPostBackTrigger ControlID="btnDelete" EventName="Click" />
                                                     <asp:AsyncPostBackTrigger ControlID="btnUpdate" EventName="Click" />
                                                 </Triggers>
                                             </asp:UpdatePanel>
                                                
                                             </div>
                                    </div>
                                    <div class="panel-body">
                                        <div class="col-md-12">
                                            <asp:UpdatePanel ID="upPaneltable" runat="server">
                                                <ContentTemplate>
 <div class="table-responsive">
                                                    <table id="Table1" class="table table-striped table-bordered" cellspacing="0" width="100%">
                                                    <thead>
                                                        <tr>
                                                            <th>S.No</th>
                                                            <th>Product</th>
                                                            <th>Image</th>
                                                            <th>Price</th>
                                                            <th>Discount</th>
                                                            <th>Size</th>
                                                           <th>Position</th>
                                                           
                                                        </tr>
                                                    </thead>

                                                    <tfoot>
                                                        <tr>
                                                             <th>S.No</th>
                                                            <th>Product</th>
                                                            <th>Image</th>
                                                            <th>Price</th>
                                                            <th>Discount</th>
                                                            <th>Size</th>
                                                           <th>Position</th>
                                                            
                                                        </tr>
                                                    </tfoot>

                                                    <tbody>
                                                        <asp:Repeater ID="rpSection" runat="server">
                                                            <ItemTemplate>
                                                        <tr>
                                                             <td><asp:CheckBox ID="sectionid" runat="server" Text='<%# Eval("hotid") %>' /></td>
                                                            <td><%#Eval("productName") %></td>
                                                            <td><img src="product/small/<%#Eval("image") %>" width="60px" height="60px"></td>
                                                            <td><%#Eval("price") %></td>
                                                            <td><%#Eval("discount") %></td>
                                                            <td><%#Eval("size") %></td>
                                                             <td><asp:TextBox ID="txtPosition" runat="server" Text='<%#Eval("position") %>'></asp:TextBox></td>
                                                            
                                                        </tr>
                                                       </ItemTemplate>
                                                        </asp:Repeater>

                                                    </tbody>
                                                </table>
                                                </div> 
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                           
                                    
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

