<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Admin_Files.aspx.cs" Inherits="OASystem.UI.Admin_Files" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="bs-header" id="content">
        <div class="modal fade" id="bsAddFileDialog" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                        <h4 class="modal-title">上传文件</h4>
                    </div>
                    <div class="modal-body">
                        <input type="hidden" id="user_id" value="<%=user_id %>" />
                        <p><b>选择上传文件</b></p>
                        <p><asp:FileUpload ID="upFile" runat="server" /></p>
                        <p><asp:Button ID="btnFileUpload" runat="server" Text="确定上传"  OnClick="Upload_Click" /></p>
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
            <h1>文件管理</h1>
            <p></p>
       </div>
    </div>

    <div class="container">
         <h2>文件列表</h2>
        <input type="hidden" id="user_rank" value="<%=user_rank %>" />
        <p>检索：<input type="text" id="txtName" placeholder="姓名" />
            <asp:DropDownList ID="cbbDepartment" runat="server" ClientIDMode="Static">
                <asp:ListItem Text="全部部门" Value="0"></asp:ListItem>
            </asp:DropDownList>
         <input type="button" value="检索" class="btn btn-sm btn-primary" id="btnEventsSearch" /></p>
        <p id="pAddEvents"><a href="javascript:void(0);" id="btnShowAddUploadFile">上传文件</a></p>
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
            <tbody id="lsFiles">
            </tbody>
        </table>
    </div>
</asp:Content>
