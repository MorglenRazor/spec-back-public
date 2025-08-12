using Specification.Core.Models.Auth;

namespace Specification.Core.Abstractions.Repository.Auth
{
    public interface IUserRepository
    {
        /// <summary>
        /// Получение пользователя по userName
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        Task<User> GetUser(string userName);

        /// <summary>
        /// Получение пользователя по его id и его depId
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        Task<User> GetUser(Guid empId, Guid depId);

        Task<User> GetUserAsync(Guid userId);

        /// <summary>
        /// Получение всех пользователей
        /// </summary>
        /// <returns></returns>
        Task<List<User>> GetUsers();

        /// <summary>
        /// Получение всех пользователей по отделу
        /// </summary>
        /// <param name="depId">Id отдела</param>
        /// <returns></returns>
        Task<List<User>> GetUsers(Guid depId);
        Task RegistrationUser(User model);

        Task<List<User>> GetFullInfoUsers();
        //Task UpdateInfo(Guid id, User model);
        Task UpdatePassword(Guid id, User model);
        Task Delete(Guid id);

        Task AddRole(Guid Id, int RoleId);
        Task UpdateUser(Guid id, User model);
        Task<bool> CheckAdmin(Guid userId);

        //Task<List<RolesPermissions>> GetUserPermissions(Guid userId);
    }
}
