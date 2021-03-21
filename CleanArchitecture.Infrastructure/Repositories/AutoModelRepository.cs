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
using System.Text;

namespace CleanArchitecture.Infrastructure.Repositories
{
    public class AutoModelRepository : IAutoModelRepository
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper autoMapper;

        public AutoModelRepository(IUnitOfWork unitOfWork, IMapper autoMapper)
        {
            this.unitOfWork = unitOfWork;
            this.autoMapper = autoMapper;
        }
        public AutoModelViewModel AutoModelSave(AutoModel autoModel)
        {
            var c = unitOfWork.GetAutoSolutionContext().Database.GetDbConnection();
            c.Open();
            var command = c.CreateCommand();
            //command.CommandType = System.Data.CommandType.StoredProcedure;
            command.CommandText ="EXEC " + AutoSolutionUtility.InsertAutoModel + " @ModelName,@AutoManufacturerId";
            command.Parameters.Add(new SqlParameter("ModelName", "XYZ"));
            command.Parameters.Add(new SqlParameter("AutoManufacturerId", "1"));
            command.ExecuteNonQuery();
            return null;
        }

        public AutoSolutionPageSet<AutoModelViewModel> GetAutoModel(AutoModelViewModel autoModelViewModel)
        {
            var c = unitOfWork.GetAutoSolutionContext().Database.GetDbConnection();
            c.Open();
            var command = c.CreateCommand();
            command.CommandText = "EXEC " + AutoSolutionUtility.SelectAutoModel + " @SearchTerm, @PageNo, @PageSize";
            if (autoModelViewModel.SearchTerm == null)
            {
                command.Parameters.Add(new SqlParameter("SearchTerm",DBNull.Value));
            }
            else
            {
                command.Parameters.Add(new SqlParameter("SearchTerm",autoModelViewModel.SearchTerm));
            }
            
            command.Parameters.Add(new SqlParameter("PageNo", autoModelViewModel.PageNo));
            command.Parameters.Add(new SqlParameter("PageSize", autoModelViewModel.PageSize));
            List<AutoModelViewModel> finalResult = new List<AutoModelViewModel>();
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
            AutoSolutionPageSet<AutoModelViewModel> autoSolutionPageSet = new AutoSolutionPageSet<AutoModelViewModel>()
            {
                Pager = new Pager(100,10),
                Data = finalResult
            };
            return autoSolutionPageSet;
        }
    }
}
