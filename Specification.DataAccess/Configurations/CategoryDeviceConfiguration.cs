using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Specification.DataAccess.Entities.Handbooks;

namespace Specification.DataAccess.Configurations
{
    public class CategoryDeviceConfiguration : IEntityTypeConfiguration<CategoryDeviceEntity>
    {
        public void Configure(EntityTypeBuilder<CategoryDeviceEntity> builder)
        {
            builder.ToTable("category_device");

            builder.HasKey(keyExpression => keyExpression.CategoryDeviceId);
            builder.Property(x => x.Name).HasMaxLength(3000);

            builder.HasMany(x => x.SubChapters).WithOne(x => x.CategoryDevice);

            builder
                .HasOne(x => x.CategoryChapter)
                .WithMany(x => x.CategoryDevice)
                .HasForeignKey(x => x.CategoryChapterId);

        }
    }
}
