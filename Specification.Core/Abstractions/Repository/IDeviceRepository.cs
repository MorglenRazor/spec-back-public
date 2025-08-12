using Specification.Core.Models;

namespace Specification.Core.Abstractions.Repository
{
    public interface IDeviceRepository
    {
        Task<List<Device>> GetFilt(Guid? ctId, Guid? subCtId);
    }
}
