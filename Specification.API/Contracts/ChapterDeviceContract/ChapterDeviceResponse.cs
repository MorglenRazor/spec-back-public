using Specification.API.Contracts.AccountingDepContract;
using Specification.API.Contracts.ConstructionDepContract;
using Specification.API.Contracts.TcDepContract;
using Specification.API.Contracts.TmsDepContract;
using Specification.API.Contracts.WarehouseDepContract;

namespace Specification.API.Contracts.ChapterDeviceContract;

public record GetDeviceChapterIdResponse(
    Guid DeviceChapterId
);

public record GetStatusRespResponse(
    Guid Status,
    Guid? EmpId
);

public record ChapterDeviceProfileResponse(
    Guid DeviceChapterId,
    Guid SubChapterGuid,
    Guid StatusId,
    string DeviceName,
    string BrandName,
    string StatusName
);


public record ChapterDeviceResponse(
    Guid DeviceChapterId,
    Guid SubChapterGuid,
    Guid DeviceId,
    Guid StatusId,
    string SerialNum,
    float CountDevice,
    Guid? CompId,
    string CompName
);

public record ChapterDeviceNftDataResponse(

    Guid DeviceChapterId,
    Guid StatusId,
    Guid SubChapterGuid,
    string SerialNum,
    string DeviceName,
    string BrandName,
    string StatusName,
    float CountDevice,
    Guid? CompId,
    string CompName
);

public record ChapterDeviceResponseInc(
    Guid DeviceChapterId,
    Guid SubChapterGuid,
    Guid StatusId,
    Guid DeviceId,
    string SerialNum,
    float CountDevice,
    Guid? CompId,
    string CompName,
    List<ConstructionDepResponse> ConstructionDep,
    List<TmsDepResponse> TechMaterialSuppDep,
    List<TcDepResponse> TechControlDep,
    List<WarehouseDepResponse> WarehouseDep,
    List<AccountingDepResponse> AccountingDep
);

public record ChapterDeviceResponseDetails(
    Guid DeviceChapterId,
    Guid SubChapterGuid,
    Guid DeviceId,
    Guid StatusId,
    string SerialNum,
    short StatusRank,
    string DeviceName,
    string BrandName,
    string StatusName,
    string DepName,
    float CountDevice,
    Guid? CompId,
    string CompName,
    int[] ReqProdDate,
    int[] DateToFilling,
    int[] DateToEditing,
    List<ConstructionDepResponseDetails> ConstructionDep,
    List<TmsDepResponseDetails> TechMaterialSuppDep,
    List<TcDepResponseDetails> TechControlDep,
    List<WarehouseDepResponseDetails> WarehouseDep,
    List<AccountingDepResponseDetails> AccountingDep
);
