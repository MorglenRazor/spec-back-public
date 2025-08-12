using Specification.Core.Abstractions.Repository;
using Specification.Core.Abstractions.Service;
using Specification.Core.Models;

namespace Specification.Application.Services
{
    public class DeviceService : ITableService<Device>, IDeviceService
    {
        private readonly ITableRepository<Device> _repos;
        private readonly IDeviceRepository _devRepos;

        public DeviceService(ITableRepository<Device> repos, IDeviceRepository devRepos)
        {
            _repos = repos;
            _devRepos = devRepos;
        }

        public async Task<List<Device>> Get(Guid id) => await _repos.Get(id);

        public async Task Add(Device model) => await _repos.Add(model);

        public async Task Update(Guid id, Device model) => await _repos.Update(id, model);

        public async Task Delete(Guid id) => await _repos.Delete(id);

        public async Task<List<Device>> GetFilt(Guid? ctId, Guid? subCtId) =>
            await _devRepos.GetFilt(ctId, subCtId);
    }
}
