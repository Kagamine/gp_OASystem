using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.Cryptography;
using System.Text;

namespace OASystem.UI
{
    public partial class Admin_Users : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            using (Dal.DB db = new Dal.DB())
            {
                var departments = (from d in db.Departments
                                   select d).ToList();
                foreach(var d in departments)
                {
                    ListItem item = new ListItem();
                    item.Text = d.Title;
                    item.Value = d.ID.ToString();
                    cbbDepartment.Items.Add(item);
                }
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            using (Dal.DB db = new Dal.DB())
            {
                db.Users.Add(new Entity.User()
                {
                    Name = txtAddName.Text,
                    Username = txtAddUsername.Text,
                    Password = SHA1.Create().ComputeHash(Encoding.UTF8.GetBytes(txtAddPassword.Text))
                });
                db.SaveChanges();
            }
        }
    }
}