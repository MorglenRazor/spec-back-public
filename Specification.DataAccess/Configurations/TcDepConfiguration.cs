using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Specification.DataAccess.Entities;

namespace Specification.DataAccess.Configurations;

public class TcDepConfiguration : IEntityTypeConfiguration<TcDepartmentEntity>
{
    public void Configure(EntityTypeBuilder<TcDepartmentEntity> builder)
    {
        builder.ToTable("tc_dep");

        builder.HasKey(x => x.TcDepId);
        builder.Property(x => x.TcDepId).UseMySqlIdentityColumn();

        builder.Property(x => x.Comment).HasMaxLength(1000);
        builder.Property(x => x.NameBrandInDoc).HasMaxLength(3000);
        //builder.Property(x => x.SerialNum).HasMaxLength(1000);
        builder.Property(x => x.CompKit).HasMaxLength(1000);
        builder.Property(x => x.CompTechDocAvailable).HasMaxLength(1000);
        builder.Property(x => x.CompTechDocMissing).HasMaxLength(1000);
        builder.Property(x => x.Defects).HasMaxLength(1000);
        builder.Property(x => x.Conclusion);
        builder.Property(x => x.Comment).IsRequired(false);
        //Устанавливаем свзязь 1 к М между таблицами TcDepartmentEntity и ChapterDeviceEntity
        builder
            .HasOne(x => x.DeviceChapter)
            .WithMany(x => x.TechControlDep)
            .HasForeignKey(x => x.DeviceChapterId);

        builder
            .HasOne(x => x.EmployerData)
            .WithMany(x => x.TcDepResp)
            .HasForeignKey(x => x.EmployerResponsibleId);

        builder.HasOne(x => x.Uom).WithMany(s => s.TechControlDep).HasForeignKey(x => x.UnitId);
    }
}
