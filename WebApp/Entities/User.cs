using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class User
    {
        public User()
        {
            UserRoles = new HashSet<UserRole>();
        }
        [Key]
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public string PhoneNumber { get; set; }
        public bool Status { get; set; }   
        public DateTime? CreateDate { get; set; } = DateTime.Now;
        public DateTime ? ModifiedDate { get; set; }
        public string CreateBy { get; set; }
        public virtual ICollection<UserRole> UserRoles { get; set; }
    }
}
