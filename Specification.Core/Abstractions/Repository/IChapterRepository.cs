using Specification.Core.Models;

namespace Specification.Core.Abstractions.Repository;

public interface IChapterRepository
{
    Task<List<Chapter>> GetChapterDetail();
    Task<List<Chapter>> GetChapterDetail(Guid id);
    Task<List<Chapter>> GetFromChapSpecIds();
    Task<List<Chapter>> GetFromChapSpecId(Guid specId);
    public Task AddWithSubChapters(Chapter chapter);
    //
}
