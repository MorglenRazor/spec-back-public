using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Specification.DataAccess.Entities;

namespace Specification.DataAccess.Configurations;

public class SpecificationConfiguration : IEntityTypeConfiguration<SpecificationEntity>
{
    public void Configure(EntityTypeBuilder<SpecificationEntity> builder)
    {
        builder.ToTable("specifications");
        builder.Property(x => x.Name).HasMaxLength(3000);
        builder.Property(x => x.NumTask).HasMaxLength(3000);
        builder.Property(x => x.NumWork).HasMaxLength(3000);

        builder.HasKey(x => x.SpecId);
        //Устанавливаем связь 1 к М между SpecificationEntity и ChapterEntity
        builder
            .HasMany(x => x.Chapters)
            .WithOne(s => s.Specification)
            .HasForeignKey(f => f.SpecificationId);

        //Устанавливаем связь 1кМ между SpecificationEntity и CustomerEntity
        builder
            .HasOne(x => x.Customer)
            .WithMany(s => s.Specification)
            .HasForeignKey(x => x.CustomerId);

        
    }
}
