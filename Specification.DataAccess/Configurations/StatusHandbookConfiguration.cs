using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Specification.DataAccess.Entities.Handbooks;
namespace Specification.DataAccess.Configurations
{
    public class StatusHandbookConfiguration : IEntityTypeConfiguration<StatusDeviceHandbookEntity>
    {
        public void Configure(EntityTypeBuilder<StatusDeviceHandbookEntity> builder)
        {
            builder.ToTable("satus_device_hanbook");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasMaxLength(1000);

            builder
              .HasMany(x => x.DevicesChapter)
              .WithOne(x => x.Status)
              .HasForeignKey(x => x.StatusId);

            builder
              .HasOne(x => x.DepartmentCurrWork)
              .WithMany(x => x.StatusWork)
              .HasForeignKey(x => x.DepId);

           
        }
    }
}
