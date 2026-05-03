using Mayordomo.Infrastructure.Data.Tables;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Mayordomo.Transversal.Common.Enums;

namespace Mayordomo.Infrastructure.Persistence.Context
{
    public class ApplicationDbContext : DbContext
    {
        #region Constructor
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        #endregion

        #region Creating
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Guid Admin = Guid.Parse("a3f8e2c9-7c1e-4c32-b8c3-9f6b8c1f1a22");
            Guid user = Guid.Parse("c7e9a0b5-5b4d-4a6e-93d8-13a9f2477e66");
            Guid superAdmin = Guid.Parse("f4a2d8e3-9b11-42a4-b2e7-8e19d8f6c3b9");


            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Data.Tables.Roles>().HasData(
            new Roles
            {
                Id = Admin,
                Name = RoleName.Administrator,
                Created = new DateTime(2025, 01, 01, 00, 00, 00),
                Updated = null,
                Deleted = null,
                IsActive = true
            },
            new Roles
            {
                Id = user,
                Name = RoleName.User,
                Created = new DateTime(2025, 01, 01, 00, 00, 00),
                Updated = null,
                Deleted = null,
                IsActive = true
            },
            new Roles
            {
                Id = superAdmin,
                Name = RoleName.SuperAdministrator,
                Created = new DateTime(2025, 01, 01, 00, 00, 00),
                Updated = null,
                Deleted = null,
                IsActive = true
            });
        }
        #endregion

        #region Tables
        public DbSet<User> User { get; set; }
        public DbSet<Code> Code { get; set; }
        public DbSet<Music> Music { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<UserMusic> UserMusic { get; set; }
        #endregion
    }
}
