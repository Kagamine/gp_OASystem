 <%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Admin_Users.aspx.cs" Inherits="OASystem.UI.Admin_Users" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="bs-header" id="content">
        <div class="modal fade" id="bsAddUserDialog" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                        <h4 class="modal-title">添加员工</h4>
                    </div>
                    <div class="modal-body">
                        <p><b>姓名</b></p>
                        <p><asp:TextBox ID="txtAddName" runat="server" CssClass="form-control"></asp:TextBox></p>
                        <p><b>用户名</b></p>
                        <p><asp:TextBox ID="txtAddUsername" runat="server" CssClass="form-control"></asp:TextBox></p>
                        <p><b>密码</b></p>
                        <p><asp:TextBox ID="txtAddPassword" runat="server" CssClass="form-control"></asp:TextBox></p>
                        <p><asp:Button ID="btnAdd" runat="server" Text="添加" CssClass="btn btn-primary" OnClick="btnAdd_Click" /></p>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                    </div>
                </div>
                <!-- /.modal-content -->
            </div>
            <!-- /.modal-dialog -->
        </div>
        <!-- /.modal -->
        <div class="container">
            <h1>员工管理</h1>
        </div>
    </div>
    <div class="container">
        <h2>员工列表</h2>
        <p>检索：<input type="text" id="txtName" placeholder="姓名" />
            <asp:DropDownList ID="cbbDepartment" runat="server" ClientIDMode="Static">
                <asp:ListItem Text="全部部门" Value="0"></asp:ListItem>
            </asp:DropDownList>
            <input type="button" value="检索" class="btn btn-sm btn-primary" id="btnUsersSearch" /></p>
        <p><a href="javascript:void(0);" id="btnShowAddUser">添加员工</a></p>
        <table style="width: 100%">
            <thead>
                <tr>
                    <th>员工ID</th>
                    <th>用户名</th>
                    <th>姓名</th>
                    <th>手机号码</th>
                    <th>部门</th>
                    <th>职务</th>
                    <th>操作</th>
                </tr>
            </thead>
            <tbody id="lstUsers">
            </tbody>
        </table>
    </div>
    <script>
        var page = 0;
    </script>
</asp:Content>
