namespace Specification.API.Contracts.StatusHandbookContract
{
    public record StatusDeviceHandbookRequest(
        string Name,
        Guid depId);
}
