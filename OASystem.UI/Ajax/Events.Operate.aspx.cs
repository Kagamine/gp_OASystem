using OASystem.Entity;
using OASystem.UI.Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OASystem.UI.Ajax
{
    public partial class Events_Operate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        [WebMethod]
        public static string AddEvent(int root_id, string title,string content)
        {
            Event Event = new Event();
            Event.Title = title;
            Event.Content = content;
            Event.RootID = root_id;
            Event.Time = DateTime.Now;
            using (DB db = new DB())
            {
                db.Configuration.ProxyCreationEnabled = false;
                db.Events.Add(Event);
                db.SaveChanges();
            }

            return "ok";
        }


        [WebMethod]
        public static List<Event> GetAllEvents(string dataName, int Page)
        {
            List<Event> Events = new List<Event>();
            List<User> Users = new List<User>();
            Dal.DB db = new DB();

            db.Configuration.ProxyCreationEnabled = false;

            Events = (from s in db.Events select s).ToList();
            if (dataName != "")
            {
                Events = (from e in db.Events
                             where e.Root.Username.Contains(dataName)
                             select e).ToList();
            }
         
            return Events;
        }
    }
}