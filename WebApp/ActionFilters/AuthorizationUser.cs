using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repositories;
using Entities;
namespace ActionFilters
{
    public class AuthorizationUser
    {
        public string UserId { get; set; }
        public bool IsSysAdmin { get; set; }
        public string Username { get; set; }
        private List<UserRole> Roles = new List<UserRole>();


        public AuthorizationUser(string username)
        {
            this.Username = username;
            this.IsSysAdmin = false;
            GetUserRolesPermissions();

        }

        public bool HasPermission(string requiredPermission)
        {
            bool bFound = false;
            foreach (UserRole role in this.Roles)
            {
                bFound = (role.Permissions.Where(p => p.PermissionDescription.ToLower() == requiredPermission.ToLower()).ToList().Count > 0);
                if (bFound)
                    break;
            }
            return bFound;
        }

        public bool HasRole(string role)
        {
            return (Roles.Where(p => p.RoleName == role).ToList().Count > 0);
        }

        public bool HasRoles(string roles)
        {
            bool bFound = false;
            string[] _roles = roles.ToLower().Split(';');
            foreach (UserRole role in this.Roles)
            {
                try
                {
                    bFound = _roles.Contains(role.RoleName.ToLower());
                    if (bFound)
                        return bFound;
                }
                catch (Exception)
                {
                }
            }
            return bFound;
        }

        public void GetUserRolesPermissions()
        {
            using (DatabaseContext data = new DatabaseContext())
            {
                User user = data.Users.FirstOrDefault(u => u.UserName == this.Username);
                if (user != null)
                {
                    this.UserId = user.UserId;
                    foreach (var role in user.UserRoles)
                    {
                        UserRole userRole = new UserRole()
                        {
                            Role_Id = role.RoleId,
                            RoleName = role.Role.RoleName
                        };
                        foreach (var permission in role.Role.AssignedRoles)
                        {
                            RolePermission rolePermission = new RolePermission() { Permission_Id = permission.PermissionId, PermissionDescription = string.Format("{0}-{1}", permission.Permission.ControllerName, permission.Permission.ActionName) };
                            userRole.Permissions.Add(rolePermission);
                        }
                        this.Roles.Add(userRole);
                        if (!this.IsSysAdmin)
                            this.IsSysAdmin = role.Role.IsSysAdmin;
                    }
                }
            }
        }

    }

    public class UserRole
    {
        public string Role_Id { get; set; }
        public string RoleName { get; set; }
        public List<RolePermission> Permissions = new List<RolePermission>();
    }

    public class RolePermission
    {
        public string Permission_Id { get; set; }
        public string PermissionDescription { get; set; }
    }
}
