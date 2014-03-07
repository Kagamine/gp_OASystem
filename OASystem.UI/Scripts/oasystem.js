$(document).ready(function () {
    $("#btnLogin").unbind().click(function () {
        $.post("Ajax/Users.Login.aspx", {
            Username: $("txtUsername").val(),
            Password: $("txtPassword").val()
        }, function (data) {
            if (data == "OK") {
                location.href = "Default.aspx";
            }
            else {
                $("#DialogTitle").html("登录失败");
                $("#DialogContent").html("您输入的用户名或密码错误，请重新尝试");
                $("#bsDialog").modal('show');
            }
        });
    });
});