var lock = false;

///加载用户
function LoadUsers()
{
    var position = { 0: 'Worker', 1: 'Manager' ,2:'Root'}

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
                .replace("{user_role}", position[data[i].Role]);
                $("#lstUsers").append(row);
            }
            lock = false;
        });
    }
}


///加载日程
function LoadSchedules() {
    var name = $("#txtName").val();
    var department_id = $("#cbbDepartment").val();
        var name = $("#txtName").val();
        var department_id=$("#cbbDepartment").val()
        if (lock) return;
        lock = true;
        $.ajax({
            type:"post",
            url: "Ajax/Schedules.Operate.aspx/GetSchedulesList",
            contentType: "application/json; chartset=utf-8",
            dataType: "json",
            data: "{ 'dataName':'" + name + "','Page': " + page + ", 'DepartmentID': " + department_id + "}",
            success:function(data){
                $(data.d).each(function () {
                    var row = "<tr id='u{schedule_id}'><td>{schedule_id}</td><td>{user_username}</td><td>{deparement_title}</td><td>{schedule_title}</td><td>{schedule_content}</td><td>{schedule_time}</td><td><a href='Admin_Schedule_Edit.aspx?id={schedule_id}'>操作</a></td></tr>"
                       .replace("{schedule_id}", this.ID)
                       .replace("{schedule_id}", this.ID)
                       .replace("{schedule_id}", this.ID)
                       .replace("{schedule_id}", this.ID)
                       .replace("{user_username}", this.ToUser.Name)
                       .replace("{deparement_title}", this.Department.Title)
                       .replace("{schedule_title}", this.Title)
                       .replace("{schedule_content}", this.Content)
                       .replace("{schedule_time}", this.TimeAsString);
                    $("#lstSchedules").append(row);
                    lock = false;
                });
                },
        });
}

//根据UserId加载日程
function LoadSchedulesByUserID() {
    var user_id = $("#user_id").val();
    if (lock) return;
    lock = true;
    $.ajax({
        type: "post",
        url: "Ajax/Schedules.Operate.aspx/GetSchedulesListByUserId",
        contentType: "application/json; chartset=utf-8",
        dataType: "json",
        data: "{ 'userID':'" + user_id + "'}",
        success: function (data) {
            $(data.d).each(function () {
                var row = "<tr id='u{schedule_id}'><td>{schedule_id}</td><td>{user_username}</td><td>{deparement_title}</td><td>{schedule_title}</td><td>{schedule_content}</td><td>{schedule_time}</td></tr>"
                   .replace("{schedule_id}", this.ID)
                   .replace("{schedule_id}", this.ID)
                   .replace("{schedule_id}", this.ID)
                   .replace("{schedule_id}", this.ID)
                   .replace("{user_username}", this.ToUser.Name)
                   .replace("{deparement_title}", this.Department.Title)
                   .replace("{schedule_title}", this.Title)
                   .replace("{schedule_content}", this.Content)
                   .replace("{schedule_time}", this.TimeAsString);
                $("#lstSchedulesByUser").append(row);
                lock = false;
            });
        },
    });
}

//根据UserId加载
function LoadFilesByUserID() {
    var user_id = $("#user_id").val();
    if (lock) return;
    lock = true;
    $.ajax({
        type: "post",
        url: "Ajax/Files.Operate.aspx/GetFilesListByUserId",
        contentType: "application/json; chartset=utf-8",
        dataType: "json",
        data: "{ 'userID':'" + user_id + "'}",
        success: function (data) {
            $(data.d).each(function () {
                var row = "<tr id='u{file_id}'><td>{file_id}</td><td>{user_username}</td><td>{deparement_title}</td><td>{file_name}</td><td>{file_time}</td></tr>"
                   .replace("{file_id}", this.ID)
                   .replace("{file_id}", this.ID)
                   .replace("{sign_id}", this.ID)
                   .replace("{user_username}", this.User.Name)
                   .replace("{deparement_title}", this.User.DepartmentTitle)
                   .replace("{file_name}", this.FileName)
                   .replace("{file_time}", this.TimeAsString);
                $("#lsFilesByUser").append(row);
                lock = false;
            });
        },
    });
}

//加载签名
function LoadSigns() {
    var type = { 0: '签到', 1: '签退' }
    var name = $("#txtName").val();
    var department_id = $("#cbbDepartment").val()
    if (lock) return;
    lock = true;
    $.ajax({
        type: "post",
        url: "Ajax/Signs.Operate.aspx/GetAllSigns",
        contentType: "application/json; chartset=utf-8",
        dataType: "json",
        data: "{ 'dataName':'" + name + "','Page': " + page + ", 'DepartmentID': " + department_id + "}",
        success: function (data) {
            $(data.d).each(function () {
                var row = "<tr id='u{sign_id}'><td>{sign_id}</td><td>{user_username}</td><td>{deparement_title}</td><td>{sign_time}</td><td>{sign_kind}</td></tr>"
                   .replace("{sign_id}", this.ID)
                   .replace("{sign_id}", this.ID)
                   .replace("{sign_id}", this.ID)
                   .replace("{user_username}", this.User.Name)
                   .replace("{deparement_title}", this.User.DepartmentTitle)
                   .replace("{sign_time}", this.TimeAsString)
                   .replace("{sign_kind}", type[this.TypeAsInt])
                   .replace("{schedule_time}", this.TimeAsString);
                $("#lstSigns").append(row);
                lock = false;
            });
        },
    });
}


///加载事务
function LoadEvents() {
   var Type={ 0:'Pending',1:'ManagerDisposing',2:'RootDisposing',3:'Done' };
    if (lock) return;
    lock = true;
    $.ajax({
        type: "post",
        url: "Ajax/Events.Operate.aspx/GetAllEvents",
        contentType: "application/json; chartset=utf-8",
        dataType: "json",
        data: "{'Page': " + page + "}",
        success: function (data) {
            $(data.d).each(function () {
                var row = "<tr id='u{event_id}'><td>{event_id}</td><td>{user_username}</td><td>{event_title}</td><td>{event_content}</td><td>{event_status}</td><td>{event_time}</td><td><a href=javascript:void(0)' class='deleteEvent'>删除</a></td></tr>"
                   .replace("{event_id}", this.ID)
                   .replace("{event_id}", this.ID)
                   .replace("{user_username}", this.Root.Username)
                   .replace("{event_title}", this.Title)
                   .replace("{event_content}", this.Content)
                   .replace("{event_status}", Type[this.StatusAsInt])
                   .replace("{event_time}", this.TimeAsString);
                $("#lstEvents").append(row);
                lock = false;
                page++;
            });


            ///删除事务
            $(".deleteEvent").click(function () {
                var event_id = $(this).parent("td").parent("tr").children("td:eq(0)").text();
                $.ajax({
                    type: "post",
                    url: "Ajax/Events.Operate.aspx/DeleteEvent",
                    contentType: "application/json; chartset=utf-8",
                    dataType: "json",
                    data: "{'event_id': " + event_id + "}",
                    success: function (data) {
                        if(data.d=="ok")
                        {
                            alert("删除成功！");
                            window.location.reload();
                        }
                    },
                    error:function(data){
                        alert("删除失败！");
                        window.location.reload();
                    },
                });
            });
            },
    });
    
}

//加载文件
function LoadFiles() {
    var name = $("#txtName").val();
    var department_id = $("#cbbDepartment").val()
    if (lock) return;
    lock = true;
    $.ajax({
        type: "post",
        url: "Ajax/Files.Operate.aspx/GetFiles",
        contentType: "application/json; chartset=utf-8",
        dataType: "json",
        data: "{ 'dataName':'" + name + "','Page': " + page + ", 'DepartmentID': " + department_id + "}",
        success: function (data) {
            $(data.d).each(function () {
                var row = "<tr id='u{file_id}'><td>{file_id}</td><td>{user_username}</td><td>{deparement_title}</td><td>{file_name}</td><td>{file_time}</td></tr>"
                   .replace("{file_id}", this.ID)
                   .replace("{file_id}", this.ID)
                   .replace("{sign_id}", this.ID)
                   .replace("{user_username}", this.User.Name)
                   .replace("{deparement_title}", this.User.DepartmentTitle)
                   .replace("{file_name}", this.FileName)
                   .replace("{file_time}", this.TimeAsString);
                $("#lsFiles").append(row);
                lock = false;
            });
        },
    });
}

/*删除日程*/
function DeleteSchedule() {
    $(".aDeleteSchedule").click(function () {
        var schedule_id = this.parent("td").parent("tr").children("td:eq(0)").text();
        alert(schedule_id);
        return false;
        $.ajax({
            type: "post",
            url: "Ajax/Schedules.Operate.aspx/AddSchedule",
            contentType: "application/json; chartset=utf-8",
            dataType: "json",
            data: "{'submit_user_id':'" + submint_user_id + "','to_user_id':'" + to_user_id + "','title':'" + schedule_title + "','content':'" + schedule_content + "','department_id':'" + department_id + "'}",
            success: function (data) {
                if (data.d) {
                    alert("添加成功！");
                    window.location.reload();//添加成功刷新页面；
                }
            },
            error: function (data) {
                $("#txtAddScheduleWarning").text("添加日程失败！");
            },
        });
    });
}

$(document).ready(function () {

    if ($("#lstUsers").length > 0) {
        LoadUsers();
        $(window).scroll(function () {
            totalheight = parseFloat($(window).height()) + parseFloat($(window).scrollTop());
            if ($(document).height() <= totalheight) {
                LoadUsers();
            }
        });
    }

    if ($("#lstSchedules").length > 0) {
        LoadSchedules();
        $(window).scroll(function () {
            totalheight = parseFloat($(window).height()) + parseFloat($(window).scrollTop());
            if ($(document).height() <= totalheight) {
                LoadSchedules();
            }
        });
    }
    
    if ($("#lstSchedulesByUser").length > 0) {
        LoadSchedulesByUserID();
        $(window).scroll(function () {
            totalheight = parseFloat($(window).height()) + parseFloat($(window).scrollTop());
            if ($(document).height() <= totalheight) {
                LoadSchedulesByUserID();
            }
        });
    }

    if ($("#lstSigns").length > 0) {
        LoadSigns();
        $(window).scroll(function () {
            totalheight = parseFloat($(window).height()) + parseFloat($(window).scrollTop());
            if ($(document).height() <= totalheight) {
                LoadSigns();
            }
        });
    }
    
    if ($("#lsFiles").length > 0) {
        LoadFiles();
        $(window).scroll(function () {
            totalheight = parseFloat($(window).height()) + parseFloat($(window).scrollTop());
            if ($(document).height() <= totalheight) {
                LoadFiles();
            }
        });
    }

    if ($("#lsFilesByUser").length > 0) {
        LoadFilesByUserID();
        $(window).scroll(function () {
            totalheight = parseFloat($(window).height()) + parseFloat($(window).scrollTop());
            if ($(document).height() <= totalheight) {
                LoadFilesByUserID();
            }
        });
    }

    if ($("#lstEvents").length > 0) {
        LoadEvents();
        $(window).scroll(function () {
            totalheight = parseFloat($(window).height()) + parseFloat($(window).scrollTop());
            if ($(document).height() <= totalheight) {
                LoadEvents();
            }
        });
    }
    

    /*search user start*/
    $("#btnUsersSearch").click(function () {
        $("#lstUsers").html("");
        page = 0;
        LoadUsers();
    });
    /*search user end*/

    /*user login*/
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

    /*add user*/
    $("#btnShowAddUser").click(function () {
        $("#bsAddUserDialog").modal('show');
    });

    /*显示增加日程框*/
    $("#btnShowAddSchedules").click(function () {
        $("#bsAddScheduleDialog").modal('show');
        $.ajax({
            type: "post",
            url: "Ajax/Department.Operate.aspx/GetAllDepartment",
            contentType: "application/json; chartset=utf-8",
            dataType: "json",
            success: function (data) {
                var str = " <option value='0'>选择部门</option>";
                $(data.d).each(function () {
                    str = str + "<option value=" + this.ID + ">" + this.Title + "</option>"
                });
                $("#addScheduleDepartmrnt").html(str);
            },
            error: function (data) {
                alert("error");
            },
        });

        $("#addScheduleDepartmrnt").change(function () {
            var sdepartment_id = $("#addScheduleDepartmrnt").val();
            $.ajax({
                type: "post",
                url: "Ajax/Schedules.Operate.aspx/GetUserByDepartment",
                contentType: "application/json; chartset=utf-8",
                dataType: "json",
                data: "{ 'department_id':'" + sdepartment_id + "'}",
                success: function (data) {
                    var str = " <option value='0'>选择员工</option>";
                    $(data.d).each(function () {
                        str = str + "<option value=" + this.ID + ">" + this.Username + "</option>"
                    });
                    $("#addScheduleUser").html(str);
                },
                error: function (data) {
                    alert("error");
                },
            });
        });

    });


    $(".delDepartment").click(function () {
        var sdepartment_id = $(this).parent("td").parent("tr").children("td:eq(0)").text();
        $.ajax({
            type: "post",
            url: "/Ajax/Department.Operate.aspx/DeleteDepartment",
            contentType: "application/json; chartset=utf-8",
            dataType: "json",
            data: "{'department_id':'" + sdepartment_id + "' }",
            success: function (data) {
                if (data.d = "ok") {
                    window.location.reload();
                }
                else {
                    alert("删除失败");
                }
            },
            error: function (data) {
                alert("删除失败");
            }
        });
    });

    $("#btnShowAddDepartment").click(function () {
        $("#bsAddDepartmentDialog").modal("show");
    });


    /*提交增加日程*/
    $("#btnAddSchedue").click(function () {
        var schedule_title = $("#ttbAddScheduleName").val();
        var schedule_content = $("#ttbAddScheduleContent").val();
        var to_user_id = $("#addScheduleUser").val();
        var submint_user_id = $("#user_id").val();
        var department_id = $("#addScheduleDepartmrnt").val();
          
        if (submint_user_id =="") {
            $("#txtAddScheduleWarning").text("你还没有登陆，请登陆添加！");
            return false;
        }
        if (schedule_title == "") {
            $("#txtAddScheduleWarning").text("日程标题不能为空！");
            return false;
        }
        if (schedule_content == "") {
            $("#txtAddScheduleWarning").text("日程内容不能为空！");
            return false;
        }
        if (to_user_id == 0) {
            $("#txtAddScheduleWarning").text("请添加使用的员工！");
            return false;
        }
        if (department_id == 0) {
            $("#txtAddScheduleWarning").text("请添加使用的员工的部门！");
            return false;
        }
        if (department_id == 0) {
            $("#txtAddScheduleWarning").text("请添加使用的员工的部门！");
            return false;
        }
         
        $.ajax({
            type: "post",
            url: "Ajax/Schedules.Operate.aspx/AddSchedule",
            contentType: "application/json; chartset=utf-8",
            dataType: "json",
            data: "{'submit_user_id':'" + submint_user_id + "','to_user_id':'"+to_user_id+"','title':'"+schedule_title+"','content':'"+schedule_content+"','department_id':'"+department_id+"'}",
            success: function (data) {
                if (data.d) {
                    alert("添加成功！");
                    window.location.reload();//添加成功刷新页面；
                }
            },
            error: function (data) {
                $("#txtAddScheduleWarning").text("添加日程失败！");
            },
        });
    });

    /*查询日程*/
    $("#btnSchedulesSearch").click(function () {
        $("#lstSchedules").html("");
        LoadSchedules();
    });


    /*显示增加考勤的框*/
    $("#pAddSign").click(function () {
        $("#bsAddSignDialog").modal('show');
    });

       
    /*查询考勤*/
    $("#btnSignSearch").click(function () {
        $("#lstSigns").html("");
        LoadSigns();
    });


    //显示增加事务的框
    $("#btnShowAddEvents").click(function () {
        $("#bsAddEventDialog").modal('show');
    });


    ///增加事务
    $("#btnAddEvent").click(function () {
        var root_id = $("#user_id").val();
        var event_title = $("#ttbAddEventName").val();
        var event_content = $("#ttbAddEventContent").val();
        if (ttbAddEventName == "") {
            $("#txtAddEventWarning").html("请，填写事务的标题");
            return false;
        }
        if (event_content == "") {
            $("#txtAddEventWarning").html("请，填写事务的内容");
            return false;
        }
        $.ajax({
            type: "post",
            url: "Ajax/Events.Operate.aspx/AddEvent",
            contentType: "application/json; chartset=utf-8",
            dataType: "json",
            data: "{'root_id':" + root_id + ",'title':'" + event_title + "','content':'" + event_content +  "'}",
            success: function (data) {
                if (data.d=="ok") {
                    alert("添加成功！");
                    window.location.reload();//添加成功刷新页面；
                }
            },
            error: function (data) {
                $("#txtAddEventWarning").text("添加日程失败！");
            },
        });

    });


    //展示上传文件框
    $("#btnShowAddUploadFile").click(function () {
        $("#bsAddFileDialog").modal('show');
    });

    //检索文件
    $("#btnFilesSearch").click(function () {
        $("#lsFiles").html(" ");
        LoadFiles();
   });



    var user_role = $("#txtUserRole").val();
    if (user_role == "0") {
               
    }
});