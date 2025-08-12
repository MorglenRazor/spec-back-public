namespace Specification.API.Contracts.TcDepContract;

public record TcDepRequest(
    // bool Status,
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
