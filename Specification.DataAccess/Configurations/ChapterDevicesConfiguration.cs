using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Specification.DataAccess.Entities;

namespace Specification.DataAccess.Configurations;

public class ChapterDevicesConfiguration : IEntityTypeConfiguration<DevicesChapterEntity>
{
    public void Configure(EntityTypeBuilder<DevicesChapterEntity> builder)
    {
        builder.ToTable("devices_chapter");

        builder.HasKey(x => x.DeviceChapterId);
        builder.Property(x => x.CompName).HasMaxLength(3000);

        builder
            .HasOne(x => x.Device)
            .WithMany(x => x.DevicesChapter)
            .HasForeignKey(x => x.DeviceId);

        builder
            .HasOne(x => x.Status)
            .WithMany(x => x.DevicesChapter)
            .HasForeignKey(x => x.StatusId);

    

        builder
            .HasOne(x => x.SubChapter)
            .WithMany(x => x.Devices)
            .HasForeignKey(x => x.SubChapterId);

        //builder
        //    .HasOne(x => x.Chapter)
        //    .WithMany(x => x.DevicesList)
        //    .HasForeignKey(x => x.ChapterId);

       

        //Устанавливаем связь 1 к М между DevicesChapterEntity и ConstructionDepEntity
        builder
            .HasMany(x => x.ConstructionDep)
            .WithOne(x => x.DeviceChapter)
            .HasForeignKey(x => x.DeviceChapterId);
        //Устанавливаем связь 1 к М между DevicesChapterEntity и AccountingDepEntity
        builder
            .HasMany(x => x.AccountingDep)
            .WithOne(x => x.DeviceChapter)
            .HasForeignKey(x => x.DeviceChapterId);
        //Устанавливаем связь 1 к М между DevicesChapterEntity и WarehouseDepEntity
        builder
            .HasMany(x => x.WarehouseDep)
            .WithOne(x => x.DeviceChapter)
            .HasForeignKey(x => x.DeviceChapterId);
        //Устанавливаем связь 1 к М между DevicesChapterEntity и TechControlDepEntity
        builder
            .HasMany(x => x.TechControlDep)
            .WithOne(x => x.DeviceChapter)
            .HasForeignKey(x => x.DeviceChapterId);
        //Устанавливаем связь 1 к М между DevicesChapterEntity и TechMaterialSuppDepEntity
        builder
            .HasMany(x => x.TechMaterialSuppDep)
            .WithOne(x => x.DeviceChapter)
            .HasForeignKey(x => x.DeviceChapterId);

        //builder
        //    .HasMany(x => x.Components)
        //    .WithOne(x => x.DeviceChapter)
        //    .HasForeignKey(x => x.DeviceChapterId);
    }
}
