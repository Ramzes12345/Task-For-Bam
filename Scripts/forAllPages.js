function ForceLogOut() {
    $.ajax({
        type: "POST",
        url: "/Account/ForceLogOut",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        async: false,
        success: function (json) {
          
        },
        error: function () {
        }
    });
    window.location.href = "/Account/Login";
}
var tid = setTimeout(mycode, 2000);
function mycode() {
    GetInfo();
    tid = setTimeout(mycode, 2000);
}

function GetInfo() {
    $.ajax({
        type: "POST",
        url: "/Account/GetInfo",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (json) {
            if (json.NeedLogOut == "true") {
                ForceLogOut();
            }
        },
        error: function () {
        }
    });
}