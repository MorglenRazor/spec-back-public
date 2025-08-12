using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Specification.DataAccessAuth.Entities;

namespace Specification.DataAccessAuth.Configurations
{
    public class UserEntityConfiguration : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder.ToTable("employers");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.UserName).HasMaxLength(50);
            builder.Property(x => x.Password).HasMaxLength(250);
            builder.Property(x => x.FullName).HasMaxLength(255);
            builder.Property(x => x.ShortName).HasMaxLength(155);
            builder.Property(x => x.PhoneNumber).HasMaxLength(20);
            builder
                .HasOne(x => x.Department)
                .WithMany(x => x.Employers)
                .HasForeignKey(x => x.DepartmentId);
            builder
                .HasMany(u => u.Roles)
                .WithMany(r => r.Users)
                .UsingEntity<UserRoleEntity>(
                    l => l.HasOne<RoleEntity>().WithMany().HasForeignKey(x => x.RoleId),
                    r => r.HasOne<UserEntity>().WithMany().HasForeignKey(x => x.UserId)
                );
        }
    }
}
