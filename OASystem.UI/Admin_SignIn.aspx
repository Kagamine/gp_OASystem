<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Admin_SignIn.aspx.cs" Inherits="OASystem.UI.Admin_SignIn" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="bs-header" id="content">
        <div class="modal fade" id="bsAddSignDialog" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                        <h4 class="modal-title">添加签到</h4>
                    </div>
                    <div class="modal-body">
                        <input type="hidden" id="user_id" value="<%=user_id %>" />
                        <p><b>签到的类型</b></p>
                        <p><asp:DropDownList ID="dllAddSignInKind" runat="server">
                           <asp:ListItem Value="0">签到</asp:ListItem>
                            <asp:ListItem Value="1">签退</asp:ListItem>
                           </asp:DropDownList></p>
                        <p><asp:Button ID="btnAddSign" runat="server" Text="提交增加" OnClick="btnAddSign_click" /></p>
                        <asp:Panel ID="plAddSignWarning" runat="server"></asp:Panel>
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
            <h1>签到管理</h1>
            <p></p>
       </div>
    </div>
    <div class="container">
        <h2>签到列表</h2>
        <p>检索：<input type="text" id="txtName" placeholder="姓名" />
            <asp:DropDownList ID="cbbDepartment" runat="server" ClientIDMode="Static">
                <asp:ListItem Text="全部部门" Value="0"></asp:ListItem>
            </asp:DropDownList>
            <input type="button" value="检索" class="btn btn-sm btn-primary" id="btnSignSearch" /></p>
        <p id="pAddSign"><a href="javascript:void(0);" id="btnShowAddSign">添加日程</a></p>
         <table style="width: 100%">
            <thead>
                <tr>
                    <th>编号</th>
                    <th>用户名</th>
                    <th>部门</th>
                    <th>签到时间</th>
                    <th>签到类型</th>
                    <th>操作</th>
                </tr>
            </thead>
            <tbody id="lstSigns">
            </tbody>
        </table>
    </div>
   
     <script src="Scripts/jquery.js" type="text/javascript"></script>
     
      <script>
          var page = 0;
    </script>  
</asp:Content>
