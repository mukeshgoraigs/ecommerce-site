<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="SiteReview.aspx.cs" Inherits="SiteReview" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="productListing " style="margin-top: 0px">



        <h2>Site Review</h2>
        <div class="clearFix jsProductContainer" data-count="212">

         
                <asp:Repeater ID="rpReview" runat="server">
                    <ItemTemplate>
                        <div style="margin:5%">
                            <div style="width:66%;font-size:18px;float:left;background-color:azure;padding:10px">
                                <img style="height:25px;width:25px" src="img/User_Circle.png" />    <%#Eval("F_name") %>
                            </div>
                            <div style="width:66%;font-size:1.5rem;float:left;background-color:lavender;padding:20px">
                              "   <%#Eval("review") %>
                            </div>
                        </div>
                               
                           
                          
                    </ItemTemplate>
                </asp:Repeater>

            <div class="clearFix"></div>
        </div>

    </div>
</asp:Content>

