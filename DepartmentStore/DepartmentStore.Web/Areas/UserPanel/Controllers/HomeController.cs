using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DepartmentStore.Core.DTOs;
using DepartmentStore.Core.Services.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;

namespace DepartmentStore.Web.Areas.UserPanel.Controllers
{

    [Authorize]
    [Area("UserPanel")]
    public class HomeController : Controller
    {
        private IUserService _userService;

        public HomeController(IUserService userService)
        {
            _userService = userService;
        }

        public IActionResult Index()
        {
            return View(_userService.GetUserInformation(User.Identity.Name));
        }

        [Route("UserPanel/EditProfile")]
        public IActionResult EditProfile()
        {
            return View(_userService.GetUserDataInEditMode(User.Identity.Name));
        }

        [HttpPost]
        [Route("UserPanel/EditProfile")]
        public IActionResult EditProfile(EditProfileUserPanelViewModel profile)
        {
            if (!ModelState.IsValid)
            {
                return View(profile);
            }
            _userService.EditUserPanelData(User.Identity.Name, profile);

            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return Redirect("/Login?EditProfile=true");
        }

        [Route("UserPanel/ChangePassword")]
        public IActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost]
        [Route("UserPanel/ChangePassword")]
        public IActionResult ChangePassword(ChangePasswordViewModel change)
        {
            if (!ModelState.IsValid)
            {
                return View(change);
            }

            if (!_userService.CompareOldPassword(User.Identity.Name, change.OldPassword))
            {
                ModelState.AddModelError("OldPassword", "کلمه عبور فعلی صحیح نمی یاشد");
                return View(change);
            }

            _userService.ChangePassword(User.Identity.Name,change.Password);
            ViewBag.IsSuccess = true;
            return View();
        }

    }
}
