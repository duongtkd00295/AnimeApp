using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class RolePermission
    {
        [Key,Column(Order = 0)]
        public string AssignedRoleId { get; set; }        
        [Key, Column(Order = 1)]
        public string RoleId { get; set; }
        public virtual Role Role{ get; set; }
        [Key, Column(Order = 2)]
        public string PermissionId { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public virtual Permission Permission { get; set; }
    }
}
