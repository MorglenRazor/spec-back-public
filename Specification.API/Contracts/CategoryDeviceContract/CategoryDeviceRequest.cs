namespace Specification.API.Contracts.CategoryDeviceContract
{
    public record CategoryDeviceRequest(Guid CaDeviceId, string Name, Guid CategoryChapterId);
}
