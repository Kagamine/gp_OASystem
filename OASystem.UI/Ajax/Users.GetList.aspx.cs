using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;

namespace OASystem.UI.Ajax
{
    public partial class Users_GetList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var Name = Request.Form["Name"].ToString();
            var Page = Convert.ToInt32(Request.Form["Page"]);
            var DepartmentID = Convert.ToInt32(Request.Form["DepartmentID"]);
            using (Dal.DB db = new Dal.DB())
            {
                var users = (from u in db.Users
                             where u.Name.Contains(Name)
                             && u.DepartmentID == (DepartmentID == 0 ? u.DepartmentID : DepartmentID)
                             select u).Skip(50 * Page).Take(50).ToList();
                JavaScriptSerializer jss = new JavaScriptSerializer();
                Response.Write(jss.Serialize(users));
            }
        }
    }
}