using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Specification.DataAccess.Entities.Auth;
using Specification.Infrastructure;

namespace Specification.DataAccess.Configurations.Auth
{
    public class EmployerEntityConfiguration : IEntityTypeConfiguration<EmployerEntity>
    {
        public void Configure(EntityTypeBuilder<EmployerEntity> builder)
        {
            builder.ToTable("employers");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.UserName).HasMaxLength(50);
            builder.Property(x => x.Password).HasMaxLength(3000);
            builder.Property(x => x.FullName).HasMaxLength(255);
            builder.Property(x => x.ShortName).HasMaxLength(155);
            builder.Property(x => x.PhoneNumber).HasMaxLength(20);
           
            builder.HasMany(x => x.ConstructionDepResp).WithOne(x => x.EmployerData);
            builder.HasMany(x => x.AccountingDepResp).WithOne(x => x.EmployerData);
            builder.HasMany(x => x.TmsDepResp).WithOne(x => x.EmployerData);
            builder.HasMany(x => x.TcDepResp).WithOne(x => x.EmployerData);
            builder.HasMany(x => x.WarehouseDepResp).WithOne(x => x.EmployerData);

            builder
                .HasMany(x => x.ResponsibleChapter)
                .WithOne(s => s.Responsible)
                .HasForeignKey(f => f.EmpId);

            builder
               .HasOne(x => x.Department)
               .WithMany(x => x.Employers)
               .HasForeignKey(x => x.DepartmentId);
            builder
                .HasMany(u => u.Roles)
                .WithMany(r => r.Employers)
                .UsingEntity<EmployerRoleEntity>(
                    l => l.HasOne<RoleEntity>().WithMany().HasForeignKey(x => x.RoleId),
                    r => r.HasOne<EmployerEntity>().WithMany().HasForeignKey(x => x.EmployerId)
                );
           
        }
    }
}
