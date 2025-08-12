using Microsoft.EntityFrameworkCore;
using Specification.Core.Abstractions.Repository;
using Specification.Core.Models;
using Specification.DataAccess.Entities;
using Specification.DataAccess.Repositories.Base;

namespace Specification.DataAccess.Repositories;

public class ConstructionDepRepositories(SpecificationDataBaseContext dbContext)
    : BaseRepositories(dbContext),
        IHandbookRepository<ConstructionDep>
{
    /// <summary>
    /// Ассинхронный запрос в БД на получение данных от Конструкторского отдела о заполнении спецификации
    /// </summary>
    /// <returns>Записи спецификации конструкторского отдела</returns>
    public async Task<List<ConstructionDep>> Get()
    {
        List<ConstructionDepartmentEntity> constructionEntities = await DataBaseContext
            .ConstructionDepartment.AsNoTracking()
            .Include(i => i.DeviceChapter)
            .Include(i => i.Uom)
            .Include(i => i.EmployerData)
            .ToListAsync();
        List<ConstructionDep> constructionParts = constructionEntities
            .Select(s =>
                ConstructionDep
                    .Create(
                        id: s.ConstructionDepId,
                        //cd: s.CountDevice,
                        comment: s.Comment,
                        unitId: s.UnitId,
                        empRespId: s.EmployerResponsibleId,
                        chpDeviceId: s.DeviceChapterId
                    )
                    .designPart
            )
            .ToList();

        return constructionParts;
    }

    /// <summary>
    /// Ассинхронный запрос в БД на добавление данных от Конструкторского отдела в спецификацию
    /// </summary>
    /// <param name="model">Заполененая модель данных</param>
    public async Task Add(ConstructionDep model)
    {
        ConstructionDepartmentEntity constructionDepartmentEntity = new ConstructionDepartmentEntity
        {
           // CountDevice = model.CountDevice,
            Comment = model.Comment,
            UnitId = model.UnitId,
            EmployerResponsibleId = model.EmpRespId,
            DeviceChapterId = model.ChapterDeviceId
        };

        await DataBaseContext.AddAsync(constructionDepartmentEntity);
        await DataBaseContext.SaveChangesAsync();
    }

    /// <summary>
    /// Ассинхронный запрос в БД на обновление данных спецификации от Конструкторского отдела
    /// </summary>
    /// <param name="id">Индификатор записи</param>
    /// <param name="model">Заполененая модель с обновленными данными</param>
    public async Task Update(int id, ConstructionDep model)
    {
        await DataBaseContext
            .ConstructionDepartment.Where(f => f.ConstructionDepId == id)
            .ExecuteUpdateAsync(e =>
                e
                    //.SetProperty(s => s.CountDevice, model.CountDevice)
                    .SetProperty(s => s.Comment, model.Comment)
                    .SetProperty(s => s.UnitId, model.UnitId)
                    .SetProperty(s => s.EmployerResponsibleId, model.EmpRespId)
                    .SetProperty(s => s.DeviceChapterId, model.ChapterDeviceId)
            );
    }

    /// <summary>
    /// Ассинхронный запрос в БД на удаление данных от Конструкторского отдела по спецификации
    /// </summary>
    /// <param name="id">Индификатор записи</param>
    public async Task Delete(int id) =>
        await DataBaseContext
            .ConstructionDepartment.Where(f => f.ConstructionDepId == id)
            .ExecuteDeleteAsync();
}
