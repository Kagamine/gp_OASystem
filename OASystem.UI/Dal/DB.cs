using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using OASystem.Entity;

namespace OASystem.UI.Dal
{
    public class DB: DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Upload> Uploads { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<UserLog> UserLogs { get; set; }
        public DbSet<SignLog> SignLogs { get; set; }
        public DbSet<Event> Events { get; set; }

        public DB()
            : base("mysqldb")
        { 
            
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //构建Department实体一对多关系
            modelBuilder.Entity<Department>()
                .HasMany(d => d.Users)
                .WithRequired(u => u.Department);

            modelBuilder.Entity<Department>()
                .HasMany(d => d.Events)
                .WithRequired(e => e.Department);

            //构建User实体一对多关系
            modelBuilder.Entity<User>()
                           .HasMany(u => u.UserLog)
                           .WithRequired(ul => ul.User);
        }
    }
}