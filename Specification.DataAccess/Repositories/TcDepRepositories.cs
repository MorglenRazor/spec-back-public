using Microsoft.EntityFrameworkCore;
using Specification.Core.Abstractions.Repository;
using Specification.Core.Models;
using Specification.DataAccess.Entities;
using Specification.DataAccess.Repositories.Base;

namespace Specification.DataAccess.Repositories;

public class TcDepRepositories(SpecificationDataBaseContext dbContext)
    : BaseRepositories(dbContext),
        IHandbookRepository<TcDep>
{
    /// <summary>
    /// Ассинхронный запрос в БД на получение данных от ОТК о заполнении спецификации
    /// </summary>
    /// <returns>Список данных ОТК</returns>
    public async Task<List<TcDep>> Get()
    {
        List<TcDepartmentEntity> tcDepartmentEntities = await DataBaseContext
            .TcDepartment.AsNoTracking()
            .Include(i => i.Uom)
            .ToListAsync();

        List<TcDep> tcDepParts = tcDepartmentEntities
            .Select(s =>
                TcDep
                    .Create(
                        id: s.TcDepId,
                        //status: s.Status,
                        name: s.NameBrandInDoc,
                        count: s.Count,
                       // sNum: s.SerialNum,
                        cKit: s.CompKit,
                        ctda: s.CompTechDocAvailable,
                        ctdm: s.CompTechDocMissing,
                        defects: s.Defects,
                        conc: s.Conclusion,
                        comment: s.Comment,
                        unitId: s.UnitId,
                        empRespId: s.EmployerResponsibleId,
                        chapDeviceId: s.DeviceChapterId
                    )
                    .otc
            )
            .ToList();

        return tcDepParts;
    }

    /// <summary>
    /// Ассинхронный запрос в БД на добавление данных от ОТК в спецификацию
    /// </summary>
    /// <param name="model">Заполененая модель данных</param>
    public async Task Add(TcDep model)
    {
        TcDepartmentEntity tcDepartmentEntity = new TcDepartmentEntity
        {
            //Status = model.Status,
            NameBrandInDoc = model.NameBrandInDoc,
            Count = model.Count,
            UnitId = model.UnitId,
            //SerialNum = "",
            CompKit = model.CompKit,
            CompTechDocAvailable = model.CompTechDocAvailable,
            CompTechDocMissing = model.CompTechDocMissing,
            Defects = model.Defects,
            Conclusion = model.Conclusion,
            Comment = model.Comment,
            EmployerResponsibleId = model.EmpRespId,
            DeviceChapterId = model.ChapterDeviceId
        };

        await DataBaseContext.AddAsync(tcDepartmentEntity);
        await DataBaseContext.SaveChangesAsync();
    }

    /// <summary>
    /// Ассинхронный запрос в БД на обновление данных спецификации от ОТК
    /// </summary>
    /// <param name="id">Индификатор записи</param>
    /// <param name="model">Заполененая модель с обновленными данными</param>
    public async Task Update(int id, TcDep model)
    {
        await DataBaseContext
            .TcDepartment.Where(f => f.TcDepId == id)
            .ExecuteUpdateAsync(e =>
                e.SetProperty(s => s.NameBrandInDoc, model.NameBrandInDoc)
                    .SetProperty(s => s.Count, model.Count)
                    .SetProperty(s => s.UnitId, model.UnitId)
                    //.SetProperty(s => s.SerialNum, model.SerialNum)
                    .SetProperty(s => s.CompKit, model.CompKit)
                    .SetProperty(s => s.CompTechDocAvailable, model.CompTechDocAvailable)
                    .SetProperty(s => s.CompTechDocMissing, model.CompTechDocMissing)
                    .SetProperty(s => s.Defects, model.Defects)
                    .SetProperty(s => s.Conclusion, model.Conclusion)
                    .SetProperty(s => s.Comment, model.Comment)
                    .SetProperty(s => s.DeviceChapterId, model.ChapterDeviceId)
                    .SetProperty(s=>s.EmployerResponsibleId, model.EmpRespId)
            );
    }

    /// <summary>
    /// Ассинхронный запрос в БД на удаление данных от ОТК по спецификации
    /// </summary>
    /// <param name="id">Индификатор записи</param>
    public async Task Delete(int id) =>
        await DataBaseContext.TcDepartment.Where(f => f.TcDepId == id).ExecuteDeleteAsync();
}
