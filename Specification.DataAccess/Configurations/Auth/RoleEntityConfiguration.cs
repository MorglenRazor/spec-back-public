using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Specification.Core.Enums;
using Specification.DataAccess.Entities.Auth;

namespace Specification.DataAccess.Configurations.Auth
{
    public class RoleEntityConfiguration : IEntityTypeConfiguration<RoleEntity>
    {
        public void Configure(EntityTypeBuilder<RoleEntity> builder)
        {
            builder.ToTable("roles");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.NameRole).HasMaxLength(1000);

            var roles = Enum.GetValues<Role>()
                .Select(r => new RoleEntity { Id = (int)r, NameRole = r.ToString(), });
            builder.HasData(roles);
        }
    }
}
