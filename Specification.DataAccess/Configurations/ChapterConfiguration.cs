using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Specification.DataAccess.Entities;

namespace Specification.DataAccess.Configurations;

public class ChapterConfiguration : IEntityTypeConfiguration<ChapterEntity>
{
    public void Configure(EntityTypeBuilder<ChapterEntity> builder)
    {
        builder.ToTable("chapters");

        builder.HasKey(s => s.ChapterId);

        builder.Property(x => x.Comment).HasMaxLength(1000);
        builder.Property(x => x.CostChapter).HasPrecision(10, 3);
       

        builder
            .HasOne(x => x.Specification)
            .WithMany(x => x.Chapters)
            .HasForeignKey(x => x.SpecificationId);

        builder
           .HasOne(x => x.CategoryChapter)
           .WithMany(x => x.Chapters)
           .HasForeignKey(x => x.ChapterId);

        builder
            .HasMany(x => x.SubChapters)
            .WithOne(x => x.ChapterEntity)
            .HasForeignKey(x => x.ChapterId);
        //builder
        //.HasMany(x => x.RespPersons)
        //.WithOne(x => x.CategoryChapter)
        //.HasForeignKey(x => x.CategoryChapterId)
        //.OnDelete(DeleteBehavior.Cascade);

        //builder
        //    .HasMany(x => x.CategoryDevice)
        //    .WithOne(x => x.Chapter)
        //    .HasForeignKey(x => x.ChapterId);

    }
}
