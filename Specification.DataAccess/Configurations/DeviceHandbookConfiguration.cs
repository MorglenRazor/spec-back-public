using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Specification.DataAccess.Entities.Handbooks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Specification.DataAccess.Configurations
{
    public class DeviceHandbookConfiguration : IEntityTypeConfiguration<DeviceHandbookEntity>
    {
        public void Configure(EntityTypeBuilder<DeviceHandbookEntity> builder)
        {
            builder.ToTable("devices_handbook");

            builder.HasKey(x => x.DeviceId);
            builder.Property(x => x.Name).HasMaxLength(3000);
            builder.Property(x => x.BrandName).HasMaxLength(3000);

            builder.HasOne(x => x.Category).WithMany(x => x.Devices);

            builder.HasMany(x => x.DevicesChapter).WithOne(x => x.Device);
        }
    }
}
