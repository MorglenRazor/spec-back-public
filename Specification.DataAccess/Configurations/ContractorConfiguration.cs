using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Specification.DataAccess.Entities.Handbooks;

namespace Specification.DataAccess.Configurations;

public class ContractorConfiguration : IEntityTypeConfiguration<ContractorEntity>
{
    public void Configure(EntityTypeBuilder<ContractorEntity> builder)
    {
        builder.ToTable("contractors");

        builder.HasKey(keyExpression => keyExpression.ContractorId);

        builder.Property(x => x.ContractorId).UseMySqlIdentityColumn();
        builder.Property(x => x.ContractorName).HasMaxLength(3000);
        builder.Property(x => x.Inn).HasMaxLength(1000);

        builder.HasMany(x => x.TechMaterialDep).WithOne(x => x.Contractor);

    }
}
