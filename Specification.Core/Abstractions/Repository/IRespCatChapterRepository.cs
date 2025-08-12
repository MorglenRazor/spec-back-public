using Specification.Core.Models;

namespace Specification.Core.Abstractions.Repository
{
    public interface IRespCatChapterRepository
    {
        public Task<List<ResponsibleCatChapter>> GetForCatId(Guid CatId);
    }
}
