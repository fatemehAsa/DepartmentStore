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
    public class ReturnUserModel : PageModel
    {
        private IUserService _userService;

        public ReturnUserModel(IUserService userService)
        {
            _userService = userService;
        }

        public UserInformationViewModel UserInformationViewModel { get; set; }

        public void OnGet(int id)
        {
            UserInformationViewModel = _userService.ReturnDeletedUser(id);
            ViewData["UserId"] = id;
        }

        public IActionResult OnPost(int userId)
        {
            _userService.ReturnUser(userId);
            return RedirectToPage("Index");
        }
    }
}
