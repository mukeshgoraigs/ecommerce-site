<%@ Page Title="" Language="C#" MasterPageFile="~/UrbanAdmin/AdminMasterPage.master" AutoEventWireup="true" CodeFile="TestTree.aspx.cs" Inherits="TestTree" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:TreeView ID="TreeView1" runat="server"   LeafNodeStyle-ImageUrl="~/assets/img/folder2.png" RootNodeStyle-ImageUrl="~/assets/img/folder1.png">
        
    </asp:TreeView>
</asp:Content>


