using OASystem.Entity;
using OASystem.UI.Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OASystem.UI
{
    public partial class User_Files : System.Web.UI.Page
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
        }


        protected void Upload_Click(object sender, EventArgs e)
        {
            if (upFile.HasFile)
            {
                var filename = DateTime.Now.ToString("yyMMddHHmmss") + System.IO.Path.GetExtension(upFile.FileName);
                System.IO.File.WriteAllBytes(System.Web.HttpContext.Current.Request.PhysicalApplicationPath + "\\Uploads\\" + filename, upFile.FileBytes);
            }

            File File = new File();
            File.Time = DateTime.Now;
            File.FileName = upFile.FileName;
            File.UserID =Convert.ToInt32(user_id);

            using (DB db = new DB())
            {
                db.Files.Add(File);
                db.SaveChanges();
            }

        }
    }
}