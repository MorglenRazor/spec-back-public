using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Specification.API.Contracts.ConstructionDepContract;
using Specification.Core.Abstractions.Service;
using Specification.Core.Models;
using Specification.Core.Utilities;

namespace Specification.API.Controllers;

[ApiController]
[Route("[controller]")]
public class ConstructionDepController : Controller
{
    private readonly IHandbookService<ConstructionDep> _designService;

    public ConstructionDepController(IHandbookService<ConstructionDep> designService)
    {
        _designService = designService;
    }

    /// <summary>
    /// Http запрос на получения списка данных КО
    /// </summary>
    /// <returns>Список Спецификаций</returns>
    [HttpGet]
    [Authorize(Roles = "Developer,User,EngineerCD")]
    public async Task<ActionResult<List<ConstructionDepResponse>>> GetDesignPart()
    {
        List<ConstructionDep> constructionParts = await _designService.Get();
        List<ConstructionDepResponse> responses = constructionParts
            .Select(s => new ConstructionDepResponse(
                Id: s.ConstructionDepId,
              //  CountDevice: s.CountDevice,
                Comment: s.Comment,
                UnitId: s.UnitId,
                EmpRespId: s.EmpRespId,
                DeviceChapterId: s.ChapterDeviceId
            ))
            .ToList();
        return Ok(responses);
    }

    /// <summary>
    /// Http запрос на Добавление записи от КО
    /// </summary>
    /// <param name="request">Данные с клиента</param>
    /// <returns>Ответ сервера(100,200,300,400,500)</returns>
    [HttpPost]
    [Authorize(Roles = "Developer,EngineerCD")]
    public async Task<ActionResult> AddDesignPart([FromBody] ConstructionDepRequest request)
    {
        var (constDep, err) = ConstructionDep.Create(
            id: 0,
            comment: request.Comment,
            unitId: request.UnitId,
            empRespId: request.EmpRespId,
            chpDeviceId: request.DeviceChapterId
        );
        await _designService.Add(constDep);
        return Ok();
    }

    /// <summary>
    /// Http запрос на Обновление данных КО
    /// </summary>
    /// <param name="id">Индификатор обновляемой записи</param>
    /// <param name="request">Данные с клиенета</param>
    /// <returns>Ответ сервера(100,200,300,400,500)</returns>
    [HttpPut("{id:int}")]
    [Authorize(Roles = "Developer,EngineerCD")]
    public async Task<ActionResult> UpdateDesignPart(
        int id,
        [FromBody] ConstructionDepRequest request
    )
    {
        var (dp, err) = ConstructionDep.Create(
            id: id,
          //  cd: request.CountDevice,
            comment: request.Comment,
            unitId: request.UnitId,
            empRespId: request.EmpRespId,
            chpDeviceId: request.DeviceChapterId
        );
        await _designService.Update(id, dp);
        return Ok();
    }

    /// <summary>
    /// Http запрос на удаление записи КО
    /// </summary>
    /// <param name="id">Индификатор удаляемой записи</param>
    /// <returns>Ответ сервера(100,200,300,400,500)</returns>
    [HttpDelete("{id:int}")]
    [Authorize(Roles = "Developer,EngineerCD")]
    public async Task<ActionResult> DeleteDesignPart(int id)
    {
        await _designService.Delete(id);
        return Ok();
    }
}
