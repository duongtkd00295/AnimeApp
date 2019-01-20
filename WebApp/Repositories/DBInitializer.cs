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
                Status = true
            };
            context.Roles.Add(role);
            User user = new User()
            {
                RoleId = role.RoleId,
                Status = true,
                UserId = Guid.NewGuid().ToString(),
                UserName = "admin"
            };
            context.Users.Add(user);
            UserPassword password = new UserPassword()
            {
                UserId = user.UserId,
                PasswordId = Guid.NewGuid().ToString(),
                Password = "admin"
            };
            context.UserPasswords.Add(password);
            base.Seed(context);
        }
    }
}
