using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OASystem.Entity;

namespace OASystem.UI.Bll
{
    public static class UserLogManager
    {
        public static void Insert(UserLog user_log)
        {
            using (Dal.DB db = new Dal.DB())
            {
                db.UserLogs.Add(user_log);
                db.SaveChanges();
            }
        }
    }
}