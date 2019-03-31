<%@ Page Title="" Language="C#" MasterPageFile="~/UrbanAdmin/AdminMasterPage.master" AutoEventWireup="true" CodeFile="TaxReport.aspx.cs" Inherits="UrbanAdmin_TaxReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
       <script>
     $(document).ready(function () {
         $(".f-date-picker").datepicker({ dateFormat: 'yy-mm-dd' });
         $(".t-date-picker").datepicker({ dateFormat: 'yy-mm-dd' });
         
     });
 </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     
    <div class="container">
        <div class="row">
            <div class="col-md-12 col-sm-12">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <h3>Urban Tax Report</h3>
                     
                    <div class="panel-body">
                        <div class="row">

                            <div class="col-md-12">

                                <div class="Compose-Message">
                                    <div class="panel panel-default">
                                        <div class="panel-heading">
                                            <div class="row">
                                                <div class="col-md-3">
                                                      <h4>Urban Tax Report</h4>
                                                </div>
                                                <div class="col-md-3">
                                                    
                                             <div class="control-group pull-right">
      
        <div class="controls">
            <div class="input-group">
               <label for="datefrom" class="input-group-addon btn"><span class="glyphicon glyphicon-calendar"></span>

                </label>
                <asp:TextBox runat="server" id="datefrom" placeholder="Date from "  type="text" class="f-date-picker form-control" />
            </div>
        </div>
    </div>
                                                </div>
                                                 <div class="col-md-3">
                                                    
                                             <div class="control-group pull-right">
      
        <div class="controls">
            <div class="input-group">
                <label runat="server" for="dateto" class="input-group-addon btn"><span class="glyphicon glyphicon-calendar"></span>

                </label>
                <asp:TextBox runat="server" id="dateto" placeholder="Date To "  type="text" class="t-date-picker form-control" />
            </div>
        </div>
    </div>
                                                </div>
                                                <div class="col-md-3">
                                                    
                                                    <asp:Button ID="btnGetTax" runat="server" CssClass="btn btn-success" Text="Get Tax Report" OnClick="btnGetTax_Click" />
                                                    
                                                </div>
                                            </div>
                                           
                                            

                                        </div>
                                        <div class="panel-body table-responsive">
                                            <table id="example" class="table table-striped table-bordered " cellspacing="0" width="100%">
                                                <thead>
                                                    <tr>
                                                        <th>Item</th>
                                                        <th>Sales</th>
                                                        <th>Tax in (%)</th>
                                                        <th>Tax to Pay</th>
                                                                                                            </tr>
                                                </thead>

                                                <tfoot>
                                                    <tr>
                                                        <th>Item</th>
                                                        <th>Sales</th>
                                                        <th>Tax in (%)</th>
                                                        <th><asp:Label runat="server" ID="lblTotalTax"></asp:Label></th>
                                                    </tr>
                                                </tfoot>

                                                <tbody>

                                                    <asp:Repeater ID="rpTaxReport" runat="server">
                                                        <ItemTemplate>
                                                            <tr>
                                                               
                                                                <td><%#Eval("item") %></td>
                                                                <td><%#Eval("sales") %></td>
                                                                <td><%#Eval("tax") %></td>
                                                                <td><%#Eval("paytax") %></td>
                                                               
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

                    </div>
                </div>
            </div>
        </div>
    </div>
    <asp:Literal ID="showmsg" runat="server"></asp:Literal>
                                                      
</asp:Content>

