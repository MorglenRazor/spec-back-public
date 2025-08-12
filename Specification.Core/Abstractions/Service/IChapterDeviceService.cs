using Specification.Core.Models;

namespace Specification.Core.Abstractions.Service;

public interface IChapterDeviceService
{
    Task<List<DevicesChapter>> GetWithIncludes(Guid id);
    Task<List<DevicesChapter>> GetDetails(Guid id);

    Task<List<DevicesChapter>> GetNtfData();
    Task<Guid> CreateChapterDetail(DevicesChapter model);
    
    Task<List<DevicesChapter>> GetDeviceChaptersId(Guid id);

    Task UpdateStatus(Guid id, Guid status);

    Task UpdateCountDevice(Guid id, float count);

    Task UpdateSerialNumber(Guid devceChapId, string serialNum);

    Task<List<DevicesChapter>> GetGroupDeviceChapters(Guid deviceChapterId);
}
