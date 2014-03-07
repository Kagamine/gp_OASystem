using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.Cryptography;

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
                var username = Request.Form["Username"].ToString();
                var password = Request.Form["Password"].ToString();
                var bytespwd = SHA1.Create().ComputeHash(Encoding.UTF8.GetBytes(password));
                Entity.User user = (from u in db.Users
                                    where u.Username == username
                                    && u.Password == bytespwd
                                    select u).SingleOrDefault();
                if (user == null) return;
                Session["User"] = user;
                Response.Write("OK");
            }
        }
    }
}