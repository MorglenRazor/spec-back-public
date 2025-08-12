using Specification.Core.Models;

namespace Specification.Core.Abstractions.Repository
{
    public interface ISubChapterRepository
    {
        Task<List<SubChapter>> GetSubChapterDetail();
        Task<List<SubChapter>> GetSubChapterProfile(List<Guid> statusIds);
    }
}
