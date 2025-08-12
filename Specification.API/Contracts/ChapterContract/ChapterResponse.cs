using Specification.API.Contracts.SubChapterContract;
using Specification.Core.Models;

namespace Specification.API.Contracts.ChapterContract;

public record ChapterToCopyResponse(
    Guid ChapterId,
    Guid CategoryChapterId,
    string ChapterName,
    float Readiness,
    decimal CostChapter,
    string Comment,
    List<SubChapterResponse> SubChapters
);

public record ChapterResponse(
    Guid ChapterId,
    string ChapterName,
    float Readiness,
    decimal CostChapter,
    string Comment,
    Guid SpecificationId
);

public record ChapterSpecResponse(
    Guid ChapterId,
    Guid SpecificationId,
    string ChapterName,
    string SpecName,
    int countDevice
);

public record ChapterDetailResponse(
    Guid ChapterId,
    string ChapterName,
    float Readiness,
    decimal CostChapter,
    string Comment,
    Guid CategoryChapterId
);


public record ChapterCopyResponse(
    Guid ChapterId,
    Guid CategoryChapterId
);