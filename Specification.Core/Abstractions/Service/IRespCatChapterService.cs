using Specification.Core.Models;

namespace Specification.Core.Abstractions.Service
{
    public interface IRespCatChapterService
    {
        public Task<List<ResponsibleCatChapter>> GetForCatId(Guid CatId);
    }
}
