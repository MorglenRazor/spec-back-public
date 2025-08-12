using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Specification.DataAccess.Entities.Handbooks;

namespace Specification.DataAccess.Configurations;

public class DepartmentConfiguration : IEntityTypeConfiguration<DepartmentEntity>
{
    public void Configure(EntityTypeBuilder<DepartmentEntity> builder)
    {
        builder.ToTable("departments");

        builder.HasKey(x => x.Id);
        // builder.Property(x => x.Id).UseMySqlIdentityColumn();
        builder.Property(x => x.Name).HasMaxLength(1000);
        builder.Property(x => x.ShortName).HasMaxLength(1000);

        //builder
        //    .HasMany(x => x.ResponsiblePersons)
        //    .WithOne(s => s.Department)
        //    .HasForeignKey(f => f.DepId);

        builder
              .HasMany(x => x.StatusWork)
              .WithOne(x => x.DepartmentCurrWork)
              .HasForeignKey(x => x.DepId);

     
    }
}
