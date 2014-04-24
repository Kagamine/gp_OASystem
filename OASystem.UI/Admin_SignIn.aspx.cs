using OASystem.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OASystem.UI
{
    public partial class Admin_SignIn : System.Web.UI.Page
    {
        public string user_rank;
        public int user_id;
        protected void Page_Load(object sender, EventArgs e)
        {
            User User = (User)Session["User"];
            if (User != null)
            {
                user_id = User.ID;
            }

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
        }


        protected void btnAddSign_click(object sender, EventArgs e)
        {
           
                string SignType = dllAddSignInKind.SelectedValue;
                SignLog Sign = new SignLog();
                Sign.UserID = user_id;
                Sign.TypeAsInt = Convert.ToInt32(SignType);
                Sign.Time = DateTime.Now;
                using (Dal.DB db = new Dal.DB())
                {
                    db.SignLogs.Add(Sign);
                    db.SaveChanges();
                }
                Response.Redirect("Admin_SignIn.aspx");
           
        } 
    }
}