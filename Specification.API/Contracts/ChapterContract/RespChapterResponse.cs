using Specification.API.Contracts.Auth;

namespace Specification.API.Contracts.ChapterContract
{
    public record RespChapterResponse(Guid id, Guid empId, Guid catId);
    public record RespChapterUserDataResponse(Guid id, Guid empId, Guid catId, UserInfoResponse userData);

}
