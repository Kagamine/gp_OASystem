using OASystem.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OASystem.UI.Ajax
{
    public partial class Signs_Operate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        [WebMethod]
        public static List<SignLog> GetAllSigns(string dataName,int Page, int DepartmentID)
        {
            List<SignLog> Signs = new List<SignLog>();
            Dal.DB db = new Dal.DB();
            db.Configuration.ProxyCreationEnabled = false;
            Signs = (from s in db.SignLogs select s).ToList();
            if(dataName!="")
            {
                Signs = (from s in db.SignLogs
                         where s.User.Name.Contains(dataName)
                         select s).ToList();
            }
            if (DepartmentID != 0)
            {
                Signs = (from s in db.SignLogs
                             where s.User.DepartmentID == DepartmentID
                             select s).ToList();
            }

            foreach (SignLog Sign in Signs)
            {
                Sign.User = db.Users.Find(Sign.UserID);
                Sign.User.DepartmentTitle = db.Departments.Find(Sign.User.DepartmentID).Title;
            }  

            return Signs;
        }
    }
}