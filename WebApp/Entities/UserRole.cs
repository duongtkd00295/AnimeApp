using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class UserRole
    {
        [Key, Column(Order = 0)]
        public string UserRoleId { get; set; }
        [Key, Column(Order = 1)]
        public string UserId { get; set; }
        [Key, Column(Order = 2)]
        public string RoleId { get; set; }
        public virtual Role Role { get; set; }
        public virtual User User { get; set; }

    }
}
