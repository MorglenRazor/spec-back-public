using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Specification.DataAccess.Entities;
using Specification.DataAccess.Entities.Handbooks;

namespace Specification.DataAccess.Configurations
{
    public class CategoryChapterHandbookConfiguration : IEntityTypeConfiguration<CategoryChapterHandbookEntity>
    {
        public void Configure(EntityTypeBuilder<CategoryChapterHandbookEntity> builder)
        {
            builder.ToTable("category_chapter");

            builder.Property(x => x.Name).HasMaxLength(1000);

            builder.HasKey(s => s.CategoryChapterId);

            builder
            .HasMany(x => x.Chapters)
            .WithOne(x => x.CategoryChapter)
            .HasForeignKey(x => x.CategoryChapterId);

            builder
            .HasMany(x => x.RespPersons)
            .WithOne(x => x.CategoryChapter)
            .HasForeignKey(x => x.CategoryChapterId)
            .OnDelete(DeleteBehavior.Cascade);

         
        }
    }
}
