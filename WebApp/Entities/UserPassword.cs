using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class UserPassword
    {
        [Key]
        public string PasswordId { get; set; }
        public string Password { get; set; }  
        public DateTime? CreateDate { get; set; }
        public DateTime? PasswordChangedDate { get; set; }
        public string UserId { get; set; }
        public virtual User User { get; set; }
    }
}
