namespace Specification.Core.Models.Auth
{
    public class RolesPermissions
    {
        public RolesPermissions(string nameRoles)
        {
            NameRoles = nameRoles;
        }

        public string NameRoles { get; } = string.Empty;
    }
}
