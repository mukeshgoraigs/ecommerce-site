$(document).ready(function () {
    $(".cd-dropdown").css("top", 155);

    $(".js-showpincode").animate({ marginTop: "50px" }, 300, function () {
        $(".login").animate({ marginTop: "50px" }, 300, function () {
            $(".signup").animate({ marginTop: "50px" }, 300);
        });
    });
    $(window).scroll(function () {
        var sctop = $(window).scrollTop();
        var wi = $(window).width();
       
        $(".cd-dropdown").css("top", sctop + 105);

        if (sctop > 100) {
            //$(".userHeader").css("margin-top", -35);
            //$(".searchHeader").css("margin-top", -35);
            //$(".logo").css("width", 200);
            //$(".logo").css("height", 70);
          
          
            $(".js-showpincode").animate({ marginTop: "50px" }, 300, function () {
                $(".login").animate({ marginTop: "50px" }, 300, function () {
                    $(".signup").animate({ marginTop: "50px" }, 300);
                });
            });
          
          
           
        }
        else {
            //$(".userHeader").css("margin-top", 0);
            //$(".searchHeader").css("margin-top", 0);
            //$(".logo").css("width", 260);
            //$(".logo").css("height", 100);
          
            $(".js-showpincode").animate({ marginTop: "50px" }, 300, function () {
                $(".login").animate({ marginTop: "50px" }, 300, function () {
                    $(".signup").animate({ marginTop: "50px" }, 300);
                });
            });
        }

       
    });

});