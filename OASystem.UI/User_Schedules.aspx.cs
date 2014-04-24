using OASystem.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OASystem.UI
{
    public partial class User_Schedules : System.Web.UI.Page
    {
        public string user_rank;
        public string user_id;
        protected void Page_Load(object sender, EventArgs e)
        {
            User User=(User)Session["User"];
            if (User != null)
            {
                user_rank = User.RoleAsInt.ToString();
                user_id = User.ID.ToString();
            } 
        }
    }
}