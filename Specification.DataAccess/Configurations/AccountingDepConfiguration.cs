using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Specification.DataAccess.Entities;

namespace Specification.DataAccess.Configurations;

public class AccountingDepConfiguration : IEntityTypeConfiguration<AccountingDepartmentEntity>
{
    public void Configure(EntityTypeBuilder<AccountingDepartmentEntity> builder)
    {
        builder.ToTable("accounting_dep");

        builder.HasKey(x => x.AccountingDepId);
        builder.Property(x => x.AccountingDepId).UseMySqlIdentityColumn();
        builder.Property(x => x.Comment).HasMaxLength(3000);
        builder.Property(x => x.Comment).IsRequired(false);
        builder.Property(x => x.NameBrandForUpd).HasMaxLength(3000);
        builder.Property(x => x.Article).HasMaxLength(3000);
        builder.Property(x => x.AcompDoc).HasMaxLength(3000);
        builder.Property(x => x.PriceOnOneTax).HasPrecision(10, 3);
        ;
        builder.Property(x => x.AmountTax).HasPrecision(10, 3);
        ;
        builder.Property(x => x.Price).HasPrecision(10, 3);
        ;

        //Устанавливаем свзяь 1 к М межлу таблицами AccountingDepartmentEntity и ChapterDesignEntity
        builder
            .HasOne(x => x.DeviceChapter)
            .WithMany(x => x.AccountingDep)
            .HasForeignKey(x => x.DeviceChapterId);

        builder
            .HasOne(x => x.EmployerData)
            .WithMany(x => x.AccountingDepResp)
            .HasForeignKey(x => x.EmployerResponsibleId);

        builder.HasOne(x => x.Uom).WithMany(s => s.AccountingDep).HasForeignKey(x => x.UnitId);
    }
}
