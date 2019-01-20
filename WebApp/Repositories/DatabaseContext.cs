using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using MySql.Data.Entity;

namespace Repositories
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class DatabaseContext:DbContext
    {
        public DatabaseContext() : base("name=context")
        {
            Database.SetInitializer(new DBInitializer());
        }
        public DbSet<Function> Functions { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserPassword> UserPasswords { get; set; }
        public DbSet<AssignedRole> AssignedRoles { get; set; }
    }
}
