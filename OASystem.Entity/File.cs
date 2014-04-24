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

<<<<<<< HEAD
        [NotMapped]
        public string TimeAsString { get { return Time.ToString(); } }

=======
>>>>>>> 3aabe62cdccf29aead7c454a773c6bc3e00d87ab
        [Column("user_id")]
        [ForeignKey("User")]
        public int UserID { set; get; }
        public virtual User User { set; get; }
        

    }
}
