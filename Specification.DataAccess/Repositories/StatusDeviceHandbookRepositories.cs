using Microsoft.EntityFrameworkCore;
using Specification.Core.Abstractions.Repository;
using Specification.Core.Models;
using Specification.DataAccess.Entities.Handbooks;
using Specification.DataAccess.Repositories.Base;

namespace Specification.DataAccess.Repositories
{
    public class StatusDeviceHandbookRepositories(SpecificationDataBaseContext dbContext)
        : BaseRepositories(dbContext), ITableRepository<StatusDeviceHandbook>, IStatusDeviceHandbookRepository
    {
        public async Task Add(StatusDeviceHandbook model)
        {
            StatusDeviceHandbookEntity statusEntity = new StatusDeviceHandbookEntity
            {
                Id = model.Id,
                Name = model.Name,
                DepId = model.DepId,
            };
            await DataBaseContext.AddAsync(statusEntity);
            await DataBaseContext.SaveChangesAsync();
        }

        public async Task Delete(Guid id)
        {
            await DataBaseContext.StatusHandbook.Where(f=>f.Id==id).ExecuteDeleteAsync();
        }

        public async Task<List<StatusDeviceHandbook>> Get(Guid id)
        {
            List<StatusDeviceHandbookEntity> statusDeviceHandbooksEnt = new List<StatusDeviceHandbookEntity>();
            if (id == Guid.Empty)
            {
                statusDeviceHandbooksEnt = await DataBaseContext.StatusHandbook.AsNoTracking().ToListAsync();
            }
            else
            {
                statusDeviceHandbooksEnt = await DataBaseContext.StatusHandbook.Where(f=>f.Id==id).AsNoTracking().ToListAsync();
            }
            List<StatusDeviceHandbook> statusDevices = statusDeviceHandbooksEnt
                .Select(s=> StatusDeviceHandbook.GetModel(s.Id,s.Name, s.DepId, s.DepartmentCurrWork.ShortName, s.IsVisible, s.Rank)).ToList();
            return statusDevices;
        }

        public async Task<List<StatusDeviceHandbook>> GetStatusByDepId(Guid depId)
        {
            List<StatusDeviceHandbookEntity> stsEnt = await DataBaseContext
                .StatusHandbook
                .AsNoTracking()
                .Include(i => i.DepartmentCurrWork)
                .Where(s => s.DepId == depId).ToListAsync();
            List<StatusDeviceHandbook> stsDev = stsEnt.Select(s => StatusDeviceHandbook.GetModel(s.Id, s.Name, s.DepId, s.DepartmentCurrWork.ShortName, s.IsVisible, s.Rank)).ToList();
            return stsDev;
        }

        public async Task Update(Guid id, StatusDeviceHandbook model)
        {
            await DataBaseContext.StatusHandbook.Where(f => f.Id == id).ExecuteUpdateAsync(e =>
                e.SetProperty(s => s.DepId, model.DepId).SetProperty(s => s.Name, model.Name));
        }
    }
}
