using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OASystem.Entity
{

    [Table("files")]
    public class File
    {
        [Column("id")]
        public int ID { set; get; }

        [Column("file_name")]
        public string FileName{set;get;}

        [Column("time")]
        public DateTime Time { set; get; }

        [NotMapped]
        public string TimeAsString { get { return Time.ToString(); } }

        [Column("user_id")]
        [ForeignKey("User")]
        public int UserID { set; get; }
        public virtual User User { set; get; }
        

    }
}
