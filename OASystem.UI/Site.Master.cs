﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OASystem.UI
{
    public partial class Site : System.Web.UI.MasterPage
    {
        public string navbar = "";
        private const string navbar_template = "<li><a href='{0}'>{1}</a></li>\r\n";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"] != null)
            {
                switch ((Session["User"] as Entity.User).Role)
                { 
                    case Entity.UserRole.Root:
                        navbar += String.Format(navbar_template, "员工管理", "Admin_Users.aspx");
                        navbar += String.Format(navbar_template, "部门管理", "Admin_Departments.aspx");
                        navbar += String.Format(navbar_template, "日程管理", "Admin_Schedules.aspx");
                        navbar += String.Format(navbar_template, "考勤管理", "Admin_SignIn.aspx");
                        navbar += String.Format(navbar_template, "文件管理", "Admin_Files.aspx");
                        navbar += String.Format(navbar_template, "事务管理", "Admin_Events.aspx");
                        break;
                }
            }
        }
    }
}