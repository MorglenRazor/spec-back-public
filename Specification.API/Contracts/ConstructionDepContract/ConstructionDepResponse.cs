namespace Specification.API.Contracts.ConstructionDepContract;

public record ConstructionDepResponse(
    int Id,
    //float CountDevice,
    string Comment,
    int UnitId,
    Guid? EmpRespId,
    Guid DeviceChapterId
);

public record ConstructionDepResponseDetails(
    int Id,
   // float CountDevice,
    string Comment,
    string UnitName,
    string EmpShortName,
    Guid DeviceChapterId,
    int UnitId,
    Guid? EmpRespId
);
