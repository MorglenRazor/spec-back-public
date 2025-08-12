using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Specification.DataAccess.Entities;

namespace Specification.DataAccess.Configurations
{
    public class RespChapterConfiguration : IEntityTypeConfiguration<RespChapterEntity>
    {
        public void Configure(EntityTypeBuilder<RespChapterEntity> builder)
        {
            builder.ToTable("responsible_chapter");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id);

            builder
                .HasOne(x => x.CategoryChapter)
                .WithMany(x => x.RespPersons)
                .HasForeignKey(x => x.CategoryChapterId);

            builder
                .HasOne(x => x.Responsible)
                .WithMany(x => x.ResponsibleChapter)
                .HasForeignKey(x => x.EmpId);

          
        }
    }
}

