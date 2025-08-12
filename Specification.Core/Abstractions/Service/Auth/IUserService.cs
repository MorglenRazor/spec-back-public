using Specification.Core.Models.Auth;

namespace Specification.Core.Abstractions.Service.Auth
{
    public interface IUserService
    {
        Task<List<User>> GetUsers();
        Task<List<User>> GetUsers(Guid depId);
        Task<User> GetInfoUser(Guid userId);
        Task Add(User model);
        Task Update(Guid id, User model);
        Task Delete(Guid id);

        Task RegistrationUser(User model);

        Task<List<User>> GetFullInfoUsers();

        Task UpdateUser(Guid empId, User model);

        Task<bool> CheckAdmin(Guid userId);
    }
}
