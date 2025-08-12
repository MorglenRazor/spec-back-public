using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Specification.API.Contracts.TmsDepContract;
using Specification.Core.Abstractions.Service;
using Specification.Core.Models;
using Specification.Core.Utilities;

namespace Specification.API.Controllers;

[ApiController]
[Route("[controller]")]
public class TmsDepController : Controller
{
    private readonly IHandbookService<TmsDep> _tmsDepService;
    private readonly ITmsService _tmsService;

    public TmsDepController(IHandbookService<TmsDep> tmsDepService, ITmsService tmsService)
    {
        _tmsDepService = tmsDepService;
        _tmsService = tmsService;
    }

    /// <summary>
    /// Http запрос на получения списка данных ОТМС
    /// </summary>
    /// <returns>Список Спецификаций</returns>
    [HttpGet]
    [Authorize(Roles = "Developer,User")]
    public async Task<ActionResult<List<TmsDepResponse>>> GetTmsDepPart()
    {
        List<TmsDep> tmsDepParts = await _tmsDepService.Get();
        List<TmsDepResponse> responses = tmsDepParts
            .Select(s => new TmsDepResponse(
                Id: s.TmsDepId,
                //  IsReady: s.IsReady,
                NameBrandForPurchase: s.NameBrandForPurchase,
                Count: s.Count,
               // DodContract: s.DodContract,
                DodPlan: s.DodPlan,
                DodFact: s.DodFact,
                PriceNoTax: s.PriceNoTax,
                PriceWithTax: s.PriceWithTax,
                Amount: s.Amount,
                AccountNumber: s.AccountNumber,
                DateAccount: s.DateAccount,
                //FirstPay: s.FirstPay,
                //DateFirstPay: s.DateFirstPay,
                //SecondPay: s.SecondPay,
                //DateSecondPay: s.DateSecondPay,
                //ThirdPay: s.ThirdPay,
                //DateThirdPay: s.DateThirdPay,
                //PaymentBalance: s.PaymentBalance,
                //CostOfRefand: s.CostOfRefand,
                Comment: s.Comment,
                ContId: s.ContId,
                DeviceChapterId: s.ChapDeviceId,
                EmpRespId: s.EmpRespId
            ))
            .ToList();

        return Ok(responses);
    }

    /// <summary>
    /// Http запрос на Добавление данных ОТМС
    /// </summary>
    /// <param name="request">Данные с клиента</param>
    /// <returns>Ответ сервера(100,200,300,400,500)</returns>
    [HttpPost]
    [Authorize(Roles = "Developer,EngineerCD,EmployeeMTS")]
    public async Task<ActionResult> AddTmsDepPart([FromBody] TmsDepRequest request)
    {
       // var dodContract = ConvertArrDate.ArrIntToDate(request.DodContract);
        var dodPlan = ConvertArrDate.ArrIntToDate(request.DodPlan);
        var dodFact = ConvertArrDate.ArrIntToDate(request.DodFact);
        var dateAccount = ConvertArrDate.ArrIntToDate(request.DateAccount);
        //var dateFirstPay = ConvertArrDate.ArrIntToDate(request.DateFirstPay);
        //var dateSecondPay = ConvertArrDate.ArrIntToDate(request.DateSecondPay);
        //var dateThirdPay = ConvertArrDate.ArrIntToDate(request.DateThirdPay);
        var (tms, err) = TmsDep.Create(
            id: 0,
            name: request.NameBrandForPurchase,
            count: request.Count,
           // dodc: dodContract,
            dodp: dodPlan,
            dodf: dodFact,
            pnt: request.PriceNoTax,
            pwt: request.PriceWithTax,
            amt: request.Amount,
            an: request.AccountNumber,
            dta: dateAccount,
            //fp: request.FirstPay,
            //dtfp: dateFirstPay,
            //sp: request.SecondPay,
            //dtsp: dateSecondPay,
            //tp: request.ThirdPay,
            //dttp: dateThirdPay,
            //pb: request.PaymentBalance,
            //cor: request.CostOfRefand,
            comment: request.Comment,
            contId: request.ContId,
            chpDeviceId: request.DeviceChapterId,
            empRespId: request.EmpRespId
        );

        await _tmsDepService.Add(tms);
        return Ok();
    }

    /// <summary>
    /// Http запрос на Обновление данных ОТМС
    /// </summary>
    /// <param name="id">Индификатор обновляемой записи</param>
    /// <param name="request">Данные с клиенета</param>
    /// <returns>Ответ сервера(100,200,300,400,500)</returns>
    [HttpPut("{id:int}")]
    [Authorize(Roles = "Developer,EmployeeMTS")]
    public async Task<ActionResult> UpdateTmsDepPart(int id, [FromBody] TmsDepRequest request)
    {
       // var dodContract = ConvertArrDate.ArrIntToDate(request.DodContract);
        var dodPlan = ConvertArrDate.ArrIntToDate(request.DodPlan);
        var dodFact = ConvertArrDate.ArrIntToDate(request.DodFact);
        var dateAccount = ConvertArrDate.ArrIntToDate(request.DateAccount);
        //var dateFirstPay = ConvertArrDate.ArrIntToDate(request.DateFirstPay);
        //var dateSecondPay = ConvertArrDate.ArrIntToDate(request.DateSecondPay);
       // var dateThirdPay = ConvertArrDate.ArrIntToDate(request.DateThirdPay);
        var (tms, err) = TmsDep.Create(
            id: id,
            //isRd:request.IsReady,
            name: request.NameBrandForPurchase,
            count: request.Count,
           // dodc: dodContract,
            dodp: dodPlan,
            dodf: dodFact,
            pnt: request.PriceNoTax,
            pwt: request.PriceWithTax,
            amt: request.Amount,
            an: request.AccountNumber,
            dta: dateAccount,
            //fp: request.FirstPay,
            //dtfp: dateFirstPay,
            //sp: request.SecondPay,
            //dtsp: dateSecondPay,
            //tp: request.ThirdPay,
            //dttp: dateThirdPay,
            //pb: request.PaymentBalance,
            //cor: request.CostOfRefand,
            comment: request.Comment,
            contId: request.ContId,
            chpDeviceId: request.DeviceChapterId,
            empRespId: request.EmpRespId
        );

        await _tmsDepService.Update(id, tms);
        return Ok();
    }
    
    [HttpPut("/TmdUpdGenField/{id:int}")]
    [Authorize(Roles = "Developer,EmployeeMTS")]
    public async Task<ActionResult> UpdateTmsGenPart(int id, [FromBody] TmsDepRequest request)
    {
        var (tms, err) = TmsDep.Create(
           id: id,
           //isRd:request.IsReady,
           name: request.NameBrandForPurchase,
           count: request.Count,
           // dodc: dodContract,
           dodp: DateTime.Now,
           dodf: DateTime.Now,
           pnt: request.PriceNoTax,
           pwt: request.PriceWithTax,
           amt: request.Amount,
           an: request.AccountNumber,
           dta: DateTime.Now,
           //fp: request.FirstPay,
           //dtfp: dateFirstPay,
           //sp: request.SecondPay,
           //dtsp: dateSecondPay,
           //tp: request.ThirdPay,
           //dttp: dateThirdPay,
           //pb: request.PaymentBalance,
           //cor: request.CostOfRefand,
           comment: request.Comment,
           contId: request.ContId,
           chpDeviceId: request.DeviceChapterId,
           empRespId: request.EmpRespId
       );
        await _tmsService.UpdateGenField(id, tms);
        return Ok();
    }

    /// <summary>
    /// Http запрос на удаление данныз спецификации
    /// </summary>
    /// <param name="id">Индификатор удаляемой записи</param>
    /// <returns>Ответ сервера(100,200,300,400,500)</returns>
    [HttpDelete("{id:int}")]
    [Authorize(Roles = "Developer,EmployeeMTS")]
    public async Task<ActionResult> DeleteTmsDepPart(int id)
    {
        await _tmsDepService.Delete(id);
        return Ok();
    }
}
