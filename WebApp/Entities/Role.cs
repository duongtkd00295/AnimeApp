using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Role
    {
        public Role()
        {
            UserRoles = new HashSet<UserRole>();
        }
        [Key]
        public string RoleId { get; set; }
        public string RoleName { get; set; }
        public bool Status { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool IsSysAdmin { get; set; }
        public virtual ICollection<RolePermission> AssignedRoles { get; set; }
        public virtual ICollection<UserRole> UserRoles { get; set; }
    }
}
