using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Specification.DataAccess.Entities.Auth;

namespace Specification.DataAccess.Configurations.Auth
{
    public class EmployerRoleEntityConfiguration : IEntityTypeConfiguration<EmployerRoleEntity>
    {
        public void Configure(EntityTypeBuilder<EmployerRoleEntity> builder)
        {
            builder.HasKey(r => new { r.RoleId, r.EmployerId });
        }
    }
}
