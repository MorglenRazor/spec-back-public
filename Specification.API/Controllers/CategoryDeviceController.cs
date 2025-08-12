using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Specification.API.Contracts.CategoryDeviceContract;
using Specification.Core.Abstractions.Service;
using Specification.Core.Models;

namespace Specification.API.Controllers;

[ApiController]
[Route("[controller]")]
public class CategoryDeviceController : Controller
{
    private readonly ITableService<CategoryDevice> _categoryDeviceService;

    public CategoryDeviceController(ITableService<CategoryDevice> categoryDeviceService)
    {
        _categoryDeviceService = categoryDeviceService;
    }

    /// <summary>
    /// Http запрос на получения списка Категорий устройств
    /// </summary>
    /// <returns>Список Спецификаций</returns>
    [HttpGet]
    [Authorize(Roles = "Developer,User")]
    public async Task<ActionResult<List<CategoryDeviceResponse>>> GetCategory()
    {
        List<CategoryDevice> categoryDevice = await _categoryDeviceService.Get(Guid.Empty);
        List<CategoryDeviceResponse> responses = categoryDevice
            .Select(s => new CategoryDeviceResponse(CaDeviceId: s.CategoryDeviceId, Name: s.Name, CategoryChapterId: s.CategoryChapterId))
            .ToList();
        return Ok(responses);
    }

    /// <summary>
    /// Http запрос на Добавление новой катогории устройства в список
    /// </summary>
    /// <param name="request">Данные с клиента</param>
    /// <returns>Ответ сервера(100,200,300,400,500)</returns>
    [HttpPost]
    [Authorize(Roles = "Developer,Admin,EngineerCD")]
    public async Task<ActionResult> AddCategoryDevice([FromBody] CategoryDeviceRequest request)
    {
        var (cd, err) = CategoryDevice.Create(id: new Guid(), name: request.Name, categoryChapterId: request.CategoryChapterId);
        await _categoryDeviceService.Add(cd);
        return Ok();
    }

    /// <summary>
    /// Http запрос на Обновление существующей категории
    /// </summary>
    /// <param name="id">Индификатор обновляемой записи</param>
    /// <param name="request">Данные с клиенета</param>
    /// <returns>Ответ сервера(100,200,300,400,500)</returns>
    [HttpPut("{id:guid}")]
    [Authorize(Roles = "Developer,Admin")]
    public async Task<ActionResult> UpdateCategoryDevice(
        Guid id,
        [FromBody] CategoryDeviceRequest request
    )
    {
        var (cd, err) = CategoryDevice.Create(id: id, name: request.Name);
        await _categoryDeviceService.Update(id, cd);
        return Ok();
    }

    [HttpDelete("{id:guid}")]
    [Authorize(Roles = "Developer,Admin,EngineerCD")]
    public async Task<ActionResult> DeleteCategory(Guid id)
    {
        await _categoryDeviceService.Delete(id);
        return Ok();
    }
}
