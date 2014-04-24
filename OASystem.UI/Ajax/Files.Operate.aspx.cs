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
    public partial class Files_Operate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }



       #region 得到全部的文件
		 /// <summary>
        /// 得到全部的文件
        /// </summary>
        /// <param name="dataName"></param>
        /// <param name="Page"></param>
        /// <param name="DepartmentID"></param>
        /// <returns></returns>
        [WebMethod]
        public static List<File> GetFiles(string dataName, int Page, int DepartmentID)
        {
            List<File> Files = new List<File>();
            Dal.DB db = new DB();

            db.Configuration.ProxyCreationEnabled = false;
            Files = (from f in db.Files select f).ToList();

            if (dataName != "")
            {
                Files = (from f in db.Files
                         where f.User.Name == dataName
                         select f).ToList();
            }

            if (DepartmentID != 0)
            {
                Files = (from f in db.Files
                         where f.User.DepartmentID == DepartmentID
                         select f).ToList();
            }

            foreach (File File in Files)
            {
                File.User = db.Users.Find(File.UserID);
                File.User.DepartmentTitle = db.Departments.Find(File.User.ID).Title;
            }

            return Files;

        } 
	#endregion



        #region 根据用户查找上传的文件
        /// <summary>
        /// 根据用户查找上传的文件
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        [WebMethod]
        public static List<File> GetFilesListByUserId(int userID)
        {
            List<File> Files = new List<File>();
            Dal.DB db = new DB();

            db.Configuration.ProxyCreationEnabled = false;
            Files = (from f in db.Files
                     where f.UserID == userID
                     select f).ToList();

            foreach (File File in Files)
            {
                File.User = db.Users.Find(File.UserID);
                File.User.DepartmentTitle = db.Departments.Find(File.User.ID).Title;
            }

            return Files;

        }  
        #endregion
        
    }
}