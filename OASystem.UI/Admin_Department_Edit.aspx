<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Admin_Department_Edit.aspx.cs" Inherits="OASystem.UI.Admin_Department_Edit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <h2>部门编辑</h2>
        <p><b>部门名称</b></p>
        <p><asp:TextBox ID="departmentName" runat="server" CssClass="form-control"></asp:TextBox></p>
        <p><b>部门描述</b></p>
        <p><asp:TextBox ID="descripment" runat="server" CssClass="form-control"></asp:TextBox></p>
        <p><asp:Button ID="btnSubmit" runat="server" Text="修改" CssClass="btn btn-primary" OnClick="btnSubmit_Click" /></p>
    </div>
</asp:Content>
