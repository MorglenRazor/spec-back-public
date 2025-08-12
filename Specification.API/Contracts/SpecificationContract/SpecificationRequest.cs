using Specification.API.Contracts.ChapterContract;
using Specification.API.Contracts.ResponsibleContract;

namespace Specification.API.Contracts.SpecificationContract;

public record SpecificationRequest(
    string NumWork,
    string NumTask,
    string Name,
    int TotalUncoverPos,
    int Readiness,
    int CusId,
    Guid UserId
);