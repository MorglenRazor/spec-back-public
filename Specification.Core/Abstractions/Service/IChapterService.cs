using Specification.Core.Models;

namespace Specification.Core.Abstractions.Service;

public interface IChapterService
{
    Task<List<Chapter>> GetChapterDetail();
    Task<List<Chapter>> GetChapterDetail(Guid specId);

    Task<List<Chapter>> GetFromChapSpecIds();
    Task<List<Chapter>> GetFromChapSpecId(Guid specId);

    public Task AddWithSubChapters(Chapter chapter);
}
