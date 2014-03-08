<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Files.aspx.cs" Inherits="OASystem.UI.Files" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <table>
            <thead>
                <tr>
                    <th>文件编号</th>
                    <th>文件标题</th>
                    <th>文件大小</th>
                    <th>操作</th>
                </tr>
            </thead>
            <tbody id="lstFiles">

            </tbody>
        </table>
    </div>
</asp:Content>
