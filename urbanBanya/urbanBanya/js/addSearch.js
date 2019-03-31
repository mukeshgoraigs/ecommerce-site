function clickOnItem(event, object) {
    window.location.href = object.href;

    event.stopPropagation();
}


function clickOnAdd(event, object) {   
    var size = $(object).attr("data-size");
    var dataid = $(object).attr("data-id");
    var newprice = $(object).attr("data-price");
    var oldprice = $(object).attr("data-oldprice");
    var sessionid = $("#hdnsessionid").val();
    var img = $(object).attr("data-img");

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

    event.stopPropagation();
}
function addProduct(dataid, oldprice, newprice, sessionid, size) {
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
function GetCartJson(ctrl) {



    $("#test1").load(window.location + ' #test2', function (event) {

        $(ctrl).blur(function () { getkeypresstextbox(ctrl); });

        //initGrid();
    });

}