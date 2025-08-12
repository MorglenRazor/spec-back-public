using Specification.Core.Abstractions.Repository;
using Specification.Core.Abstractions.Service;
using Specification.Core.Models;

namespace Specification.Application.Services;

public class ConstructionDepService : IHandbookService<ConstructionDep>
{
    private readonly IHandbookRepository<ConstructionDep> _designPartRepository;

    public ConstructionDepService(IHandbookRepository<ConstructionDep> designPartRepository)
    {
        _designPartRepository = designPartRepository;
    }

    public async Task<List<ConstructionDep>> Get() => await _designPartRepository.Get();

    public async Task Add(ConstructionDep model) => await _designPartRepository.Add(model);

    public async Task Update(int id, ConstructionDep model) =>
        await _designPartRepository.Update(id, model);

    public async Task Delete(int id) => await _designPartRepository.Delete(id);
}
