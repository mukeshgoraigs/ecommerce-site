<%@ Page Title="" Language="C#" MasterPageFile="~/UrbanAdmin/AdminMasterPage.master" AutoEventWireup="true" CodeFile="Product.aspx.cs" Inherits="Product" %>

<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="container">
        <div class="row">
            <div class="col-md-12 col-sm-12">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <h3>Product Management</h3>
                    </div>
                    <div class="panel-body">
                        <ul class="nav nav-tabs">

                            <li class="active"><a href="#update" data-toggle="tab">All Products</a>
                            </li>
                            <li class=""><a href="#addnew" data-toggle="tab">Add Product</a>
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
                               

                                        <asp:Panel ID="viewPanel" runat="server">
                                            <h4>All Products</h4>
                                            <div class="col-md-3">
                                                <div class="panel panel-default">
                                                    <div class="panel-heading">
                                                        All Categores
                                                    </div>
                                                    <div class="panel-body">
                                                        <asp:TreeView ID="tvCategores" runat="server" LeafNodeStyle-ImageUrl="~/UrbanAdmin/assets/img/folder2.png" RootNodeStyle-ImageUrl="~/UrbanAdmin/assets/img/folder1.png" OnSelectedNodeChanged="tvCategores_SelectedNodeChanged">
                                                        </asp:TreeView>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-9">
                                                <!--    Hover Rows  -->
                                                <div class="panel panel-default">
                                                    <div class="panel-heading">
                                                        Products 
                                            <div class="pull-right">
                                                <asp:Button ID="btnDelete" runat="server" Text="Delete" CssClass="btn btn-danger" OnClick="btnDelete_Click" />
                                            </div>
                                                    </div>
                                                    <div class="panel-body">

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
                                                                        <th>Action</th>
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
                                                                        <th>Action</th>
                                                                    </tr>
                                                                </tfoot>

                                                                <tbody>
                                                                    <asp:Repeater ID="rpProduct" runat="server" OnItemCommand="rpProduct_ItemCommand" OnItemDataBound="rpProduct_ItemDataBound">
                                                                        <ItemTemplate>
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:CheckBox ID="productid" runat="server" Text='<%# Eval("id") %>' /></td>
                                                                                <td><%#Eval("productName") %></td>
                                                                                <td>
                                                                                    <img src="product/small/<%#Eval("image") %>" width="60px" height="60px"></td>
                                                                                <td><%#Eval("price") %></td>
                                                                                <td><%#Eval("discount") %></td>
                                                                                <td><%#Eval("size") %></td>
                                                                                <td><%#Eval("quantity") %></td>
                                                                                <td><%#Eval("code") %></td>
                                                                                <td>
                                                                                    <asp:Button ID="btnEdit" runat="server" Text="Edit  " CommandArgument='<%# Eval("id") %>' CommandName="edit" CssClass="btn btn-warning btn-sm" />

                                                                                    <asp:Button ID="btnMoreSize" runat="server" Text="Size" CommandArgument='<%# Eval("id") %>' CommandName="moresize" CssClass="btn-sm btn btn-info" />
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
                                            </div>
                                        </asp:Panel>
                                   
                                
                                        <asp:Panel ID="updatePanel" runat="server">
                                            <h4>Update Product Details</h4>
                                            <div class="panel panel-default">
                                                <div class="panel-heading">
                                                    Products Details
                                                </div>
                                                <div class="panel-body">

                                                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                        <ContentTemplate>
                                                            <div class="col-md-4">
                                                                <div class="form-group">
                                                                    <label for="exampleInputEmail1">Category Name </label>
                                                                    <asp:DropDownList ID="cmbCategoryUp" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="cmbCategoryUp_SelectedIndexChanged" />
                                                                </div>
                                                                <div class="form-group">
                                                                    <label for="exampleInputEmail1">Sub-Category Name </label>
                                                                    <asp:DropDownList ID="cmbSubCateUp" runat="server" CssClass="form-control" />
                                                                </div>
                                                                <div class="form-group">
                                                                    <label for="exampleInputEmail1">Product Name </label>
                                                                    <asp:TextBox ID="txtProductUp" runat="server" CssClass="form-control" placeholder="Enter Product Name" />
                                                                </div>
                                                                <div class="form-group">
                                                                    <label for="exampleInputEmail1">MRP Price </label>
                                                                    <asp:TextBox ID="txtPriceUp" runat="server" CssClass="form-control" placeholder="Enter MRP Price" />
                                                                </div>
                                                              
                                                                <div class="form-group">
                                                                    <label for="exampleInputEmail1">Offer Price</label>
                                                                    <asp:TextBox ID="txtNewPriceUp" AutoPostBack="true" OnTextChanged="txtNewPriceUp_Changed"  class="form-control" runat="server"></asp:TextBox>
                                                                </div>
                                                                  <div class="form-group">
                                                                    <label for="exampleInputEmail1">Discount</label>
                                                                    <asp:TextBox ID="txtDiscountUp" runat="server" CssClass="form-control" placeholder="Enter Discount" />
                                                                </div>
                                                                <div class="form-group">
                                                                    <label for="exampleInputEmail1">Tax</label>
                                                                    <asp:TextBox ID="txtTaxUp" class="form-control" runat="server"></asp:TextBox>
                                                                </div>
                                                                <div class="form-group">
                                                                    <label for="exampleInputEmail1">Product Type</label>
                                                                    <asp:DropDownList ID="cmbProductTypeUp" runat="server" CssClass="form-control">
                                                                        <asp:ListItem Value="1">Veg</asp:ListItem>
                                                                        <asp:ListItem Value="2">Non Veg</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </div>
                                                            </div>
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                    <div class="col-md-6">
                                                        <div class="form-group">
                                                            <label for="exampleInputEmail1">Product Description</label>
                                                            <CKEditor:CKEditorControl ID="txtDescriptionUp" BasePath="~/UrbanAdmin/ckeditor/" runat="server" Toolbar="Source
Bold|Italic|Underline|Strike|-|Subscript|Superscript
NumberedList|BulletedList|-|Outdent|Indent/
Styles|Format|Font|FontSize|TextColor|BGColor"
                                                                Height="100px">
                                                            </CKEditor:CKEditorControl>
                                                        </div>

                                                        <div class="form-group">
                                                            <label for="exampleInputEmail1">Product Code</label>
                                                            <asp:TextBox ID="txtCodeUp" runat="server" CssClass="form-control" placeholder="Enter Code" />
                                                        </div>
                                                        <div class="form-group">
                                                            <label for="exampleInputEmail1">Size</label>
                                                            <asp:TextBox ID="txtSizeUp" runat="server" CssClass="form-control" placeholder="Enter Size" />
                                                        </div>
                                                        <div class="form-group">
                                                            <label for="exampleInputEmail1">Quantity</label>
                                                            <asp:TextBox ID="txtQuantityUp" runat="server" CssClass="form-control" placeholder="Enter Quantity" />
                                                        </div>
                                                        <div class="form-group">
                                                            <label for="exampleInputEmail1">Product Image</label>
                                                            <asp:FileUpload ID="productImgUp" CssClass="form-control" runat="server" />

                                                        </div>
                                                    </div>
                                                    <div class="col-md-2">
                                                        <asp:Image ID="productImgDis" runat="server" />
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
                                                            <asp:TextBox ID="txtTitleUp" runat="server" class="form-control" placeholder="Enter Title" />
                                                        </div>
                                                        <div class="form-group">
                                                            <label for="exampleInputEmail1">Meta Keywords</label>
                                                            <asp:TextBox ID="txtMetaKeyUp" CssClass="form-control" runat="server" TextMode="MultiLine"></asp:TextBox>

                                                        </div>
                                                    </div>
                                                    <div class="col-md-4">
                                                        <div class="form-group">
                                                            <label for="exampleInputEmail1">Meta Description</label>
                                                            <asp:TextBox ID="txtMetaDesUp" CssClass="form-control" runat="server" TextMode="MultiLine" Rows="4"></asp:TextBox>
                                                        </div>
                                                        <div class="form-group">
                                                            <asp:Button ID="btnUpdate" runat="server" Text="Update Product" CssClass="btn btn-success" OnClick="btnUpdate_Click" />
                                                            <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="btn-danger" OnClick="btnCancel_Click" />
                                                        </div>
                                                    </div>
                                                </div>

                                            </div>
                                        </asp:Panel>
                                   

                           
                                        <asp:Panel ID="sizePanel" runat="server">
                                            <div class="panel panel-default">
                                                <div class="panel-heading">
                                                    Product Size Details
                                          <div class="pull-right">
                                             
                                                      <asp:Button ID="btnAddMore" runat="server" Text="Add More Size" CssClass="btn btn-success" OnClick="btnAddMore_Click" />
                                                      <asp:Button ID="btnEditMore" runat="server" Text="Edit Size" CssClass="btn btn-warning" OnClick="btnEditMore_Click" />
                                                      <asp:Button ID="btnDeleteMore" runat="server" Text="Delete Size" CssClass="btn btn-danger" OnClick="btnDeleteMore_Click" />
                                                
                                          </div>
                                                </div>
                                              

                                                        <asp:Panel ID="panelAddMore" runat="server">
                                                            <div class="panel-body">
                                                                <div class="col-md-3">
                                                                    <div class="form-group">

                                                                        <asp:Label ID="txtProductNameSize" runat="server" class="form-control" />
                                                                    </div>
                                                                    <div class="form-group">
                                                                        <label for="exampleInputEmail1">Select Number Of Size</label>

                                                                        <asp:DropDownList ID="cmbNumberOfSize" AutoPostBack="true" CssClass="form-control" runat="server" OnSelectedIndexChanged="cmbNumberOfSize_IndexChange">
                                                                            <asp:ListItem Value="0">---Select--</asp:ListItem>
                                                                            <asp:ListItem Value="1">1</asp:ListItem>
                                                                            <asp:ListItem Value="2">2</asp:ListItem>
                                                                            <asp:ListItem Value="3">3</asp:ListItem>
                                                                            <asp:ListItem Value="4">4</asp:ListItem>
                                                                            <asp:ListItem Value="5">5</asp:ListItem>
                                                                            <asp:ListItem Value="6">6</asp:ListItem>
                                                                            <asp:ListItem Value="7">7</asp:ListItem>
                                                                            <asp:ListItem Value="8">8</asp:ListItem>
                                                                            <asp:ListItem Value="9">9</asp:ListItem>
                                                                            <asp:ListItem Value="10">10</asp:ListItem>
                                                                        </asp:DropDownList>



                                                                    </div>
                                                                    <div class="form-group">
                                                                        <asp:Button ID="btnAddMoreSize" runat="server" Text="Submit" CssClass="btn btn-success" OnClick="btnAddMoreSize_Click" />
                                                                        <asp:Button ID="btnCancelMoreSize" runat="server" Text="Cancel" CssClass="btn-danger" OnClick="btnCancelMoreSize_Click" />
                                                                    </div>
                                                                </div>
                                                                <div class="col-md-9">
                                                                    <div class="form-group">
                                                                        <div class="table-responsive">

                                                                            <table id="Table1" class="table table-striped table-bordered" cellspacing="0" width="100%">
                                                                                <thead>
                                                                                    <tr>
                                                                                        <th>Size</th>
                                                                                        <th>Price</th>
                                                                                        <th>Discount Price</th>
                                                                                        <th>Quantity</th>

                                                                                    </tr>
                                                                                </thead>

                                                                                <tfoot>
                                                                                    <tr>
                                                                                        <th>Size</th>
                                                                                        <th>Price</th>
                                                                                        <th>Discount Price</th>
                                                                                        <th>Quantity</th>
                                                                                    </tr>
                                                                                </tfoot>

                                                                                <tbody>
                                                                                    <asp:Repeater ID="rpMySize" runat="server">
                                                                                        <ItemTemplate>
                                                                                            <tr>
                                                                                                <td>
                                                                                                    <asp:TextBox ID="txtMoreSize" runat="server"></asp:TextBox></td>
                                                                                                <td>
                                                                                                    <asp:TextBox ID="txtMorePrice" runat="server"></asp:TextBox></td>
                                                                                                <td>
                                                                                                    <asp:TextBox ID="txtMoreDiscountPr" runat="server"></asp:TextBox></td>
                                                                                                <td>
                                                                                                    <asp:TextBox ID="txtMoreQuantity" runat="server"></asp:TextBox></td>


                                                                                            </tr>
                                                                                        </ItemTemplate>
                                                                                    </asp:Repeater>

                                                                                </tbody>
                                                                                </table>
                                                                        </div>
                                                                    </div>

                                                                </div>

                                                            </div>
                                                        </asp:Panel>
                                              
                                                        <asp:Panel ID="panelViewMore" runat="server">
                                                            <div class="panel-body">
                                                                <div class="col-md-12">
                                                                    <div class="form-group">

                                                                        <div class="table-responsive">

                                                                            <table id="Table2" class="table table-striped table-bordered" cellspacing="0" width="100%">
                                                                                <thead>
                                                                                    <tr>
                                                                                        <th>S.No</th>
                                                                                        <th>Select</th>
                                                                                        <th>Size</th>
                                                                                        <th>Price</th>
                                                                                        <th>Discount Price</th>
                                                                                        <th>Quantity</th>

                                                                                    </tr>
                                                                                </thead>

                                                                                <tfoot>
                                                                                    <tr>
                                                                                        <th>S.No</th>
                                                                                        <th>Select</th>
                                                                                        <th>Size</th>
                                                                                        <th>Price</th>
                                                                                        <th>Discount Price</th>
                                                                                        <th>Quantity</th>

                                                                                    </tr>
                                                                                </tfoot>

                                                                                <tbody>
                                                                                    <asp:Repeater ID="rpMoreSizeView" runat="server">
                                                                                        <ItemTemplate>
                                                                                            <tr>
                                                                                                <td>
                                                                                                    <asp:Label ID="lblSizeId" runat="server" Text='<%#Eval("id") %>'></asp:Label></td>
                                                                                                <td>
                                                                                                    <asp:CheckBox ID="chkSize" runat="server"></asp:CheckBox></td>
                                                                                                <td>
                                                                                                    <asp:TextBox ID="lblMoreSize" Text='<%#Eval("vsize") %>' runat="server"></asp:TextBox></td>
                                                                                                <td>
                                                                                                    <asp:TextBox ID="lblMorePrice" Text='<%#Eval("vprice") %>' runat="server"></asp:TextBox></td>
                                                                                                <td>
                                                                                                    <asp:TextBox ID="lblMoreDiscountPr" Text='<%#Eval("vnewprice") %>' runat="server"></asp:TextBox></td>
                                                                                                <td>
                                                                                                    <asp:TextBox ID="lblMoreQuantity" Text='<%#Eval("vquantity") %>' runat="server"></asp:TextBox></td>


                                                                                            </tr>
                                                                                        </ItemTemplate>
                                                                                    </asp:Repeater>

                                                                                </tbody>
                                                                            </table>


                                                                        </div>

                                                                    </div>
                                                                    <div class="form-group">

                                                                        <asp:Button ID="btnUpdateMore" runat="server" Text="Update" CssClass="btn btn-warning" OnClick="btnUpdateMore_Click" />
                                                                        <asp:Button ID="btnCancelUpdateMore" runat="server" Text="Cancel" CssClass="btn btn-danger" OnClick="btnCancelUpdateMore_Click" />


                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </asp:Panel>
                                                  
                                            </div>
                                        </asp:Panel>
                                   >
                            </div>





                            <div class="tab-pane fade" id="addnew">



                                <h4>Add Products</h4>
                                <div class="panel panel-default">
                                    <div class="panel-heading">
                                        Products Details
                                    </div>
                                    <div class="panel-body">

                                        <asp:UpdatePanel ID="productUpdatePanel" runat="server">
                                            <ContentTemplate>
                                                <div class="col-md-4">
                                                    <div class="form-group">
                                                        <label for="exampleInputEmail1">Category Name </label>
                                                        <asp:DropDownList ID="cmbCategory" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="cmbCategory_SelectedIndexChanged" />
                                                    </div>
                                                    <div class="form-group">
                                                        <label for="exampleInputEmail1">Sub-Category Name </label>
                                                        <asp:DropDownList ID="cmbSubCategory" runat="server" CssClass="form-control" />
                                                    </div>
                                                    <div class="form-group">
                                                        <label for="exampleInputEmail1">Product Name </label>
                                                        <asp:TextBox ID="txtProductName" runat="server" CssClass="form-control" placeholder="Enter Product Name" />
                                                    </div>
                                                    <div class="form-group">
                                                        <label for="exampleInputEmail1">MRP Price </label>
                                                        <asp:TextBox ID="txtPrice" runat="server" CssClass="form-control" placeholder="Enter MRP Price" />
                                                    </div>
                                                      <div class="form-group">
                                                        <label for="exampleInputEmail1">Offer Price</label>
                                                        <asp:TextBox ID="txtDiscountPr" AutoPostBack="true" OnTextChanged="txtDiscount_TextChanged" class="form-control" runat="server"></asp:TextBox>
                                                    </div>
                                                    <div class="form-group">
                                                        <label for="exampleInputEmail1">Discount</label>
                                                        <asp:Label ID="txtDiscount" runat="server" CssClass="form-control"/>
                                                    </div>
                                                  
                                                     <div class="form-group">
                                                                    <label for="exampleInputEmail1">Tax</label>
                                                                    <asp:TextBox ID="txtTax" class="form-control" placeholder="Tax" runat="server"></asp:TextBox>
                                                                </div>
                                                    <div class="form-group">
                                                        <label for="exampleInputEmail1">Product Type</label>
                                                        <asp:DropDownList ID="cmbProductType" runat="server" CssClass="form-control">
                                                            <asp:ListItem Value="1">Veg</asp:ListItem>
                                                            <asp:ListItem Value="2">Non Veg</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label for="exampleInputEmail1">Product Description</label>
                                                <CKEditor:CKEditorControl ID="txtProductDescription" BasePath="~/UrbanAdmin/ckeditor/" runat="server" Toolbar="Source
Bold|Italic|Underline|Strike|-|Subscript|Superscript
NumberedList|BulletedList|-|Outdent|Indent/
Styles|Format|Font|FontSize|TextColor|BGColor"
                                                    Height="100px">
                                                </CKEditor:CKEditorControl>
                                            </div>

                                            <div class="form-group">
                                                <label for="exampleInputEmail1">Product Code</label>
                                                <asp:TextBox ID="txtCode" runat="server" CssClass="form-control" placeholder="Enter Code" />
                                            </div>
                                            <div class="form-group">
                                                <label for="exampleInputEmail1">Size</label>
                                                <asp:TextBox ID="txtSize" runat="server" CssClass="form-control" placeholder="Enter Size" />
                                            </div>
                                            <div class="form-group">
                                                <label for="exampleInputEmail1">Quantity</label>
                                                <asp:TextBox ID="txtQuantity" runat="server" CssClass="form-control" placeholder="Enter Quantity" />
                                            </div>
                                            <div class="form-group">
                                                <label for="exampleInputEmail1">Product Image</label>
                                                <asp:FileUpload ID="ProductImg" CssClass="form-control" runat="server" />

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
                                                <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-success" OnClick="btnSave_Click" />
                                                <asp:Button ID="btnReset" runat="server" Text="Reset" CssClass="btn-danger" OnClick="btnReset_Click" />
                                            </div>
                                        </div>
                                    </div>

                                </div>


                            </div>



                            <div class="tab-pane fade" id="uploadExcel">
                                <asp:UpdatePanel ID="updatePanelExelUp" runat="server">
                                    <ContentTemplate>

                                <h4>Upload All Products Using Excel</h4>
                                <div class="panel panel-default">
                                    <div class="panel-heading">
                                        Excel Products Upload
                                    </div>

                                    <div class="panel-body">
                                        <div class="col-md-4">
                                            <div class="form-group">
                                                <label for="exampleInputEmail1">Category Name</label>
                                                <asp:DropDownList ID="cmbCategoryEx" CssClass="form-control" runat="server" AutoPostBack="true" OnSelectedIndexChanged="cmbCategoryEx_IndexChange" />

                                            </div>
                                            <div class="form-group">
                                                <label for="exampleInputEmail1">Sub-Category Name</label>
                                                <asp:DropDownList ID="cmbSubCateEx" CssClass="form-control" runat="server" />

                                            </div>
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
                                        
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:PostBackTrigger ControlID="btnUploadExcel" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </div>
                            <div class="tab-pane fade" id="updateExcel">
                                <h4>Update All Products Using Excel</h4>
                                <div class="panel panel-default">
                                    <div class="panel-heading">
                                        Excel Products Update
                                    </div>

                                    <div class="panel-body">
                                        <div class="col-md-4">
                                           <asp:UpdatePanel ID="updatePanelexUp" runat="server">
                                               <ContentTemplate>
                                             <div class="form-group">
                                                                    <label for="exampleInputEmail1">Category Name </label>
                                                                    <asp:DropDownList ID="cmbCategoryExUp" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="cmbCategoryExUp_SelectedIndexChanged" />
                                                                </div>
                                                   
                                                                <div class="form-group">
                                                                    <label for="exampleInputEmail1">Sub-Category Name </label>
                                                                    <asp:DropDownList ID="cmbSubCateExUp" runat="server" CssClass="form-control" />
                                                                </div>
                                                   </ContentTemplate>
                                               </asp:UpdatePanel>
                                            <div class="form-group">
                                                <asp:Button ID="btnExcelExport" runat="server" Text="Export Excel" OnClick="btnExcelExport_Click" CssClass="btn btn-success" />
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
                                <h4>Update All Products Image</h4>
                                <div class="panel panel-default">
                                    <div class="panel-heading">
                                        Products Image Update
                                    </div>

                                    <div class="panel-body">
                                        <div class="col-md-4">
                                            <div class="form-group">
                                                <label for="exampleInputEmail1">Select Images</label>
                                                <asp:FileUpload ID="uploadProImage" AllowMultiple="true" CssClass="form-control" runat="server" />

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
</asp:Content>

