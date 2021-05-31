using CleanArchitecture.Core.PageSet;
using CleanArchitecture.Core.ViewModels;
using CleanArchitecture.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Core.Interfaces
{
    public interface IUserRepository
    {
        bool DeleteUser(int Id);
        UserViewModel SaveUser(UserViewModel userViewModel);
        AutoSolutionPageSet<UserViewModel> GetUser(UserViewModel UserViewModel);
        UserViewModel GetUserById(int Id);
        bool UpdateUser(User user);
    }
}
