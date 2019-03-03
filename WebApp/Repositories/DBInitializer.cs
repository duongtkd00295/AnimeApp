using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace Repositories
{
    public class DBInitializer: DropCreateDatabaseAlways<DatabaseContext>
    {
        protected override void Seed(DatabaseContext context)
        {
            Role role = new Role()
            {
                RoleId = Guid.NewGuid().ToString(),
                RoleName = "Admin",
                Status = true,
                IsSysAdmin = true
            };
            context.Roles.Add(role);
            User user = new User()
            {
                Status = true,
                UserId = Guid.NewGuid().ToString(),
                UserName = "admin"
            };
            context.Users.Add(user);
            UserPassword password = new UserPassword()
            {
                UserId = user.UserId,
                PasswordId = Guid.NewGuid().ToString(),
                Password = "F3O1mKoocVu7y4NExBmKqA=="
            };
           
            context.UserPasswords.Add(password);
            UserRole userRole = new UserRole()
            {
                UserRoleId = Guid.NewGuid().ToString(),
                UserId = user.UserId,
                RoleId = role.RoleId
            };
            context.UserRoles.Add(userRole);
            base.Seed(context);
        }
    }
}
