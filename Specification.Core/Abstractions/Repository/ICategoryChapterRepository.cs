using Specification.Core.Models;

namespace Specification.Core.Abstractions.Repository
{
    public interface ICategoryChapterRepository
    {
        public Task AddWithResponsible(CategoryChapter categoryChapter);
    }
}
