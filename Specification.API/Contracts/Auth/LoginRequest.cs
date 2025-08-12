namespace Specification.API.Contracts.Auth
{
    public record SignInRequestType1(string UserName, string Password);

    public record SignInRequestType2(Guid DepId, Guid EmpId, string Password);

    public record AddRole(Guid UserId, int RoleId);
}
