using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using OASystem.Entity;

namespace OASystem.UI.Dal
{
    public class DB:DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Upload> Uploads { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<UserLog> UserLogs { get; set; }
        public DB()
            : base("mysqldb")
        { 
            
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //构建Department实体一对多关系
            modelBuilder.Entity<Department>()
                .HasMany(d => d.User)
                .WithRequired(u => u.Department);

            //构建User实体一对多关系
            modelBuilder.Entity<User>()
                           .HasMany(u => u.UserLog)
                           .WithRequired(ul => ul.User);
        }
    }
}