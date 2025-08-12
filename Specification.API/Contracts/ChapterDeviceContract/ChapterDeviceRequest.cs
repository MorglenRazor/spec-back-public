namespace Specification.API.Contracts.ChapterDeviceContract;

public record ChapterDeviceRequest(
    Guid ChapterDeviceId,
    Guid SubChapterId,
    Guid DeviceId,
    Guid StatusId,
    string SerialNum,
    int[] ReqProdDate,
    int[] DateToFilling,
    int[] DateToEditing,
    float CountDevice,
    Guid? CompId,
    string CompName
);
