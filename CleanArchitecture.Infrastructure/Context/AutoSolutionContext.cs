using CleanArchitecture.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Infrastructure.Context
{
    public class AutoSolutionContext:DbContext
    {
        public AutoSolutionContext(DbContextOptions options) : base(options) { }

        /// <summary>
        /// 
        /// </summary>
        #region Auto
        public DbSet<AutoManufacturer> AutoManufacturers { get; set; }
        public DbSet<AutoModel> AutoModels { get; set; }
        public DbSet<AutoBodyType> AutoBodyType { get; set; }

        #endregion

        #region Management
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        #endregion



    }
}
