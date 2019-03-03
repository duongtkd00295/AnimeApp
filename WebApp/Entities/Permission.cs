using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Permission
    {
        [Key]
        public string PermissionId { get; set; }
        public string ControllerName { get; set; }
        public string ActionName { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string CreateBy { get; set; }
        public string ModifiedBy { get; set; }
        public bool Status { get; set; }
        public virtual ICollection<RolePermission> AssignedRoles { get; set; }
    }
}
