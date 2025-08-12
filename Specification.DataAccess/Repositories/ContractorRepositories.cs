using Microsoft.EntityFrameworkCore;
using Specification.Core.Abstractions.Repository;
using Specification.Core.Models;
using Specification.DataAccess.Entities.Handbooks;
using Specification.DataAccess.Repositories.Base;

namespace Specification.DataAccess.Repositories;

public class ContractorRepositories(SpecificationDataBaseContext dbContext)
    : BaseRepositories(dbContext),
        IHandbookRepository<Contractor>
{
    public async Task<List<Contractor>> Get()
    {
        List<ContractorEntity> contractorEntities = await DataBaseContext
            .Contractor.AsNoTracking()
            .ToListAsync();
        List<Contractor> contractors = contractorEntities
            .Select(s =>
                Contractor
                    .Create(id: s.ContractorId, contractorName: s.ContractorName, inn: s.Inn, isVisible: s.IsVisible)
                    .contractor
            )
            .ToList();
        return contractors;
    }

    public async Task Add(Contractor model)
    {
        ContractorEntity contractorEntity = new ContractorEntity
        {
            ContractorId = model.ContractorId,
            ContractorName = model.ContractorName,  
            Inn = model.Inn
        };

        await DataBaseContext.AddAsync(contractorEntity);
        await DataBaseContext.SaveChangesAsync();
    }

    public async Task Update(int id, Contractor model)
    {
        await DataBaseContext
            .Contractor.Where(f => f.ContractorId == id)
            .ExecuteUpdateAsync(e =>
                e.SetProperty(s => s.ContractorName, model.ContractorName)
                    .SetProperty(s => s.Inn, model.Inn)
            );
    }

    public async Task Delete(int id) =>
        await DataBaseContext.Contractor.Where(f => f.ContractorId == id).ExecuteDeleteAsync();
}
