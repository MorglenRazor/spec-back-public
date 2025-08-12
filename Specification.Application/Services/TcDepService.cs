using Specification.Core.Abstractions.Repository;
using Specification.Core.Abstractions.Service;
using Specification.Core.Models;

namespace Specification.Application.Services;

public class TcDepService : IHandbookService<TcDep>
{
    private readonly IHandbookRepository<TcDep> _otcRepository;

    public TcDepService(IHandbookRepository<TcDep> otcRepository)
    {
        _otcRepository = otcRepository;
    }

    public Task<List<TcDep>> Get() => _otcRepository.Get();

    public Task Add(TcDep model) => _otcRepository.Add(model);

    public Task Update(int id, TcDep model) => _otcRepository.Update(id, model);

    public Task Delete(int id) => _otcRepository.Delete(id);
}
