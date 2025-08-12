using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Specification.API.Contracts.StatusHandbookContract;
using Specification.Core.Abstractions.Service;
using Specification.Core.Models;

namespace Specification.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StatusDeviceHandbookController : Controller
    {
        private readonly ITableService<StatusDeviceHandbook> _service;
        private readonly IStatusDeviceHandbookService _serviceSts;

        public StatusDeviceHandbookController(ITableService<StatusDeviceHandbook> service, IStatusDeviceHandbookService serviceSts)
        {
            _service = service;
            _serviceSts = serviceSts;
        }

        [HttpPost("/add_new_status")]
        public async Task<ActionResult> AddStatus([FromBody] StatusDeviceHandbookRequest request)
        {
            var newGuid = Guid.NewGuid();
            var sts = StatusDeviceHandbook.Create(
                id: newGuid,
                name: request.Name,
                depId: request.depId,
                isVisible: true, rank: 0);
            await _service.Add(sts);
            return Ok();
        }

        [HttpGet("/getStatusByDep/{depId:guid}")]
        [Authorize(Roles = "Developer,User")]
        public async Task<ActionResult<List<StatusDeviceHandbook>>> GetStatusByDep(Guid depId)
        {
            List<StatusDeviceHandbook> sts = await _serviceSts.GetStatusByDepId(depId);
            List<StatusDeviceHandbookResponse> responses = sts.Where(f=>f.IsVisible).Select(s=> new StatusDeviceHandbookResponse(
                StatusId: s.Id,
                Name: s.Name,
                DepId: s.DepId
                )).ToList();
            return Ok(responses);            
        }
    }
}
