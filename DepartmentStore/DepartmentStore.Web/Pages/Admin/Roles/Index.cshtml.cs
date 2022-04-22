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
    [PermissionChecker(6)]
    public class IndexModel : PageModel
    {
        private IPermissionService _permissionService;

        public IndexModel(IPermissionService permissionService)
        {
            _permissionService = permissionService;
        }

        public List<Role> ListRoles { get; set; }
        public void OnGet()
        {
            ListRoles = _permissionService.GetRoles();
        }
    }
}
