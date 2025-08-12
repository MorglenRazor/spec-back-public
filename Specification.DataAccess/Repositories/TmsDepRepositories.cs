using Microsoft.EntityFrameworkCore;
using Specification.Core.Abstractions.Repository;
using Specification.Core.Models;
using Specification.DataAccess.Entities;
using Specification.DataAccess.Repositories.Base;

namespace Specification.DataAccess.Repositories;

public class TmsDepRepositories(SpecificationDataBaseContext dbContext)
    : BaseRepositories(dbContext),
        IHandbookRepository<TmsDep>, ITmsRepository
{
    /// <summary>
    /// Ассинхронный запрос в БД на получение данных от ОТМС о заполнении спецификации
    /// </summary>
    /// <returns>Список данных ОТМС</returns>
    public async Task<List<TmsDep>> Get()
    {
        List<TmsDepartmentEntity> tmsDepEntity = await DataBaseContext
            .TmsDepartment.AsNoTracking()
            .Include(i => i.Contractor)
            .ToListAsync();
        List<TmsDep> tmsDepParts = tmsDepEntity
            .Select(s =>
                TmsDep
                    .Create(
                        id: s.TmsDepId,
                        // isRd: s.IsReady,
                        name: s.NameBrandForPurchase,
                        count: s.Count,
                       // dodc: s.DodContract,
                        dodp: s.DodPlan,
                        dodf: s.DodFact,
                        pnt: s.PriceNoTax,
                        pwt: s.PriceWithTax,
                        amt: s.Amount,
                        an: s.AccountNumber,
                        dta: s.DateAccount,
                        //fp: s.FirstPay,
                        //dtfp: s.DateFirstPay,
                        //sp: s.SecondPay,
                        //dtsp: s.DateSecondPay,
                        //tp: s.ThirdPay,
                        //dttp: s.DateThirdPay,
                        //pb: s.PaymentBalance,
                        //cor: s.CostOfRefand,
                        comment: s.Comment,
                        chpDeviceId: s.DeviceChapterId,
                        contId: s.ContractorId,
                        empRespId: s.EmployerResponsibleId
                    )
                    .otms
            )
            .ToList();
        return tmsDepParts;
    }

    /// <summary>
    /// Ассинхронный запрос в БД на добавление данных от ОТМС в спецификацию
    /// </summary>
    /// <param name="model">Заполененая модель данных</param>
    public async Task Add(TmsDep model)
    {
        TmsDepartmentEntity tmsDepartmentEntity = new TmsDepartmentEntity
        {
            // IsReady = model.IsReady,
            NameBrandForPurchase = model.NameBrandForPurchase,
            //DodContract = model.DodContract,
            Count =  model.Count,
            DodPlan = model.DodPlan,
            DodFact = model.DodFact,
            PriceNoTax = model.PriceNoTax,
            PriceWithTax = model.PriceWithTax,
            Amount = model.Amount,
            AccountNumber = model.AccountNumber,
            DateAccount = model.DateAccount,
           // FirstPay = 0,
           // DateFirstPay = DateTime.Now,
            //SecondPay = 0,
           // DateSecondPay = DateTime.Now,
            //ThirdPay = 0,
           // DateThirdPay = DateTime.Now,
            //PaymentBalance = 0,
            //CostOfRefand = 0,
            Comment = model.Comment,
            DeviceChapterId = model.ChapDeviceId,
            EmployerResponsibleId = model.EmpRespId,
            ContractorId = model.ContId
        };

        await DataBaseContext.AddAsync(tmsDepartmentEntity);
        await DataBaseContext.SaveChangesAsync();
    }

    /// <summary>
    /// Ассинхронный запрос в БД на обновление данных спецификации от ОТМС
    /// </summary>
    /// <param name="id">Индификатор записи</param>
    /// <param name="model">Заполененая модель с обновленными данными</param>
    public async Task Update(int id, TmsDep model)
    {
        await DataBaseContext
            .TmsDepartment.Where(f => f.TmsDepId == id)
            .ExecuteUpdateAsync(e =>
                e
                // .SetProperty(s => s.IsReady, model.IsReady)
                .SetProperty(s => s.NameBrandForPurchase, model.NameBrandForPurchase)
                   // .SetProperty(s => s.DodContract, model.DodContract)
                    .SetProperty(s=>s.Count, model.Count)
                    .SetProperty(s => s.DodPlan, model.DodPlan)
                    .SetProperty(s => s.DodFact, model.DodFact)
                    .SetProperty(s => s.PriceNoTax, model.PriceNoTax)
                    .SetProperty(s => s.PriceWithTax, model.PriceWithTax)
                    .SetProperty(s => s.Amount, model.Amount)
                    .SetProperty(s => s.AccountNumber, model.AccountNumber)
                    .SetProperty(s => s.DateAccount, model.DateAccount)
                    //.SetProperty(s => s.FirstPay, model.FirstPay)
                    //.SetProperty(s => s.DateFirstPay, model.DateFirstPay)
                    //.SetProperty(s => s.SecondPay, model.SecondPay)
                    //.SetProperty(s => s.DateSecondPay, model.DateSecondPay)
                    //.SetProperty(s => s.ThirdPay, model.ThirdPay)
                    //.SetProperty(s => s.DateThirdPay, model.DateThirdPay)
                    //.SetProperty(s => s.PaymentBalance, model.PaymentBalance)
                    //.SetProperty(s => s.CostOfRefand, model.CostOfRefand)
                    .SetProperty(s => s.Comment, model.Comment)
                    .SetProperty(s => s.DeviceChapterId, model.ChapDeviceId)
                    .SetProperty(s => s.ContractorId, model.ContId)
                    .SetProperty(s=>s.EmployerResponsibleId, model.EmpRespId)
            );
    }

    public async Task UpdateGenField(int id, TmsDep model)
    {
        await DataBaseContext.TmsDepartment.Where(f => f.TmsDepId == id)
            .ExecuteUpdateAsync(e => e
            .SetProperty(s => s.DodPlan, model.DodPlan)
            .SetProperty(s=>s.DodFact, model.DodFact)
            .SetProperty(s => s.ContractorId, model.ContId)
            .SetProperty(s => s.EmployerResponsibleId, model.EmpRespId));
    }

    /// <summary>
    /// Ассинхронный запрос в БД на удаление данных от ОТМС по спецификации
    /// </summary>
    /// <param name="id">Индификатор записи</param>
    public async Task Delete(int id) =>
        await DataBaseContext.TmsDepartment.Where(f => f.TmsDepId == id).ExecuteDeleteAsync();
}
