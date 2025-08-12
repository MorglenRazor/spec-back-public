using Specification.Core.Abstractions.Repository;
using Specification.Core.Abstractions.Service;
using Specification.Core.Models;

namespace Specification.Application.Services
{
    public class RespChapterService : ITableService<ResponsibleCatChapter>,IRespCatChapterService
    {
        private readonly ITableRepository<ResponsibleCatChapter> _repos;
        private readonly IRespCatChapterRepository _ccrRepos;
        public RespChapterService(ITableRepository<ResponsibleCatChapter> repos, IRespCatChapterRepository ccrRepos)
        {
            _repos = repos;
            _ccrRepos = ccrRepos;
        }
        public async Task Add(ResponsibleCatChapter model) => await _repos.Add(model);

        public Task Delete(Guid id) => _repos.Delete(id);   

        public async Task<List<ResponsibleCatChapter>> Get(Guid id) => await _repos.Get(id);

        public async Task<List<ResponsibleCatChapter>> GetForCatId(Guid CatId) => await _ccrRepos.GetForCatId(CatId);

        public async Task Update(Guid id, ResponsibleCatChapter model) => await _repos.Update(id, model);
    }
}
