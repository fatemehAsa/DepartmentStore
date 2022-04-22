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
    [PermissionChecker(9)]
    public class DeleteRoleModel : PageModel
    {
        private IPermissionService _permissionService;

        public DeleteRoleModel(IPermissionService permissionService)
        {
            _permissionService = permissionService;
        }


        [BindProperty]
        public Role Role { get; set; }
        public void OnGet(int id)
        {
            Role = _permissionService.GetRoleById(id);
        }

        public IActionResult OnPost()
        {
            _permissionService.DeleteRole(Role);
            return RedirectToPage("Index");
        }
    }
}
