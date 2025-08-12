namespace Specification.API.Contracts.ResponsibleContract;

public record ResponsibleSpecResponse(Guid Id, Guid EmpId, Guid SpecId);

public record ResponsibleSpecResponseDetails(
    Guid Id,
    Guid EmpId,
    string ResponsibleName,
    Guid SpecId
);

