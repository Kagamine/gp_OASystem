using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Security.Cryptography;

namespace OASystem.UI
{
    public partial class Admin_User_Edit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
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
                    int uid = Convert.ToInt32(Request.QueryString["ID"]);
                    var user = db.Users.Find(uid);
                    txtName.Text = user.Name;
                    if (user.Avatar != null)
                    {
                        imgAvatar.ImageUrl = "data:image/png;base64," + Convert.ToBase64String(user.Avatar);
                    }
                    if (user.DepartmentID != null)
                    {
                        var item = cbbDepartment.Items.FindByValue(user.DepartmentID.GetValueOrDefault().ToString());
                        cbbDepartment.SelectedIndex = cbbDepartment.Items.IndexOf(item);
                    }
                    var i = cbbRole.Items.FindByValue(user.RoleAsInt.ToString());
                    cbbRole.SelectedIndex = cbbRole.Items.IndexOf(i);
                }
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            using (Dal.DB db = new Dal.DB())
            {
                int uid = Convert.ToInt32(Request.QueryString["ID"]);
                var user = db.Users.Find(uid);
                if (!string.IsNullOrEmpty(txtPassword.Text))
                {
                    user.Password = SHA1.Create().ComputeHash(Encoding.UTF8.GetBytes(txtPassword.Text));
                }
                user.DepartmentID = Convert.ToInt32(cbbDepartment.SelectedValue);
                if (user.DepartmentID == 0)
                    user.DepartmentID = null;
                user.Role = (Entity.UserRole)Convert.ToInt32(cbbRole.SelectedValue);
                user.Name = txtName.Text;
                if (FileUpload1.HasFile)
                {
                    user.Avatar = FileUpload1.FileBytes;
                }
                db.SaveChanges();
                imgAvatar.ImageUrl = "data:image/png;base64," + Convert.ToBase64String(user.Avatar);
            }
        }
    }
}