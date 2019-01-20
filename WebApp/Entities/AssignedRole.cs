using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class AssignedRole
    {
        [Key,Column(Order = 0)]
        public string AssignedRoleId { get; set; }        
        public DateTime? CreateDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        [Key, Column(Order = 1)]
        public string RoleId { get; set; }
        public virtual  Role Role{ get; set; }
        [Key, Column(Order = 2)]
        public string FunctionId { get; set; }
        public virtual Function Function { get; set; }
    }
}
