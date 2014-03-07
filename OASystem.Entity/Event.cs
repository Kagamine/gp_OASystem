using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.ComponentModel.DataAnnotations.Schema;

namespace OASystem.Entity
{
    [Table("events")]
    public class Event
    {
        [Column("id")]
        public int ID { get; set; }

        [Column("user_id")]
        [ForeignKey("UserID")]
        public int UserID { get; set; }

        public virtual User User { get; set; }

        [Column("manager_id")]
        [ForeignKey("Manager")]
        public int ManagerID { get; set; }

        public virtual User Manager { get; set; }

        [Column("root_id")]
        [ForeignKey("Root")]
        public int RootID { get; set; }

        public virtual User Root { get; set; }

        [Column("title")]
        public string Title { get; set; }

        [Column("content")]
        public string Content { get; set; }

        [Column("status")]
        public int StatusAsInt { get; set; }

        [NotMapped]
        public EventStatus Status 
        {
            get { return (EventStatus)StatusAsInt; }
            set { StatusAsInt = (int)value; }
        }

        [Column("feedback")]
        public string FeedBack { get; set; }

        [Column("department_id")]
        [ForeignKey("Department")]
        public int DepartmentID { get; set; }

        public virtual Department Department { get; set; }
    }
    public enum EventStatus { Pending, ManagerDisposing,RootDisposing, Done };
}
