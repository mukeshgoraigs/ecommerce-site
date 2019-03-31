var checkLoginState;
console.log("init checkLoginState")
$(document).ready(function () {
    var moveme = "";
    var t = 0;
    var emailverify = "";
    var validcoupon = "";
    var isvalid = false;
   
    var placeOrderFlag = "";

  var w=  $(window).width();
  if (w <= 1024) {
      $(".cd-dropdown").hide();
      $(".showmenu").show();
      $("#sidebar").hide();
     
  }

  $(".chkShowPassword").change(function () {
      if ($(this).prop("checked") == true)
      {
          $("#loginPassword").attr("type", "text");
      }
      else {
          $("#loginPassword").attr("type", "password");
      }
     
  });
 

    /********************Facebook Login**************************/

    // This is called with the results from from FB.getLoginStatus().
    function statusChangeCallback(response) {
        console.log('statusChangeCallback');
        console.log(response);
        // The response object is returned with a status field that lets the
        // app know the current login status of the person.
        // Full docs on the response object can be found in the documentation
        // for FB.getLoginStatus().
        if (response.status === 'connected') {
            // Logged into your app and Facebook.
           
                testAPI();
               
                    } else if (response.status === 'not_authorized') {
            // The person is logged into Facebook, but not your app.
            document.getElementById('status').innerHTML = 'Please log ' +
              'into this app.';
        } else {
            // The person is not logged into Facebook, so we're not sure if
            // they are logged into this app or not.
            document.getElementById('status').innerHTML = 'Please log ' +
              'into Facebook.';
        }
    }

    // This function is called when someone finishes with the Login
    // Button.  See the onlogin handler attached to it in the sample
    // code below.


  window.fbAsyncInit = function() {
      FB.init({
          appId      : '1060353177346534',
          cookie     : true,  // enable cookies to allow the server to access 
          // the session
          xfbml      : true,  // parse social plugins on this page
          version    : 'v2.5' // use graph api version 2.5
      });

      // Now that we've initialized the JavaScript SDK, we call 
      // FB.getLoginStatus().  This function gets the state of the
      // person visiting this page and can return one of three states to
      // the callback you provide.  They can be:
      //
      // 1. Logged into your app ('connected')
      // 2. Logged into Facebook, but not your app ('not_authorized')
      // 3. Not logged into Facebook and can't tell if they are logged into
      //    your app or not.
      //
      // These three cases are handled in the callback function.
      checkLoginState =function () {
          localStorage.logout = false;
          $(".urbanLogin").slideUp();

          FB.getLoginStatus(function (response) {
              statusChangeCallback(response);
          });
      }


/*****************************************************************This call is commit by Aman Kashyap**********************************/
      if (!localStorage.logout) {
          console.log("never clicked logout till now. so checking fb status")
          FB.getLoginStatus(function (response) {
              console.log("start getLogingstatus")
              statusChangeCallback(response);
          });
      } else {
          console.log("Just logged out so not looking for fb status")
      }
  




  };


    // Load the SDK asynchronously
  (function(d, s, id) {
      var js, fjs = d.getElementsByTagName(s)[0];
      if (d.getElementById(id)) return;
      js = d.createElement(s); js.id = id;
      js.src = "//connect.facebook.net/en_US/sdk.js";
      fjs.parentNode.insertBefore(js, fjs);
  }(document, 'script', 'facebook-jssdk'));

    // Here we run a very simple test of the Graph API after login is
    // successful.  See statusChangeCallback() for when this call is made.
  function testAPI() {
      console.log('Welcome!  Fetching your information.... ');
      FB.api('/me',{fields: 'name,email,gender,birthday'}, function(response) {
          console.log('Successful login for: ', response);

          checkUserExist(response.name, response.email);

          document.getElementById('status').innerHTML =
             
            'Thanks for logging in, ' + response.name + '<br/> Email : '+response.email;
      });
  }
 
  

    /********************Facebook Login**************************/

  function checkUserExist(name,email)
  {
      $.ajax({
          type: "POST",
          url: 'Default.aspx/checkUserExist',
          data: "{email:'" + email + "'}",
          contentType: "application/json",
          datatype: "json",
          async: "true",
          success: function (response) {
              var res = response.d;
              if (res == "no") {
                 
                  $(".urbanFacebookSignUp").slideDown();
                  $("#facebookfname").val(name);
                  $("#facebookemail").val(email);
              }
              else if (res == "website")
              {
                  showMessageBox("Please Login with site id and password,u Don't have facebook Login with Urban");
              }
              else if (res == "block") {
                  showMessageBox("Your Account is Blocked , Contact Urban Banya");
              }
              else {
                 
                  $(".signup").hide();
                  $(".login").hide();                 
                  $("#userName").text("Hi " + res);
                  $(".account").show();
                  $(".logout").show();
              }

          },
          error: function (response) {
              $(".urbanFacebookSignUp").slideDown();
              showMessageBox(response.status);
          }
      });
  }
  $('#logout').click(function () {
      localStorage.logout = true;

      window.location = "/Logout.aspx";
  });

  function showMessageBox(message)
  {
      $(".lblMessage").text(message);
      $(".messageBox").fadeIn();
      $(".loadwait").fadeIn();
  }
  $(".btnMessageOk").click(function () {
      $(".messageBox").fadeOut();
      $(".loadwait").fadeOut();
  });
  $(".msgbtnclose").click(function () {
      $(".messageBox").fadeOut();
      $(".loadwait").fadeOut();
  });

  $(".btnForget").click(function () {
      $(".urbanForgetPassword").slideDown();
      $(".urbanLogin").slideUp();
  });

  $(".btnForgetPassword").click(function () {
      var email = $("#txtEmailForget").val();
      $(".loadwait").fadeIn();
      $(".urbanForgetPassword").slideUp();
      $.ajax({
          type: "POST",
          url: 'WebService.asmx/forgetPassword',
          data: "{email:'" + email + "'}",
          contentType: "application/json",
          datatype: "json",
          async: "true",
          success: function (response) {
              var email = response.d;
              if (email != "no") {
                  $(".loadwait").fadeOut();
                  showMessageBox("Please Check Your Mail-Id ");
              } else {
                  $(".urbanForgetPassword").slideDown();
                  showMessageBox("Invaled Mail-Id ,Please Enter Register Mail-Id ! ");
              }

          },
          error: function (response) {
              $(".urbanFacebookSignUp").slideDown();
              showMessageBox(response.status);
          }
      });
  });

  $(".fsbtnclose").click(function () {
      $(".urbanFacebookSignUp").slideUp();
  })

  $(".btnFacebookSignUp").click(function () {
      var name = $("#facebookfname").val();
      var email = $("#facebookemail").val();
      var mobile = $("#facebookmobile").val();
      var pass = "";
      var loginby = "facebook";
      if ($(".chkfacebooktram").prop("checked") == true) {
          if (name != "" && email != "" && mobile != "") {
              $(".urbanFacebookSignUp").slideUp();
              $(".loadwait").fadeIn();
              $.ajax({
                  type: "POST",
                  url: 'Default.aspx/register',
                  data: "{name:'" + name + "',email:'" + email + "',mobile:'" + mobile + "',password:'" + pass + "',loginby:'"+loginby+"'}",
                  contentType: "application/json",
                  datatype: "json",
                  async: "true",
                  success: function (response) {
                      var email = response.d;
                      if (email != "no") {
                          $(".loadwait").fadeOut();
                          
                          otpbox(email);
                         

                      } else {
                          $(".urbanFacebookSignUp").slideDown();
                          showMessageBox("Email id already exist");
                      }

                  },
                  error: function (response) {
                      $(".urbanFacebookSignUp").slideDown();
                      showMessageBox(response.status);
                  }
              });
          }
          else {
              showMessageBox("Please Fill all the fields !");
              
          }
      } else {
          showMessageBox("Please Accept term and condition");
         
      }

  });


  $(".showmenu").click(function () {
      if (t == 0) {
          $(".mobilemenu").slideDown();
          t++;
      }
      else {         
          $(".mobilemenu").slideUp();
          t = 0;
      }
  });

  checkCart();

  function checkCart() {
      var sessionid = $("#hdnsessionid").val();

      $.ajax({
          type: "POST",
          url: 'WebService.asmx/checkCart',
          data: "{sessionid:'" + sessionid + "'}",
          contentType: "application/json",
          datatype: "json",
          async: "true",
          success: function (response) {
              if (response.d == "no") {
                  $("#responsive-cart").hide();
              }

          },
          error: function (response) {
              showMessageBox(response.status);
          }
      });

  }

    chekLogin();
    function chekLogin() {
        $.ajax({
            type: "POST",
            url: 'Default.aspx/checklogin',
            data: "{}",
            contentType: "application/json",
            datatype: "json",
            async: "true",
            success: function (response) {
                if (response.d != "no") {
                    $(".signup").hide();
                    $(".login").hide();
                    $("#userName").text("Hi " + response.d);
                    $(".account").show();
                    $(".logout").show();
                } else {

                    //loginSlide();
                }

            },
            error: function (response) {
                showMessageBox(response.status);
            }
        });
    }

    $("#cart-open-btn").click(function () {
       
       
    });

    $("#mycartdata").on('click', '.cclearCart', function () {
    //$(".cclearCart").click(function () {
        var r = confirm("Do You Want to Clear The Cart!");
        if (r == true)
        {
           
            var sessionid = $("#hdnsessionid").val();
           
            $.ajax({
                type: "POST",
                url: 'WebService.asmx/clearCart',
                data: "{sessionid:'" + sessionid + "'}",
                contentType: "application/json",
                datatype: "json",
                async: "true",
                success: function (response) {
                   
                    $("#responsive-cart").hide();
                    window.location.reload();
                    
                },
                error: function (response) {
                    showMessageBox(response.status);
                }
            });
        }
        

    });

    $(".btnResendOtp").click(function () {
        $(".urbanOtp").slideUp();
        $(".loadwait").fadeIn();
        var email = emailverify;
        $.ajax({
            type: "POST",
            url: 'WebService.asmx/reSendOtp',
            data: "{email:'" + email + "'}",
            contentType: "application/json",
            datatype: "json",
            async: "true",
            success: function (response) {
                $(".urbanOtp").slideDown();
                $(".loadwait").fadeOut();
            },
            error: function (response) {
                
            }
        });
    });


    $(".otpbtnclose").click(function () {
        $(".urbanOtp").slideUp();
    });
    $(".forgetbtnclose").click(function () {
        $(".urbanForgetPassword").slideUp();
    });
    $(".lbtnclose").click(function () {
        $(".urbanLogin").slideUp();
    });
    $(".sbtnclose").click(function () {
        $(".urbanSignUp").slideUp();
    });
    $("#loginButton").click(function () {
        moveme = "home";
        $(".urbanLogin").slideDown();
        $(".urbanSignUp").slideUp();
    });
    $("#signupButton").click(function () {
        moveme = "home";
        $(".urbanLogin").slideUp();
        $(".urbanSignUp").slideDown();
    });

    $(".lbtnSignUp").click(function () {
        $(".urbanLogin").slideUp();
        $(".urbanSignUp").slideDown();
    });

    $(".sbtnLogin").click(function () {

        $(".urbanLogin").slideDown();
        $(".urbanSignUp").slideUp();
    });
    $("#loginEmail").keypress(function (e) {
        var key = e.which;
        if (key == 13)  // the enter key code
        {
            loginAccount();
        }
    });

    $("#loginPassword").keypress(function (e) {
        var key = e.which;
        if (key == 13)  // the enter key code
        {
            loginAccount();
        }
    });


    $(".btnLogin").click(function () {

        loginAccount();
    });


    function loginAccount()
    {
        var email = $("#loginEmail").val();

        var pass = $("#loginPassword").val();

        if (email != "" && pass != "") {
            $(".urbanLogin").slideUp();
            $(".loadwait").fadeIn();
            $.ajax({
                type: "POST",
                url: 'Default.aspx/login',
                data: "{email:'" + email + "',password:'" + pass + "'}",
                contentType: "application/json",
                datatype: "json",
                async: "true",
                success: function (response) {
                    $(".loadwait").fadeOut();
                    var user = response.d;
                    if (user != "no" && user != "block") {
                        $(".signup").hide();
                        $(".login").hide();
                        //  $(".urbanLogin").slideUp();
                        $("#userName").text("Hi " + user);
                        $(".account").show();
                        $(".logout").show();
                        if (moveme == "home") {

                        }
                        if (moveme == "cart") {
                            window.location.href = "UrbanCart.aspx";
                        }
                    }
                    else if (user == "block") {
                        $(".urbanLogin").slideDown();
                        showMessageBox("Your Account is Blocked By UrbanBanya Please Contact To Customer Care !");

                    }
                    else {
                        $(".urbanLogin").slideDown();
                        showMessageBox("Check your mail-Id & password ! try again !");

                    }

                },
                error: function (response) {
                    $(".urbanLogin").slideDown();
                    $(".loadwait").fadeOut();
                }
            });
        }
        else {
            showMessageBox("Please Enter the User-Id and Password !");

        }
    }



    function otpbox(email)
    {
        emailverify = email;
        $(".urbanOtp").slideDown();
    }

    $(".btnVerifyOtp").click(function () {
        var otp = $("#txtotp").val();
        verifyOtp(emailverify,otp);
    });


    function verifyOtp(email,otp)
    {
        $(".loadwait").fadeIn();
        $.ajax({
            type: "POST",
            url: 'Default.aspx/verifyOtp',
            data: "{email:'" + email + "',otp:'" + otp + "'}",
            contentType: "application/json",
            datatype: "json",
            async: "true",
            success: function (response) {
                $(".loadwait").fadeOut();
                var user = response.d;
                if (user != "invalid") {
                    $(".urbanOtp").slideUp();                   
                    $(".signup").hide();
                    $(".login").hide();
                    $("#userName").text("Hi " + user);
                    $(".account").show();
                    $(".logout").show();
                    $(".urbanSignUp").slideUp();
                    if (moveme == "home") {

                    }
                    if (moveme == "cart") {
                        window.location.href = "UrbanCart.aspx";
                    }

                } else {
                    showMessageBox("Invalid OTP Please Try Again !");
                }

            },
            error: function (response) {
                showMessageBox(response.status);
            }
        });
    }

    $(".btnSignUp").click(function () {

        var name = $("#fname").val();
        var email = $("#email").val();
        var mobile = $("#mobile").val();

        var pass = $("#password").val();
        var loginby = "website";
        reSendOtpNumber = mobile;
        if ($(".chktram").prop("checked") == true)
            {
            if (name != "" && email != "" && mobile != "" && pass != "") {
                $(".urbanSignUp").slideUp();
                $(".loadwait").fadeIn();
            $.ajax({
                type: "POST",
                url: 'Default.aspx/register',
                data: "{name:'" + name + "',email:'" + email + "',mobile:'" + mobile + "',password:'" + pass + "',loginby:'" + loginby + "'}",
                contentType: "application/json",
                datatype: "json",
                async: "true",
                success: function (response) {
                    var email = response.d;
                    if (email != "no") {
                        $(".loadwait").fadeOut();
                       // $(".urbanSignUp").slideUp();
                        otpbox(email);
                        //$(".signup").hide();
                        //$(".login").hide();
                        //$("#userName").text("Hi " + user);
                        //$(".account").show();
                        //$(".logout").show();
                        //$(".urbanSignUp").slideUp();
                        //if (moveme == "home") {

                        //}
                        //if (moveme == "cart") {
                        //    window.location.href = "UrbanCart.aspx";
                        //}

                    } else {
                        $(".urbanSignUp").slideDown();
                        showMessageBox("Email id already exist");
                    }

                },
                error: function (response) {
                    $(".urbanSignUp").slideDown();
                    showMessageBox(response.status);
                }
            });
        }
        else {
            showMessageBox("Please Fill all the fields !");
        }
        } else {
            showMessageBox("Please Accept term and condition");
        }
    });

    $(".myAdd").click(function () {

        var size = $("#psize").val();


        if (size == "0") {
            showMessageBox("Please Select Product Size");
            $("#psize").focus();
            $("#psize").css("border-color", "red");
        }
        else {
            var size = $(this).attr("data-size");
            var dataid = $(this).attr("data-id");
            var newprice = $(this).attr("data-price");
            var oldprice = $(this).attr("data-oldprice");
            var sessionid = $("#hdnsessionid").val();
            var img = $(this).attr("data-img");
            

            addProduct(dataid, oldprice, newprice, sessionid, size);

        }

    });




    $(".addButton").click(function (event) {
        var size = $(this).attr("data-size");
        var dataid = $(this).attr("data-id");
        var newprice = $(this).attr("data-price");
        var oldprice = $(this).attr("data-oldprice");
        var stock =parseInt( $(this).attr("data-slock"));
        var qtt;
      
        var sessionid = $("#hdnsessionid").val();
        var img = $(this).attr("data-img");
        var myprev = $(this).prev();

        var quant = myprev.val();
        if (quant == "")
        {
            qtt = 0;
        }
        else {
            qtt = parseInt(quant);
        }

        if (qtt < stock)
        {
            var hi = $(this).parent(".product-inner").addClass("added");

            $(this).parent().addClass("selected");


            $("#myob").show();
            $("#myob").attr("src", "UrbanAdmin/product/small/" + img);
            $("#myob").css("left", event.pageX);
            $("#myob").css("top", event.pageY);
            $("#myob").animate({
                left: event.pageX,
                top: $(document).height()

            }, 1500, function () {
                $("#myob").hide();
            });

            addProduct(dataid, oldprice, newprice, sessionid, size);
            var uqan = myprev.val();
            if (uqan == "") {
                uqan = 0;
            }
            var q = parseInt(uqan);
            var pq = q + 1;

            myprev.val(pq);
        }
        else {
            showMessageBox("Only "+stock+" Items In Stock");
        }
    });

    $(".deleteButton").click(function () {
        var mynext = $(this).next();
        var uqan = mynext.val();
        if (uqan != "" && uqan > 0) {
            var dataid = $(this).attr("data-id");
            var dataprice = $(this).attr("data-price");
            var sessionid = $("#hdnsessionid").val();
            var size = $(this).attr("data-size");

            if (uqan==1) {
                $(this).parent().removeClass("selected");
            }

            $.ajax({
                type: "POST",
                url: 'WebService.asmx/removeData',
                data: "{dataid:'" + dataid + "',price:'" + dataprice + "',sessionid:'" + sessionid + "',size:'" + size + "'}",
                contentType: "application/json",
                datatype: "json",
                async: "true",
                success: OnSuccess,
                error: function (response) {
                    showMessageBox(response.status);
                }
            });

            function OnSuccess(response) {
                var uqan = mynext.val();
                if (uqan != "" && uqan > 0) {
                    var q = parseInt(uqan);
                    var pq = q - 1;

                    mynext.val(pq);
                    GetCartJson('test1');
                    GetCartJsonf('test3');
                }
                

            }
        }
        else
        {
            showMessageBox("No Item In Cart");
        }
    });


    function GetCartJson(ctrl) {



        $("#test1").load(window.location + ' #test2', function (event) {

            $(ctrl).blur(function () { getkeypresstextbox(ctrl); });

            //initGrid();
        });

    }
    function GetCartJsonf(ctrl) {



        $("#test3").load(window.location + ' #test4', function (event) {

            $(ctrl).blur(function () { getkeypresstextbox(ctrl); });

            //initGrid();
        });
        $("#test5").load(window.location + ' #test6', function (event) {

            $(ctrl).blur(function () { getkeypresstextbox(ctrl); });

            //initGrid();
        });

    }
    function addProduct(dataid,oldprice,newprice,sessionid ,size) {
        $.ajax({
            type: "POST",
            url: 'WebService.asmx/saveData',
            data: "{dataid:'" + dataid + "',oldprice:'" + oldprice + "',newprice:'" + newprice + "',sessionid:'" + sessionid + "',size:'" + size + "'}",
            contentType: "application/json",
            datatype: "json",
            async: "true",
            success: OnSuccess,
            error: function (response) {

            }
        });
        function OnSuccess(response) { GetCartJson('test1'); }
    }

    $("#mycartdata").on('click', '.caddButton', function () {
        //$(".addButton").click(function () {
        var size = $(this).attr("data-size");
        var dataid = $(this).attr("data-id");
        var newprice = $(this).attr("data-price");
        var oldprice = $(this).attr("data-oldprice");

        var sessionid = $("#hdnsessionid").val();
        var size = $(this).attr("data-size");
        //addProduct(dataid, oldprice, newprice, sessionid, size);
        $.ajax({
            type: "POST",
            url: 'WebService.asmx/saveData',
            data: "{dataid:'" + dataid + "',oldprice:'" + oldprice + "',newprice:'" + newprice + "',sessionid:'" + sessionid + "',size:'" + size + "'}",
            contentType: "application/json",
            datatype: "json",
            async: "true",
            success: OnSuccess,
            error: function (response) {

            }
        });
        function OnSuccess(response) { GetCartJsonf('test3'); }

    });
    $("#mycartdata").on("click", ".editCart, .cartItem", function (e) {

        
            var t = $(".reviewWrapper").css("display");
            switch (t) {
                case "none":
                    $(".reviewWrapper").show(50), $(".cartWrapper").hide(50), $(".editCart").text("Done");
                    break;
                case "block":
                    $(".reviewWrapper").hide(50), $(".cartWrapper").show(50), $(".editCart").text("Edit Cart"), $(".reviewWrapper").find(".close").click()
            }
        
    });

    $("#mycartdata").on('click', '.cdeleteButton', function () {

        //$(".deleteButton").click(function () {
        var dataid = $(this).attr("data-id");
        var dataprice = $(this).attr("data-price");
        var sessionid = $("#hdnsessionid").val();
        var size = $(this).attr("data-size");
        $.ajax({
            type: "POST",
            url: 'WebService.asmx/removeData',
            data: "{dataid:'" + dataid + "',price:'" + dataprice + "',sessionid:'" + sessionid + "',size:'" + size + "'}",
            contentType: "application/json",
            datatype: "json",
            async: "true",
            success: OnSuccess,
            error: function (response) {
                showMessageBox(response.status);
            }
        });

        function OnSuccess(response) {


            GetCartJsonf('test3');

        }
        
       
    });

    function subProduct(dataid, dataprice, sessionid,size) {
        $.ajax({
            type: "POST",
            url: 'WebService.asmx/removeData',
            data: "{dataid:'" + dataid + "',price:'" + dataprice + "',sessionid:'" + sessionid + "',size:'"+size+"'}",
            contentType: "application/json",
            datatype: "json",
            async: "true",
            success: OnSuccess,
            error: function (response) {
                showMessageBox(response.status);
            }
        });

        function OnSuccess(response) {


            GetCartJson('test1');

        }
    }

    $("#mycartdata").on('click', '.btnCheckOut', function () {

        //$(".btnCheckOut").click(function () {
        moveme = "cart";
        $(".loadwait").fadeIn();
        $.ajax({
            type: "POST",
            url: 'Default.aspx/checklogin',
            data: "{}",
            contentType: "application/json",
            datatype: "json",
            async: "true",
            success: function (response) {
                $(".loadwait").fadeOut();
                if (response.d != "no") {
                    window.location.href = "UrbanCart.aspx";
                } else {

                    $(".urbanLogin").slideDown();
                }

            },
            error: function (response) {
                showMessageBox(response.status);
            }
        });
    });

    $(".detailsContainer").on('click', '.del', function () {
    //$(".del").click(function () {
        var id = $(this).attr("data-id");
        var sessionid = $("#hdnsessionid").val();
        var size = $(this).attr("data-size");
        $.ajax({
            type: "POST",
            url: 'WebService.asmx/deleteItem',
            data: "{id:'" + id + "',sessionid:'"+sessionid+"',size:'"+size+"'}",
            contentType: "application/json",
            datatype: "json",
            async: "true",
            success: function (response) {
                GetCartJson('test1');
            },
            error: function (response) {
                showMessageBox(response.status);
            }
        });
    });
    $(".detailsContainer").on('click', '.caddButton', function () {
        //$(".addButton").click(function () {
        var size = $(this).attr("data-size");
        var dataid = $(this).attr("data-id");
        var newprice = $(this).attr("data-price");
        var oldprice = $(this).attr("data-oldprice");
        
        var sessionid = $("#hdnsessionid").val();
        var size = $(this).attr("data-size");
        addProduct(dataid, oldprice, newprice, sessionid, size);
       
    });
    $(".detailsContainer").on('click', '.cdeleteButton', function () {
        //$(".deleteButton").click(function () {
        var dataid = $(this).attr("data-id");
        var dataprice = $(this).attr("data-price");
        var sessionid = $("#hdnsessionid").val();
        var size = $(this).attr("data-size");
      
        subProduct(dataid, dataprice, sessionid,size);

    });
    $("#area").autocomplete({
        source: function (request, response) {
            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: "WebService.asmx/GetArea",
                data: "{'area':'" + $("#area").val() + "'}",
                dataType: "json",
                success: function (data) {
                    response(data.d);
                },
                error: function (result) {
                    showMessageBox("Error");
                }
            });
        }
    });
    var mydata = [{"Id":32,"Product":"Almond - Sliced (Badam Cutting)","Image":"almond Sliced.jpg","NewPrice":80.75},{"Id":33,"Product":"Almonds - American","Image":"Almonds - American.jpg","NewPrice":180},{"Id":34,"Product":"Almonds Mamra - Sattar Bhai","Image":"Almonds--Sattar-bhai.png","NewPrice":560},{"Id":35,"Product":"Almonds Mamra Giri ","Image":"Almonds Mamra Giri .jpg","NewPrice":599.9},{"Id":37,"Product":"Anjir - Dried (Medium Size)","Image":"Anjir - Dried (Medium Size).jpg","NewPrice":142},{"Id":42,"Product":"Dates(Khajur) - Premium","Image":"Dates(Khajur) - Premium.jpg","NewPrice":36},{"Id":43,"Product":"Munakka ","Image":"Munakka .jpg","NewPrice":138},{"Id":44,"Product":"Munakka - Premium Pack","Image":"Munakka .jpg","NewPrice":168},{"Id":45,"Product":"Muskmelon Seeds - White","Image":"Muskmelon Seeds - White.jpg","NewPrice":100},{"Id":46,"Product":"Phool Makhana","Image":"Phool Makhana.jpg","NewPrice":125},{"Id":49,"Product":"Raisins (Kishmish) - Premium","Image":"Raisins (Kishmish) - Premium.jpg","NewPrice":85},{"Id":50,"Product":"Raisins (Kishmish) - Round","Image":"Raisins (Kishmish) - round.jpg","NewPrice":72},{"Id":51,"Product":"Tim Tim Walnut Kernels - Gold","Image":"Tim Tim Walnut Kernels - Gold.jpg","NewPrice":390},{"Id":52,"Product":"Tim Tim Walnut Kernels - Silver","Image":"Tim Tim Walnut Kernels - silver.jpg","NewPrice":369.954},{"Id":54,"Product":"Tulsi Munakka","Image":"Tulsi .jpg","NewPrice":198.4},{"Id":56,"Product":"Watermelon Seeds (Matira Magaj) - White","Image":"Watermelon Seeds (Matira Magaj) - White.jpg","NewPrice":115}];
    $("#earea").autocomplete({
        source: function (request, response) {
          
            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: "WebService.asmx/GetArea",
                data: "{'area':'" + $("#earea").val() + "'}",
                dataType: "json",
                success: function (data) {
               
                    response(data.d);
                },
                error: function (result) {
                    showMessageBox("Error");
                }
            });
        }
    });
    $("#txtproduct").autocomplete({
        minLength: 2,
        focus: function (event, ui) {
            $(this).val(ui.item.Product);
            return false;
        },
        select:function(event,ui){
            $(this).val(ui.item.Product);
            window.location.href = "DetailsPage.aspx?pid=" + ui.item.Id + "&price=" + ui.item.NewPrice + "&pron=" + ui.item.Product + "&dis=" + ui.item.Discount;
            return false;
        },
        source: function (request, response) {
           // response(mydata);
            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: "WebService.asmx/GetProduct",
                data: "{'product':'" + $("#txtproduct").val() + "'}",
                dataType: "json",
                success: function (data) {
                    //JSON.parse()
                    response(jQuery.parseJSON(data.d));
                },
                error: function (result) {
                    showMessageBox(result.status);
                }
            });
        }
    })
        .autocomplete('instance')._renderItem = function (ul, item) {
            return $('<li>')
            .append('<a onclick="clickOnItem(event,this)" href="DetailsPage.aspx?pid=' + item.Id + '&price=' + item.NewPrice + '&pron=' + item.Product + '&dis=' + item.Discount + '"><img style="width:30px:flot:left" class="searchimg" src="UrbanAdmin/product/small/' + item.Image + '" />')
            .append('<div class="searchpname"><a class="searchpname">' + item.Product + '</a></div></a>')
                 .append('<div class="searchsize"><a>' + item.Size + '</a></div>')
                 .append('<div class="searchprice"><a> <i class="fa fa-inr"></i> ' + item.NewPrice + '</a></div>')
                 //.append('<div class="searchQuan"><input class="searchQuan" value="1" type="text" id="txtquan"></div>')
                .append('<a style="color:#ffffff" onclick="clickOnAdd(event,this)"  class="searchadd" data-img=' + item.Image + ' data-size=' + item.Size + ' data-id=' + item.Id + ' data-oldprice=' + item.OldPrice + ' data-price=' + item.NewPrice + ' data-discount=' + item.Discount + ' onclick="clickOnItem(event,this)">Add</a>')
                .append('</li>')
        .appendTo(ul);
           
    };

    

    $(".btnAddress").click(function () {

        var email = $("#ContentPlaceHolder1_email").val();

        var city = $("#ContentPlaceHolder1_cmbCity").val();
        var area = $("#area").val();
        //var pincode = $("#pincode").val();
        var address1 = $("#address1").val();
        var address2 = $("#address2").val();

        var landmark = $("#landmark").val();

        if (email != "" && area != "" && city != "" && address1 != "" && landmark != "") {
            $(".loadwait").fadeIn();
            $.ajax({
                type: "POST",
                url: 'WebService.asmx/saveAddressP',
                data: "{email:'" + email + "',city:'" + city + "',area:'" + area + "',address1:'" + address1 + "',address2:'" + address2 + "',landmark:'" + landmark + "'}",
                contentType: "application/json",
                datatype: "json",
                async: "true",
                success: function (response) {
                    $(".loadwait").fadeOut();
                    window.location.href = "ShippingAddress.aspx";

                },
                error: function (response) {
                    showMessageBox(response.status);
                }
            });
        }
        else {
            showMessageBox("Please fill all the fields");
        }
    });

    $(".btnNewAddress").click(function () {

        $(".urbanAnother").slideDown();
    });

    $(".abtnclose").click(function () {
        $(".urbanAnother").slideUp();
    });
    $(".btnSubmitAn").click(function () {
        var email = $("#hdemail").val();
        var city = $("#ContentPlaceHolder1_ecmbCity").val();
        var area = $("#earea").val();
        
        var address1 = $("#eaddress1").val();
        var address2 = $("#eaddress2").val();
      
        var landmark = $("#elandmark").val();
        if (email != "" && area != "" && city != "" && address1 != "" && landmark != "") {
            $(".urbanAnother").slideUp();
            $(".loadwait").fadeIn();
            $.ajax({
                type: "POST",
                url: 'WebService.asmx/saveAddress',
                data: "{email:'" + email + "',city:'" + city + "',area:'" + area + "',address1:'" + address1 + "',address2:'" + address2 + "',landmark:'" + landmark + "'}",
                contentType: "application/json",
                datatype: "json",
                async: "true",
                success: function (response) {
                    $(".loadwait").fadeOut();
                    window.location.href = "ShippingAddress.aspx";

                },
                error: function (response) {
                    $(".urbanAnother").slideDown();
                    showMessageBox(response.status);
                }
            });
        }
        else {
            showMessageBox("Please fill all the fields");
        }

    });

    $(".btnGoToSlot").click(function () {
        var id = $("#dlAddress").val();
        window.location.href = "DeliverySlot.aspx?adid=" + id;

    });

    $(".btnExpress").click(function () {
        $(".urbanFast").slideDown();
    });

    $(".fbtnclose").click(function () {
        $(".urbanFast").slideUp();
    });

    $(".btnPlaceOrder").click(function () {
        var coupon = $(".txtcoupon").val();
        var totalOrderAmount = $("#ContentPlaceHolder1_lblTotalAmount").text();
        if (totalOrderAmount >= 200)
            {
        if (coupon != "")
        {
            placeOrderFlag = "place";
            checkCoupon(coupon);
            
        }
        else {
            placeOrder();
        }
        }
        else {
            
            showMessageBox("Minimum Order Should be 200 !");
        }
       
    });

    var ac = $(".addressBox");
    $(".goodiesbox").hide();
    $(".orderBox").hide();
    $(".btnProfile").click(function () {
        ac.slideUp("fast");
        ac = $(".addressBox");
        $(".addressBox").slideDown();
    });
    $(".btnMyAddress").click(function () {
        ac.slideUp("fast");
        ac = $(".addressBox");
        $(".addressBox").slideDown();
    });
    $(".btnGoodies").click(function () {
        ac.slideUp("fast");
        ac = $(".goodiesbox");
        $(".goodiesbox").slideDown();
    });
    $(".btnOrders").click(function () {
        ac.slideUp("fast");
        ac = $(".orderBox");
        $(".orderBox").slideDown();
    });

    $(".btnCancelOrder").click(function () {
        var id = $(this).attr("data-id");
        $(".loadwait").fadeIn();
        $.ajax({
            type: "POST",
            url: 'WebService.asmx/cancelOrder',
            data: "{id:'" + id + "'}",
            contentType: "application/json",
            datatype: "json",
            async: "true",
            success: function (response) {
                $(".loadwait").fadeOut();
                if (response.d != "no") {
                    showMessageBox("Your Order Has been Canceled");
                    window.location.href = "MyAccount.aspx";
                }
                else {
                    showMessageBox("You Can't Cancel this Order Now ,Order already processed .");
                }
            },
            error: function (response) {
                showMessageBox(response.status);
            }
        });
    });

    $(".btnApplyCoupon").click(function () {
        var coupon = $(".txtcoupon").val();
        if (coupon=="")
        {
            showMessageBox("Enter Valid Coupon Numer !");
        }
        else
        {
            placeOrderFlag = "checkonly";

            checkCoupon(coupon);
        }
        
    });

    function checkCoupon(coupon)
    {
        $(".loadwait").fadeIn();
        var sessionid = $("#hdnsessionid").val();
        var email = $("#hdemail").val();
        $.ajax({
            type: "POST",
            url: 'WebService.asmx/applyCoupon',
            data: "{email:'"+email+"',coupon:'" + coupon + "',sessionid:'" + sessionid + "'}",
            contentType: "application/json",
            datatype: "json",
            async: "true",
            success: function (response) {
                $(".loadwait").fadeOut();
                var res = response.d.split(",");
                if (response.d != "no") {
                    validcoupon = coupon;
                    //$(".btnApplyCoupon").fadeOut(true);
                    $(".invalidCoupon").fadeOut();
                    $(".validCoupon").text(response.d);
                    $(".validCoupon").fadeIn();
                    var totalAmount = $("#ContentPlaceHolder1_lblTotalPayAmount").text() - res[1];
                    $("#ContentPlaceHolder1_lblTotalPayAmount").text(totalAmount);
                    isvalid = true;
                    if (placeOrderFlag == "place")
                    {
                        placeOrder();
                    }
                   
                }
                else {
                    $(".invalidCoupon").fadeIn();
                    $(".validCoupon").fadeOut();
                    isvalid=false;
                }
            },
            error: function (response) {
                showMessageBox(response.status);
            }
        });
    }

    function placeOrder()
    {
        var chk = 0;
        $('input[type=radio]').each(function () {

            if ($(this).is(':checked')) {
                chk = 1;
                var payoption = $(".urbanPayment").val();
                if (payoption === 'no') {
                    showMessageBox("Please Select Payment Option");
                    $(".urbanPayment").focus();
                    $(".urbanPayment").css("border-color", "red");
                }
                else {
                    var myslot = $(this).val();
                    var adid = $("#dlAddress").val();
                    chk = 1;
                    var mydate = $(this).attr("rel");
                    var email = $("#hdemail").val();
                    var goodies = $("#goodies").val();
                    var instruction = "no";
                    goodies = $.trim(goodies);
                    if (goodies === "") {
                        goodies = 0;
                    }

                    $(".loadwait").fadeIn();
                    $.ajax({
                        type: "POST",
                        url: 'WebService.asmx/confirm',
                        data: "{myslot:'" + myslot + "',adid:'" + adid + "',mydate:'" + mydate + "',payoption:'" + payoption + "',email:'" + email + "',goodies:'" + goodies + "',coupon:'"+validcoupon+"',instruction:'" + instruction + "'}",
                        contentType: "application/json",
                        datatype: "json",
                        async: "true",
                        success: function (response) {
                            $(".loadwait").fadeOut();

                            if (response.d == "myaccount")
                            {
                                $(".loadwait").fadeIn();
                                $(".reviewBox").slideDown();
                            }
                            else {
                                window.location.href = response.d;
                            }
                            

                        },
                        error: function (response) {
                            showMessageBox(response.status);
                        }
                    });



                }
            }
        });
        if (chk == 0) {
            showMessageBox("Please Select Your Time Slot ");
            window.location.href = "ShippingAddress.aspx#moveMeHere";
        }
    }

    $(".btnRedeemGoodies").click(function () {
        var goodies = $("#goodies").val();
        var email = $("#hdemail").val();
        goodies = $.trim(goodies);
        if(goodies!="")
        {
            if (goodies >= 100) {
                var validgoodies = (goodies % 100);
                if (validgoodies == 0) {
                    $(".loadwait").fadeIn();
                    $.ajax({
                        type: "POST",
                        url: 'WebService.asmx/myGoodies',
                        data: "{email:'" + email + "',goodies:'" + goodies + "'}",
                        contentType: "application/json",
                        datatype: "json",
                        async: "true",
                        success: function (response) {
                            $(".loadwait").fadeOut();
                            var res = response.d.split(",");

                            if (res[0] != "no") {
                                var totalAmount = $("#ContentPlaceHolder1_lblTotalPayAmount").text() - res[2];
                                $("#ContentPlaceHolder1_lblTotalPayAmount").text(totalAmount);
                                //$(".btnRedeemGoodies").fadeOut();
                                $(".invalidRedeem").fadeOut();
                                $(".validRedeem").text(res[1] + " Rs. " + res[2]);
                                $(".validRedeem").fadeIn();

                            }
                            else {
                                $(".invalidRedeem").fadeIn();
                                $(".invalidRedeem").text(res[1] + " " + res[2] + " Goodies");
                                $(".validRedeem").fadeOut();

                            }
                        },
                        error: function (response) {
                            showMessageBox(response.status);
                        }
                    });
                }
                else {
                    showMessageBox("Wrong amount of goodies , it should be multipule of 100 !");
                }
            }
            else {
                showMessageBox("Goodies value should be more then 100 !");
            }
        }
    });

    $(".btnSendRiview").click(function () {
        var review = $("#txtReview").val();
        var email = $("#hdemail").val();
       

        if (review != "")
            {
            $(".reviewBox").slideUp();
            $(".loadwait").fadeIn();
        $.ajax({
            type: "POST",
            url: 'WebService.asmx/sendReview',
            data: "{email:'" + email + "',review:'" + review + "'}",
            contentType: "application/json",
            datatype: "json",
            async: "true",
            success: function (response) {
                $(".loadwait").fadeOut();
                window.location.href = "MyAccount.aspx";
            },
            error: function (response) {
                $(".reviewBox").slideDown();
                showMessageBox(response.status);
            }
        });

        }
        else {
            showMessageBox("Please write some words as your review for Urban Banya !");
        }

    });

    $(".reviewbtnclose").click(function () {
        $(".reviewBox").slideUp();
        $(".loadwait").fadeOut();
        window.location.href = "MyAccount.aspx";
    });
   
});