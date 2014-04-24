using OASystem.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OASystem.UI
{
    public partial class Admin_Events : System.Web.UI.Page
    {
        public string user_rank;
        public string user_id;
        protected void Page_Load(object sender, EventArgs e)
        {
            User User = (User)Session["User"];
            if (User != null)
            {
                user_rank = User.RoleAsInt.ToString();
                user_id = User.ID.ToString();
            }

<<<<<<< HEAD
=======
            using (Dal.DB db = new Dal.DB())
            {
                var departments = (from d in db.Departments
                                   select d).ToList();
                foreach (var d in departments)
                {
                    ListItem item = new ListItem();
                    item.Text = d.Title;
                    item.Value = d.ID.ToString();
                    cbbDepartment.Items.Add(item);
                }
            }
>>>>>>> 3aabe62cdccf29aead7c454a773c6bc3e00d87ab
        }
    }
}