using OASystem.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OASystem.UI
{
    public partial class Admin_Schedule_Edit : System.Web.UI.Page
    {
 
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int sid = Convert.ToInt32(Request.QueryString["id"]);
                Schedule Schedule=new Entity.Schedule();
                List<Department> Departments=new List<Department> ();
                List<User> Users = new List<User>();
                using (Dal.DB db = new Dal.DB())
                {
                    Departments=(from d in db.Departments select d).ToList();
                    Schedule = db.Schedules.Find(sid);
                    Users = db.Users.Where<User>(u => u.DepartmentID == Schedule.DepartmentID).ToList();                 
                    txtEditScheduleName.Text = Schedule.Title;
                    txtEditScheduleContent.Text = Schedule.Content;
                    
                    foreach (Department Department in Departments) 
                    {
                        ddlEditScheduleDepartment.Items.Add(Department.Title);
                        ddlEditScheduleDepartment.Items.FindByText(Department.Title).Value = Department.ID.ToString();
                    }
                    ddlEditScheduleDepartment.SelectedValue = Schedule.DepartmentID.ToString();
                   
                    foreach (User User in Users)
                    {
                        ddlEditScheduleToUser.Items.Add(User.Username);
                        ddlEditScheduleToUser.Items.FindByText(User.Username).Value = User.ID.ToString();
                       
                    }
                    ddlEditScheduleToUser.SelectedValue = Schedule.ToUserID.ToString();
                    
                }
            }
        }

        protected void btnSubmitUpdate_Click(object sender, EventArgs e)
        {
            
            int sid = Convert.ToInt32(Request.QueryString["id"]);
            User User=(User)Session["User"];
            Schedule Schedule = new Schedule();
            using (Dal.DB db = new Dal.DB())
            {
                Schedule = db.Schedules.Find(sid);
                Schedule.Title = txtEditScheduleName.Text;
                Schedule.Content = txtEditScheduleContent.Text;
                Schedule.Time = DateTime.Now;
                Schedule.ToUserID = Convert.ToInt32(ddlEditScheduleToUser.SelectedValue);
                Schedule.SubmittionUserID = User.ID;
                Schedule.DepartmentID = Convert.ToInt32(ddlEditScheduleDepartment.SelectedValue);
              
                db.SaveChanges();
            }

            Response.Redirect("Admin_Schedules.aspx");
        }

        protected void ddlEditScheduleDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<User> Users = new List<Entity.User>();
            int? DepartmentID =Convert.ToInt32(ddlEditScheduleDepartment.SelectedValue);
            using (Dal.DB db = new Dal.DB())
            {
                Users = db.Users.Where(u => u.DepartmentID == DepartmentID).ToList(); 
            }
            ddlEditScheduleToUser.Items.Clear();
            if (Users.Count== 0)
            {
                ddlEditScheduleToUser.Items.Add("无");
                ddlEditScheduleToUser.Items.FindByText("无").Value = "0";
            }
            else 
            { 
                foreach (User User in Users)
                {
                    ddlEditScheduleToUser.Items.Add(User.Username);
                    ddlEditScheduleToUser.Items.FindByText(User.Username).Value = User.ID.ToString();
                   // ddlEditScheduleToUser.SelectedItem.Value = Schedule.ToUserID.ToString();
                }
            }
            
        }

        protected void btnDeleteSchedule_Click(object sender, EventArgs e)
        {
            int sid = Convert.ToInt32(Request.QueryString["id"]);
            Schedule Schedule = new Schedule();
            using (Dal.DB db = new Dal.DB())
            {
                Schedule = db.Schedules.Find(sid);
                db.Schedules.Remove(Schedule);
                db.SaveChanges();
            }
            Response.Redirect("Admin_Schedules.aspx");
        }
    }
}