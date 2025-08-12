using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Specification.DataAccess.Entities;

namespace Specification.DataAccess.Configurations;

public class ConstructionDepConfiguration : IEntityTypeConfiguration<ConstructionDepartmentEntity>
{
    public void Configure(EntityTypeBuilder<ConstructionDepartmentEntity> builder)
    {
        builder.ToTable("construction_dep");

        builder.HasKey(x => x.ConstructionDepId);
        builder.Property(x => x.ConstructionDepId).UseMySqlIdentityColumn();
        builder.Property(x => x.Comment).HasMaxLength(3000);
        builder.Property(x => x.Comment).IsRequired(false);
        //Устанавливаем свзязь 1 к М между таблицами DesignEntity и UnitOfMeasure
        builder.HasOne(x => x.Uom).WithMany(s => s.ConstructionDep).HasForeignKey(x => x.UnitId);

        //Устанавливаем свзяь 1 к М межлу таблицами ConstructionDepartmentEntity и ChapterDesignEntity
        builder
            .HasOne(x => x.DeviceChapter)
            .WithMany(x => x.ConstructionDep)
            .HasForeignKey(x => x.DeviceChapterId);

        builder
            .HasOne(x => x.EmployerData)
            .WithMany(x => x.ConstructionDepResp)
            .HasForeignKey(x => x.EmployerResponsibleId);
    }
}
