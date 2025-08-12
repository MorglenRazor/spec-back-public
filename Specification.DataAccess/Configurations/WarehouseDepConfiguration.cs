using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Specification.DataAccess.Entities;

namespace Specification.DataAccess.Configurations;

public class WarehouseDepConfiguration : IEntityTypeConfiguration<WarehouseDepartmentEntity>
{
    public void Configure(EntityTypeBuilder<WarehouseDepartmentEntity> builder)
    {
        builder.ToTable("warehouse_dep");

        builder.HasKey(x => x.WarehouseDepId);
        builder.Property(x => x.WarehouseDepId).UseMySqlIdentityColumn();

        builder.Property(x => x.Comment).HasMaxLength(3000);
        builder.Property(x => x.CountOnStorage).HasMaxLength(1000);
        builder.Property(x => x.CountAfterPurchase).HasMaxLength(1000);
        builder.Property(x => x.RemainsCountAfterPurchase).HasMaxLength(1000);
       // builder.Property(x => x.SerialNumber).HasMaxLength(1000);
        builder.Property(x => x.WriteOfDoc).HasMaxLength(1000);
        builder.Property(x => x.AcceptSets).HasMaxLength(1000);
        builder.Property(x => x.Comment).IsRequired(false);

        //Устанавливаем свзяь 1 к М межлу таблицами WarehouseDepEntity и ChapterDesignEntity
        builder
            .HasOne(x => x.DeviceChapter)
            .WithMany(x => x.WarehouseDep)
            .HasForeignKey(x => x.DeviceChapterId);

        builder
            .HasOne(x => x.GenUom)
            .WithMany(s => s.WarehouseDepGenUom)
            .HasForeignKey(x => x.GenUnitId);

        builder
            .HasOne(x => x.Uom)
            .WithMany(s => s.WarehouseDepRemainUom)
            .HasForeignKey(x => x.RemainsUnitId);

        builder
            .HasOne(x => x.EmployerData)
            .WithMany(x => x.WarehouseDepResp)
            .HasForeignKey(x => x.EmployerResponsibleId);
    }
}
