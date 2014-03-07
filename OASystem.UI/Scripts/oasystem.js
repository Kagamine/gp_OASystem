$(document).ready(function () {
    $("#btnLogin").unbind().click(function () {
        $.post("Ajax/Users.Login.aspx", {
            Username: $("txtUsername").val(),
            Password: $("txtPassword").val()
        }, function (data) {
            alert(data);
            if (data == "OK") {
                location.href = "Default.aspx";
            }
            else {
                $("#DialogContent").html("<h2>登录失败</h2><p>您输入的用户名或密码错误，请重新尝试</p>");
            }
        });
    });
});