using AutoMapper;
using CleanArchitecture.Core.Interfaces;
using CleanArchitecture.Core.PageSet;
using CleanArchitecture.Core.ViewModels;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Infrastructure.Interfaces;
using CleanArchitecture.Infrastructure.Utility;
using Dapper;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace CleanArchitecture.Infrastructure.Repositories
{
    public class UserRepository :IUserRepository
    {
        private readonly IRepository<User> repository;
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper autoMapper;


        #region store procedure parameters
        private const string UserId = "@UserId";
        private const string UserName = "@UserName";
        private const string UserRoles = "@UserRoles";
        private const string OutPutResult = "@OutPutResult";
        #endregion

        public UserRepository(IRepository<User> repository, IUnitOfWork unitOfWork, IMapper autoMapper)
        {
            this.repository = repository;
            this.unitOfWork = unitOfWork;
            this.autoMapper = autoMapper;
        }

        public bool DeleteUser(int Id)
        {
            var result = repository.Remove(Id);
            if (result)
            {
                unitOfWork.SaveChanges();
                return result;
            }
            return result;

        }

        public AutoSolutionPageSet<UserViewModel> GetUser(UserViewModel UserViewModel)
        {
            List<User> finalResult = new List<User>();
            IQueryable<User> result =  unitOfWork.GetAutoSolutionContext().Users.AsQueryable();
            //if (UserViewModel.SearchTerm != null)
            //{
            //    result = result.Where(x => x.UserName.Contains(UserViewModel.SearchTerm));
            //}
            Pager pager = new Pager(result.Count(), UserViewModel.PageNo,UserViewModel.PageSize);
            finalResult =  result.OrderBy(x => x.UserName).Skip((pager.CurrentPage - 1) * pager.PageSize).Take(pager.PageSize).ToList();
            AutoSolutionPageSet<UserViewModel> autoSolutionPageSet = new AutoSolutionPageSet<UserViewModel>()
            {
                Pager = pager,
                Data = autoMapper.Map<List<UserViewModel>>(finalResult)
            };
            return autoSolutionPageSet;
        }

        public UserViewModel GetUserById(int Id)
        {
            var result = repository.GetById(Id);
            return autoMapper.Map<UserViewModel>(result);
        }


        public UserViewModel SaveUser(UserViewModel userViewModel)
        {

            using (var db = unitOfWork.GetAutoSolutionContext().Database.GetDbConnection())
            {
                db.Open();
                var roles = "";
                if (userViewModel.SelectedItems != null)
                {
                    roles = string.Join(',', userViewModel.SelectedItems);
                }
                else
                {
                    roles = null;
                }

                DynamicParameters parameter = new DynamicParameters();
                parameter.Add(UserName, userViewModel.UserName, DbType.String, ParameterDirection.Input);
                parameter.Add(UserRoles, roles, DbType.String, ParameterDirection.Input);
                var result = db.Query<string>(AutoSolutionStoreProcedureUtility.spInsertUser,
                    parameter, commandType: CommandType.StoredProcedure);
                return null;
            }
        }

        public bool UpdateUser(User User)
        {
            var checkAlreadyExist = repository.GetById(User.Id);
            if (checkAlreadyExist != null)
            {
                unitOfWork.GetAutoSolutionContext().Entry(checkAlreadyExist).State = EntityState.Detached;
                checkAlreadyExist = autoMapper.Map<User>(User);
                repository.Update(checkAlreadyExist);
                autoMapper.Map<UserViewModel>(checkAlreadyExist);
                var resultbool = unitOfWork.SaveChanges();
                return resultbool == true ? true : false;
            }
            else
                return false;
        }


        private bool UserAlreadyExist(User User)
        {

           //var c =  unitOfWork.GetAutoSolutionContext().Database.GetDbConnection();
           //var command =  c.CreateCommand();
           // c.Open();
           // command.CommandText = "[spName] @P3, @P2, @P1";
            //add parameter values
            //execute reader
            

            var result = (from item in unitOfWork.GetAutoSolutionContext().Users
                         //where (item.UserName == User.UserName)
                         select item).FirstOrDefault();
            return result != null ? true : false;
        }
    }
}
