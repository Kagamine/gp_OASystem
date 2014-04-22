using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;

namespace OASystem.UI
{
    public partial class Admin_Department_Edit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) 
            {
                using (Dal.DB db = new Dal.DB())
                {
                    int did = Convert.ToInt32(Request.QueryString["ID"]);
                    var Department = db.Departments.Find(did);
                    departmentName.Text = Department.Title;
                    descripment.Text = Department.Description;
                }
            }
        }


        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            using (Dal.DB db = new Dal.DB())
            {
                int did = Convert.ToInt32(Request.QueryString["ID"]);
                var Department = db.Departments.Find(did);
                Department.Title = departmentName.Text;
                Department.Description = descripment.Text;
                db.SaveChanges();
                Response.Redirect("Admin_Departments.aspx");
            }
        }


      
    }
}