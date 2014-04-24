<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="User_Schedules.aspx.cs" Inherits="OASystem.UI.User_Schedules" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="bs-header" id="content">
        <div class="container">
            <h1>日程管理</h1>
       </div>
    </div>
    <input type="hidden" value="<%=user_id %>" id="user_id" />
    <div class="container" style="margin-top:30px;">
         <table style="width: 100%">
            <thead>
                <tr>
                    <th>编号</th>
                    <th>用户名</th>
                    <th>部门</th>
                    <th>日程标题</th>
                    <th>日程内容</th>
                    <th>日期</th>
                </tr>
            </thead>
            <tbody id="lstSchedulesByUser">
            </tbody>
        </table>
    </div>
   
     <script src="Scripts/jquery.js" type="text/javascript"></script>
     
      <script>
          var page = 0;
    </script>
</asp:Content>

