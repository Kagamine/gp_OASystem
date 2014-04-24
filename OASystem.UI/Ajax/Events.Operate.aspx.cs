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

        /// <summary>
        /// 增加事务
        /// </summary>
        /// <param name="root_id"></param>
        /// <param name="title"></param>
        /// <param name="content"></param>
        /// <returns></returns>
        [WebMethod]
        public static string AddEvent(int root_id, string title,string content)
        {
            Events Event = new Events();
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





        /// <summary>
        /// 查找事务
        /// </summary>
        /// <param name="dataName"></param>
        /// <param name="Page"></param>
        /// <returns></returns>
        [WebMethod]
        public static List<Events> GetAllEvents(int Page)
        {
            List<Events> Events = new List<Events>();
            List<User> Users = new List<User>();
            Dal.DB db = new DB();

            db.Configuration.ProxyCreationEnabled = false;

            ///分页查询 按时间倒叙查询
             Events = (from e in db.Events
                           orderby e.Time descending
                           select e).ToList();
            int total = Events.Count;
            //跳过的总条数
             int totalNum = (Page) * 10;
             Events = Events.Skip(totalNum).ToList();
             if (Events.Count > 10)
            {
                Events.RemoveRange(10, total - 10);
            }

            /*Events=db.Events.OrderByDescending(e=>e.Time).Select(e => e).Skip(
                (Page) * 10).Take(Page).ToList();  
           */
            foreach (Events Event in Events)
            {
                Event.Root = db.Users.Find(Event.RootID);
            }
            return Events;
        }


        /// <summary>
        /// 删除事务
        /// </summary>
        /// <param name="Page"></param>
        /// <returns></returns>
       [WebMethod]
        public static string DeleteEvent(int event_id)
        {
            Events Event = new Events();
            using(DB db =new DB ())
            {
                Event = db.Events.Find(event_id);
                db.Events.Remove(Event);
                db.SaveChanges();
            }

            return "ok";
           
        }
    }
}