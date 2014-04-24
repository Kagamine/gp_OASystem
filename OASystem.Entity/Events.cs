using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OASystem.Entity
{

    [Table("events")]
    public class Events
    {
        [Column("id")]
        public int ID { set; get; }

        [Column("root_id")]
        [ForeignKey("Root")]
        public int RootID { set; get; }

        public virtual User Root { set; get; }

        [Column("time")]
        public DateTime Time { set; get; }

        [NotMapped]
        public string TimeAsString { get { return Time.ToString(); } }

        [Column("title")]
        public string Title { set; get; }

        [Column("content")]
        public string Content { set; get; }

        [Column("status")]
        public int StatusAsInt { set; get; }

        [NotMapped]
        public EventStatus Status
        {
            get { return (EventStatus)StatusAsInt; }
            set { StatusAsInt = (int)value; }
        }

        [Column("feedback")]
        public string FeedBack { set; get; }
    }
    public enum EventStatus { Pending, ManagerDisposing, RootDisposing, Done };
}
