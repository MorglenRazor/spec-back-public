using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Specification.DataAccessAuth.Configurations;
using Specification.DataAccessAuth.Entities;

namespace Specification.DataAccessAuth
{
    public class AuthDataBaseContext(
        DbContextOptions<AuthDataBaseContext> options,
        IOptions<AuthorizationOptions> authOptions
    ) : DbContext(options)
    {
        //public DbSet<PermisionsEntity> DepartmentsTable { get; set; }
        public DbSet<RoleEntity> RolesTable { get; set; }
        public DbSet<DepartmentEntity> Departments { get; set; }
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<UserRoleEntity> UserRoles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserEntityConfiguration());
            modelBuilder.ApplyConfiguration(new DepartmentEntityConfiguration());
            modelBuilder.ApplyConfiguration(new RoleEntityConfiguration());
            modelBuilder.ApplyConfiguration(new UserRoleConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
