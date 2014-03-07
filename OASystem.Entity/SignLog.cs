using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.ComponentModel.DataAnnotations.Schema;

namespace OASystem.Entity
{
    [Table("sign_logs")]
    public class SignLog
    {
        [Column("id")]
        public int ID { get; set; }

        [Column("user_id")]
        public int UserID { get; set; }

        public virtual User User { get; set; }

        [Column("type")]
        public int TypeAsInt { get; set; }

        [NotMapped]
        public SignType Type
        {
            get { return (SignType)TypeAsInt; }
            set { TypeAsInt = (int)value; }
        }
    }
    public enum SignType { Login,Logout };
}
