using Specification.Core.Models.Auth;

namespace Specification.Core.Abstractions.Repository.Auth
{
    public interface IDepartmentRepository
    {
        Task<Guid> Get(string ShortName);
    }
}
