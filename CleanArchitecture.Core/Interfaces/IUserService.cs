using CleanArchitecture.Core.PageSet;
using CleanArchitecture.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Core.Interfaces
{
    public interface IUserService
    {
        bool DeleteUser(int Id);
        UserViewModel UserSave(UserViewModel UserViewModel);
        AutoSolutionPageSet<UserViewModel> GetUser(UserViewModel UserViewModel);
        UserViewModel GetUserById(int Id);
        bool UpdateUser(UserViewModel UserViewModel);
    }
}
