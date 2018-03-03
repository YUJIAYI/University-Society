$().ready(function() {
    $(".form_datetime").datetimepicker({
        autoclose: true,
        //isRTL: App.isRTL(),
        format: "yyyy-MM-dd hh:ii"
        // pickerPosition: (App.isRTL() ? "bottom-right" : "bottom-left")
    });
    $('.form_date').datetimepicker({
        weekStart: 1,
        todayBtn: 1,
        autoclose: 1,
        todayHighlight: 1,
        startView: 2,
        minView: 2,
        forceParse: 0,
        format: 'yyyy-mm-dd'
    });

    $("#submit").click(function () {
        var data = $("form").serializeArray(); //自动将form表单封装成json


        //                $.ajax({
        //                    type: "Post",   //访问WebService使用Post方式请求
        //                    contentType: "application/json", //WebService 会返回Json类型
        //                    url: "/home/ratearticle", //调用WebService的地址和方法名称组合 ---- WsURL/方法名
        //                    data: data,         //这里是要传递的参数，格式为 data: "{paraName:paraValue}",下面将会看到      
        //                    dataType: 'json',
        //                    success: function (result) {     //回调函数，result，返回值
        //                        alert(result.UserName + result.Mobile + result.Pwd);
        //                    }
        //                });

        $.post("/demo/form", data, RateArticleSuccess, "json");
    });
});
function RateArticleSuccess() {
    log("ok");
}
//$(".back").click(back);
