using Specification.Core.Models;

namespace Specification.Core.Abstractions.Repository
{
    public interface IStatusDeviceHandbookRepository
    {
        Task<List<StatusDeviceHandbook>> GetStatusByDepId(Guid depId);
    }
}
