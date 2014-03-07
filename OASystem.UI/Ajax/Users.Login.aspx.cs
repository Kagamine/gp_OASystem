using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OASystem.UI.Ajax
{
    public partial class Users_Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Form["Username"] == null || Request.Form["Password"] == null)
            {
                return;
            }
            using (Dal.DB db = new Dal.DB())
            {
                Entity.User user = (from u in db.Users
                            where u.Username == Request.Form["Username"].ToString()
                            && u.Password == Request.Form["Password"]
                            select u).FirstOrDefault();
                if (user == null) return;
                else Session["User"] = user;
                Response.Write("OK");
            }
        }
    }
}