using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Specification.API.Contracts.Auth;
using Specification.Core.Abstractions.Service.Auth;
using Specification.Core.Models.Auth;

namespace Specification.API.Controllers.Auth
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : Controller
    {
        private readonly IAuthService _authService;
        private readonly IUserService _userService;

        public UsersController(IAuthService authService, IUserService userService)
        {
            _authService = authService;
            _userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult<List<EmployerResponse>>> GetEmployers()
        {
            List<User> user = await _userService.GetUsers();
            List<EmployerResponse> emp = user.Select(s => new EmployerResponse(
                    Id: s.Id,
                    FullName: s.FullName,
                    ShortName: s.ShortName,
                    DepId: s.DepartmentId
                ))
                .ToList();
            return Ok(emp);
        }

        [HttpGet("/FullInfo/")]
        [Authorize(Roles = "Developer")]
        public async Task<ActionResult<List<EmployerResponse>>> GetFullInfoForUser()
        {
            List<User> user = await _userService.GetUsers();
            List<UserFullInfoResponse> emp = user.Select(s => new UserFullInfoResponse(
                    Id: s.Id,
                    UserName: s.UserName,
                    Password: "test1",
                    FullName: s.FullName,
                    ShortName: s.ShortName,
                    PhoneNumber: s.PhoneNumber,
                    PosName: s.PositionName,
                    IsAdmin: s.IsAdmin,
                    IsActual: s.IsActual,
                    DepId: s.DepartmentId
                ))
                .ToList();
            return Ok(emp);
        }

        [HttpGet("/Users/Department/{depId:guid}")]
    //    [Authorize]
        public async Task<ActionResult<List<EmployerResponse>>> GetEmployers(Guid depId)
        {
            List<User> user = await _userService.GetUsers(depId);
            List<EmployerResponse> emp = user.Select(s => new EmployerResponse(
                    Id: s.Id,
                    FullName: s.FullName,
                    ShortName: s.ShortName,
                    DepId: s.DepartmentId
                ))
                .ToList();
            return Ok(emp);
        }

        [HttpPost("/SignUp/")]
        [Authorize(Roles = "Developer")]
        public async Task<ActionResult> Register([FromBody] RegistrationRequest regRequest)
        {
            await _authService.Register(
                regRequest.UserName,
                regRequest.Password,
                regRequest.FullName,
                regRequest.ShortName,
                regRequest.PhoneNumber,
                regRequest.PosName,
                regRequest.isAdmin,
                regRequest.isActual,
                regRequest.DepId
            );
            return Ok();
        }
       

        /// <summary>
        /// Вход по логину и паролю
        /// </summary>
        /// <param name="userRequest"></param>
        /// <returns>Токен JWT</returns>
        [HttpPost("/SignInType1/")]
        public async Task<ActionResult<string>> Login([FromBody] SignInRequestType1 userRequest)
        {
            var token = await _authService.Login(userRequest.UserName, userRequest.Password);
            HttpContext.Response.Cookies.Append(
                "vsm_token_cookies",
                token,
                new CookieOptions { HttpOnly = true }
            );
            return Ok(token);
        }

        /// <summary>
        /// Вход по отделу, фио и паролю
        /// </summary>
        /// <param name="userRequest"></param>
        /// <returns>Токен JWT</returns>
        [HttpPost("/SignInType2/")]
        public async Task<ActionResult<string>> Login([FromBody] SignInRequestType2 userRequest)
        {
            var token = await _authService.Login(
                userRequest.EmpId,
                userRequest.DepId,
                userRequest.Password
            );
            if (token == "1")
            {
                return Ok("1");
            }
            else
            {
                HttpContext.Response.Cookies.Append(
                    
                    "vsm_token_cookies",
                    token,
                    new CookieOptions { HttpOnly = true , Secure = false, SameSite=SameSiteMode.None, Path = "/"}
                );
                return Ok(token);
            }
        }

        [HttpPost("/AddRole/")]
        [Authorize(Roles = "Developer,Admin")]
        public async Task<ActionResult> AddRole([FromBody] AddRole addRoleRequest)
        {
            await _authService.AddRole(addRoleRequest.UserId, addRoleRequest.RoleId);
            return Ok();
        }

        [HttpGet("/Profile/{userId:guid}")]
        //[Authorize]
        public async Task<ActionResult<UserInfoResponse>> GetUserInfo(Guid userId)
        {
            var user = await _userService.GetInfoUser(userId);
            UserInfoResponse response = new UserInfoResponse(
                user.UserName,
                user.FullName,
                user.ShortName,
                user.PhoneNumber,
                user.DepName,
                user.PositionName
            );
            return Ok(response);
        }

        [HttpGet("/GetDep/{userId:guid}")]
        //[Authorize]
        public async Task<ActionResult<Guid>> GetUserDep(Guid userId)
        {
            var user = await _userService.GetInfoUser(userId);
            return Ok(user.DepartmentId);
        }


        [HttpPut("/UpdateUser/{empId:guid}")]
        [Authorize(Roles = "Developer")]
        public async Task<ActionResult> UpdUser( Guid empId,[FromBody] EmployerRequest request)
        {
            var user = Core.Models.Auth.User.Create(request.Id,request.UserName, request.Password, request.FullName, request.ShortName,
                request.PhoneNumber, request.PosName, request.IsAdmin, request.IsActual, request.DepId);
            await _userService.UpdateUser(empId, user);
            return Ok();
        }
    }
}
