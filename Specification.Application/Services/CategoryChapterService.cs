using Specification.Core.Abstractions.Repository;
using Specification.Core.Abstractions.Service;
using Specification.Core.Models;

namespace Specification.Application.Services
{
    public class CategoryChapterService : ITableService<CategoryChapter>
    {
        private readonly ITableRepository<CategoryChapter> _repos;

        public CategoryChapterService(ITableRepository<CategoryChapter> repos)
        {
            _repos = repos;
        }
        public async Task Add(CategoryChapter model) => await _repos.Add(model);
        public async Task Delete(Guid id) => await _repos.Delete(id);        

        public async Task<List<CategoryChapter>> Get(Guid id) => await _repos.Get(id);

        public async Task Update(Guid id, CategoryChapter model) => await _repos.Update(id, model);
    }
}
