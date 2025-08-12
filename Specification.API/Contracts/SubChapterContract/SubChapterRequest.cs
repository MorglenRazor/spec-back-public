namespace Specification.API.Contracts.SubChapterContract
{
    public record SubChapterRequest(Guid SubChapId, Guid CategoryDeviceId, Guid ChapterId);

    public record CopySubChapRequest(
    Guid CategoryChapterId,
    Guid OldChapGuid,
    Guid ChapterId,
    Guid SpecId,
    List<SubChapterRequest> SubChapterRequests
);

}
