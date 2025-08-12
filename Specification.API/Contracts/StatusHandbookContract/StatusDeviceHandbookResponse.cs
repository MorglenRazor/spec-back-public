namespace Specification.API.Contracts.StatusHandbookContract
{
    public record StatusDeviceHandbookResponse(
        Guid StatusId,
        string Name,
        Guid DepId
        );
}
