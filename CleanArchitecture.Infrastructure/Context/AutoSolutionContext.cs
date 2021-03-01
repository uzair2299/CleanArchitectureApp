using CleanArchitecture.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Infrastructure.Context
{
    public class AutoSolutionContext:DbContext
    {
        public AutoSolutionContext(DbContextOptions options) : base(options) { }

        
        public DbSet<AutoManufacturer> AutoManufacturers { get; set; }
        public DbSet<Role> Roles { get; set; }
    }
}
