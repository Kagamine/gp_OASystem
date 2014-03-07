using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace OASystem.Entity
{
    [Table("uploads")]
    public class Upload
    {
        [Column("id")]
        public int ID { get; set; }

        [Column("user_id")]
        [ForeignKey("User")]
        public int UserID { get; set; }

        public virtual User User { get; set; }

        [Column("type")]
        public int TypeAsInt { get; set; }

        [NotMapped]
        public UploadType Type 
        {
            get { return (UploadType)TypeAsInt; }
            set { TypeAsInt = (int)value; }
        }

        [Column("filename")]
        public string Filename { get; set; }

        [Column("file")]
        public byte[] File { get; set; }
    }
    public enum UploadType { Private, Public };
}
