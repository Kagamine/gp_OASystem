using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Script.Serialization;

namespace OASystem.Entity
{
    [Table("users")]
    public class User
    {
        [Column("id")]
        public int ID { get; set; }

        [Column("username")]
        public string Username { get; set; }

        [Column("password")]
        [ScriptIgnore]
        public byte[] Password { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("phone_number")]
        public string PhoneNumber { get; set; }

        [Column("avatar")]
        public byte[] Avatar { get; set; }

        [Column("role")]
        [ScriptIgnore]
        public int RoleAsInt { get; set; }

        [NotMapped]
        public UserRole Role 
        {
            get { return (UserRole)RoleAsInt; }
            set { RoleAsInt = (int)value; }
        }

        [Column("department_id")]
        public int? DepartmentID { get; set; }

        [ScriptIgnore]
        public virtual Department Department { get; set; }

        [ScriptIgnore]
        public virtual ICollection<UserLog> UserLog { get; set; }

        public override int GetHashCode()
        {
            return this.ID;
        }

        public override bool Equals(object obj)
        {
            var user = obj as User;
            if (user.ID == this.ID) return true;
            else return false;
        }
    }
    public enum UserRole { Worker, Manager, Root };
}
