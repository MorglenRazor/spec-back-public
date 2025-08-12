using Specification.Core.Abstractions.Service;
using Specification.Core.Abstractions.Service.Auth;

namespace Specification.Infrastructure
{
    public class CheckAccess
    {
        private readonly IUserService _userService;

        public CheckAccess(IUserService userService)
        {
            _userService = userService;
        }
        public async Task<bool> IsAdmin(Guid userId)
        {
            return await _userService.CheckAdmin(userId);
        }

    }
}
