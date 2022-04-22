using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DepartmentStore.Core.DTOs;
using DepartmentStore.Core.Security;
using DepartmentStore.Core.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DepartmentStore.Web.Pages.Admin.Users
{
    [PermissionChecker(2)]
    public class IndexModel : PageModel
    {
        private IUserService _userService;

        public IndexModel(IUserService userService)
        {
            _userService = userService;
        }

        public UserForAdminViewModel UserForAdminViewModel { get; set; }

        public void OnGet(int pageId=1,string filterUserName = "",string filterEmail = "")
        {
            UserForAdminViewModel = _userService.GetUsers(pageId,filterUserName,filterEmail);
        }
    }
}
