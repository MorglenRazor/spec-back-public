namespace Specification.API.Contracts.ConstructionDepContract;

public record ConstructionDepRequest(
    //float CountDevice,
    string Comment,
    int UnitId,
    Guid? EmpRespId,
    Guid DeviceChapterId
);
