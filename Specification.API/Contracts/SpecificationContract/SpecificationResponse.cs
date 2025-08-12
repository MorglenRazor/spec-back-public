using Specification.API.Contracts.ChapterContract;
using Specification.API.Contracts.ResponsibleContract;

namespace Specification.API.Contracts.SpecificationContract;

public record SpecificationResponse(
    Guid SpecId,
    string NumWork,
    string NumTask,
    string Name,
    int TotalUncoverPos,
    int Readiness,
    int CusId,
    string CustomerName
);

public record SpecificationCopyResponse(
    Guid SpecId,
    List<ChapterCopyResponse> Chapter
);