using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Specification.DataAccess.Entities;

namespace Specification.DataAccess.Configurations
{
    public class SubChapterConfiguration : IEntityTypeConfiguration<SubChapterEntity>
    {
        public void Configure(EntityTypeBuilder<SubChapterEntity> builder)
        {
            builder.ToTable("sub_chapters");
            builder.HasKey(s => s.SubChapId);

            builder
                .HasOne(x => x.ChapterEntity)
                .WithMany(x => x.SubChapters)
                .HasForeignKey(x => x.ChapterId);

            builder
                .HasOne(x => x.CategoryDevice)
                .WithMany(x => x.SubChapters)
                .HasForeignKey(x => x.CategoryDeviceId);

            builder
                .HasMany(x => x.Devices)
                .WithOne(x => x.SubChapter)
                .HasForeignKey(x => x.SubChapterId);
        }
    }
}
