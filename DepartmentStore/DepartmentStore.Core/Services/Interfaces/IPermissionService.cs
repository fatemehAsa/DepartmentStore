using System;
using System.Collections.Generic;
using System.Text;
using DepartmentStore.DataLayer.Entities.Permissions;
using DepartmentStore.DataLayer.Entities.User;

namespace DepartmentStore.Core.Services.Interfaces
{
    public interface IPermissionService
    {
        #region Role

        List<Role> GetRoles();
        void AddRolesToUser(List<int> roleIds, int userId);
        void EditUserRoles(int userId, List<int> roleIds);
        int AddRole(Role role);
        Role GetRoleById(int roleId);
        void UpdateRole(Role role);
        void DeleteRole(Role role);

        #endregion

        #region Permission

        List<Permission> GteAllPermissions();
        void AddPermissionsToRole(int roleId, List<int> permission);
        List<int> PermissionsRole(int roleId);
        void UpdatePermissionsRole(int roleId, List<int> permissions);
        bool CheckPermission(int permissionId, string userName);

        #endregion
    }
}
