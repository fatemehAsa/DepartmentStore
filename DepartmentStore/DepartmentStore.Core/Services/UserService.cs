using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using DepartmentStore.Core.Convertors;
using DepartmentStore.Core.DTOs;
using DepartmentStore.Core.Generator;
using DepartmentStore.Core.Security;
using DepartmentStore.Core.Services.Interfaces;
using DepartmentStore.DataLayer.Context;
using DepartmentStore.DataLayer.Entities.User;
using Microsoft.EntityFrameworkCore;

namespace DepartmentStore.Core.Services
{
    public class UserService : IUserService
    {
        private DepartmentStoreContext _context;

        public UserService(DepartmentStoreContext context)
        {
            _context = context;
        }

        public bool IsExistUserName(string userName)
        {
            return _context.Users.Any(u => u.UserName == userName);
        }

        public bool IsExistEmail(string email)
        {
            return _context.Users.Any(u => u.Email == email);
        }

        public int AddUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
            return user.UserId;
        }

        public User LoginUser(LoginViewModel login)
        {
            string hashPassword = PasswordHelper.EncodePasswordMd5(login.Password);
            string email = FixedText.FixedEmail(login.Email);

            return _context.Users.SingleOrDefault(u => u.Password == hashPassword && u.Email == email);

        }

        public User GetUserByEmail(string email)
        {
            return _context.Users.SingleOrDefault(u => u.Email == email);
        }

        public User GetUserById(int userId)
        {
            return _context.Users.Find(userId);
        }

        public User GetDeletedUserById(int userId)
        {
            return _context.Users.IgnoreQueryFilters().Where(u => u.IsDelete)
                .Single(u => u.UserId == userId);
                    ;
        }

        public User GetUserByActiveCode(string activeCode)
        {
            return _context.Users.SingleOrDefault(u => u.ActiveCode == activeCode);
        }

        public User GetUserByName(string userName)
        {
            return _context.Users.SingleOrDefault(u => u.UserName == userName);
        }

        public int GetUserIdByUserName(string userName)
        {
            return _context.Users.Single(u => u.UserName == userName).UserId;
        }

        public void UpdateUser(User user)
        {
            _context.Update(user);
            _context.SaveChanges();
        }

        public bool ActiveAccount(string activeCode)
        {
            var user = _context.Users.SingleOrDefault(u => u.ActiveCode == activeCode);
            if (user == null || user.IsActive)
            {
                return false;
            }

            user.IsActive = true;
            user.ActiveCode = NameGenerator.GenerateUniqCode();
            _context.SaveChanges();
            return true;

        }

        public UserInformationViewModel GetUserInformation(string userName)
        {
            User user = GetUserByName(userName);
            UserInformationViewModel information = new UserInformationViewModel()
            {
                Email = user.Email,
                Address = user.Address,
                RegisterDate = user.RegisterDate,
                UserName = user.UserName
            };

            return information;
        }

        public UserInformationViewModel GetUserInformation(int userId)
        {
            User user = GetUserById(userId);
            UserInformationViewModel information = new UserInformationViewModel()
            {
                Email = user.Email,
                Address = user.Address,
                RegisterDate = user.RegisterDate,
                UserName = user.UserName
            };

            return information;
        }

        public UserInformationViewModel ReturnDeletedUser(int userId)
        {
            User user = GetDeletedUserById(userId);
            UserInformationViewModel information = new UserInformationViewModel()
            {
                Email = user.Email,
                Address = user.Address,
                RegisterDate = user.RegisterDate,
                UserName = user.UserName
            };

            return information;
        }

        public SideProfileViewModel GetSideProfileData(string userName)
        {
            return _context.Users.Where(u => u.UserName == userName)
                .Select(u => new SideProfileViewModel()
                {
                    ImageName = u.AvatarName,
                    UserName = u.UserName

                }).Single();
        }

        public EditProfileUserPanelViewModel GetUserDataInEditMode(string userName)
        {
            return _context.Users.Where(u => u.UserName == userName)
                .Select(u => new EditProfileUserPanelViewModel()
                {
                    AvatarName = u.AvatarName,
                    Email = u.Email,
                    UserName = u.UserName,
                    Address = u.Address
                }).Single();
        }

        public void EditUserPanelData(string userName, EditProfileUserPanelViewModel profile)
        {
            if (profile.UserAvatar != null)
            {
                string imagePath = "";

                if (profile.AvatarName != "Defult.jpg")
                {
                    imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/UserAvatar", profile.AvatarName);
                    if (File.Exists(imagePath))
                    {
                        File.Delete(imagePath);
                    }
                }

                profile.AvatarName = NameGenerator.GenerateUniqCode() + Path.GetExtension(profile.UserAvatar.FileName);
                imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/UserAvatar", profile.AvatarName);

                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    profile.UserAvatar.CopyTo(stream);
                }
            }

            var user = GetUserByName(userName);
            user.Address = profile.Address;
            user.AvatarName = profile.AvatarName;
            user.Email = profile.Email;
            user.UserName = profile.UserName;

            UpdateUser(user);
        }

        public bool CompareOldPassword(string userName, string oldPassword)
        {
            string hashOldPassword = PasswordHelper.EncodePasswordMd5(oldPassword);
            return _context.Users.Any(u => u.UserName == userName && u.Password == hashOldPassword);
        }

        public void ChangePassword(string userName, string password)
        {
            var user = GetUserByName(userName);
            user.Password = PasswordHelper.EncodePasswordMd5(password);
            UpdateUser(user);
        }

        public UserForAdminViewModel GetUsers(int pageId = 1, string filterUserName = "", string filterEmail = "")
        {
            IQueryable<User> result = _context.Users;
            if (!string.IsNullOrEmpty(filterEmail))
            {
                result = result.Where(u => u.Email.Contains(filterEmail));
            }

            if (!string.IsNullOrEmpty(filterUserName))
            {
                result = result.Where(u => u.UserName.Contains(filterUserName));
            }

            int take = 20;
            int skip = (pageId - 1) * take;

            UserForAdminViewModel list = new UserForAdminViewModel();
            list.Users = result.OrderBy(u => u.RegisterDate).Skip(skip).Take(take).ToList();
            list.CurrentPage = pageId;
            list.PageCount = result.Count() / take;

            return list;
        }

        public UserForAdminViewModel GetDeletedUsers(int pageId = 1, string filterUserName = "", string filterEmail = "")
        {
            IQueryable<User> result = _context.Users.IgnoreQueryFilters().Where(u=>u.IsDelete);
            if (!string.IsNullOrEmpty(filterEmail))
            {
                result = result.Where(u => u.Email.Contains(filterEmail));
            }

            if (!string.IsNullOrEmpty(filterUserName))
            {
                result = result.Where(u => u.UserName.Contains(filterUserName));
            }

            int take = 20;
            int skip = (pageId - 1) * take;

            UserForAdminViewModel list = new UserForAdminViewModel();
            list.Users = result.OrderBy(u => u.RegisterDate).Skip(skip).Take(take).ToList();
            list.CurrentPage = pageId;
            list.PageCount = result.Count() / take;

            return list;
        }

        public int AddUserFromAdmin(CreateUserViewModel user)
        {
            User addUser = new User();
            addUser.Address = user.Address;
            addUser.ActiveCode = NameGenerator.GenerateUniqCode();
            addUser.Email = FixedText.FixedEmail(user.Email);
            addUser.IsActive = true;
            addUser.Password = PasswordHelper.EncodePasswordMd5(user.Password);
            addUser.RegisterDate = DateTime.Now;
            addUser.UserName = user.UserName;
            addUser.AvatarName = "Defult.jpg";

            #region Save Avatar

            if (user.UserAvatar != null)
            {
                string imagePath = "";

                addUser.AvatarName = NameGenerator.GenerateUniqCode() + Path.GetExtension(user.UserAvatar.FileName);
                imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/UserAvatar", addUser.AvatarName);

                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    user.UserAvatar.CopyTo(stream);
                }
            }

            #endregion

            return AddUser(addUser);
        }

        public EditUserViewModel GetUserForShowInEditMode(int userId)
        {
            return _context.Users.Where(u => u.UserId == userId)
                .Select(u => new EditUserViewModel()
                {
                    UserId = u.UserId,
                    Address = u.Address,
                    AvatarName = u.AvatarName,
                    Email = u.Email,
                    UserName = u.UserName,
                    UserRoles = u.UserRoles.Select(r => r.RoleId).ToList()

                }).Single();
        }

        public void EditUserFromAdmin(EditUserViewModel editUser)
        {
            User user = GetUserById(editUser.UserId);
            user.Address = editUser.Address;
            user.Email = FixedText.FixedEmail(editUser.Email);
            if (!string.IsNullOrEmpty(editUser.Password))
            {
                user.Password = PasswordHelper.EncodePasswordMd5(editUser.Password);
            }

            if (editUser.UserAvatar != null)
            {

                if (editUser.AvatarName != "Defult.jpg")
                {
                    string deletePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/UserAvatar", editUser.AvatarName);
                    if (File.Exists(deletePath))
                    {
                        File.Delete(deletePath);
                    }
                }

                user.AvatarName = NameGenerator.GenerateUniqCode() + Path.GetExtension(editUser.UserAvatar.FileName);
                string imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/UserAvatar", user.AvatarName);

                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    editUser.UserAvatar.CopyTo(stream);
                }
            }

            _context.Users.Update(user);
            _context.SaveChanges();
        }

        public void DeleteUser(int userId)
        {
            User user = GetUserById(userId);
            user.IsDelete = true;
            UpdateUser(user);
        }

        public void ReturnUser(int userId)
        {
            User user = GetDeletedUserById(userId);
            user.IsDelete = false;
            UpdateUser(user);
        }
    }
}
