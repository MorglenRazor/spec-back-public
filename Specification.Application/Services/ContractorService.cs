using Specification.Core.Abstractions.Repository;
using Specification.Core.Abstractions.Service;
using Specification.Core.Models;

namespace Specification.Application.Services;

public class ContractorService : IHandbookService<Contractor>
{
    private readonly IHandbookRepository<Contractor> _repos;

    public ContractorService(IHandbookRepository<Contractor> repos)
    {
        _repos = repos;
    }

    public async Task<List<Contractor>> Get() => await _repos.Get();

    public async Task Add(Contractor model) => await _repos.Add(model);

    public async Task Update(int id, Contractor model) => await _repos.Update(id, model);

    public async Task Delete(int id) => await _repos.Delete(id);
}
