using Specification.Core.Abstractions.Repository;
using Specification.Core.Abstractions.Service;
using Specification.Core.Models;

namespace Specification.Application.Services;

public class CategoryDeviceService : ITableService<CategoryDevice>
{
    private readonly ITableRepository<CategoryDevice> _repos;

    public CategoryDeviceService(ITableRepository<CategoryDevice> repos)
    {
        _repos = repos;
    }

    public async Task<List<CategoryDevice>> Get(Guid id) => await _repos.Get(id);

    public async Task Add(CategoryDevice model) => await _repos.Add(model);

    public async Task Update(Guid id, CategoryDevice model) => await _repos.Update(id, model);

    public async Task Delete(Guid id) => await _repos.Delete(id);
}
