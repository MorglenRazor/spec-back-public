using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Specification.API.Contracts.WarehouseDepContract;
using Specification.Core.Abstractions.Service;
using Specification.Core.Models;
using Specification.Core.Utilities;

namespace Specification.API.Controllers;

[ApiController]
[Route("[controller]")]
public class WarehouseDepController : Controller
{
    private readonly IHandbookService<WarehouseDep> _warehouseDepService;

    public WarehouseDepController(IHandbookService<WarehouseDep> warehouseDepService)
    {
        _warehouseDepService = warehouseDepService;
    }

    /// <summary>
    /// Http запрос на получения списка данных Склада
    /// </summary>
    /// <returns>Список Спецификаций</returns>
    [HttpGet]
    [Authorize(Roles = "Developer,User")]
    public async Task<ActionResult<List<WarehouseDepResponse>>> GetWarehousePart()
    {
        List<WarehouseDep> warehouseDepParts = await _warehouseDepService.Get();
        List<WarehouseDepResponse> responses = warehouseDepParts
            .Select(s => new WarehouseDepResponse(
                Id: s.WarehouseDepId,
                // ExistOnStorage: s.ExistOnStorage,
                CountOnStorage: s.CountOnStorage,
                CountAfterPurchase: s.CountAfterPurchase,
                RemainsCountAfterPurchase: s.RemainsCountAfterPurchase,
                //SerialNumber: s.SerialNumber,
                //WriteOfDoc: s.WriteOfDoc,
                //WriteOfDate: s.WriteOfDate,
                //AcceptSets: s.AcceptSets,
                Comment: s.Comment,
                GenUnitId: s.GenUnitId,
                RemainsUnitId: s.RemainsUnitId,
                DeviceChapterId: s.ChapterDeviceId,
                EmpRespId: s.EmpRespId
            ))
            .ToList();
        return Ok(responses);
    }

    /// <summary>
    /// Http запрос на Добавление данных Склада
    /// </summary>
    /// <param name="request">Данные с клиента</param>
    /// <returns>Ответ сервера(100,200,300,400,500)</returns>
    [HttpPost]
    [Authorize(Roles = "Developer,EngineerCD,EmployeeWD")]
    public async Task<ActionResult> AddWarehouseDepPart([FromBody] WarehouseDepRequest request)
    {
        //var writeOfDate = ConvertArrDate.ArrIntToDate(request.WriteOfDate);
        var (sp, err) = WarehouseDep.Create(
            id: 0,
            cos: request.CountOnStorage,
            cap: request.CountAfterPurchase,
            rCap: request.RemainsCountAfterPurchase,
            //sNum: request.SerialNumber,
            //wod: request.WriteOfDoc,
            //wodt: writeOfDate,
            //acs: request.AcceptSets,
            comment: request.Comment,
            getUnitId: request.GenUnitId,
            dopUnitId: request.RemainsUnitId,
            chpDeviceId: request.DeviceChapterId,
            empRespId: request.EmpRespId
        );
        await _warehouseDepService.Add(sp);
        return Ok();
    }

    /// <summary>
    /// Http запрос на Обновление данных Склада
    /// </summary>
    /// <param name="id">Индификатор обновляемой записи</param>
    /// <param name="request">Данные с клиенета</param>
    /// <returns>Ответ сервера(100,200,300,400,500)</returns>
    [HttpPut("{id:int}")]
    [Authorize(Roles = "Developer,EmployeeWD")]
    public async Task<ActionResult> UpdateWarehouseDepPart(
        int id,
        [FromBody] WarehouseDepRequest request
    )
    {
        //var writeOfDate = ConvertArrDate.ArrIntToDate(request.WriteOfDate);
        var (sp, err) = WarehouseDep.Create(
            id: id,
            cos: request.CountOnStorage,
            cap: request.CountAfterPurchase,
            rCap: request.RemainsCountAfterPurchase,
            //sNum: request.SerialNumber,
            //wod: request.WriteOfDoc,
            //wodt: writeOfDate,
            //acs: request.AcceptSets,
            comment: request.Comment,
            getUnitId: request.GenUnitId,
            dopUnitId: request.RemainsUnitId,
            chpDeviceId: request.DeviceChapterId,
            empRespId: request.EmpRespId
        );
        await _warehouseDepService.Update(id, sp);
        return Ok();
    }

    /// <summary>
    /// Http запрос на удаление данных склада
    /// </summary>
    /// <param name="id">Индификатор удаляемой записи</param>
    /// <returns>Ответ сервера(100,200,300,400,500)</returns>
    [HttpDelete("{id:int}")]
    [Authorize(Roles = "Developer,EmployeeWD")]
    public async Task<ActionResult> DeleteWarehouseDepPart(int id)
    {
        await _warehouseDepService.Delete(id);
        return Ok();
    }
}
