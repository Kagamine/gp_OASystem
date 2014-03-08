var lock = false;

function LoadUsers()
{
    if ($("#lstUsers").length > 0) {
        if (lock) return;
        lock = true;
        $.getJSON("Ajax/Users.Getlist.aspx", {
            Name: $("#txtName").val(),
            Page: page,
            DepartmentID: $("#cbbDepartment").val()
        }, function (data) {
            for (var i in data) {
                var row = "<tr id='u{user_id}'><td>{user_id}</td><td>{user_username}</td><td>{user_name}</td><td>{user_phonenumber}</td><td>{user_departmenttitle}</td><td>{user_role}</td><td><a href='Admin_User_Edit.aspx?id={user_id}'>操作</a></td></tr>"
                .replace("{user_id}", data[i].ID)
                .replace("{user_id}", data[i].ID)
                .replace("{user_id}", data[i].ID)
                .replace("{user_username}", data[i].Username)
                .replace("{user_name}", data[i].Name)
                .replace("{user_phonenumber}", data[i].PhoneNumber)
                .replace("{user_departmenttitle}", data[i].DepartmentTitle)
                .replace("{user_role}", data[i].Role);
                $("#lstUsers").append(row);
            }
            lock = false;
        });
    }
}

$(document).ready(function () {
    if ($("#lstUsers").length > 0)
    {
        LoadUsers();
        $(window).scroll(function () {
            totalheight = parseFloat($(window).height()) + parseFloat($(window).scrollTop());
            if ($(document).height() <= totalheight) {
                LoadUsers();
            }
        });
    }

    $("#btnUsersSearch").click(function () {
        $("#lstUsers").html("");
        page = 0;
        LoadUsers();
    });

    $("#btnLogin").unbind().click(function () {
        $.post("Ajax/Users.Login.aspx", {
            Username: $("#txtUsername").val(),
            Password: $("#txtPassword").val()
        }, function (data) {
            if (data == "OK") {
                self.location = "Default.aspx";
            }
            else {
                $("#DialogTitle").html("登录失败");
                $("#DialogContent").html("您输入的用户名或密码错误，请重新尝试");
                $("#bsDialog").modal('show');
            }
        });
    });

    $("#btnShowAddUser").click(function () {
        $("#bsAddUserDialog").modal('show');
    });
});