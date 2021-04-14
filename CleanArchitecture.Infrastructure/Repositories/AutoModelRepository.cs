using AutoMapper;
using CleanArchitecture.Core.Interfaces;
using CleanArchitecture.Core.PageSet;
using CleanArchitecture.Core.ViewModels;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Infrastructure.Interfaces;
using CleanArchitecture.Infrastructure.Utility;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace CleanArchitecture.Infrastructure.Repositories
{
    public class AutoModelRepository : IAutoModelRepository
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper autoMapper;
        private readonly IRepository<AutoModel> repository;

        public AutoModelRepository(IUnitOfWork unitOfWork, IMapper autoMapper, IRepository<AutoModel> repository)
        {
            this.unitOfWork = unitOfWork;
            this.autoMapper = autoMapper;
            this.repository = repository;
        }
        public AutoModelViewModel AutoModelSave(AutoModelViewModel autoModelViewModel)
        {
            var c = unitOfWork.GetAutoSolutionContext().Database.GetDbConnection();
            c.Open();
            var command = c.CreateCommand();
            //command.CommandType = System.Data.CommandType.StoredProcedure;
            command.CommandText ="EXEC " + AutoSolutionUtility.InsertAutoModel + " @ModelName,@AutoManufacturerId";
            command.Parameters.Add(new SqlParameter("ModelName", autoModelViewModel.ModelName));
            command.Parameters.Add(new SqlParameter("AutoManufacturerId", autoModelViewModel.SelectedManufacturer));
            int rowAffected =  command.ExecuteNonQuery();
            return rowAffected > 0 ? autoModelViewModel : null;        }

        public AutoSolutionPageSet<AutoModelViewModel> GetAutoModel(AutoModelViewModel autoModelViewModel)
        {
            var c = unitOfWork.GetAutoSolutionContext().Database.GetDbConnection();
            c.Open();
            var command = c.CreateCommand();
            command.CommandText = "EXEC " + AutoSolutionUtility.SelectAutoModel + " @SearchTerm, @PageNo, @PageSize,@TotalCount OUT";
            if (autoModelViewModel.SearchTerm == null)
            {
                command.Parameters.Add(new SqlParameter("SearchTerm",DBNull.Value));
            }
            else
            {
                command.Parameters.Add(new SqlParameter("SearchTerm",autoModelViewModel.SearchTerm));
            }
            
            command.Parameters.Add(new SqlParameter("@PageNo", autoModelViewModel.PageNo));
            command.Parameters.Add(new SqlParameter("@PageSize", autoModelViewModel.PageSize));
            command.Parameters.Add(new SqlParameter("@TotalCount",0));
            command.Parameters["@TotalCount"].Direction = ParameterDirection.Output;
            List<AutoModelViewModel> finalResult = new List<AutoModelViewModel>();
            int TotalCount = 0;
            using (var reader = command.ExecuteReader())
            {
                if (reader.HasRows){

                    while (reader.Read())
                    {
                        finalResult.Add(new AutoModelViewModel
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            ModelName = reader["ModelName"].ToString(),
                            AutoManufacturerName = reader["AutoManufacturerName"].ToString()
                        });
                    }

                }
            }

            TotalCount = Convert.ToInt32(command.Parameters["@TotalCount"].Value);
            AutoSolutionPageSet<AutoModelViewModel> autoSolutionPageSet = new AutoSolutionPageSet<AutoModelViewModel>()
            {
                Pager = new Pager(TotalCount, autoModelViewModel.PageNo,autoModelViewModel.PageSize),
                Data = finalResult
            };
            return autoSolutionPageSet;
        }

        public AutoModelViewModel GetAutoModelById(int Id)
        {
            AutoModel auto = repository.GetById(Id);
           return  autoMapper.Map<AutoModelViewModel>(auto);

            //string ne = auto.AutoManufacturer.AutoManufacturerName;
            //return null;
        }
    }
}
