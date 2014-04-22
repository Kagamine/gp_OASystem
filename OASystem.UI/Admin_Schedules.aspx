<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Admin_Schedules.aspx.cs" Inherits="OASystem.UI.Admin_Schedules" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="bs-header" id="content">
        <div class="modal fade" id="bsAddScheduleDialog" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                        <h4 class="modal-title">添加日程</h4>
                    </div>
                    <div class="modal-body">
                        <input type="hidden" id="user_id" value="<%=user_id %>" />
                        <p><b>名称</b></p>
                        <p><input type="text" id="ttbAddScheduleName" class="form-control" style="width:300px;" /></p>
                        <p><b>内容</b></p>
                        <p><textarea  id="ttbAddScheduleContent" class="form-control" style="width:300px;" ></textarea></p>
                        <p><b>部门</b></p>
                        <p>
                            <select id="addScheduleDepartmrnt">
                                <option value="0">选择部门</option>
                            </select></p>
                        <p><b>部员</b></p>
                        <p>
                            <select id="addScheduleUser">
                                <option value="0">部员</option>
                            </select></p> 
                        <p><input type="button" id="btnAddSchedue" value="提交" class="btn btn-info" /></p>
                        <p style="font:100;width:400px;"><span id="txtAddScheduleWarning" style="font-size:20px;color:#ff0000;"></span></p>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                    </div>
                </div>
                <!-- /.modal-content -->
            </div>
            <!-- /.modal-dialog -->
        </div>
        <div class="container">
            <h1>日程管理</h1>
            <p></p>
       </div>
    </div>

    <div class="container">
         <h2>日程列表</h2>
        <input type="hidden" id="user_rank" value="<%=user_rank %>" />
        <p>检索：<input type="text" id="txtName" placeholder="姓名" />
            <asp:DropDownList ID="cbbDepartment" runat="server" ClientIDMode="Static">
                <asp:ListItem Text="全部部门" Value="0"></asp:ListItem>
            </asp:DropDownList>
         <input type="button" value="检索" class="btn btn-sm btn-primary" id="btnSchedulesSearch" /></p>
        <p id="pAddSchedules"><a href="javascript:void(0);" id="btnShowAddSchedules">添加日程</a></p>
         <table style="width: 100%">
            <thead>
                <tr>
                    <th>编号</th>
                    <th>用户名</th>
                    <th>部门</th>
                    <th>日程标题</th>
                    <th>日程内容</th>
                    <th>日期</th>
                    <th>操作</th>
                </tr>
            </thead>
            <tbody id="lstSchedules">
            </tbody>
        </table>
    </div>
   
     <script src="Scripts/jquery.js" type="text/javascript"></script>
     
      <script>
          var page = 0;
          var user_rank = $("#user_rank").val();
          if (user_rank == "0") {
              $("#pAddSchedules").css("display", "none");
          }

    </script>
</asp:Content>

