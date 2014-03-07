using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace OASystem.Entity
{
    [Table("messages")]
    public class Message
    {
        [Column("id")]
        public int ID { get; set; }

        [Column("from_user_id")]
        [ForeignKey("FromUser")]
        public int FromUserID { get; set; }

        [Column("to_user_id")]
        [ForeignKey("ToUser")]
        public int ToUserID { get; set; }

        public virtual User FromUser { get; set; }

        public virtual User ToUser { get; set; }

        [Column("title")]
        public string Title { get; set; }

        [Column("content")]
        public string Content { get; set; }
    }
}
