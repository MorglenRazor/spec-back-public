using Microsoft.EntityFrameworkCore;
using Specification.Core.Abstractions.Repository;
using Specification.Core.Models;
using Specification.DataAccess.Entities.Handbooks;
using Specification.DataAccess.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Specification.DataAccess.Repositories
{
    public class DeviceRepositories(SpecificationDataBaseContext dbContext) : BaseRepositories(dbContext),
        ITableRepository<Device>,
        IDeviceRepository
    {
        public async Task<List<Device>> Get(Guid id)
        {
            List<DeviceHandbookEntity> deviceEntities = new List<DeviceHandbookEntity>();
            if (id == Guid.Empty)
            {
                deviceEntities = await DataBaseContext
                .Devices.AsNoTracking()
                .ToListAsync();
            }
            else if (id != Guid.Empty)
            {
                deviceEntities = await DataBaseContext
                .Devices.AsNoTracking()
                .Where(f=>f.DeviceId == id)
                .ToListAsync();
            }


            List<Device> devices = deviceEntities
                .Select(s =>
                    Device
                        .Create(
                            id: s.DeviceId,
                            name: s.Name,
                            brandName: s.BrandName,
                            categoryId: s.CategoryId
                        )
                        .device
                )
                .ToList();

            return devices;
        }

        public async Task Add(Device model)
        {
            DeviceHandbookEntity deviceHandbookEntity = new DeviceHandbookEntity
            {
                DeviceId = model.DeviceId,
                Name = model.Name,
                BrandName = model.BrandName,
                CategoryId = model.CategoryDeviceId
            };
            await DataBaseContext.AddAsync(deviceHandbookEntity);
            await DataBaseContext.SaveChangesAsync();
        }

        public async Task Update(Guid id, Device model)
        {
            await DataBaseContext
                .Devices.Where(f => f.DeviceId == id)
                .ExecuteUpdateAsync(e =>
                    e.SetProperty(s => s.DeviceId, model.DeviceId)
                        .SetProperty(s => s.Name, model.Name)
                        .SetProperty(s => s.BrandName, model.BrandName)
                        .SetProperty(s => s.CategoryId, model.CategoryDeviceId)
                );
        }

        public async Task Delete(Guid id) =>
            await DataBaseContext.Devices.Where(f => f.DeviceId == id).ExecuteDeleteAsync();

        public async Task<List<Device>> GetFilt(Guid? ctId, Guid? subCtId)
        {
            List<DeviceHandbookEntity> deviceEntities = new List<DeviceHandbookEntity>();
            if (ctId != null && subCtId == null)
            {
                deviceEntities = await DataBaseContext
                    .Devices.Where(f => f.CategoryId == ctId && subCtId == null)
                    .AsNoTracking()
                    .ToListAsync();
            }
            else if (ctId != null && subCtId != null)
            {
                deviceEntities = await DataBaseContext
                    .Devices.Where(f => f.CategoryId == ctId)
                    .AsNoTracking()
                    .ToListAsync();
            }
            List<Device> devices = deviceEntities
                .Select(s =>
                    Device
                        .Create(
                            id: s.DeviceId,
                            name: s.Name,
                            brandName: s.BrandName,
                            categoryId: s.CategoryId
                        )
                        .device
                )
                .ToList();

            return devices;
        }
    }
}

