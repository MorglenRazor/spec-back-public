namespace Specification.API.Contracts.WarehouseDepContract;

public record WarehouseDepResponse(
    int Id,
    // bool ExistOnStorage,
    string CountOnStorage,
    string CountAfterPurchase,
    string RemainsCountAfterPurchase,
    //string SerialNumber,
    //string WriteOfDoc,
    //DateTime WriteOfDate,
    //string AcceptSets,
    string Comment,
    int GenUnitId,
    int RemainsUnitId,
    Guid DeviceChapterId,
    Guid? EmpRespId
);

public record WarehouseDepResponseDetails(
    int Id,
    string CountOnStorage,
    string CountAfterPurchase,
    string RemainsCountAfterPurchase,
    //string SerialNumber,
    //string WriteOfDoc,
    //int[] WriteOfDate,
    //string AcceptSets,
    string Comment,
    string GenUnitName,
    string RemainsUnitName,
    Guid DeviceChapterId,
    string EmpShortName,
    int GenUnitId,
    int RemUnitId,
    Guid? EmpRespId
);
