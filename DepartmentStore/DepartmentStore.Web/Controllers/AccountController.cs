using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using DepartmentStore.Core.Convertors;
using DepartmentStore.Core.DTOs;
using DepartmentStore.Core.Generator;
using DepartmentStore.Core.Security;
using DepartmentStore.Core.Senders;
using DepartmentStore.Core.Services.Interfaces;
using DepartmentStore.DataLayer.Entities.User;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace DepartmentStore.Web.Controllers
{
    public class AccountController : Controller
    {
        private IUserService _userService;
        private IViewRenderService _viewRender;

        public AccountController(IUserService userService, IViewRenderService viewRender)
        {
            _userService = userService;
            _viewRender = viewRender;
        }


        #region Register

        [Route("Register")]
        public IActionResult Register()
        {
            return View();
        }

        [Route("Register")]
        [HttpPost]
        public IActionResult Register(RegisterViewModel register)
        {
            if (!ModelState.IsValid)
            {
                return View(register);
            }

            if (_userService.IsExistUserName(register.UserName))
            {
                ModelState.AddModelError("UserName", "نام کاربری معتبر نمی باشد");
                return View(register);
            }

            if (_userService.IsExistEmail(FixedText.FixedEmail(register.Email)))
            {
                ModelState.AddModelError("Email", "ایمیل معتبر نمی باشد");
                return View(register);
            }

            User user = new User();

            user.Email = FixedText.FixedEmail(register.Email);
            user.ActiveCode = NameGenerator.GenerateUniqCode();
            user.Address = register.Address;
            user.AvatarName = "Defult.jpg";
            user.IsActive = false;
            user.Password = PasswordHelper.EncodePasswordMd5(register.Password);
            user.RegisterDate = DateTime.Now;
            user.UserName = register.UserName;

            _userService.AddUser(user);

            string body = _viewRender.RenderToStringAsync("_ActiveEmail", user);
            SendEmail.Send(user.Email, "فعالسازی", body);

            return View("SuccessRegister", user);
        }

        #endregion

        #region Login

        [Route("Login")]
        public IActionResult Login(bool EditProfile = false)
        {
            ViewBag.EditProfile = EditProfile;
            return View();
        }


        [HttpPost]
        [Route("Login")]
        public IActionResult Login(LoginViewModel login, string ReturnUrl = "/")
        {
            if (!ModelState.IsValid)
            {
                return View(login);
            }

            var user = _userService.LoginUser(login);
            if (user != null)
            {
                if (user.IsActive)
                {
                    var claims = new List<Claim>()
                    {
                        new Claim(ClaimTypes.NameIdentifier,user.UserId.ToString()),
                        new Claim(ClaimTypes.Name,user.UserName)
                    };
                    var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var principal = new ClaimsPrincipal(identity);

                    var properties = new AuthenticationProperties
                    {
                        IsPersistent = login.RememberMe
                    };
                    HttpContext.SignInAsync(principal, properties);
                    if (ReturnUrl != "/")
                    {
                        return Redirect(ReturnUrl);
                    }
                    ViewBag.IsSuccess = true;
                    return View();

                }
                else
                {
                    ModelState.AddModelError("Email", "حساب کاربری شما فعال نمی باشد");
                }

            }

            ModelState.AddModelError("Email", "کاربری با مشخصات وارد شده یافت نشد");
            return View(login);
        }
        #endregion

        #region Active Account

        public IActionResult ActiveAccount(string id)
        {
            ViewBag.IsActive = _userService.ActiveAccount(id);
            return View();
        }

        #endregion

        #region Logout

        [Route("Logout")]
        public IActionResult Logout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Redirect("/Login");
        }

        #endregion

        #region Forgot Password

        [Route("ForgotPassword")]
        public IActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        [Route("ForgotPassword")]
        public IActionResult ForgotPassword(ForgotPasswordViewModel forgot)
        {
            if (!ModelState.IsValid)
            {
                return View(forgot);
            }

            string fixedEmail = FixedText.FixedEmail(forgot.Email);
            DataLayer.Entities.User.User user = _userService.GetUserByEmail(fixedEmail);

            if (user == null)
            {
                ModelState.AddModelError("Email", "کاربری یافت نشد");
                return View(forgot);
            }

            string body = _viewRender.RenderToStringAsync("_ForgotPassword", user);
            SendEmail.Send(user.Email, "بازیابی حساب کاربری", body);
            ViewBag.IsSuccess = true;

            return View();
        }


        #endregion

        #region Reset Password


        public IActionResult ResetPassword(string id)
        {
            return View(new ResetPasswordViewModel()
            {
                ActiveCode = id
            });
        }

        [HttpPost]
        public IActionResult ResetPassword(ResetPasswordViewModel reset)
        {
            if (!ModelState.IsValid)
            {
                return View(reset);
            }

            DataLayer.Entities.User.User user = _userService.GetUserByActiveCode(reset.ActiveCode);

            if (user == null)
            {
                return NotFound();
            }

            string hashNewPassword = PasswordHelper.EncodePasswordMd5(reset.Password);
            user.Password = hashNewPassword;
            _userService.UpdateUser(user);

            return Redirect("/Login");
        }

        #endregion

    }
}
