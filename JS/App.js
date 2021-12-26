$(document).ready(function () {

    $("#Login").click(function () {
        var options = {};
        options.url = "https://localhost:44360/api/User/token";
        options.type = "POST";

        var username = $("#UserName").val();
        var password = $("#Password").val();
        var obj = {};
        obj.username = username;
        obj.password = password;
        options.data = JSON.stringify(obj);
        options.contentType = "application/json";
        options.dataType = "json";
        options.success = function (data) {
            if (data.isSuccess) {
                if (data != "Error") {
                    console.log(data.tokenInfo);
                    sessionStorage.setItem("token", data.tokenInfo.token);
                    
                        window.location.href = '/Uyeler/Liste'
                    
                }

                $("#response").html("<h2>User successfully logged in.</h2 > ");
                
                options.beforeSend = function (request) {
                    request.setRequestHeader("Authorization", "Bearer " + sessionStorage.getItem("token"));

                };
               
               
                
                
            } else {
                $("#response").html("<h2>Geçersiz giriş!</h2 > ");
            }

        };
        options.error = function () {
            $("#response").html("<h2>Error while calling the Web API!</h2 > ");
        };
        $.ajax(options);
    });
});