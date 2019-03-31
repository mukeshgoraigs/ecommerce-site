<%@ Page Title="" Language="C#" MasterPageFile="~/UrbanAdmin/AdminMasterPage.master" AutoEventWireup="true" CodeFile="Category.aspx.cs" Inherits="Category" %>

<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container">
        <div class="row">
            <div class="col-md-12 col-sm-12">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <h3>Category Management</h3>
                    </div>
                    <div class="panel-body">
                        <ul class="nav nav-tabs">

                            <li class="active"><a href="#update" data-toggle="tab">All Category</a>
                            </li>
                            <li class=""><a href="#addnew" data-toggle="tab">Add Category</a>
                            </li>
                            <li class=""><a href="#uploadExcel" data-toggle="tab">Upload Excel</a>
                            </li>
                            <li class=""><a href="#updateExcel" data-toggle="tab">Update Excel</a>
                            </li>
                             <li class=""><a href="#uploadImage" data-toggle="tab">Upload Image</a>
                            </li>
                        </ul>

                        <div class="tab-content">

                            <div class="tab-pane fade active in" id="update">
                                <h4>All Categores</h4>
                                <div class="col-md-3">
                                    <div class="panel panel-default">
                                        <div class="panel-heading">
                                            Categores
                                            
                                        </div>
                                        <div class="panel-body">
                                            <asp:TreeView ID="tvCategores" runat="server" LeafNodeStyle-ImageUrl="~/UrbanAdmin/assets/img/folder2.png" RootNodeStyle-ImageUrl="~/UrbanAdmin/assets/img/folder1.png" OnSelectedNodeChanged="tvCategores_SelectedNodeChanged">
                                            </asp:TreeView>
                                        </div>
                                    </div>
                                </div>

                                <div class="col-md-9">
                                    <!--    Hover Rows  -->
                                    <asp:Panel ID="addPanel" runat="server">
                                    <div class="panel panel-default">
                                        <div class="panel-heading">
                                            Categores
                                             <div class="pull-right"><asp:Button ID="btnDelete" runat="server" Text="Delete" CssClass="btn btn-danger" OnClick="btnDelete_Click" /></div>
                                        </div>
                                        
                                            <div class="panel-body">
                                                <div class="table-responsive">
                                                    <table id="example" class="table table-striped table-bordered" cellspacing="0" width="100%">
                                                        <thead>
                                                            <tr>
                                                                <th>S.No</th>
                                                                <th>Category</th>
                                                                <th>Image</th>
                                                                <th>Title</th>
                                                                <th>Meta Key</th>
                                                                <th>Meta Description</th>
                                                               
                                                            </tr>
                                                        </thead>

                                                        <tfoot>
                                                            <tr>
                                                                <th>S.No</th>
                                                                <th>Category</th>
                                                                <th>Image</th>
                                                                <th>Title</th>
                                                                <th>Meta Key</th>
                                                                <th>Meta Description</th>
                                                                
                                                            </tr>
                                                        </tfoot>

                                                        <tbody>
                                                            <asp:Repeater ID="rpCategory" runat="server">
                                                                <ItemTemplate>
                                                                    <tr>
                                                                        <td><asp:CheckBox ID="categoryid" runat="server" Text='<%# Eval("id") %>' /></td>
                                                                        <td><%#Eval("categoryName") %></td>
                                                                        <td>
                                                                            <img src="category/small/<%#Eval("image") %>" width="60px" height="60px"></td>
                                                                        <td><%#Eval("pagetitle") %></td>
                                                                        <td><%#Eval("metakey") %></td>
                                                                        <td><%#Eval("metadescription") %></td>
                                                                        
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
                                        Category Details For Update
                                    </div>
                                    <div class="panel-body">
                                        <div class="col-md-4">
                                            <div class="form-group">
                                                <label for="exampleInputEmail1">Category Name </label>
                                                <asp:TextBox ID="txtCategoryUp" runat="server" CssClass="form-control" placeholder="Enter Category" />
                                            </div>
                                            <div class="form-group">
                                                <label for="exampleInputEmail1">Category Image</label>
                                                <asp:FileUpload ID="categoryImgUp" CssClass="form-control" runat="server" />

                                            </div>
                                             <div class="form-group">
                                                <asp:Image ID="catimgup" runat="server" />

                                            </div>
                                        </div>
                                        <div class="col-md-8">
                                            <div class="form-group">
                                                <label for="exampleInputEmail1">Category Description</label>
                                                <CKEditor:CKEditorControl ID="txtDescriptionUp" BasePath="~/UrbanAdmin/ckeditor/" runat="server" Toolbar="Source
Bold|Italic|Underline|Strike|-|Subscript|Superscript
NumberedList|BulletedList|-|Outdent|Indent/
Styles|Format|Font|FontSize|TextColor|BGColor"
                                                    Height="70px">
                                                </CKEditor:CKEditorControl>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="panel-footer text-muted">
                                    </div>
                                </div>
 <div class="panel panel-default">
                                    <div class="panel-heading">
                                        SEO Details
                                    </div>
                                    <div class="panel-body">
                                        <div class="col-md-4">
                                            <div class="form-group">
                                                <label for="exampleInputEmail1">Title</label>
                                                <asp:TextBox ID="txtPageTitleUp" runat="server" class="form-control" placeholder="Enter Title" />
                                            </div>
                                            <div class="form-group">
                                                <label for="exampleInputEmail1">Meta Keywords</label>
                                                <asp:TextBox ID="txtMetaKeyUp" CssClass="form-control" runat="server" TextMode="MultiLine"></asp:TextBox>

                                            </div>
                                        </div>
                                        <div class="col-md-4">
                                            <div class="form-group">
                                                <label for="exampleInputEmail1">Meta Description</label>
                                                <asp:TextBox ID="txtMetaDescriptionUp" CssClass="form-control" runat="server" TextMode="MultiLine" Rows="4"></asp:TextBox>
                                            </div>
                                            <div class="form-group">
                                                <asp:Button ID="btnUpdate" runat="server" Text="Update" CssClass="btn btn-success" OnClick="btnUpdate_Click" />
                                                <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="btn btn-danger" OnClick="btnCancel_Click" />
                                            </div>
                                        </div>
                                    </div>

                                </div>
                                        </asp:Panel>
                                </div>


                            </div>





                            <div class="tab-pane fade" id="addnew">
                                <h4>Add Category</h4>
                                <div class="panel panel-default">
                                    <div class="panel-heading">
                                        Category Details
                                    </div>
                                    <div class="panel-body">
                                        <div class="col-md-4">
                                            <div class="form-group">
                                                <label for="exampleInputEmail1">Category Name </label>
                                                <asp:TextBox ID="txtCategory" runat="server" CssClass="form-control" placeholder="Enter Category" />
                                            </div>
                                            <div class="form-group">
                                                <label for="exampleInputEmail1">Category Image</label>
                                                <asp:FileUpload ID="categoryImg" CssClass="form-control" runat="server" />

                                            </div>
                                        </div>
                                        <div class="col-md-8">
                                            <div class="form-group">
                                                <label for="exampleInputEmail1">Category Description</label>
                                                <CKEditor:CKEditorControl ID="txtDescription" BasePath="~/UrbanAdmin/ckeditor/" runat="server" Toolbar="Source
Bold|Italic|Underline|Strike|-|Subscript|Superscript
NumberedList|BulletedList|-|Outdent|Indent/
Styles|Format|Font|FontSize|TextColor|BGColor"
                                                    Height="70px">
                                                </CKEditor:CKEditorControl>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="panel-footer text-muted">
                                    </div>
                                </div>
                                <div class="panel panel-default">
                                    <div class="panel-heading">
                                        SEO Details
                                    </div>
                                    <div class="panel-body">
                                        <div class="col-md-4">
                                            <div class="form-group">
                                                <label for="exampleInputEmail1">Title</label>
                                                <asp:TextBox ID="txtTitle" runat="server" class="form-control" placeholder="Enter Title" />
                                            </div>
                                            <div class="form-group">
                                                <label for="exampleInputEmail1">Meta Keywords</label>
                                                <asp:TextBox ID="txtMetaKey" CssClass="form-control" runat="server" TextMode="MultiLine"></asp:TextBox>

                                            </div>
                                        </div>
                                        <div class="col-md-4">
                                            <div class="form-group">
                                                <label for="exampleInputEmail1">Meta Description</label>
                                                <asp:TextBox ID="txtMetaDescription" CssClass="form-control" runat="server" TextMode="MultiLine" Rows="4"></asp:TextBox>
                                            </div>
                                            <div class="form-group">
                                                <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-success" OnClick="btnUpload_Click" />
                                                <asp:Button ID="btnReset" runat="server" Text="Reset" CssClass="btn-danger" OnClick="btnReset_Click" />
                                            </div>
                                        </div>
                                    </div>

                                </div>
                            </div>



                            <div class="tab-pane fade" id="uploadExcel">
                                <h4>Upload All Categotres Using Excel</h4>
                                <div class="panel panel-default">
                                    <div class="panel-heading">
                                        Excel Category Upload
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
                                <h4>Update All Categotres Using Excel</h4>
                                <div class="panel panel-default">
                                    <div class="panel-heading">
                                        Excel Category Update
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
                            <div class="tab-pane fade" id="uploadImage">
                                <h4>Update All Category Image</h4>
                                <div class="panel panel-default">
                                    <div class="panel-heading">
                                        Category Image Update
                                    </div>

                                    <div class="panel-body">
                                        <div class="col-md-4">
                                            <div class="form-group">
                                                <label for="exampleInputEmail1">Select Images</label>
                                                <asp:FileUpload ID="uploadCatImage" AllowMultiple="true" CssClass="form-control" runat="server" />

                                            </div>
                                            <div class="form-group">
                                                <asp:Button ID="btnUploadImage" runat="server" Text="Update Images" CssClass="btn btn-success" OnClick="btnImageUpload_Click" />
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

