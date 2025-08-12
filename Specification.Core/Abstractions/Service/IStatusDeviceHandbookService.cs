using Specification.Core.Models;

namespace Specification.Core.Abstractions.Service
{
    public interface IStatusDeviceHandbookService
    {
        Task<List<StatusDeviceHandbook>> GetStatusByDepId(Guid depId);
    }
}
