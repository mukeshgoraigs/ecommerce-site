<%@ Page Title="" Language="C#" MasterPageFile="~/UrbanAdmin/AdminMasterPage.master" AutoEventWireup="true" CodeFile="Slider.aspx.cs" Inherits="UrbanAdmin_SliderData" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <div class="container">
        <div class="row">
            <div class="col-md-12 col-sm-12">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <h3>Slider Management</h3>
                    </div>
                    <div class="panel-body">
                        <ul class="nav nav-tabs">

                            <li class="active"><a href="#update" data-toggle="tab">All Slides</a>
                            </li>
                            <li class=""><a href="#addnew" data-toggle="tab">Add Slide</a>
                            </li>
                           
                        </ul>

                        <div class="tab-content">

                            <div class="tab-pane fade active in" id="update">
                                <h4>All Slides</h4>
                                
                                <div class="col-md-12">
                                    <!--    Hover Rows  -->
                                    <asp:Panel ID="viewPanel" runat="server">
                                    <div class="panel panel-default">
                                        <div class="panel-heading">
                                            Slides
                                             <div class="pull-right"><asp:Button ID="btnDelete" runat="server" Text="Delete" CssClass="btn btn-danger" OnClick="btnDelete_Click"   /></div>
                                        </div>
                                        
                                            <div class="panel-body">
                                                <div class="table-responsive">
                                                    <table id="example" class="table table-striped table-bordered" cellspacing="0" width="100%">
                                                        <thead>
                                                            <tr>
                                                                <th>S.No</th>
                                                                <th>Image</th>
                                                                <th>Link</th>
                                                                <th>Is Active</th>
                                                                <th>Offer</th>
                                                               <th>About Offer</th>
                                                                 <th>Action</th>
                                                            </tr>
                                                        </thead>

                                                        <tfoot>
                                                            <tr>
                                                                <th>S.No</th>
                                                                <th>Image</th>
                                                                <th>Link</th>
                                                                <th>Is Active</th>
                                                                <th>Offer</th>
                                                               <th>About Offer</th>
                                                                <th>Action</th>
                                                            </tr>
                                                        </tfoot>

                                                        <tbody>
                                                            <asp:Repeater ID="rpSilder" runat="server" OnItemCommand="rpProduct_ItemCommand" OnItemDataBound="rpProduct_ItemDataBound">
                                                                <ItemTemplate>
                                                                    <tr>
                                                                       
                                                                <td><asp:CheckBox ID="sliderid" runat="server" Text='<%# Eval("id") %>' /></td>
                                                                <td><img width="150px" height="70px" class="img-responsive" src="slider/<%#Eval("imagename") %>" /></td>
                                                                <td><%#Eval("link") %></td>
                                                                <td><%#Eval("isvisible") %></td>
                                                                <td><%#Eval("offer") %></td>
                                                               <td><%#Eval("aboutoffer") %></td>
                                                                <td><asp:Button ID="btnEdit" runat="server" Text="Edit" CommandArgument='<%# Eval("id") %>' CommandName="edit"  CssClass="btn btn-warning" /></td>        
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
                                        Slider Details For Update
                                    </div>
                                    <div class="panel-body">
                                        <div class="col-md-6">
                                            <div class="form-group">
                                            <label>Slider Image</label>
                                           <asp:FileUpload ID="sliderUploadUp" runat="server" class="form-control" />
                                        </div>
                                     <div class="form-group">
                                            <label>Offer</label>
                                            <asp:TextBox ID="txtOfferUp" runat="server" class="form-control"></asp:TextBox>
                                        </div>
                                     <div class="form-group">
                                            <label>About Offer</label>
                                           <asp:TextBox ID="txtAboutOfferUp" runat="server" class="form-control"></asp:TextBox>
                                        </div>
                                        <div class="form-group">
                                            <label>URL</label>
                                            <asp:TextBox ID="txtLinkUp" runat="server" class="form-control"></asp:TextBox>
                                            
                                        </div>
                                         <div class="form-group">
                                            <label>Is Visible ?</label>
                                             <asp:CheckBox ID="chkVisibleUp" Text="Do you want to display ?" class="form-control" runat="server" />
                                            
                                        </div>
                                      
                                     
                                         
                                         <div class="form-group">

                                             <asp:Button ID="btnUpdate" class="btn btn-success" runat="server" Text="Update" onclick="btnUpdate_Click" />
                                              <asp:Button ID="btnCancel" class="btn btn-danger" runat="server" Text="Cancel" OnClick="btnCancel_Click" 
                                                  />
                                        </div>

                                        </div>
                                       <div class="col-md-6">
                                            <div class="form-group">
                                            <label>Slider Image </label>
                                             <asp:Image CssClass="img-responsive" ID="sliderImage" runat="server" />
                                            
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
                                <h4>Add Slider</h4>
                                <div class="col-md-3"></div>
                                <div class="col-md-6">
                                <div class="panel panel-default">
                                    <div class="panel-heading">
                                        Slider Details
                                    </div>
                                    <div class="panel-body">
                                        <div class="col-md-11">
                                             <div class="form-group">
                                            <label>Slider Image</label>
                                           <asp:FileUpload ID="sliderUpload" runat="server" class="form-control" />
                                        </div>
                                     <div class="form-group">
                                            <label>Offer</label>
                                            <asp:TextBox ID="txtOffer" runat="server" class="form-control"></asp:TextBox>
                                        </div>
                                     <div class="form-group">
                                            <label>About Offer</label>
                                           <asp:TextBox ID="txtAboutOffer" runat="server" class="form-control"></asp:TextBox>
                                        </div>
                                        <div class="form-group">
                                            <label>URL</label>
                                            <asp:TextBox ID="txtUrl" runat="server" class="form-control"></asp:TextBox>
                                            
                                        </div>
                                         <div class="form-group">
                                            <label>Is Visible ?</label>
                                             <asp:CheckBox ID="chkIsVisible" Text="Do you want to display ?" class="form-control" runat="server" />
                                            
                                        </div>
                                      
                                     
                                         
                                         <div class="form-group">

                                             <asp:Button ID="btnUpload" class="btn btn-success" runat="server" Text="Upload" onclick="btnUpload_Click"
                                                 />
                                              <asp:Button ID="Button1" class="btn btn-danger" runat="server" Text="Reset" 
                                                  />
                                        </div>

                                    
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

