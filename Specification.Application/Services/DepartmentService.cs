using Specification.Core.Abstractions.Repository;
using Specification.Core.Abstractions.Repository.Auth;
using Specification.Core.Abstractions.Service;
using Specification.Core.Abstractions.Service.Auth;
using Specification.Core.Models;
using System.Security.Cryptography.X509Certificates;

namespace Specification.Application.Services;

public class DepartmentService : ITableService<Department>, IDepartmentService
{
    private readonly ITableRepository<Department> _repos;
    private readonly IDepartmentRepository _depRepos;

    public DepartmentService(ITableRepository<Department> repos, IDepartmentRepository depRepos)
    {
        _repos = repos;
        _depRepos = depRepos;
    }

    public Task<List<Department>> Get(Guid id) => _repos.Get(id);


    public Task Add(Department model) => _repos.Add(model);

    public Task Update(Guid id, Department model) => _repos.Update(id, model);
    public Task Delete(Guid id) => _repos.Delete(id);

    public async Task<Guid> Get(string shortName) => await _depRepos.Get(shortName);
}
