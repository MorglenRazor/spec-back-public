using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Specification.API.Contracts.DepartmentContract;
using Specification.Core.Abstractions.Service;
using Specification.Core.Abstractions.Service.Auth;
using Specification.Core.Models;

namespace Specification.API.Controllers;

[ApiController]
[Route("[controller]")]
public class DepartmentController : Controller
{
    private readonly ITableService<Department> _depService;
    private readonly IDepartmentService _depServ;
    

    public DepartmentController(
        ITableService<Department> depService, IDepartmentService depServ)
    {
        _depService = depService;
        _depServ = depServ;
    }

    /// <summary>
    /// Http запрос на получения списка Отделов
    /// </summary>
    /// <returns>Список Отделов</returns>
    [HttpGet]
    //[Authorize]
    public async Task<ActionResult<List<DepartmentResponse>>> GetDepartments()
    {
        List<Department> dep = await _depService.Get(Guid.Empty);
        List<DepartmentResponse> responses = dep.Select(s => new DepartmentResponse(
                Id: s.Id,
                Name: s.Name,
                ShortName: s.ShortName
            ))
            .ToList();
        return Ok(responses);
    }

    [HttpGet("/Department/ToShortName/")]
    public async Task<ActionResult<Guid>> GetDepToShortName(string shortName)
    {
        Guid depId = await _depServ.Get(shortName);
        return Ok(depId);
    }


    /// <summary>
    /// Http запрос на Добавление нового Отдела в список
    /// </summary>
    /// <param name="request">Данные с клиента</param>
    /// <returns>Ответ сервера(100,200,300,400,500)</returns>
    [HttpPost]
    [Authorize(Roles = "Developer,Admin")]
    public async Task<ActionResult> AddDepartments([FromBody] DepartmentRequest request)
    {
        var (dep, err) = Department.Create(
            id: Guid.NewGuid(),
            name: request.Name,
            shortName: request.ShortName
        );
        await _depService.Add(dep);
        return Ok();
    }
    /// <summary>
    /// Http запрос на Обновление существующего Отдела
    /// </summary>
    /// <param name="id">Индификатор обновляемой записи</param>
    /// <param name="request">Данные с клиенета</param>
    /// <returns>Ответ сервера(100,200,300,400,500)</returns>
    [HttpPut("{id:guid}")]
    [Authorize(Roles = "Developer,Admin")]
    public async Task<ActionResult> UpdateDepartment(Guid id, [FromBody] DepartmentRequest request)
    {
        var (dep, err) = Department.Create(
            id: id,
            name: request.Name,
            shortName: request.ShortName
        );
        await _depService.Update(id, dep);
        return Ok();
    }

    /// <summary>
    /// Http запрос на удаление Отдела из списка
    /// </summary>
    /// <param name="id">Индификатор удаляемой записи</param>
    /// <returns>Ответ сервера(100,200,300,400,500)</returns>
    [HttpDelete("{id:guid}")]
    [Authorize(Roles = "Developer,Admin")]
    public async Task<ActionResult> DeleteDepartment(Guid id)
    {
        await _depService.Delete(id);
        return Ok();
    }
}
