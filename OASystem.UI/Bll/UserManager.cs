using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OASystem.Entity;

namespace OASystem.UI.Bll
{
    public static class UserManager
    {
        /// <summary>
        /// 添加一个用户
        /// </summary>
        /// <param name="user">用户实体</param>
        /// <returns>产生的用户id，如果失败返回-1</returns>
        public static int Insert(User user)
        {
            using (Dal.DB db = new Dal.DB())
            {
                if (db.Users.Any(x => x.Username == user.Username))
                {
                    return -1;
                }
                else
                {
                    db.Users.Add(user);
                    db.SaveChanges();
                    return user.ID;
                }
            }
        }
    }
}