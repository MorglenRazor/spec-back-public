namespace Specification.API.Contracts.DeviceContract
{
    public record DeviceResponse(
        Guid DeviceId,
        string Name,
        string BrandName,
        Guid? CategoryId
    );
}
