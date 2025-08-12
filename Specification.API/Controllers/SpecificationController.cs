using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Specification.API.Contracts.SpecificationContract;
using Specification.Core.Abstractions.Service;
using Specification.Core.Abstractions.Service.Auth;
using Specification.Infrastructure;

namespace Specification.API.Controllers;

[ApiController]
[Route("[controller]")]
public class SpecificationController : Controller
{
    private readonly ITableService<Core.Models.Specification> _specService;

    private readonly ISpecificationService _specServiceResp;

    private CheckAccess _checkAccess;
    public SpecificationController(
        ITableService<Core.Models.Specification> specService,
        ISpecificationService specServiceResp,
        IUserService _userService
    )
    {
        _specService = specService;
        _specServiceResp = specServiceResp;
        _checkAccess = new CheckAccess(_userService);
    }

    /// <summary>
    /// Http запрос на получения данных списка Спецификаций
    /// </summary>
    /// <returns>Список Спецификаций</returns>
    [HttpGet]
    [Authorize(Roles = "Developer,EngineerCD,User")]
    public async Task<ActionResult<List<SpecificationResponse>>> GetSpecifications()
    {
        List<Core.Models.Specification> specifications = await _specService.Get(Guid.Empty);
        List<SpecificationResponse> responses = specifications
            .Select(s => new SpecificationResponse(
                s.SpecificationId,
                s.NumWork,
                s.NumTask,
                s.Name,
                s.TotalUncoverPos,
                s.Readiness,
                s.CustomerSpecId,
                s.CustomerName
            ))
            .ToList();

        return Ok(responses);
    }

    /// <summary>
    /// Http запрос на Добавление пустой спецификации
    /// </summary>
    /// <param name="request">Данные с клиента</param>
    /// <returns>Ответ сервера(100,200,300,400,500)</returns>
    [HttpPost]
    [Authorize(Roles = "Developer,EngineerCD")]
    public async Task<ActionResult<Guid>> AddSpecification([FromBody] SpecificationRequest request)
    {
        
        var newGuid = Guid.NewGuid();
        var (spec, err) = Core.Models.Specification.Create(
            id: newGuid,
            numWork: request.NumWork,
            numTask: request.NumTask,
            name: request.Name,
            totalUncoverPos: request.TotalUncoverPos,
            readiness: request.Readiness,
            cusId: request.CusId
        );
        bool isAccess = await _checkAccess.IsAdmin(request.UserId);
        if (isAccess)
        {
            await _specService.Add(spec);
            return Ok(newGuid);
        }
        return StatusCode(403);
        
    }


    /// <summary>
    /// Http запрос на удаление спецификации
    /// </summary>
    /// <param name="id">Индификатор удаляемой записи</param>
    /// <returns>Ответ сервера(100,200,300,400,500)</returns>
    [HttpDelete("{id:guid}")]
    [Authorize(Roles = "Developer,EngineerCD")]
    public async Task<ActionResult> DeleteSpecification(Guid id)
    {
        await _specService.Delete(id);
        return Ok();
    }

    /// <summary>
    /// Http запрос на удаление спецификации
    /// </summary>
    /// <param name="id">Индификатор удаляемой записи</param>
    /// <returns>Ответ сервера(100,200,300,400,500)</returns>
    [HttpDelete("/Specification/ResponsibleDeletedSpec/{id:guid}&{empId:guid}")]
    [Authorize(Roles = "Developer,EngineerCD")]
    public async Task<ActionResult> DeleteSpecificationResponsible(Guid id, Guid empId)
    {
        var isAccess = true;
        if (isAccess)
        {
            await _specService.Delete(id);
            return Ok();
        }
        return StatusCode(403);
    }

    [HttpPut("/Specification/Update/{id:guid}")]
    [Authorize(Roles = "Developer,EngineerCD")]
    public async Task<ActionResult> UpdateSpecification(Guid id, SpecificationRequest request)
    {
        var specUpd = Specification.Core.Models.Specification.Create(id, request.NumWork, request.NumTask, request.Name, request.TotalUncoverPos, request.Readiness, request.CusId).Spec;
        await _specService.Update(id,specUpd);
        return Ok();
    }

}
