namespace Specification.Core.Abstractions.Service.Auth
{
    public interface IAuthService
    {
        public Task Register(
            string userName,
            string password,
            string fullName,
            string shortName,
            string phoneNumber,
            string positionName,
            bool isAdmin,
            bool isActual,
            Guid depId
        );
        public Task<string> Login(string userName, string password);
        public Task<string> Login(Guid empId, Guid depId, string password);
        public Task AddRole(Guid userId, int RoleId);

    }
}
