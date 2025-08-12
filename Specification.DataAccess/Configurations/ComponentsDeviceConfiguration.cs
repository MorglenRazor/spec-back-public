using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Specification.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Specification.DataAccess.Configurations
{
    public class ComponentsDeviceConfiguration : IEntityTypeConfiguration<ComponentsDeviceEntity>
    {
        public void Configure(EntityTypeBuilder<ComponentsDeviceEntity> builder)
        {
            builder.ToTable("components_device");
            builder.HasKey(x => x.Id);

           // builder
           //.HasOne(x => x.DeviceChapter)
           //.WithMany(x => x.Components)
           //.HasForeignKey(x => x.DeviceChapterId);
        }
    }
}
