namespace Specification.API.Contracts.Auth
{
    public record EmployerRequest(
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
