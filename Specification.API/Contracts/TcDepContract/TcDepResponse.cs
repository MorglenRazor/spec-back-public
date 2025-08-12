namespace Specification.API.Contracts.TcDepContract;

public record TcDepResponse(
    int Id,
    string NameBrandInDoc,
    float Count,
   // string SerialNum,
    string CompKit,
    string CompTechDocAvailable,
    string CompTechDocMissing,
    string Defects,
    string Conclusion,
    string Comment,
    int UnitId,
    Guid? EmpRespId,
    Guid DeviceChapterId
);

public record TcDepResponseDetails(
    int Id,
    string NameBrandInDoc,
    float Count,
   // string SerialNum,
    string CompKit,
    string CompTechDocAvailable,
    string CompTechDocMissing,
    string Defects,
    string Conclusion,
    string Comment,
    string UnitName,
    string EmpShortName,
    Guid DeviceChapterId,
    int UnitId,
    Guid? EmpRespId
);
