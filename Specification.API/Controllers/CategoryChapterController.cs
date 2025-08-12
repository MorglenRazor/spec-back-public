using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Specification.API.Contracts.ChapterContract;
using Specification.Core.Abstractions.Service;
using Specification.Core.Models;

namespace Specification.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoryChapterController : Controller
    {
        private readonly ITableService<CategoryChapter> _serv;

        public CategoryChapterController(ITableService<CategoryChapter> serv)
        {
            _serv = serv;
        }

        [HttpGet]
        [Authorize(Roles = "Developer,User")]
        public async Task<ActionResult<List<CategoryChapterResponse>>> GetCatChapter()
        {
            List<CategoryChapter> catChap = await _serv.Get(Guid.Empty);
            List<CategoryChapterResponse> responses = catChap.Select(s=> new CategoryChapterResponse(
                s.CategoryChapterId,
                s.Name
                )).ToList();   
            return responses;
        }
        [HttpGet("{id:guid}")]
        [Authorize(Roles = "Developer,User")]
        public async Task<ActionResult<List<CategoryChapterResponse>>> GetCatChapter(Guid id)
        {
            List<CategoryChapter> catChap = await _serv.Get(id);
            List<CategoryChapterResponse> responses = catChap.Select(s => new CategoryChapterResponse(
                s.CategoryChapterId,
                s.Name
                )).ToList();
            return responses;
        }
    }
}
