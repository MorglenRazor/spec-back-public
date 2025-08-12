using Specification.API.Contracts.SubChapterContract;
using Specification.Core.Models;

namespace Specification.API.Contracts.ChapterContract;

public record ChapterRequest(    
    float Readiness,
    decimal CostChapter,
    string Comment,
    Guid SpecId
);

