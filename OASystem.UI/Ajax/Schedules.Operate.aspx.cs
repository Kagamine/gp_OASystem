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
    public partial class Schedules_Getlist : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        #region 根据部门得到用户
        /// <summary>
        /// 根据部门得到用户
        /// </summary>
        /// <returns></returns>
        [WebMethod]
        public static List<User> GetUserByDepartment(int department_id)
        {
            List<User> Users = new List<User>();
            using (Dal.DB db = new DB())
            {
                db.Configuration.ProxyCreationEnabled = false;
                Users = (from u in db.Users
                         where u.DepartmentID == department_id
                         select u).ToList();
            }
            return Users;
        } 
        #endregion

        #region 得到全部日程的集合
        /// <summary>
        /// 得到全部日程的集合
        /// </summary>
        /// <param name="dataName"></param>
        /// <param name="Page"></param>
        /// <param name="DepartmentID"></param>
        /// <returns></returns>
        [WebMethod]
        public static List<Schedule> GetSchedulesList(string dataName, int Page, int DepartmentID)
        {

            List<Schedule> Schedules = new List<Schedule>();
            List<User> Users = new List<User>();
            Dal.DB db = new DB();

            db.Configuration.ProxyCreationEnabled = false;
           
            Schedules = (from s in db.Schedules select s).ToList();
            if (dataName != "")
            {
                Schedules = (from s in db.Schedules
                             where s.ToUser.Username.Contains(dataName)
                             select s).ToList();
            }

           
            
            if (DepartmentID != 0) 
            {
                Schedules = (from s in db.Schedules 
                              where s.DepartmentID==DepartmentID
                             select s).ToList();
            }

            foreach (Schedule Schedule in Schedules)
            {
                Schedule.ToUser = db.Users.Find(Schedule.ToUserID);
                Schedule.SubmittionUser = db.Users.Find(Schedule.SubmittionUserID);
                Schedule.Department = db.Departments.Find(Schedule.DepartmentID);
            }
          
            return Schedules;
        } 
        #endregion

        #region 增加日程
        /// <summary>
        /// 增加日程
        /// </summary>
        /// <param name="submit_user_id"></param>
        /// <param name="to_user_id"></param>
        /// <param name="title"></param>
        /// <param name="content"></param>
        /// <param name="department_id"></param>
        /// <returns></returns>
        [WebMethod]
        public static string AddSchedule(int submit_user_id, int to_user_id, string title, string content, int department_id)
        {
            Schedule Schedule = new Schedule();
            Schedule.ToUserID = to_user_id;
            Schedule.SubmittionUserID = submit_user_id;
            Schedule.Title = title;
            Schedule.Content = content;
            Schedule.DepartmentID = department_id;
            Schedule.Time = DateTime.Now;
            using (Dal.DB db = new DB())
            {
                db.Schedules.Add(Schedule);
                db.SaveChanges();
            }
            return "ok";
        }  
        #endregion


<<<<<<< HEAD


        /// <summary>
        /// 根据用户查找日程
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
       [WebMethod]
        public static List<Schedule> GetSchedulesListByUserId(int userID)
        {

            List<Schedule> Schedules = new List<Schedule>();
            List<User> Users = new List<User>();
            Dal.DB db = new DB();

            db.Configuration.ProxyCreationEnabled = false;

            Schedules = (from s in db.Schedules 
                         where s.ToUserID==userID
                         select s).ToList();
          

            foreach (Schedule Schedule in Schedules)
            {
                Schedule.ToUser = db.Users.Find(Schedule.ToUserID);
                Schedule.SubmittionUser = db.Users.Find(Schedule.SubmittionUserID);
                Schedule.Department = db.Departments.Find(Schedule.DepartmentID);
            }

            return Schedules;
        }  
=======
>>>>>>> 3aabe62cdccf29aead7c454a773c6bc3e00d87ab
       
    }
}