using System;
using System.Collections.Generic;
using System.Text;
using DepartmentStore.Core.DTOs;
using DepartmentStore.DataLayer.Entities.User;
using Microsoft.AspNetCore.Http;

namespace DepartmentStore.Core.Services.Interfaces
{
    public interface IUserService
    {
        #region User

        bool IsExistUserName(string userName);
        bool IsExistEmail(string email);
        int AddUser(User user);
        User LoginUser(LoginViewModel login);
        User GetUserByEmail(string email);
        User GetUserById(int userId);
        User GetDeletedUserById(int userId);
        User GetUserByActiveCode(string activeCode);
        User GetUserByName(string userName);
        int GetUserIdByUserName(string userName);
        void UpdateUser(User user);
        bool ActiveAccount(string activeCode);

        #endregion

        #region User Panel

        UserInformationViewModel GetUserInformation(string userName);
        UserInformationViewModel GetUserInformation(int userId);
        UserInformationViewModel ReturnDeletedUser(int userId);
        SideProfileViewModel GetSideProfileData(string userName);
        EditProfileUserPanelViewModel GetUserDataInEditMode(string userName);
        void EditUserPanelData(string userName, EditProfileUserPanelViewModel profile);
        bool CompareOldPassword(string userName, string oldPassword);
        void ChangePassword(string userName, string password);

        #endregion


        #region Admin Panel

        UserForAdminViewModel GetUsers(int pageId = 1, string filterUserName = "", string filterEmail = "");
        UserForAdminViewModel GetDeletedUsers(int pageId = 1, string filterUserName = "", string filterEmail = "");
        int AddUserFromAdmin(CreateUserViewModel user);
        EditUserViewModel GetUserForShowInEditMode(int userId);
        void EditUserFromAdmin(EditUserViewModel editUser);
        void DeleteUser(int userId);
        void ReturnUser(int userId);

        #endregion

    }
}
