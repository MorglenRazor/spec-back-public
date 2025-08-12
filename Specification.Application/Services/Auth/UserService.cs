using Specification.Core.Abstractions.Repository.Auth;
using Specification.Core.Abstractions.Service.Auth;
using Specification.Core.Models.Auth;

namespace Specification.Application.Services.Auth
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public Task Add(User model)
        {
            throw new NotImplementedException();
        }

        public Task Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<User> GetInfoUser(Guid userId) =>await _userRepository.GetUserAsync(userId);

        public async Task<List<User>> GetUsers() => await _userRepository.GetUsers();

        public async Task<List<User>> GetUsers(Guid depId) => await _userRepository.GetUsers(depId);

        public async Task RegistrationUser(User model) => await _userRepository.RegistrationUser(model);

        public async Task<List<User>> GetFullInfoUsers() => await _userRepository.GetFullInfoUsers();   

        public Task Update(Guid id, User model)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateUser(Guid empId, User model) => await _userRepository.UpdateUser(empId, model);

        public async Task<bool> CheckAdmin(Guid userId) => await _userRepository.CheckAdmin(userId);
    }
}
