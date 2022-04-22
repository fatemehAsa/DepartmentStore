using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DepartmentStore.Core.Security;
using DepartmentStore.Core.Services.Interfaces;
using DepartmentStore.DataLayer.Entities.User;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DepartmentStore.Web.Pages.Admin.Roles
{
    [PermissionChecker(7)]
    public class CreateRoleModel : PageModel
    {
        private IPermissionService _permissionService;

        public CreateRoleModel(IPermissionService permissionService)
        {
            _permissionService = permissionService;
        }

        [BindProperty]
        public Role Role { get; set; }

        public void OnGet()
        {
            ViewData["Permissions"] = _permissionService.GteAllPermissions();
        }

        public IActionResult OnPost(List<int> SelectedPermission)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Role.IsDelete = false;
            int roleId = _permissionService.AddRole(Role);
           
            _permissionService.AddPermissionsToRole(roleId,SelectedPermission);

            return RedirectToPage("Index");
        }
    }
}
