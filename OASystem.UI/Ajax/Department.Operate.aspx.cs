using OASystem.Entity;
using OASystem.UI.Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OASystem.UI.Ajax
{
    public partial class Department_Operate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        /// <summary>
        /// 删除部门
        /// </summary>
        /// <param name="department_id"></param>
        /// <returns></returns>
        [WebMethod]
        public static string DeleteDepartment(int department_id)
        {
            Department Department=new Department ();
            using (Dal.DB db = new Dal.DB())
            {
                Department = db.Departments.Find(department_id);
               // Department.Title = "aaa";
                db.Departments.Remove(Department);
                db.SaveChanges();
            }
            return "ok";
        }

        /// <summary>
        /// 取全部部门
        /// </summary>
        /// <returns></returns>
        [WebMethod]
        public static List<Department> GetAllDepartment()
        {
            List<Department> Departments = new List<Department>();
            using (Dal.DB db = new Dal.DB())
            {
                db.Configuration.ProxyCreationEnabled = false;
                Departments = (from d in db.Departments select d).ToList();
            }
            return Departments;
        }
    }
}