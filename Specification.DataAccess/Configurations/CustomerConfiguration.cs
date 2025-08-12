using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Specification.DataAccess.Entities.Handbooks;

namespace Specification.DataAccess.Configurations;

public class CustomerConfiguration : IEntityTypeConfiguration<CustomerEntity>
{
    public void Configure(EntityTypeBuilder<CustomerEntity> builder)
    {
        builder.ToTable("customers");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).UseMySqlIdentityColumn();
        builder.Property(x => x.Name).HasMaxLength(3000);
        builder.HasMany(x => x.Specification).WithOne(x => x.Customer);

    }
}
