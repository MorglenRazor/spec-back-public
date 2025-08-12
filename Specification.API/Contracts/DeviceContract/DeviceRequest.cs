namespace Specification.API.Contracts.DeviceContract
{
    public record DeviceRequest(
        Guid DeviceId,
        string Name,
        string BrandName,
        Guid? CategoryId,
        Guid? SubCategoryId
    );

}
