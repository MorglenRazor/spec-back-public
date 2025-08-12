using Specification.Core.Abstractions.Repository;
using Specification.Core.Abstractions.Service;
using Specification.Core.Models;

namespace Specification.Application.Services;

public class CustomerService : IHandbookService<Customer>
{
    private readonly IHandbookRepository<Customer> _repos;

    public CustomerService(IHandbookRepository<Customer> repos)
    {
        _repos = repos;
    }

    public async Task<List<Customer>> Get() => await _repos.Get();

    public async Task Add(Customer model) => await _repos.Add(model);

    public async Task Update(int id, Customer model) => await _repos.Update(id, model);

    public async Task Delete(int id) => await _repos.Delete(id);
}
