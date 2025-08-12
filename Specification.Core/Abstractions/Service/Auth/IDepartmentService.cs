namespace Specification.Core.Abstractions.Service.Auth
{
    public interface IDepartmentService
    {
        Task<Guid> Get(string shortName);
    }
}
