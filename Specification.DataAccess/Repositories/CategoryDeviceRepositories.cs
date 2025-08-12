using Microsoft.EntityFrameworkCore;
using Specification.Core.Abstractions.Repository;
using Specification.Core.Models;
using Specification.DataAccess.Entities.Handbooks;
using Specification.DataAccess.Repositories.Base;

namespace Specification.DataAccess.Repositories
{
    public class CategoryDeviceRepositories(SpecificationDataBaseContext dbContext)
    : BaseRepositories(dbContext),
        ITableRepository<CategoryDevice>
    {
        public async Task<List<CategoryDevice>> Get(Guid id)
        {
            List<CategoryDeviceEntity> categoryDeviceEntities = await DataBaseContext
                .CategoryDevices.AsNoTracking()
                .ToListAsync();
            List<CategoryDevice> categoryDevices = categoryDeviceEntities
                .Select(s => CategoryDevice.Create(id: s.CategoryDeviceId, name: s.Name, categoryChapterId: s.CategoryChapterId).categoryDevice)
                .ToList();
            return categoryDevices;
        }

        public async Task Add(CategoryDevice model)
        {
            CategoryDeviceEntity categoryDeviceEntity = new CategoryDeviceEntity { CategoryDeviceId = model.CategoryDeviceId, Name = model.Name, CategoryChapterId = model.CategoryChapterId};
            await DataBaseContext.AddAsync(categoryDeviceEntity);
            await DataBaseContext.SaveChangesAsync();
        }

        public async Task Update(Guid id, CategoryDevice model)
        {
            await DataBaseContext
                .CategoryDevices.Where(f => f.CategoryDeviceId == id)
                .ExecuteUpdateAsync(e => e.SetProperty(s => s.Name, model.Name));
        }

        public async Task Delete(Guid id) =>
            await DataBaseContext
                .CategoryDevices.Where(f => f.CategoryDeviceId == id)
                .ExecuteDeleteAsync();
    }
}
