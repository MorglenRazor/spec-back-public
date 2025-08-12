namespace Specification.API.Contracts.ChapterContract
{
    public record CategoryChapterResponse(Guid id, string name);

    public record CategoryChapterDtlResponse(Guid id, string name, List<RespChapterResponse> rsp);
}
