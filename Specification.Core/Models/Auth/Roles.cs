namespace Specification.Core.Models.Auth
{
    public class Roles
    {
        private Roles(int id, string nameRole)
        {
            Id = id;
            NameRole = nameRole;
        }

        public int Id { get; private set; }
        public string NameRole { get; private set; } = string.Empty;

        public static Roles Create(int id, string nameRole)
        {
            Roles roles = new Roles(id, nameRole);
            return roles;
        }
    }
}
