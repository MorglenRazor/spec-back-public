using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Specification.API.Contracts.AccountingDepContract;
using Specification.Core.Abstractions.Service;
using Specification.Core.Models;
using Specification.Core.Utilities;

namespace Specification.API.Controllers;

[ApiController]
[Route("[controller]")]
public class AccountingDepController : Controller
{
    private readonly IHandbookService<AccountingDep> _accService;

    public AccountingDepController(IHandbookService<AccountingDep> accService)
    {
        _accService = accService;
    }

    /// <summary>
    /// Http запрос на получения списка Бухгалтерских данных
    /// </summary>
    /// <returns>Список Спецификаций</returns>
    [HttpGet]
    [Authorize(Roles = "Developer,User,EmployeeAD")]
    public async Task<ActionResult<List<AccountingDepResponse>>> GetAccountingPart()
    {
        List<AccountingDep> accountParts = await _accService.Get();
        List<AccountingDepResponse> responses = accountParts
            .Select(s => new AccountingDepResponse(
                Id: s.AccountingDepId,
                //DocIsSubmitted: s.DocIsSubmitted,
                NameBrandForUpd: s.NameBrandForUpd,
                CountFact: s.CountFact,
                PriceOnOneTax: s.PriceOnOneTax,
                AmountTax: s.AmountTax,
                Article: s.Article,
                AcompDoc: s.AcompDoc,
                DateDev: s.DateDev,
                Price: s.Price,
                Comment: s.Comment,
                UnitId: s.UnitId,
                EmpRespId: s.EmpRespId,
                ChapterDeviceId: s.ChapterDeviceId
            ))
            .ToList();
        return Ok(responses);
    }

    /// <summary>
    /// Http запрос на Добавление Бухгалтерских данных
    /// </summary>
    /// <param name="request">Данные с клиента</param>
    /// <returns>Ответ сервера(100,200,300,400,500)</returns>
    [HttpPost]
    [Authorize(Roles = "Developer,EngineerCD,EmployeeAD")]
    public async Task<ActionResult> AddAccountingPart([FromBody] AccountingDepRequest request)
    {
        var dateDev = ConvertArrDate.ArrIntToDate(request.DateDev);
        var (ap, err) = AccountingDep.Create(
            id: 0,
            //isSub: request.DocIsSubmitted,
            name: request.NameBrandForUpd,
            cf: request.CountFact,
            prcOnOneTax: request.PriceOnOneTax,
            amTax: request.AmountTax,
            arc: request.Article,
            dtDev: dateDev,
            price: request.Price,
            ad: request.AcompDoc,
            comment: request.Comment,
            unitId: request.UnitId,
            empRespId: request.EmpRespId,
            chpDeviceId: request.ChapterDeviceId
        );
        await _accService.Add(ap);
        return Ok();
    }

    /// <summary>
    /// Http запрос на Обновление Бухгалтерских данных
    /// </summary>
    /// <param name="id">Индификатор обновляемой записи</param>
    /// <param name="request">Данные с клиенета</param>
    /// <returns>Ответ сервера(100,200,300,400,500)</returns>
    [HttpPut("{id:int}")]
    [Authorize(Roles = "Developer,EmployeeAD")]
    public async Task<ActionResult> UpdateAccountingPart(
        int id,
        [FromBody] AccountingDepRequest request
    )
    {
        var dateDev = ConvertArrDate.ArrIntToDate(request.DateDev);
        var (ap, err) = AccountingDep.Create(
            id: id,
            // isSub: request.DocIsSubmitted,
            name: request.NameBrandForUpd,
            cf: request.CountFact,
            prcOnOneTax: request.PriceOnOneTax,
            amTax: request.AmountTax,
            arc: request.Article,
            dtDev: dateDev,
            price: request.Price,
            ad: request.AcompDoc,
            comment: request.Comment,
            unitId: request.UnitId,
            empRespId: request.EmpRespId,
            chpDeviceId: request.ChapterDeviceId
        );
        await _accService.Update(id, ap);
        return Ok();
    }

    /// <summary>
    /// Http запрос на удаление бухгалтерской записи
    /// </summary>
    /// <param name="id">Индификатор удаляемой записи</param>
    /// <returns>Ответ сервера(100,200,300,400,500)</returns>
    [HttpDelete("{id:int}")]
    [Authorize(Roles = "Developer,EmployeeAD")]
    public async Task<ActionResult> DeleteAccountingPart(int id)
    {
        await _accService.Delete(id);
        return Ok();
    }
}
