using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DepartmentStore.Core.Services.Interfaces;
using DepartmentStore.DataLayer.Context;
using DepartmentStore.DataLayer.Entities.Permissions;
using DepartmentStore.DataLayer.Entities.User;

namespace DepartmentStore.Core.Services
{
    public class PermissionService : IPermissionService
    {
        private DepartmentStoreContext _context;

        public PermissionService(DepartmentStoreContext context)
        {
            _context = context;
        }

        public List<Role> GetRoles()
        {
            return _context.Roles.ToList();
        }

        public void AddRolesToUser(List<int> roleIds, int userId)
        {
            foreach (int roleId in roleIds)
            {
                _context.UserRoles.Add(new UserRole()
                {
                    RoleId = roleId,
                    UserId = userId
                });
            }

            _context.SaveChanges();
        }

        public void EditUserRoles(int userId, List<int> roleIds)
        {
            //Delete All User Roles
            _context.UserRoles.Where(r => r.UserId == userId)
                .ToList().ForEach(r => _context.UserRoles.Remove(r));

            //Add New Roles
            AddRolesToUser(roleIds, userId);
        }

        public int AddRole(Role role)
        {
            _context.Roles.Add(role);
            _context.SaveChanges();
            return role.RoleId;
        }

        public Role GetRoleById(int roleId)
        {
            return _context.Roles.Find(roleId);
        }

        public void UpdateRole(Role role)
        {
            _context.Roles.Update(role);
            _context.SaveChanges();
        }

        public void DeleteRole(Role role)
        {
            role.IsDelete = true;
            UpdateRole(role);
        }

        public List<Permission> GteAllPermissions()
        {
            return _context.Permission.ToList();
        }

        public void AddPermissionsToRole(int roleId, List<int> permission)
        {
            foreach (int p in permission)
            {
                _context.RolePermission.Add(new RolePermission()
                {
                    RoleId = roleId,
                    PermissionId = p
                });
            }

            _context.SaveChanges();
        }

        public List<int> PermissionsRole(int roleId)
        {
            return _context.RolePermission.Where(r => r.RoleId == roleId)
                .Select(r => r.PermissionId).ToList();
        }

        public void UpdatePermissionsRole(int roleId, List<int> permissions)
        {
           _context.RolePermission.Where(p=>p.RoleId==roleId).ToList()
               .ForEach(p=>_context.RolePermission.Remove(p));

           AddPermissionsToRole(roleId,permissions);
        }

        public bool CheckPermission(int permissionId, string userName)
        {
            int userId = _context.Users.Single(u => u.UserName == userName).UserId;

            List<int> userRoles = _context.UserRoles.Where(r => r.UserId == userId)
                .Select(r => r.RoleId).ToList();

            List<int> rolePermissions = _context.RolePermission.Where(p => p.PermissionId == permissionId)
                .Select(p => p.RoleId).ToList();

            return rolePermissions.Any(p => userRoles.Contains(p));
        }
    }
}
