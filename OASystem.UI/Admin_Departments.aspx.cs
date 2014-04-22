using OASystem.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OASystem.UI
{
    public partial class Admin_Departments : System.Web.UI.Page
    {
        public List<Department>  departments;
        protected void Page_Load(object sender, EventArgs e)
        {
            using (Dal.DB db = new Dal.DB())
            {
               departments = (from d in db.Departments
                                   select d).ToList();
               
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Department Department = new Department();
            Department.Title = departmentAddName.Text;
            Department.Description = departmentAddDecriptment.Text;

            using (Dal.DB db = new Dal.DB())
            {
                db.Departments.Add(Department);
                db.SaveChanges();
            }
            departmentAddName.Text = "";
            departmentAddDecriptment.Text = "";
        }

    }
}