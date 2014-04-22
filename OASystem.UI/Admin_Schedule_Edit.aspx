<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Admin_Schedule_Edit.aspx.cs" Inherits="OASystem.UI.Admin_Schedule_Edit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <h2>日程操作</h2>
        <p><b>日程名称</b></p>
        <p><asp:TextBox ID="txtEditScheduleName" runat="server" CssClass="form-control"></asp:TextBox></p>
        <p><b>日程内容</b></p>
        <p><asp:TextBox ID="txtEditScheduleContent" runat="server" CssClass="form-control"></asp:TextBox></p>
        <p><b>适用的员工的部门</b></p>
        <p><asp:DropDownList ID="ddlEditScheduleDepartment" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="ddlEditScheduleDepartment_SelectedIndexChanged"></asp:DropDownList></p>
        <p><b>适用的员工</b></p>
        <p><asp:DropDownList ID="ddlEditScheduleToUser" runat="server" CssClass="form-control"></asp:DropDownList></p>
        <p><asp:Button ID="btnSubmitUpdate" runat="server" Text="修改" CssClass="btn btn-primary" OnClick="btnSubmitUpdate_Click"  /><asp:Button ID="btnDeleteSchedule" runat="server" Text="删除" CssClass="btn btn-danger" OnClick="btnDeleteSchedule_Click"/></p>
    </div>

</asp:Content>
