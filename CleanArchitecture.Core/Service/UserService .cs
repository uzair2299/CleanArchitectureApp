using AutoMapper;
using CleanArchitecture.Core.Interfaces;
using CleanArchitecture.Core.PageSet;
using CleanArchitecture.Core.ViewModels;
using CleanArchitecture.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace CleanArchitecture.Core.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository UserRepository;
        private readonly IMapper autoMapper;
        private User User;

        public UserService(IUserRepository UserRepository, IMapper autoMapper, User User)
        {
            this.UserRepository = UserRepository;
            this.autoMapper = autoMapper;
            this.User = User;
        }

        public UserViewModel UserSave(UserViewModel UserViewModel)
        {
            //User = autoMapper.Map<User>(UserViewModel);
            return UserRepository.SaveUser(UserViewModel);
        }

        public bool DeleteUser(int Id)
        {
            return UserRepository.DeleteUser(Id);
        }

        public AutoSolutionPageSet<UserViewModel> GetUser(UserViewModel UserViewModel)
        {
             return  UserRepository.GetUser(UserViewModel);
        }

        public UserViewModel GetUserById(int Id)
        {
            return UserRepository.GetUserById(Id);
        }

        public bool UpdateUser(UserViewModel UserViewModel)
        {
            User = autoMapper.Map<User>(UserViewModel);
            return UserRepository.UpdateUser(User);
        }
    }
}
