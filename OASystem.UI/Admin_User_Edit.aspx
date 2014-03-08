<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Admin_User_Edit.aspx.cs" Inherits="OASystem.UI.Admin_User_Edit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <h2>编辑员工</h2>
        <p><b>照片</b></p>
        <p><asp:Image ID="imgAvatar" runat="server" Width="100" Height="100" /></p>
        <p><asp:FileUpload ID="FileUpload1" runat="server" CssClass="form-control" /></p>
        <p><b>姓名</b></p>
        <p><asp:TextBox ID="txtName" runat="server" CssClass="form-control"></asp:TextBox></p>
        <p><b>密码(不修改请留空)</b></p>
        <p><asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox></p>
        <p><b>部门</b></p>
        <p><asp:DropDownList ID="cbbDepartment" runat="server" CssClass="form-control"><asp:ListItem Text="未分配" Value="0"></asp:ListItem></asp:DropDownList></p>
        <p><b>职务</b></p>
        <p><asp:DropDownList ID="cbbRole" runat="server" CssClass="form-control"><asp:ListItem Text="Worker" Value="0"></asp:ListItem><asp:ListItem Text="Manager" Value="1"></asp:ListItem><asp:ListItem Text="Root" Value="2"></asp:ListItem></asp:DropDownList></p>
        <p><asp:Button ID="btnSubmit" runat="server" Text="修改" CssClass="btn btn-primary" OnClick="btnSubmit_Click" /> <asp:Button CssClass="btn btn-danger" ID="btnDelete" runat="server" Text="删除员工" /></p>
    </div>
</asp:Content>
