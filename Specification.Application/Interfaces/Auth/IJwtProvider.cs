using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Specification.Core.Models.Auth;

namespace Specification.Application.Interfaces.Auth
{
    public interface IJwtProvider
    {
        public string GenerateToken(User user);
        public JwtSecurityToken Verify(string jwt);
        public List<Claim> GetClaims(string jwt);
    }
}
