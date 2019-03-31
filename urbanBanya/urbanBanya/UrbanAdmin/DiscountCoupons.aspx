<%@ Page Title="" Language="C#" MasterPageFile="~/UrbanAdmin/AdminMasterPage.master" AutoEventWireup="true" CodeFile="DiscountCoupons.aspx.cs" Inherits="UrbanAdmin_DiscountCoupons" %>

<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script>
        $(document).ready(function () {
            $(".f-date-picker").datepicker({ dateFormat: 'yy-mm-dd' });
            $(".t-date-picker").datepicker({ dateFormat: 'yy-mm-dd' });

        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="container">
        <div class="row">
            <div class="col-md-12 col-sm-12">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <h3>Discount Counpons Management</h3>
                    </div>
                    <div class="panel-body">
                        <ul class="nav nav-tabs">

                            <li class="active"><a href="#update" data-toggle="tab">Add New Coupons</a>
                            </li>
                            <li class=""><a href="#addnew" data-toggle="tab">Update Coupons</a>
                            </li>

                        </ul>

                        <div class="tab-content">

                            <div class="tab-pane fade active in" id="update">
                                <h4>Coupons Details</h4>
                                <div class="col-md-4">
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
                                <div class="col-md-8">
                                    <!--    Hover Rows  -->
                                    <asp:Panel ID="addNewPanel" runat="server">
                                        <div class="panel panel-default">
                                            <div class="panel-heading">
                                                Sub-Categores
                                           
                                            </div>
                                            <div class="panel-body">
                                                <div class="table-responsive">
                                                    <table id="example" class="table table-striped table-bordered" cellspacing="0" width="100%">
                                                        <thead>
                                                            <tr>
                                                                <th>S.No</th>
                                                                <th>Sub-Category</th>
                                                                <th>Image</th>
                                                            </tr>
                                                        </thead>

                                                        <tfoot>
                                                            <tr>
                                                                <th>S.No</th>
                                                                <th>Sub-Category</th>
                                                                <th>Image</th>
                                                            </tr>
                                                        </tfoot>

                                                        <tbody>
                                                            <asp:Repeater ID="rpSubCategory" runat="server">
                                                                <ItemTemplate>
                                                                    <tr>
                                                                        <td>
                                                                            <asp:CheckBox ID="subcateid" runat="server" Text='<%# Eval("id") %>' /></td>
                                                                        <td><%#Eval("subCategoryName") %></td>
                                                                        <td>
                                                                            <img src="subcategory/small/<%#Eval("image") %>" width="60px" height="60px"></td>
                                                                    </tr>
                                                                </ItemTemplate>
                                                            </asp:Repeater>



                                                        </tbody>
                                                    </table>
                                                </div>
                                            </div>
                                        </div>
                                    </asp:Panel>

                                    <div class="panel panel-default">
                                        <div class="panel-heading">
                                            Coupon Details
                                        </div>
                                        <div class="panel-body">
                                            <div class="col-md-5">
                                                <div class="form-group">
                                                    <div class="controls">
                                                        <div class="input-group">
                                                            <label for="datefrom" class="input-group-addon btn">
                                                                <span class="glyphicon glyphicon-font"></span>

                                                            </label>
                                                            <asp:TextBox runat="server" ID="txtCouponName" placeholder="Coupon ,Example JAN50" type="text" class="form-control" />
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="form-group">
                                                    <div class="controls">
                                                        <div class="input-group">
                                                            <label for="datefrom" class="input-group-addon btn">
                                                                <span class="glyphicon glyphicon-font"></span>

                                                            </label>
                                                            <asp:TextBox runat="server" ID="txtMinimumAmount" placeholder="Minimum Amount" type="text" class="form-control" />
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="form-group">
                                                    <div class="controls">
                                                        <div class="input-group">
                                                            <label for="datefrom" class="input-group-addon btn">
                                                                <span class="glyphicon glyphicon-font"></span>

                                                            </label>
                                                            <asp:TextBox runat="server" ID="txtDiscount" placeholder="Discount" type="text" class="form-control" />
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="form-group">
                                                    <div class="controls">
                                                        <div class="input-group">
                                                            <label for="datefrom" class="input-group-addon btn">
                                                                <span class="glyphicon glyphicon-calendar"></span>

                                                            </label>
                                                            <asp:TextBox runat="server" ID="datefrom" placeholder="Date from " type="text" class="f-date-picker form-control" />
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="form-group">
                                                    <div class="controls">
                                                        <div class="input-group">
                                                            <label runat="server" for="dateto" class="input-group-addon btn">
                                                                <span class="glyphicon glyphicon-calendar"></span>

                                                            </label>
                                                            <asp:TextBox runat="server" ID="dateto" placeholder="Date To " type="text" class="t-date-picker form-control" />
                                                        </div>
                                                    </div>
                                                </div>

                                                <div class="form-group">
                                                    <asp:Button ID="btnGenerateCoupon" runat="server" CssClass="btn btn-success" Text="Generate Coupon" OnClick="btnGenerateCoupon_Click" />
                                                </div>
                                            </div>
                                            <div class="col-md-7">
                                                <div class="form-group">

                                                    <CKEditor:CKEditorControl ID="txtDescription" placeholder="Description" BasePath="~/UrbanAdmin/ckeditor/" runat="server" Toolbar="Source
Bold|Italic|Underline|Strike|-|Subscript|Superscript
NumberedList|BulletedList|-|Outdent|Indent/
Styles|Format|Font|FontSize|TextColor|BGColor"
                                                        Height="70px">
                                                    </CKEditor:CKEditorControl>
                                                </div>
                                                <div class="form-group">
                                                    <asp:FileUpload ID="couponImage" runat="server" CssClass="form-control" />
                                                </div>
                                            </div>
                                        </div>
                                        <div class="panel-footer text-muted">
                                        </div>
                                    </div>


                                    <!-- End  Hover Rows  -->
                                </div>

                            </div>





                            <div class="tab-pane fade" id="addnew">
                                <h4>Discount Counpons Management</h4>
                                <asp:UpdatePanel ID="updatepanelShow" runat="server">
                                    <ContentTemplate>

                                        <asp:Panel ID="viewPanel" runat="server">
                                            <div class="panel panel-default">
                                                <div class="panel-heading">
                                                    Coupons
                                           
                                                </div>
                                                <div class="panel-body">
                                                    <div class="table-responsive">
                                                        <table id="example1" class="table table-striped table-bordered" cellspacing="0" width="100%">
                                                            <thead>
                                                                <tr>
                                                                    <th>S.No</th>
                                                                    <th>Coupons</th>
                                                                    <th>Minimum Amount</th>
                                                                    <th>Discount</th>
                                                                    <th>Start Date</th>
                                                                    <th>End Date</th>
                                                                    <th>Description</th>
                                                                    <th>Action</th>
                                                                </tr>
                                                            </thead>

                                                            <tfoot>
                                                                <tr>
                                                                    <th>S.No</th>
                                                                    <th>Coupons</th>
                                                                    <th>Minimum Amount</th>
                                                                    <th>Discount</th>
                                                                    <th>Start Date</th>
                                                                    <th>End Date</th>
                                                                    <th>Description</th>
                                                                    <th>Action</th>
                                                                </tr>
                                                            </tfoot>

                                                            <tbody>
                                                                <asp:Repeater ID="rpCoupons" runat="server" OnItemCommand="rpCoupons_ItemCommand">
                                                                    <ItemTemplate>
                                                                        <tr>
                                                                            <td>
                                                                                <asp:CheckBox ID="subcateid" runat="server" Text='<%# Eval("id") %>' /></td>
                                                                            <td><%# Eval("name") %></td>
                                                                            <td><%# Eval("minimumamount") %></td>
                                                                            <td><%# Eval("discount") %></td>
                                                                            <td><%# Eval("start_date").ToString().Replace(" 12:00:00 AM", "") %></td>
                                                                            <td><%# Eval("end_date").ToString().Replace(" 12:00:00 AM", "") %></td>
                                                                            <td><%# Eval("description") %></td>
                                                                            <td>
                                                                                <asp:Button ID="btnEdit" runat="server" Text="Edit" CommandName="edit" CssClass="btn btn-sm btn-warning" CommandArgument='<%# Eval("id") %>' />
                                                                                <asp:Button ID="btnDelete" runat="server" Text="Delete" CommandName="delete" CssClass="btn btn-sm btn-danger" CommandArgument='<%# Eval("id") %>' /></td>
                                                                        </tr>
                                                                    </ItemTemplate>
                                                                </asp:Repeater>



                                                            </tbody>
                                                        </table>
                                                    </div>
                                                </div>
                                            </div>
                                        </asp:Panel>


                                        <asp:Panel ID="updatePanel" runat="server">
                                            <h4>Coupons Details</h4>
                                            <div class="col-md-4">
                                                <div class="panel panel-default">
                                                    <div class="panel-heading">
                                                        Categores
                                             
                                                    </div>
                                                    <div class="panel-body">
                                                        <asp:TreeView ID="tvCategoresUp" runat="server" LeafNodeStyle-ImageUrl="~/UrbanAdmin/assets/img/folder2.png" RootNodeStyle-ImageUrl="~/UrbanAdmin/assets/img/folder1.png" OnSelectedNodeChanged="tvCategoresUp_SelectedNodeChanged">
                                                        </asp:TreeView>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-8">
                                                <!--    Hover Rows  -->
                                                <asp:Panel ID="Panel1" runat="server">
                                                    <div class="panel panel-default">
                                                        <div class="panel-heading">
                                                            Sub-Categores
                                           
                                                        </div>
                                                        <div class="panel-body">
                                                            <div class="table-responsive">
                                                                <table id="example" class="table table-striped table-bordered" cellspacing="0" width="100%">
                                                                    <thead>
                                                                        <tr>
                                                                            <th>S.No</th>
                                                                            <th>Sub-Category</th>
                                                                            <th>Image</th>
                                                                        </tr>
                                                                    </thead>

                                                                    <tfoot>
                                                                        <tr>
                                                                            <th>S.No</th>
                                                                            <th>Sub-Category</th>
                                                                            <th>Image</th>
                                                                        </tr>
                                                                    </tfoot>

                                                                    <tbody>
                                                                        <asp:Repeater ID="rpSubCategoryUp" runat="server">
                                                                            <ItemTemplate>
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:CheckBox ID="subcateid" runat="server" Text='<%# Eval("id") %>' /></td>
                                                                                    <td><%#Eval("subCategoryName") %></td>
                                                                                    <td>
                                                                                        <img src="subcategory/small/<%#Eval("image") %>" width="60px" height="60px"></td>
                                                                                </tr>
                                                                            </ItemTemplate>
                                                                        </asp:Repeater>



                                                                    </tbody>
                                                                </table>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </asp:Panel>

                                                <div class="panel panel-default">
                                                    <div class="panel-heading">
                                                        Coupon Details
                                                    </div>
                                                    <div class="panel-body">
                                                        <div class="col-md-5">
                                                            <div class="form-group">
                                                                <div class="controls">
                                                                    <div class="input-group">
                                                                        <label for="datefrom" class="input-group-addon btn">
                                                                            <span class="glyphicon glyphicon-font"></span>

                                                                        </label>
                                                                        <asp:TextBox runat="server" ID="txtCouponNameUp" placeholder="Coupon ,Example JAN50" type="text" class="form-control" />
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="form-group">
                                                                <div class="controls">
                                                                    <div class="input-group">
                                                                        <label for="datefrom" class="input-group-addon btn">
                                                                            <span class="glyphicon glyphicon-font"></span>

                                                                        </label>
                                                                        <asp:TextBox runat="server" ID="txtMinimumAmountUp" placeholder="Minimum Amount" type="text" class="form-control" />
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="form-group">
                                                                <div class="controls">
                                                                    <div class="input-group">
                                                                        <label for="datefrom" class="input-group-addon btn">
                                                                            <span class="glyphicon glyphicon-font"></span>

                                                                        </label>
                                                                        <asp:TextBox runat="server" ID="txtDiscountUp" placeholder="Discount" type="text" class="form-control" />
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="form-group">
                                                                <div class="controls">
                                                                    <div class="input-group">
                                                                        <label for="datefrom" class="input-group-addon btn">
                                                                            <span class="glyphicon glyphicon-calendar"></span>

                                                                        </label>
                                                                        <asp:TextBox runat="server" ID="txtFromUp" placeholder="Date from " type="text" class="f-date-picker form-control" />
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="form-group">
                                                                <div class="controls">
                                                                    <div class="input-group">
                                                                        <label runat="server" for="dateto" class="input-group-addon btn">
                                                                            <span class="glyphicon glyphicon-calendar"></span>

                                                                        </label>
                                                                        <asp:TextBox runat="server" ID="txtToUp" placeholder="Date To " type="text" class="t-date-picker form-control" />
                                                                    </div>
                                                                </div>
                                                            </div>

                                                           
                                                        </div>
                                                        <div class="col-md-7">
                                                            <div class="form-group">

                                                                <CKEditor:CKEditorControl ID="txtDescriptionUp" placeholder="Description" BasePath="~/UrbanAdmin/ckeditor/" runat="server" Toolbar="Source
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


                                                <!-- End  Hover Rows  -->
                                            </div>
                                        </asp:Panel>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                                <asp:Panel ID="panelUpdateAction" runat="server">
                                <div class="col-md-4 col-md-offset-4">

                                
                                <div class="form-group">
                                                                <asp:FileUpload ID="couponImageUp" runat="server" CssClass="form-control" />
                                                            </div>
                                     <div class="form-group">
                                                                <asp:Button ID="btnUpdateCoupon" runat="server" CssClass="btn btn-success" Text="Update Coupon" OnClick="btnUpdateCoupon_Click" />
                                                                <asp:Button ID="btnCancelCouponUpdate" runat="server" CssClass="btn btn-danger" Text="Cancel" OnClick="btnCancelCouponUpdate_Click" />
                                                            </div>
                                </div>
                                    </asp:Panel>
                            </div>

                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

