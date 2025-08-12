namespace Specification.API.Contracts.WarehouseDepContract;

public record WarehouseDepRequest(
    //  bool ExistOnStorage,
    string? CountOnStorage,
    string? CountAfterPurchase,
    string? RemainsCountAfterPurchase,
    //string? SerialNumber,
    //string? WriteOfDoc,
    //int[] WriteOfDate,
    //string? AcceptSets,
    string? Comment,
    int GenUnitId,
    int RemainsUnitId,
    Guid DeviceChapterId,
    Guid? EmpRespId
);
