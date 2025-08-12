using Specification.Core.Abstractions.Repository;
using Specification.Core.Abstractions.Service;
using Specification.Core.Models;

namespace Specification.Application.Services;

public class WarehouseDepService : IHandbookService<WarehouseDep>
{
    private readonly IHandbookRepository<WarehouseDep> _storageRepository;

    public WarehouseDepService(IHandbookRepository<WarehouseDep> storageRepository)
    {
        _storageRepository = storageRepository;
    }

    public async Task<List<WarehouseDep>> Get() => await _storageRepository.Get();

    public async Task Add(WarehouseDep model) => await _storageRepository.Add(model);

    public async Task Update(int id, WarehouseDep model) =>
        await _storageRepository.Update(id, model);

    public async Task Delete(int id) => await _storageRepository.Delete(id);
}
