using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OASystem.UI
{
    public partial class Site : System.Web.UI.MasterPage
    {
        public string navbar = "", loginbar="";
        private const string navbar_template = "<li><a href='{1}'>{0}</a></li>\r\n";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"] != null)
            {
                loginbar += String.Format(navbar_template, "注销", "Logout.aspx");
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
                    case Entity.UserRole.Manager:
                        navbar += String.Format(navbar_template, "部门管理", "Admin_Departments.aspx");
                        navbar += String.Format(navbar_template, "日程管理", "Admin_Schedules.aspx");
                        navbar += String.Format(navbar_template, "考勤管理", "Admin_SignIn.aspx");
                        navbar += String.Format(navbar_template, "文件管理", "Admin_Files.aspx");
                        navbar += String.Format(navbar_template, "事务管理", "Admin_Events.aspx");
                        break;
                    case Entity.UserRole.Worker:
                        navbar += String.Format(navbar_template, "日程", "User_Schedules.aspx");
                        navbar += String.Format(navbar_template, "文件", "User_Files.aspx");
                        navbar += String.Format(navbar_template, "事务", "Admin_Events.aspx");
                        break;
                    default:
                        break;
                }
            }
            else
            {
                loginbar += String.Format(navbar_template, "登录", "Login.aspx");
            }
        }
    }
}