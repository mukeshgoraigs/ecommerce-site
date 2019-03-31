<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Problem.aspx.cs" Inherits="Problem" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
      <div class="items">
		  <div class="container">
			<div class="row">
			  <!-- Sidebar navigation-->
			  <div class="col-md-3 col-sm-3 hidden-xs">
				  <nav>
            <ul id="navi">
              <li><a href="MyAcount.aspx">My Account</a></li>
             
            </ul>
          </nav>

			  </div>

			  <div class="col-md-9 col-sm-9">
				
				<h2 style="color:red">There was the Problem in Payment Method Please Try Again </h2>
				<p><a href="Default.aspx" class="btn">Continue Shopping</a>&nbsp;<a href="UrbanCart.aspx" class="btn">Try Again</a></p>
				
			
			  </div>                                                                    



			</div>
		  </div>
		</div>
</asp:Content>

