using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Specification.API.Contracts.Auth;
using Specification.API.Contracts.ChapterContract;
using Specification.Application.Services;
using Specification.Core.Abstractions.Service;
using Specification.Core.Models;

namespace Specification.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ResponsibleChapterController : Controller
    {
        private readonly ITableService<ResponsibleCatChapter> _serv;
        private readonly IRespCatChapterService _catService;
        public ResponsibleChapterController(ITableService<ResponsibleCatChapter> serv, IRespCatChapterService catService)
        {
            _serv = serv;
            _catService = catService;
        }

        [HttpGet]
        [Authorize(Roles = "Developer, User")]
        public async Task<ActionResult<List<RespChapterResponse>>> GetRespChapter()
        {
            List<ResponsibleCatChapter> rspChap = await _serv.Get(Guid.Empty);
            List<RespChapterResponse> responses = rspChap.Select(s => new RespChapterResponse(s.RespId, s.EmpId, s.CategoryChapterId)).ToList();
            return Ok(responses);
        }


        [HttpGet("/GetChapRespForCatId/{catId:guid}")]
        [Authorize(Roles = "Developer, User")]
        public async Task<ActionResult<List<RespChapterResponse>>> GetRespChapterForCatId(Guid catId)
        {
            List<ResponsibleCatChapter> rspChap = await _catService.GetForCatId(catId);
            List<RespChapterUserDataResponse> responses = rspChap.Select(s => 
                new RespChapterUserDataResponse(
                    s.RespId, 
                    s.EmpId, 
                    s.CategoryChapterId,
                    userData: new UserInfoResponse(
                        s.UserData.UserName,
                        s.UserData.FullName,
                        s.UserData.ShortName,
                        s.UserData.PhoneNumber,
                        s.UserData.DepName,
                        s.UserData.PositionName
                        ))).ToList();
            return Ok(responses);
        }

        [HttpGet("{id:guid}")]
        [Authorize(Roles = "Developer, User")]
        public async Task<ActionResult<List<RespChapterResponse>>> GetRespChapter(Guid id)
        {
            List<ResponsibleCatChapter> rspChap = await _serv.Get(id);
            List<RespChapterResponse> responses = rspChap.Select(s => 
                new RespChapterResponse(
                    s.RespId, 
                    s.EmpId, 
                    s.CategoryChapterId
                    )).ToList();
            return Ok(responses);
        }

        [HttpPost]
        [Authorize(Roles = "Developer")]
        public async Task<ActionResult> AddRespChapter(RespChapterRequest createRespChap)
        {
            var newGuid = Guid.NewGuid();
            var newRespChap = ResponsibleCatChapter.Create(newGuid, createRespChap.empId, createRespChap.catId);
            await _serv.Add(newRespChap);
            return Ok();
        }
    }
}
