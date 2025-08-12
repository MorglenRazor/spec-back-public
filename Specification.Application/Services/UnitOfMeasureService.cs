using Specification.Core.Abstractions.Repository;
using Specification.Core.Abstractions.Service;
using Specification.Core.Models;

namespace Specification.Application.Services;

public class UnitOfMeasureService : IHandbookService<UnitOfMeasure>, IUomService
{
    private readonly IHandbookRepository<UnitOfMeasure> _repos;
    private readonly IUomRepository _uomRepos;

    public UnitOfMeasureService(IHandbookRepository<UnitOfMeasure> repos, IUomRepository uomRepos)
    {
        _repos = repos;
        _uomRepos = uomRepos;
    }

    public async Task<List<UnitOfMeasure>> Get() => await _repos.Get();

    public async Task Add(UnitOfMeasure model) => await _repos.Add(model);

    public async Task Update(int id, UnitOfMeasure model) => await _repos.Update(id, model);

    public async Task Delete(int id) => await _repos.Delete(id);

    public Task<UnitOfMeasure> Get(int id)
    {
        return _uomRepos.Get(id);
    }
}
