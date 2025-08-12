using Specification.Core.Abstractions.Repository;
using Specification.Core.Abstractions.Service;
using Specification.Core.Models;

namespace Specification.Application.Services;

public class ChapterService : ITableService<Chapter>, IChapterService
{
    private readonly ITableRepository<Chapter> _chapterRepository;
    private readonly IChapterRepository _chapterDetailRepository;

    public ChapterService(
        ITableRepository<Chapter> chapter,
        IChapterRepository chapterDetailRepository
    )
    {
        _chapterRepository = chapter;
        _chapterDetailRepository = chapterDetailRepository;
    }

    public async Task<List<Chapter>> Get(Guid id) => await _chapterRepository.Get(id);

    public async Task Add(Chapter model) => await _chapterRepository.Add(model);

    public async Task Update(Guid id, Chapter model) => await _chapterRepository.Update(id, model);

    public async Task Delete(Guid id) => await _chapterRepository.Delete(id);

    public async Task<List<Chapter>> GetChapterDetail() =>
        await _chapterDetailRepository.GetChapterDetail();

    public async Task<List<Chapter>> GetChapterDetail(Guid specId) =>
        await _chapterDetailRepository.GetChapterDetail(specId);

    public async Task<List<Chapter>> GetFromChapSpecIds() => await  _chapterDetailRepository.GetFromChapSpecIds();

    public async Task<List<Chapter>> GetFromChapSpecId(Guid specId) => await _chapterDetailRepository.GetFromChapSpecId(specId);

    public async Task AddWithSubChapters(Chapter chapter) => await _chapterDetailRepository.AddWithSubChapters(chapter);
}
