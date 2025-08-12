using Microsoft.AspNetCore.Mvc;
using Specification.API.Contracts.Auth;
using Specification.Core.Abstractions.Service;
using Specification.Core.Models.Auth;

namespace Specification.API.Controllers.Auth
{
    [ApiController]
    [Route("[controller]")]
    public class RoleController : Controller
    {
        private readonly IHandbookService<Roles> _roleService;

        public RoleController(IHandbookService<Roles> roleService)
        {
            _roleService = roleService;
        }

        [HttpGet]
        //[Authorize]
        public async Task<ActionResult<List<EmployerResponse>>> GetRoles()
        {
            List<Roles> roles = await _roleService.Get();
            List<RolesResponse> roleResponse = roles.Select(s => new RolesResponse(
                    id: s.Id,
                    nameRole: s.NameRole
                ))
                .ToList();
            return Ok(roleResponse);
        }
    }
}
