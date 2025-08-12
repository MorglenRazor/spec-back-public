using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Specification.DataAccessAuth.Entities;

namespace Specification.DataAccessAuth.Configurations
{
    internal class UserRoleConfiguration : IEntityTypeConfiguration<UserRoleEntity>
    {
        public void Configure(EntityTypeBuilder<UserRoleEntity> builder)
        {
            builder.HasKey(r => new { r.RoleId, r.UserId });
        }
    }
}
