<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Admin_Departments.aspx.cs" Inherits="OASystem.UI.Admin_Departments" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="bs-header" id="content">
        <div class="modal fade" id="bsAddDepartmentDialog" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                        <h4 class="modal-title">添加部门</h4>
                    </div>
                    <div class="modal-body">
                        <p><b>名称</b></p>
                        <p><asp:TextBox ID="departmentAddName" runat="server" CssClass="form-control" Width="300px"></asp:TextBox></p>
                        <p><b>描述</b></p>
                        <p><asp:TextBox ID="departmentAddDecriptment" runat="server" CssClass="form-control" TextMode="MultiLine" Width="300px"></asp:TextBox></p>
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


      <div class="container">
            <h1>部门管理</h1>
            <p></p>
      </div>
    </div>

    <div class="container">
          <h2>部门列表</h2>
      <p><a href="javascript:void(0);" id="btnShowAddDepartment">添加部门</a></p>
      <table style="width: 100%">
            <thead>
                <tr>
                    <th>部门ID</th>
                    <th>部门名称</th>
                    <th>部门简介</th>
                    <th>操作</th>
                </tr>
            </thead>
            <tbody id="lstDepartments">
                <%
                  foreach(var department in departments){    
                %>
                <tr><td class="departmentId"><%=department.ID %></td><td><%=department.Title %></td><td><%=department.Description %></td><td><a href="Admin_Department_Edit.aspx?id=<%=department.ID %>" >修改</a><a style="margin-left:20px;" class="delDepartment">删除</a></td></tr>
                <%
                 }     
                %>
            </tbody>
        </table>
    </div>
</asp:Content>

