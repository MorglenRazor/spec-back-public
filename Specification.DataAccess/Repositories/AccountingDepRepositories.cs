using Microsoft.EntityFrameworkCore;
using Specification.Core.Abstractions.Repository;
using Specification.Core.Models;
using Specification.DataAccess.Entities;
using Specification.DataAccess.Repositories.Base;

namespace Specification.DataAccess.Repositories;

public class AccountingDepRepositories(SpecificationDataBaseContext dbContext)
    : BaseRepositories(dbContext),
        IHandbookRepository<AccountingDep>
{
    /// <summary>
    /// Ассинхронный запрос в БД на получение данных от Бухгалтерскоого отдела о заполнении спецификации
    /// </summary>
    /// <returns>Список данных Бухгалтерскоого отдела</returns>
    public async Task<List<AccountingDep>> Get()
    {
        List<AccountingDepartmentEntity> accountEntities = await DataBaseContext
            .AccountingDepartment.AsNoTracking()
            .Include(i => i.Uom)
            .Include(i => i.EmployerData)
            .ToListAsync();
        List<AccountingDep> accountPart = accountEntities
            .Select(s =>
                AccountingDep
                    .Create(
                        id: s.AccountingDepId,
                        //isSub:s.DocIsSubmitted,
                        name: s.NameBrandForUpd,
                        cf: s.CountFact,
                        prcOnOneTax: s.PriceOnOneTax,
                        amTax: s.AmountTax,
                        arc: s.Article,
                        dtDev: s.DateDev,
                        price: s.Price,
                        ad: s.AcompDoc,
                        comment: s.Comment,
                        unitId: s.UnitId,
                        empRespId: s.EmployerResponsibleId!=null?s.EmployerResponsibleId:null,
                        chpDeviceId: s.DeviceChapterId
                    )
                    .accountPart
            )
            .ToList();
        return accountPart;
    }

    /// <summary>
    /// Ассинхронный запрос в БД на добавление данных от Бухгалтерскоого отдела в спецификацию
    /// </summary>
    /// <param name="model">Заполененая модель данных</param>
    public async Task Add(AccountingDep model)
    {
        AccountingDepartmentEntity accountingDepartmentEntity = new AccountingDepartmentEntity
        {
            AccountingDepId = model.AccountingDepId,
            //DocIsSubmitted = model.DocIsSubmitted,
            NameBrandForUpd = model.NameBrandForUpd,
            CountFact = model.CountFact,
            PriceOnOneTax = model.PriceOnOneTax,
            AmountTax = model.AmountTax,
            Article = model.Article,
            DateDev = model.DateDev,
            Price = model.Price,
            AcompDoc = model.AcompDoc,
            Comment = model.Comment,
            UnitId = model.UnitId,
            EmployerResponsibleId = model.EmpRespId,
            DeviceChapterId = model.ChapterDeviceId
        };

        await DataBaseContext.AddAsync(accountingDepartmentEntity);
        await DataBaseContext.SaveChangesAsync();
    }

    /// <summary>
    /// Ассинхронный запрос в БД на обновление данных спецификации от Бухгалтерскоого отдела
    /// </summary>
    /// <param name="id">Индификатор записи</param>
    /// <param name="model">Заполененая модель с обновленными данными</param>
    public async Task Update(int id, AccountingDep model)
    {
        await DataBaseContext
            .AccountingDepartment.Where(f => f.AccountingDepId == id)
            .ExecuteUpdateAsync(e =>
                e
                //.SetProperty(s => s.DocIsSubmitted, model.DocIsSubmitted)
                .SetProperty(s => s.NameBrandForUpd, model.NameBrandForUpd)
                    .SetProperty(s => s.CountFact, model.CountFact)
                    .SetProperty(s => s.PriceOnOneTax, model.PriceOnOneTax)
                    .SetProperty(s => s.AmountTax, model.AmountTax)
                    .SetProperty(s => s.Article, model.Article)
                    .SetProperty(s => s.DateDev, model.DateDev)
                    .SetProperty(s => s.Price, model.Price)
                    .SetProperty(s => s.AcompDoc, model.AcompDoc)
                    .SetProperty(s => s.Comment, model.Comment)
                    .SetProperty(s => s.UnitId, model.UnitId)
                    .SetProperty(s => s.DeviceChapterId, model.ChapterDeviceId)
                    .SetProperty(s=>s.EmployerResponsibleId, model.EmpRespId)
            );
    }

    /// <summary>
    /// Ассинхронный запрос в БД на удаление данных от Бухгалтерскоого отдела по спецификации
    /// </summary>
    /// <param name="id">Индификатор записи</param>
    public async Task Delete(int id) =>
        await DataBaseContext
            .AccountingDepartment.Where(f => f.AccountingDepId == id)
            .ExecuteDeleteAsync();
}
