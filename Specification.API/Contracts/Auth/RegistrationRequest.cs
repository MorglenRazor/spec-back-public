namespace Specification.API.Contracts.Auth
{
    public record RegistrationRequest(
        string UserName,
        string Password,
        string FullName,
        string ShortName,
        string PhoneNumber,
        string PosName,
        bool isAdmin,
        bool isActual,
        Guid DepId
    );
}
