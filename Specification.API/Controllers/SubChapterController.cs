using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Specification.API.Contracts.ChapterContract;
using Specification.API.Contracts.ChapterDeviceContract;
using Specification.API.Contracts.SubChapterContract;
using Specification.Core.Abstractions.Service;
using Specification.Core.Models;

namespace Specification.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SubChapterController : Controller
    {
        private readonly ITableService<SubChapter> _service;
        private readonly ISubChapterService _serviceSubChap;

        public SubChapterController(
            ITableService<SubChapter> service,
            ISubChapterService serviceSubChap
        )
        {
            _service = service;
            _serviceSubChap = serviceSubChap;
        }

        [HttpGet]
        [Authorize(Roles = "Developer,User")]
        public async Task<ActionResult<List<SubChapterResponse>>> GetSubChapter()
        {
            List<SubChapter> subChapters = await _service.Get(Guid.Empty);
            List<SubChapterResponse> responses = subChapters
                .Select(s => new SubChapterResponse(
                    s.SubChapId,
                    s.CategoryDeviceId,
                    s.ChapterId
                ))
                .ToList();
            return Ok(responses);
        }

        ///// <summary>
        ///// Http запрос на Добавление пустого раздела
        ///// </summary>
        ///// <param name="request">Данные с клиента</param>
        ///// <returns>Ответ сервера(100,200,300,400,500)</returns>
        //[HttpPost("/AddSubChap")]
        //[Authorize(Roles = "Developer,EngineerCD")]
        //public async Task<ActionResult<ChapterCopyResponse>> AddChapterWithSubChapter([FromBody] CopySubChapRequest request)
        //{
        //    Guid newGuid = Guid.NewGuid();
        //    Guid newSubChapGuid = Guid.NewGuid();
        //    foreach (var item in request.SubChapterRequests)
        //    {
        //        var subChap = SubChapter.Create(sChId: newSubChapGuid,
        //            CdId: item.CategoryDeviceId,
        //            chId: item.ChapterId);
        //        await _service.Add(subChap.sch);
        //    }
        //    ChapterCopyResponse ret = new ChapterCopyResponse(request.OldChapGuid, newGuid, newSubChapGuid);
        //    return Ok(ret);
        //}

        [HttpGet("Details")]
        [Authorize(Roles = "Developer,User")]
        public async Task<ActionResult<List<SubChapterResponseDetail>>> GetSubChapterDetails()
        {
            List<SubChapter> subChapters = await _serviceSubChap.GetSubChapterDetail();
            List<SubChapterResponseDetail> responses = subChapters
                .Select(s => new SubChapterResponseDetail(
                    s.SubChapId,
                    s.CategoryDeviceId,
                    s.CategoryName,
                    s.ChapterId
                ))
                .ToList();
            return Ok(responses);
        }

        [HttpPost("Profile")]
        [Authorize(Roles = "Developer,User")]
        public async Task<ActionResult<List<SubChapterResponseDetail>>> GetSubChapterProfile([FromBody] Guid[] statusIds)
        {
            List<SubChapter> subChapters = await _serviceSubChap.GetSubChapterProfile(statusIds.ToList());
            List<SubChapterResponseProfile> responses = subChapters
                .Select(s => new SubChapterResponseProfile(
                    SubChapId: s.SubChapId,
                    CategoryDeviceId: s.CategoryDeviceId,
                    CountDevice: s.CountDevice,
                    NameCategory: s.CategoryName,
                    CatChapName: s.CategoryChapName,
                    SpecId: s.SpecId,
                    ChapterId: s.ChapterId,
                    SpecName: s.SpecName,
                    DevChapProf: s.Devices.Select(ss=> new ChapterDeviceProfileResponse(
                            ss.DeviceChapterId,
                            ss.SubChapterId,
                            ss.StatusId,
                            ss.DeviceName,
                            ss.BrandName,
                            ss.StatusName
                        )).ToList()
                ))
                .ToList();
            return Ok(responses);
        }

        [HttpPost]
        [Authorize(Roles = "Developer,EngineerCD")]
        public async Task<ActionResult<Guid>> AddSubChapter([FromBody] SubChapterRequest request)
        {
            Guid newGuid = Guid.NewGuid();
            var (subChapter, err) = SubChapter.Create(
                sChId: newGuid,
                CdId: request.CategoryDeviceId,
                chId: request.ChapterId
            );
            await _service.Add(subChapter);
            return Ok(newGuid);
        }

        [HttpPut("{id:guid}")]
        [Authorize(Roles = "Developer,EngineerCD")]
        public async Task<ActionResult> UpdateSubChapter(
            Guid id,
            [FromBody] SubChapterRequest request
        )
        {
            var (subChapter, err) = SubChapter.Create(
                sChId: id,
                CdId: request.CategoryDeviceId,
                chId: request.ChapterId
            );
            await _service.Update(id, subChapter);
            return Ok();
        }

        [HttpDelete("{id:guid}")]
        [Authorize(Roles = "Developer,EngineerCD")]
        public async Task<ActionResult> DeleteSubChapter(Guid id)
        {
            await _service.Delete(id);
            return Ok();
        }
    }
}
