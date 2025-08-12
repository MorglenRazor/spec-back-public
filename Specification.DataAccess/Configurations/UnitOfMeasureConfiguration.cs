using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Specification.DataAccess.Entities.Handbooks;

namespace Specification.DataAccess.Configurations;

public class UnitOfMeasureConfiguration : IEntityTypeConfiguration<UnitOfMeasureEntity>
{
    public void Configure(EntityTypeBuilder<UnitOfMeasureEntity> builder)
    {
        builder.ToTable("unit_of_measure");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).UseMySqlIdentityColumn();
        builder.Property(x => x.Name).HasMaxLength(3000);
        builder.Property(x => x.ShortName).HasMaxLength(1000);

        builder.HasMany(x => x.WarehouseDepGenUom).WithOne(x => x.GenUom);
        builder.HasMany(x => x.WarehouseDepRemainUom).WithOne(x => x.Uom);

        builder.HasMany(x => x.ConstructionDep).WithOne(x => x.Uom);

        builder.HasMany(x => x.TechControlDep).WithOne(x => x.Uom);

        builder.HasMany(x => x.AccountingDep).WithOne(x => x.Uom);

        List<UnitOfMeasureEntity> uom = [
            new UnitOfMeasureEntity{
                Id = 1,
                Name = "�������������",
                ShortName = "��",
                IsVisible = false,
            },
            new UnitOfMeasureEntity{
                Id = 2,
                Name = "���������",
                ShortName = "��.",
                IsVisible = true,
            },
            new UnitOfMeasureEntity{
                Id = 3,
                Name = "�����",
                ShortName = "��.",
                IsVisible = true,
            },
            new UnitOfMeasureEntity{
                Id = 4,
                Name = "����",
                ShortName = "��.",
                IsVisible = true,
            },
            new UnitOfMeasureEntity{
                Id = 5,
                Name = "��������",
                ShortName = "����.",
                IsVisible = true,
            },
            new UnitOfMeasureEntity{
                Id = 6,
                Name = "����",
                ShortName = "�.",
                IsVisible = true,
            },
            new UnitOfMeasureEntity{
                Id = 7,
                Name = "���� �������",
                ShortName = "�2.",
                IsVisible = true,
            },
            new UnitOfMeasureEntity{
                Id = 8,
                Name = "��������",
                ShortName = "��.",
                IsVisible = true,
            },
        ];
        builder.HasData( uom );
    }
}
