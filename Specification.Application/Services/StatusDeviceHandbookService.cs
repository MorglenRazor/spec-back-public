using Specification.Core.Abstractions.Repository;
using Specification.Core.Abstractions.Service;
using Specification.Core.Models;

namespace Specification.Application.Services
{
    public class StatusDeviceHandbookService : ITableService<StatusDeviceHandbook>, IStatusDeviceHandbookService
    {
        private readonly ITableRepository<StatusDeviceHandbook> _repo;
        private readonly IStatusDeviceHandbookRepository _repoStatus;

        public StatusDeviceHandbookService(ITableRepository<StatusDeviceHandbook> repo, IStatusDeviceHandbookRepository repoStatus)
        {
            _repo = repo;
            _repoStatus = repoStatus;
        }
        public async Task Add(StatusDeviceHandbook model) => await _repo.Add(model);

        public async Task Delete(Guid id) => await _repo.Delete(id);

        public async Task<List<StatusDeviceHandbook>> Get(Guid id) => await _repo.Get(id);

        public async Task Update(Guid id, StatusDeviceHandbook model) => await _repo.Update(id, model);

        public Task<List<StatusDeviceHandbook>> GetStatusByDepId(Guid depId) => _repoStatus.GetStatusByDepId(depId);

    }
}
