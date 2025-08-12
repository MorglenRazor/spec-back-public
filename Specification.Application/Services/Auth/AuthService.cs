using Specification.Application.Interfaces.Auth;
using Specification.Core.Abstractions.Repository.Auth;
using Specification.Core.Abstractions.Service.Auth;
using Specification.Core.Models.Auth;

namespace Specification.Application.Services.Auth
{
    public class AuthService : IAuthService
    {
        private readonly IPasswordHasher _passwordHasher;
        private readonly IUserRepository _usersRepo;
        private readonly IJwtProvider _jwtProvider;

        public AuthService(
            IPasswordHasher passwordHasher,
            IUserRepository userRepository,
            IJwtProvider jwtProvider
        )
        {
            _passwordHasher = passwordHasher;
            _usersRepo = userRepository;
            _jwtProvider = jwtProvider;
        }

        public async Task AddRole(Guid userId, int RoleId) =>
            await _usersRepo.AddRole(userId, RoleId);

        public async Task<string> Login(string userName, string password)
        {
            var user = await _usersRepo.GetUser(userName);

            var result = _passwordHasher.VerifyPassword(password, user.Password);
            if (result == false)
            {
                throw new Exception("Failed to login");
            }
            var token = _jwtProvider.GenerateToken(user);
            return token;
        }

        public async Task<string> Login(Guid empId, Guid depId, string password)
        {
            var user = await _usersRepo.GetUser(empId, depId);
            var result = _passwordHasher.VerifyPassword(password, user.Password);
            var token = "";
            if (result == false)
            {
                token = "1";
                return token;
            }
            token = _jwtProvider.GenerateToken(user);
            return token;
        }

        public async Task Register(
            string userName,
            string password,
            string fullName,
            string shortName,
            string phoneNumber,
            string positionName,
            bool isAdmin,
            bool isActual,
            Guid depId
        )
        {
            var hasherPassword = _passwordHasher.Generate(password);
            var user = User.Create(
                Guid.NewGuid(),
                userName,
                hasherPassword,
                fullName,
                shortName,
                phoneNumber,
                positionName,
                isAdmin, isActual,
                depId
            );
            await _usersRepo.RegistrationUser(user);
        }
    }
}
