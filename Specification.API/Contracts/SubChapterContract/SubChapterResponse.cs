using Specification.API.Contracts.ChapterDeviceContract;

namespace Specification.API.Contracts.SubChapterContract
{
    public record SubChapterResponse(Guid SubChapId, Guid CategoryDeviceId, Guid ChapterId);
    public record SubChapterResponseDetail(
        Guid SubChapId,
        Guid CategoryDeviceId,
        string NameCategory,
        Guid ChapterId
    );

    public record SubChapterResponseProfile(
        Guid SubChapId,
        Guid CategoryDeviceId,
        int CountDevice,
        string NameCategory,
        string CatChapName,
        string SpecName,
        Guid SpecId,
        Guid ChapterId,
        List<ChapterDeviceProfileResponse> DevChapProf
    );
}
