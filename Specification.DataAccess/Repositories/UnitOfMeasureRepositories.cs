using Microsoft.EntityFrameworkCore;
using Specification.Core.Abstractions.Repository;
using Specification.Core.Models;
using Specification.DataAccess.Entities.Handbooks;
using Specification.DataAccess.Repositories.Base;

namespace Specification.DataAccess.Repositories;

public class UnitOfMeasureRepositories(SpecificationDataBaseContext dbContext)
    : BaseRepositories(dbContext),
        IHandbookRepository<UnitOfMeasure>, IUomRepository
{
    public async Task<List<UnitOfMeasure>> Get()
    {
        List<UnitOfMeasureEntity> uomEntities = await DataBaseContext
            .UnitOfMeasure.AsNoTracking()
            .ToListAsync();
        List<UnitOfMeasure> unitOfMeasures = uomEntities
            .Select(s => UnitOfMeasure.Create(id: s.Id, name: s.Name, shortName: s.ShortName, isVisible: s.IsVisible).uom)
            .ToList();
        return unitOfMeasures;
    }

    public async Task<UnitOfMeasure> Get(int id)
    {
        UnitOfMeasureEntity uomEntities = await DataBaseContext.UnitOfMeasure.AsNoTracking().Where(f => f.Id == id).FirstOrDefaultAsync();
        if(uomEntities!= null)
        {
           UnitOfMeasure uom = UnitOfMeasure.Create(id: uomEntities.Id, name: uomEntities.Name, shortName: uomEntities.ShortName, isVisible: uomEntities.IsVisible).uom;
            return uom;
        }
        return null;
    }

    public async Task Add(UnitOfMeasure model)
    {
        UnitOfMeasureEntity uomEntity = new UnitOfMeasureEntity
        {
            Name = model.Name,
            ShortName = model.ShortName
        };

        await DataBaseContext.AddAsync(uomEntity);
        await DataBaseContext.SaveChangesAsync();
    }

    public async Task Update(int id, UnitOfMeasure model)
    {
        await DataBaseContext
            .UnitOfMeasure.Where(f => f.Id == id)
            .ExecuteUpdateAsync(e =>
                e.SetProperty(s => s.Name, model.Name)
                    .SetProperty(s => s.ShortName, model.ShortName)
            );
    }

    public async Task Delete(int id) =>
        await DataBaseContext.UnitOfMeasure.Where(f => f.Id == id).ExecuteDeleteAsync();
}
