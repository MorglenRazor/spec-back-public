using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Specification.DataAccess.Entities;

namespace Specification.DataAccess.Configurations;

public class TmsDepConfiguration : IEntityTypeConfiguration<TmsDepartmentEntity>
{
    public void Configure(EntityTypeBuilder<TmsDepartmentEntity> builder)
    {
        builder.ToTable("tms_dep");

        builder.HasKey(x => x.TmsDepId);
        builder.Property(x => x.TmsDepId).UseMySqlIdentityColumn();

        builder.Property(x => x.Comment).HasMaxLength(3000);
        builder.Property(x => x.NameBrandForPurchase).HasMaxLength(3000);
        builder.Property(x => x.AccountNumber).HasMaxLength(3000);
        builder.Property(x => x.PriceNoTax).HasPrecision(10, 3);
        builder.Property(x => x.PriceWithTax).HasPrecision(10, 3);
        builder.Property(x => x.Amount).HasPrecision(10, 3);
       // builder.Property(x => x.FirstPay).HasPrecision(10, 3);
       // builder.Property(x => x.SecondPay).HasPrecision(10, 3);
       // builder.Property(x => x.ThirdPay).HasPrecision(10, 3);
       // builder.Property(x => x.PaymentBalance).HasPrecision(10, 3);
       // builder.Property(x => x.CostOfRefand).HasPrecision(10, 3);
        builder.Property(x => x.Comment).IsRequired(false);

        //Устанавливаем свзязь 1 к М между таблицами TmsDepartmentEntity и TechMaterialSuppDep
        builder
            .HasOne(x => x.DeviceChapter)
            .WithMany(x => x.TechMaterialSuppDep)
            .HasForeignKey(x => x.DeviceChapterId);

        builder
            .HasOne(x => x.EmployerData)
            .WithMany(x => x.TmsDepResp)
            .HasForeignKey(x => x.EmployerResponsibleId);

        //Устанавливаем свзязь 1 к М между таблицами ContractorEntity и TechMaterialDep
        builder
            .HasOne(x => x.Contractor)
            .WithMany(s => s.TechMaterialDep)
            .HasForeignKey(x => x.ContractorId);
    }
}
