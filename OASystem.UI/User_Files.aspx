<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="User_Files.aspx.cs" Inherits="OASystem.UI.User_Files" %>
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

    <div class="container" style="margin-top:30px;">
        <input type="hidden" value="<%=user_id %>" id="user_id" />
        <p id="pAddEvents"><a href="javascript:void(0);" id="btnShowAddUploadFile">上传文件</a></p>
         <table style="width: 100%">
            <thead>
                <tr>
                    <th>编号</th>
                    <th>上传用户</th>
                    <th>上传用户部门</th>
                    <th>文件名</th>
                    <th>上传时间</th>
                </tr>
            </thead>
            <tbody id="lsFilesByUser">
            </tbody>
        </table>
    </div>
    <script>
        var page = 0;
    </script>
</asp:Content>
