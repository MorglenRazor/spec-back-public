using System.Collections.Generic;
using Specification.Core.Abstractions.Repository;
using Specification.Core.Abstractions.Service;
using Specification.Core.Models;

namespace Specification.Application.Services
{
    public class SubChapterService : ITableService<SubChapter>, ISubChapterService
    {
        private readonly ITableRepository<SubChapter> _repository;
        private readonly ISubChapterRepository _repoSupChap;

        public SubChapterService(
            ITableRepository<SubChapter> repository,
            ISubChapterRepository repoSupChap
        )
        {
            _repository = repository;
            _repoSupChap = repoSupChap;
        }

        public async Task Add(SubChapter model)
        {
            await _repository.Add(model);
        }

        public async Task Delete(Guid id)
        {
            await _repository.Delete(id);
        }

        public async Task<List<SubChapter>> Get(Guid id)
        {
            return await _repository.Get(id);
        }

        public Task<List<SubChapter>> GetSubChapterDetail() => _repoSupChap.GetSubChapterDetail();

        public Task<List<SubChapter>> GetSubChapterProfile(List<Guid> statusIds) => _repoSupChap.GetSubChapterProfile(statusIds);

        public async Task Update(Guid id, SubChapter model)
        {
            await _repository.Update(id, model);
        }
    }
}
