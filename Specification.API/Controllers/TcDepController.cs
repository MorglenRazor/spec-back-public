using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Specification.API.Contracts.TcDepContract;
using Specification.Core.Abstractions.Service;
using Specification.Core.Models;

namespace Specification.API.Controllers;

[ApiController]
[Route("[controller]")]
public class TcDepController : Controller
{
    private readonly IHandbookService<TcDep> _tcDepService;

    public TcDepController(IHandbookService<TcDep> tcDepService)
    {
        _tcDepService = tcDepService;
    }

    /// <summary>
    /// Http запрос на получения списка данных ОТМС
    /// </summary>
    /// <returns>Список Спецификаций</returns>
    [HttpGet]
    [Authorize(Roles = "Developer,User")]
    public async Task<ActionResult<List<TcDepResponse>>> GetTcDepPart()
    {
        List<TcDep> tcDepParts = await _tcDepService.Get();
        List<TcDepResponse> responses = tcDepParts
            .Select(s => new TcDepResponse(
                Id: s.TcDepId,
                NameBrandInDoc: s.NameBrandInDoc,
                Count: s.Count,
              //  SerialNum: s.SerialNum,
                CompKit: s.CompKit,
                CompTechDocAvailable: s.CompTechDocAvailable,
                CompTechDocMissing: s.CompTechDocMissing,
                Defects: s.Defects,
                Conclusion: s.Conclusion,
                Comment: s.Comment,
                UnitId: s.UnitId,
                EmpRespId: s.EmpRespId,
                DeviceChapterId: s.ChapterDeviceId
            ))
            .ToList();

        return Ok(responses);
    }

    /// <summary>
    /// Http запрос на Добавление данных ОТК
    /// </summary>
    /// <param name="request">Данные с клиента</param>
    /// <returns>Ответ сервера(100,200,300,400,500)</returns>
    [HttpPost]
    [Authorize(Roles = "Developer,EngineerCD,ControllerTCD")]
    public async Task<ActionResult> AddTcDepPart([FromBody] TcDepRequest request)
    {
        var (tcDep, err) = TcDep.Create(
            id: 0,
            //  status: request.Status,
            name: request.NameBrandInDoc,
            count: request.Count,
            //sNum: request.SerialNum,
            cKit: request.CompKit,
            ctda: request.CompTechDocAvailable,
            ctdm: request.CompTechDocMissing,
            defects: request.Defects,
            conc: request.Conclusion,
            comment: request.Comment,
            unitId: request.UnitId,
            empRespId: request.EmpRespId,
            chapDeviceId: request.DeviceChapterId
        );

        await _tcDepService.Add(tcDep);
        return Ok();
    }

    /// <summary>
    /// Http запрос на Обновление данных ОТК
    /// </summary>
    /// <param name="id">Индификатор обновляемой записи</param>
    /// <param name="request">Данные с клиенета</param>
    /// <returns>Ответ сервера(100,200,300,400,500)</returns>
    [HttpPut("{id:int}")]
    [Authorize(Roles = "Developer,ControllerTCD")]
    public async Task<ActionResult> UpdateTcDepPart(int id, [FromBody] TcDepRequest request)
    {
        var (tcDep, err) = TcDep.Create(
            id: id,
            // status: request.Status,
            name: request.NameBrandInDoc,
            count: request.Count,
           // sNum: request.SerialNum,
            cKit: request.CompKit,
            ctda: request.CompTechDocAvailable,
            ctdm: request.CompTechDocMissing,
            defects: request.Defects,
            conc: request.Conclusion,
            comment: request.Comment,
            unitId: request.UnitId,
            empRespId: request.EmpRespId,
            chapDeviceId: request.DeviceChapterId
        );
        await _tcDepService.Update(id, tcDep);
        return Ok();
    }

    /// <summary>
    /// Http запрос на удаление данных ОТК
    /// </summary>
    /// <param name="id">Индификатор удаляемой записи</param>
    /// <returns>Ответ сервера(100,200,300,400,500)</returns>
    [HttpDelete("{id:int}")]
    [Authorize(Roles = "Developer,ControllerTCD")]
    public async Task<ActionResult> DeleteTcDepPart(int id)
    {
        await _tcDepService.Delete(id);
        return Ok();
    }
}
