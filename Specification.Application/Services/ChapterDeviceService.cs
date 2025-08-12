using Specification.Core.Abstractions.Repository;
using Specification.Core.Abstractions.Service;
using Specification.Core.Models;

namespace Specification.Application.Services;

public class ChapterDeviceService : ITableService<DevicesChapter>, IChapterDeviceService
{
    private readonly ITableRepository<DevicesChapter> _repos;
    private readonly IChapterDeviceRepository _reposChapDev;

    public ChapterDeviceService(
        ITableRepository<DevicesChapter> repos,
        IChapterDeviceRepository reposChapDev
    )
    {
        _repos = repos;
        _reposChapDev = reposChapDev;
    }

    public async Task<List<DevicesChapter>> Get(Guid id) => await _repos.Get(id);

    public async Task<List<DevicesChapter>> GetWithIncludes(Guid id) =>
        await _reposChapDev.GetWithIncludes(id);

    public async Task<List<DevicesChapter>> GetDetails(Guid id) =>
        await _reposChapDev.GetDetails(id);

    public async Task Add(DevicesChapter model) => await _repos.Add(model);

    public async Task Update(Guid id, DevicesChapter model) => await _repos.Update(id, model);

    public async Task Delete(Guid id) => await _repos.Delete(id);

    public async Task<Guid> CreateChapterDetail(DevicesChapter model) =>
        await _reposChapDev.CreateChapterDetail(model);

    public async Task UpdateStatus(Guid id, Guid status) => await _reposChapDev.UpdateStatus(id, status);

    public async Task<List<DevicesChapter>> GetNtfData() => await _reposChapDev.GetNtfData();

    public async Task<List<DevicesChapter>> GetDeviceChaptersId(Guid id) => await _reposChapDev.GetDeviceChaptersId(id);

    public async Task<List<DevicesChapter>> GetGroupDeviceChapters(Guid deviceChapterId) => await _reposChapDev.GetGroupDeviceChapters(deviceChapterId);

    public async Task UpdateCountDevice(Guid id, float count) => await _reposChapDev.UpdateCountDevice(id, count);

    public async Task UpdateSerialNumber(Guid devceChapId, string serialNum) => await _reposChapDev.UpdateSerialNumber(devceChapId, serialNum);

}
