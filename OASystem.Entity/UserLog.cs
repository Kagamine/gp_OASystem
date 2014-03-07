using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace OASystem.Entity
{
    [Table("user_logs")]
    public class UserLog
    {
        [Column("id")]
        public int ID { get; set; }

        [Column("user_id")]
        [ForeignKey("User")]
        public int UserID { get; set; }

        public virtual User User { get; set; }

        [Column("time")]
        public DateTime Time { get; set; }

        [Column("content")]
        public string Content { get; set; }
    }
}
