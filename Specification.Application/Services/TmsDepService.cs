using Specification.Core.Abstractions.Repository;
using Specification.Core.Abstractions.Service;
using Specification.Core.Models;

namespace Specification.Application.Services;

public class TmsDepService : IHandbookService<TmsDep>, ITmsService
{
    private readonly IHandbookRepository<TmsDep> _otmsRepository;
    private readonly ITmsRepository tmsRepository;

    public TmsDepService(IHandbookRepository<TmsDep> otmsRepository, ITmsRepository _tmsRepository)
    {
        tmsRepository = _tmsRepository;
        _otmsRepository = otmsRepository;
    }

    public async Task UpdateGenField(int id, TmsDep model) => await tmsRepository.UpdateGenField(id, model);

    public async Task<List<TmsDep>> Get() => await _otmsRepository.Get();

    public async Task Add(TmsDep model) => await _otmsRepository.Add(model);

    public async Task Update(int id, TmsDep model) => await _otmsRepository.Update(id, model);

    public async Task Delete(int id) => await _otmsRepository.Delete(id);
}
