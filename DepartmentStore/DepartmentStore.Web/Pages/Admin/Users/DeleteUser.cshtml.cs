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
    [PermissionChecker(5)]
    public class DeleteUserModel : PageModel
    {
        private IUserService _userService;

        public DeleteUserModel(IUserService userService)
        {
            _userService = userService;
        }

        public UserInformationViewModel UserInformationViewModel { get; set; }

        public void OnGet(int id)
        {
            ViewData["UserId"] = id;
            UserInformationViewModel = _userService.GetUserInformation(id);
        }

        public IActionResult OnPost(int userId)
        {
            _userService.DeleteUser(userId);
            return RedirectToPage("Index");
        }
    }
}
