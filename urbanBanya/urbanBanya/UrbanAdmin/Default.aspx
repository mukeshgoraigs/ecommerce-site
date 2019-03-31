<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="UrbanAdmin_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1" />
    <meta name="description" content="" />
    <meta name="author" content="" />
    <!--[if IE]>
        <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1">
        <![endif]-->
    <title>Urban Banya | Login</title>
    <!-- BOOTSTRAP CORE STYLE  -->
    <link href="assets/css/bootstrap.css" rel="stylesheet" />
    <!-- FONT AWESOME ICONS  -->
    <link href="assets/css/font-awesome.css" rel="stylesheet" />
    <!-- CUSTOM STYLE  -->
    <link href="assets/css/style.css" rel="stylesheet" />
     <!-- HTML5 Shiv and Respond.js for IE8 support of HTML5 elements and media queries -->
    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
    <!--[if lt IE 9]>
        <script src="https://oss.maxcdn.com/libs/html5shiv/3.7.0/html5shiv.js"></script>
        <script src="https://oss.maxcdn.com/libs/respond.js/1.4.2/respond.min.js"></script>
    <![endif]-->
 
 
  
</head>
<body>
  
   <form id="loginform" runat="server">

   
   
    
    <div class="content-wrapper">
        <div class="container">
            <div class="row">
                <div class="col-md-12">
                    <h4 class="page-head-line">Please Login To Enter </h4>

                </div>

            </div>
            <div class="row">
                <div class="col-md-4"></div>
                <div class="col-md-4">
                 <div class="panel-success panel">
                     <div class="panel-heading">
                       <h4> Login with <strong>Urban Admin Account  :</strong></h4>
                     </div>
                     <div class="panel-body">
                           <label>Enter Email ID : </label>
                        <asp:TextBox ID="txtUserId" runat="server" class="form-control" />
                        <label>Enter Password :  </label>
                        <asp:TextBox ID="txtPassword" TextMode="Password" runat="server" class="form-control" />
                        <hr />
                         <asp:Button ID="btnLogin" runat="server" CssClass="btn btn-info" Text="Login Admin" OnClick="btnLogin_Click" />
                        <asp:Label ID="lblMessage" runat="server" ForeColor="Red"> </asp:Label>
                     </div>
                 </div>
                     

                    
                   
                </div>
                <div class="col-md-4"></div>

            </div>
        </div>
    </div>
       </form>
    <!-- CONTENT-WRAPPER SECTION END-->
    <footer>
        <div class="container">
            <div class="row">
                <div class="col-md-12">
                    &copy; 2016 Tarkari | By : <a href="http://www.par-ken.com/" target="_blank">Parken Solution Pvt. Ltd</a>
                </div>

            </div>
        </div>
    </footer>
    <!-- FOOTER SECTION END-->
    <!-- JAVASCRIPT AT THE BOTTOM TO REDUCE THE LOADING TIME  -->
    <!-- CORE JQUERY SCRIPTS -->
    <script src="assets/js/jquery-1.11.1.js"></script>
    <!-- BOOTSTRAP SCRIPTS  -->
    <script src="assets/js/bootstrap.js"></script>
    
 
</body>
</html>
