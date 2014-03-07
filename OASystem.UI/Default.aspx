<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="OASystem.UI.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="bs-header" id="content">
        <div class="container">
            <h1>智联办公自动化系统</h1>
            <p>随着社会进步，电子办公在生活中变得越来越重要，在人力资源紧张时，则需要借助计算机的力量来提高工作效率，与传统的办公模式相比，使用电子办公系统可以做到资源的节省、信息的实时发布、明晰的人员管理。同时现在社会对环境的保护要求越来越高，而无纸的办公方式也会为保护环境起到一定的作用，因此该系统诞生了。</p>
        </div>
    </div>
    <div class="container bs-docs-container">
        <div class="bs-docs-section">
            <h2>功能介绍</h2>
            <p>前台采用HTML5、CSS3进行界面设计，Javascript、JQuery进行交互性优化，后台采用ASP.Net进行业务逻辑处理、跳转等操作。系统划分为三层分别为数据连接层，业务逻辑层和表现层。</p>
            <p>该系统划分为如下模块：</p>
            <p>人事管理：机构管理，部门管理，员工管理</p>
            <p>日程管理：我的日历，部门日历，我的便签</p>
            <p>文档管理: 文档管理，回收站，文件搜索</p>
            <p>消息传递：信息管理，信箱</p>
            <p>系统管理：角色管理，登陆日志，操作日志，菜单排序</p>
            <p>考勤管理：签到签退，考勤查询，考勤统计</p>
        </div>
    </div>
</asp:Content>
