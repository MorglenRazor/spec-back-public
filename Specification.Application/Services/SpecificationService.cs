using System.Reflection;
using Specification.Core.Abstractions.Repository;
using Specification.Core.Abstractions.Service;
using Specification.Core.Models;

namespace Specification.Application.Services;

public class SpecificationService : ITableService<Core.Models.Specification>, ISpecificationService
{
    private readonly ITableRepository<Core.Models.Specification> _specRepository;
    private readonly ISpecificationRepository _specRepositoryResp;

    public SpecificationService(
        ITableRepository<Core.Models.Specification> specRepository,
        ISpecificationRepository specRepositoryResp
    )
    {
        _specRepository = specRepository;
        _specRepositoryResp = specRepositoryResp;
    }

    /// <summary>
    /// Интерфейс получения модели
    /// </summary>
    /// <param name="id">Индификатор</param>
    /// <returns>Список модели</returns>
    public async Task<List<Core.Models.Specification>> Get(Guid id) =>
        await _specRepository.Get(id);

    /// <summary>
    /// Интерфейс добавления модели
    /// </summary>
    /// <param name="model">Модели данных</param>
    public async Task Add(Core.Models.Specification model) => await _specRepository.Add(model);

    /// <summary>
    /// Интерфейс обновления модели
    /// </summary>
    /// <param name="id">Индификатор обновляемой записи</param>
    /// <param name="model">Модель обновления</param>
    public async Task Update(Guid id, Core.Models.Specification model) =>
        await _specRepository.Update(id, model);

    /// <summary>
    /// Интерфейс удаления записи
    /// </summary>
    /// <param name="id">Индификатор удаляемой записи</param>
    public async Task Delete(Guid id) => await _specRepository.Delete(id);


   // public async Task<List<Core.Models.Specification>> AddWthReturnChapIds(Core.Models.Specification model) => await _specRepositoryResp.AddWthReturnChapIds(model);
}
