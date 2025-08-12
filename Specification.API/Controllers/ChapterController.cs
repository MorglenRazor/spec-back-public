using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Specification.API.Contracts.ChapterContract;
using Specification.API.Contracts.SubChapterContract;
using Specification.Core.Abstractions.Service;
using Specification.Core.Models;

namespace Specification.API.Controllers;

[ApiController]
[Route("[controller]")]
public class ChapterController : Controller
{
    private readonly ITableService<Chapter> _chapService;

    private readonly IChapterService _chapterDetailService;

    public ChapterController(
        ITableService<Chapter> chapService,
        IChapterService chapterDetailService
    )
    {
        _chapService = chapService;
        _chapterDetailService = chapterDetailService;
    }

    /// <summary>
    /// Http запрос на получения данных списка Раздела
    /// </summary>
    /// <returns>Список разделов</returns>
    [HttpGet]
    [Authorize(Roles = "Developer,User")]
    public async Task<ActionResult<List<ChapterResponse>>> GetChapters()
    {
        List<Chapter> chapters = await _chapService.Get(Guid.Empty);
        List<ChapterResponse> responses = chapters
            .Select(s => new ChapterResponse(
                s.ChapterId,
                s.ChapterName,
                s.Readiness,
                s.CostChapter,
                s.Comment,
                s.SpecificationId
            ))
            .ToList();

        return Ok(responses);
    }

    [HttpGet("/GetChapterToCopy/{specId:guid}")]
    [Authorize(Roles = "Developer,EngineerCD")]
    public async Task<ActionResult<List<ChapterResponse>>> GetChapterSpec(Guid specId)
    {
        List<Chapter> chapters = await _chapterDetailService.GetFromChapSpecId(specId);
        List<ChapterToCopyResponse> responses = chapters
            .Select(s => new ChapterToCopyResponse(
                s.ChapterId,
                s.CategoryChapterId,
                s.ChapterName,
                s.Readiness,
                s.CostChapter,
                s.Comment,
                SubChapters: s.SubChapters.Select(ss=> new SubChapterResponse(ss.SubChapId, ss.CategoryDeviceId, ss.ChapterId)).ToList()
            ))
            .ToList();

        return Ok(responses);
    }


    [HttpGet("/Chapter/SpecIds/")]
    [Authorize(Roles = "Developer,EngineerCD")]
    public async Task<ActionResult<List<ChapterResponse>>> GetChapterSpec()
    {
        List<Chapter> chapters = await _chapterDetailService.GetFromChapSpecIds();
        List<ChapterSpecResponse> responses = chapters
            .Select(s => new ChapterSpecResponse(
                s.ChapterId,
                s.SpecificationId,
                s.ChapterName,
                s.SpecName,
                s.CountDevice
            ))
            .ToList();

        return Ok(responses);
    }

    [HttpGet("/chapter/details")]
    [Authorize(Roles = "Developer,User")]
    public async Task<ActionResult<List<ChapterDetailResponse>>> GetChapterDetail()
    {
        List<Chapter> chapters = await _chapterDetailService.GetChapterDetail();
        List<ChapterDetailResponse> responses = chapters
            .Select(s => new ChapterDetailResponse(
                s.ChapterId,
                s.ChapterName,
                s.Readiness,
                s.CostChapter,
                s.Comment,
                s.CategoryChapterId
            ))
            .ToList();

        return Ok(responses);
    }

    [HttpGet("/{specId:guid}/chapter/details")]
    [Authorize(Roles = "Developer,User")]
    public async Task<ActionResult<List<ChapterDetailResponse>>> GetChapterDetail(Guid specId)
    {
        List<Chapter> chapters = await _chapterDetailService.GetChapterDetail(specId);
        List<ChapterDetailResponse> responses = chapters
            .Select(s => new ChapterDetailResponse(
                s.ChapterId,
                s.ChapterName,
                s.Readiness,
                s.CostChapter,
                s.Comment,
                s.CategoryChapterId
            ))
            .ToList();

        return Ok(responses);
    }

    /// <summary>
    /// Http запрос на Добавление пустого раздела
    /// </summary>
    /// <param name="request">Данные с клиента</param>
    /// <returns>Ответ сервера(100,200,300,400,500)</returns>
    [HttpPost]
    [Authorize(Roles = "Developer,EngineerCD")]
    public async Task<ActionResult<Guid>> AddChapter([FromBody] ChapterRequest request)
    {
        Guid newGuid = Guid.NewGuid();
        var (chapter, err) = Chapter.Create(
            id: newGuid,
           // chapterName: request.ChapterName,
            rd: request.Readiness,
            costChap: request.CostChapter,
            com: request.Comment,
            specId: request.SpecId
        );

        await _chapService.Add(chapter);
        return Ok(newGuid);
    }

  

    /// <summary>
    /// Http запрос на Обновление общей информации о разделе
    /// </summary>
    /// <param name="id"></param>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPut("{id:guid}")]
    [Authorize(Roles = "Developer,EngineerCD")]
    public async Task<ActionResult> UpdateChapter(Guid id, [FromBody] ChapterRequest request)
    {
        Guid newGuid = Guid.NewGuid();
        var (chapter, err) = Chapter.Create(
            id: id,
           //chapterName: request.ChapterName,
            rd: request.Readiness,
            costChap: request.CostChapter,
            specId: request.SpecId,
            com: request.Comment
        );
        await _chapService.Update(id, chapter);
        return Ok();
    }

    [HttpDelete("{id:guid}")]
    [Authorize(Roles = "Developer,EngineerCD")]
    public async Task<ActionResult> DeleteChapter(Guid id)
    {
        await _chapService.Delete(id);
        return Ok();
    }
}
