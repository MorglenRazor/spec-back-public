using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Specification.DataAccessAuth.Entities;

namespace Specification.DataAccessAuth.Configurations
{
    public class DepartmentEntityConfiguration : IEntityTypeConfiguration<DepartmentEntity>
    {
        public void Configure(EntityTypeBuilder<DepartmentEntity> builder)
        {
            builder.ToTable("departments");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.DepartmentName).HasMaxLength(1000);
            builder.Property(x => x.DepShortName).HasMaxLength(1000);

            builder
                .HasMany(x => x.Employers)
                .WithOne(x => x.Department)
                .HasForeignKey(x => x.DepartmentId);
        }
    }
}
