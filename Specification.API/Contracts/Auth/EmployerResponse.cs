namespace Specification.API.Contracts.Auth
{
    public record EmployerResponse(Guid Id, string FullName, string ShortName, Guid DepId);

    public record UserInfoResponse(
        string UserName,
        string FullName,
        string ShortName,
        string PhoneNumber,
        string DepName,
        string PosName
    );

    public record UserFullInfoResponse(
     Guid Id,
     string UserName,
     string Password,
     string FullName,
     string ShortName,
     string PhoneNumber,
     string PosName,
     bool IsAdmin,
     bool IsActual,
     Guid DepId
     
 );


}
