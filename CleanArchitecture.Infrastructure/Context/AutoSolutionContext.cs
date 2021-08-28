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
        public DbSet<AutoVersion> AutoVersion { get; set; }
        public DbSet<AutoEngineType> AutoEngineType { get; set; }
        public DbSet<AutoVersionPrice> AutoVersionPrice { get; set; }
        public DbSet<AutoLookUpType> AutoLookUpType { get; set; }
        public DbSet<AutoSpecification> AutoSpecifications { get; set; }
        public DbSet<AutoSpecificationSub> AutoSpecificationSubs { get; set; }
        public DbSet<AutoVersionWeightCapacity> AutoVersionWeightCapacities { get; set; }
        public DbSet<AutoVersionDimension> AutoVersionDimensions { get; set; }
        public DbSet<AutoVersionSpecification> AutoVersionSpecifications { get; set; }

        #endregion

        #region Management
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<AppControllers> AppControllers { get; set; }

        public DbSet<AppControllerActions> AppControllerActions { get; set; }
        public DbSet<UserRoles> UserRoles { get; set; }
        public DbSet<RolePermissions> RolePermissions { get; set; }

        #endregion

        public DbSet<Province> Provinces { get; set; }

        protected override void  OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AutoSpecification>()
                .HasMany(x => x.SpecificationSubParameter)
                .WithOne(x => x.ParentNode)
                .HasForeignKey(x => x.ParentId);

            modelBuilder.Entity<AutoVersionSpecification>().HasKey(avs => new { avs.AutoVersionId, avs.AutoSpecificationId });
            modelBuilder.Entity<AutoVersionSpecification>().HasOne(avs => avs.AutoVersion).WithMany(avs => avs.AutoVersionSpecifications).HasForeignKey(avs => avs.AutoVersionId);
            modelBuilder.Entity<AutoVersionSpecification>().HasOne(avs => avs.AutoSpecification).WithMany(avs => avs.AutoVersionSpecifications).HasForeignKey(avs => avs.AutoSpecificationId);
        }   

    }
}
