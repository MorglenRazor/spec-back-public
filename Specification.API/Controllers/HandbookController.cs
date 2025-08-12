using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Specification.API.Contracts.ContractorContract;
using Specification.API.Contracts.HandbookContract;
using Specification.Core.Abstractions.Service;
using Specification.Core.Models;

namespace Specification.API.Controllers;

[ApiController]
[Route("[controller]")]
public class HandbookController : Controller
{
    //DI для зависимости с UnitOfMeasure
    private readonly IHandbookService<UnitOfMeasure> _uomService;
    private readonly IUomService _uomServiceSingle;

    //DI для зависимости с Customers
    private readonly IHandbookService<Customer> _cusService;

    //DI для зависимости с Contractor
    private readonly IHandbookService<Contractor> _contService;

    public HandbookController(
        IHandbookService<UnitOfMeasure> uomService,
        IHandbookService<Customer> cusService,
        IHandbookService<Contractor> contService,
        IUomService uomServiceSingle
    )
    {
        _uomService = uomService;
        _cusService = cusService;
        _contService = contService;
        _uomServiceSingle = uomServiceSingle;   
    }

    /// <summary>
    /// Http запрос на получения списка ед.измерерий
    /// </summary>
    /// <returns>Список ед.измерерий</returns>
    [HttpGet("/uom")]
    [Authorize(Roles = "Developer,User")]
    public async Task<ActionResult<List<UomResponse>>> GetUom()
    {
        List<UnitOfMeasure> uoms = await _uomService.Get();
        List<UomResponse> responses = uoms.Select(s => new UomResponse(
                Id: s.Id,
                Name: s.Name,
                ShortName: s.ShortName
            ))
            .ToList();
        return Ok(responses);
    }

    /// <summary>
    /// Http запрос на получения списка ед.измерерий
    /// </summary>
    /// <returns>Список ед.измерерий</returns>
    [HttpGet("/uom/{id:int}")]
    [Authorize(Roles = "Developer,User")]
    public async Task<ActionResult<UomResponse>> GetUom(int id)
    {
        UnitOfMeasure uom = await _uomServiceSingle.Get(id);
        UomResponse response = new UomResponse(uom.Id, uom.Name, uom.ShortName);
        return Ok(response);
    }

    /// <summary>
    /// Http запрос на получения списка Заказчиков
    /// </summary>
    /// <returns>Список Заказчиков</returns>
    [HttpGet("/customers")]
    [Authorize(Roles = "Developer,User")]
    public async Task<ActionResult<List<HandbookResponse>>> GetCustomer()
    {
        List<Customer> cus = await _cusService.Get();
        List<HandbookResponse> responses = cus.Select(s => new HandbookResponse(
                Id: s.Id,
                StrVar: s.Name
            ))
            .ToList();
        return Ok(responses);
    }

    /// <summary>
    /// Http запрос на получения списка Подрядчиков
    /// </summary>
    /// <returns>Список Подрядчиков</returns>
    [HttpGet("/contractor")]
    [Authorize(Roles = "Developer,User")]
    public async Task<ActionResult<List<ContractorResponse>>> GetContractor()
    {
        List<Contractor> cont = await _contService.Get();
        List<ContractorResponse> responses = cont.Select(s => new ContractorResponse(
                Id: s.ContractorId,
                Name: s.ContractorName,
                Inn: s.Inn
            ))
            .ToList();
        return Ok(responses);
    }

    /// <summary>
    /// Http запрос на Добавление новой ед.изм в список
    /// </summary>
    /// <param name="request">Данные с клиента</param>
    /// <returns>Ответ сервера(100,200,300,400,500)</returns>
    [HttpPost("/add/uom")]
    [Authorize(Roles = "Developer,Admin")]
    public async Task<ActionResult> AddUom([FromBody] UomRequest request)
    {
        var (uom, err) = UnitOfMeasure.Create(
            id: 0,
            name: request.Name,
            shortName: request.ShortName,
            isVisible: true
        );
        await _uomService.Add(uom);
        return Ok();
    }

    /// <summary>
    /// Http запрос на Добавление нового Исполнителя в список
    /// </summary>
    /// <param name="request">Данные с клиента</param>
    /// <returns>Ответ сервера(100,200,300,400,500)</returns>
    [HttpPost("/add/customer")]
    [Authorize(Roles = "Developer,Admin")]
    public async Task<ActionResult> AddCustomer([FromBody] HandbookRequest request)
    {
        var (cus, err) = Customer.Create(id: 0, name: request.StrVar, isVisible: true);
        await _cusService.Add(cus);
        return Ok();
    }

    /// <summary>
    /// Http запрос на Добавление нового Подрядчика в список
    /// </summary>
    /// <param name="request">Данные с клиента</param>
    /// <returns>Ответ сервера(100,200,300,400,500)</returns>
    [HttpPost("/add/contractor")]
    [Authorize(Roles = "Developer,Admin,EmployeeMTS")]
    public async Task<ActionResult> AddContractor([FromBody] ContractorRequest request)
    {
        var (cont, err) = Contractor.Create(id: 0, contractorName: request.Name, inn: request.Inn, isVisible: true);
        await _contService.Add(cont);
        return Ok();
    }

    /// <summary>
    /// Http запрос на Обновление существующей ед.изм
    /// </summary>
    /// <param name="id">Индификатор обновляемой записи</param>
    /// <param name="request">Данные с клиенета</param>
    /// <returns>Ответ сервера(100,200,300,400,500)</returns>
    [HttpPut("/uom/{id:int}")]
    [Authorize(Roles = "Developer,Admin")]
    public async Task<ActionResult> UpdateUom(int id, [FromBody] UomRequest request)
    {
        var (uom, err) = UnitOfMeasure.Create(
            id: id,
            name: request.Name,
            shortName: request.ShortName,
            isVisible: true
        );
        await _uomService.Update(id, uom);
        return Ok();
    }

    /// <summary>
    /// Http запрос на Обновление существующего Исполнителя
    /// </summary>
    /// <param name="id">Индификатор обновляемой записи</param>
    /// <param name="request">Данные с клиенета</param>
    /// <returns>Ответ сервера(100,200,300,400,500)</returns>
    [HttpPut("/customer/{id:int}")]
    [Authorize(Roles = "Developer,Admin")]
    public async Task<ActionResult> UpdateCustomer(int id, [FromBody] HandbookRequest request)
    {
        var (cus, err) = Customer.Create(id: id, name: request.StrVar, isVisible: true);
        await _cusService.Update(id, cus);
        return Ok();
    }

    /// <summary>
    /// Http запрос на Обновление существующего Подрядчика
    /// </summary>
    /// <param name="id">Индификатор обновляемой записи</param>
    /// <param name="request">Данные с клиенета</param>
    /// <returns>Ответ сервера(100,200,300,400,500)</returns>
    [HttpPut("/contractor/{id:int}")]
    [Authorize(Roles = "Developer,Admin")]
    public async Task<ActionResult> UpdateContractor(int id, [FromBody] ContractorRequest request)
    {
        var (cont, err) = Contractor.Create(
            id: request.Id,
            contractorName: request.Name,
            inn: request.Name
            
        , isVisible: true);
        await _contService.Update(id, cont);
        return Ok();
    }

    /// <summary>
    /// Http запрос на удаление ед.изм из списка
    /// </summary>
    /// <param name="id">Индификатор удаляемой записи</param>
    /// <returns>Ответ сервера(100,200,300,400,500)</returns>
    [HttpDelete("/uom/{id:int}")]
    [Authorize(Roles = "Developer,Admin")]
    public async Task<ActionResult> DeleteUom(int id)
    {
        await _uomService.Delete(id);
        return Ok();
    }

    /// <summary>
    /// Http запрос на удаление Исполнителя из списка
    /// </summary>
    /// <param name="id">Индификатор удаляемой записи</param>
    /// <returns>Ответ сервера(100,200,300,400,500)</returns>
    [HttpDelete("/customer/{id:int}")]
    [Authorize(Roles = "Developer,Admin")]
    public async Task<ActionResult> DeleteCustomer(int id)
    {
        await _cusService.Delete(id);
        return Ok();
    }

    /// <summary>
    /// Http запрос на удаление Подрядчика из списка
    /// </summary>
    /// <param name="id">Индификатор удаляемой записи</param>
    /// <returns>Ответ сервера(100,200,300,400,500)</returns>
    [HttpDelete("/contractor/{id:int}")]
    [Authorize(Roles = "Developer,Admin")]
    public async Task<ActionResult> DeleteContractor(int id)
    {
        await _contService.Delete(id);
        return Ok();
    }
}
