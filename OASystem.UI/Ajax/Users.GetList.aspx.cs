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
            var Name = Request.QueryString["Name"].ToString();
            var Page = Convert.ToInt32(Request.QueryString["Page"]);
            var DepartmentID = Convert.ToInt32(Request.QueryString["DepartmentID"]);
            using (Dal.DB db = new Dal.DB())
            {
                var users = (from u in db.Users
                             where u.Name.Contains(Name)
                             orderby u.ID ascending
                             select u).ToList();
                for (int i = 0; i < users.Count(); i++)
                {
                    if (users[i].Department != null)
                        users[i].DepartmentTitle = users[i].Department.Title;
                    else
                        users[i].DepartmentTitle = "";
                }
                if (DepartmentID != 0)
                {
                    users.Where(x=>x.DepartmentID == DepartmentID);
                }
                JavaScriptSerializer jss = new JavaScriptSerializer();
                Response.Write(jss.Serialize(users));
            }
        }
    }
}