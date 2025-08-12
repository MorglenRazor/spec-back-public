using Specification.Core.Models;

namespace Specification.Core.Abstractions.Service
{
    public interface IDeviceService
    {
        Task<List<Device>> GetFilt(Guid? ctId, Guid? subCtId);
    }
}
