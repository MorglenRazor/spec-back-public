namespace Specification.DataAccess.Entities.Auth
{
    public class RoleEntity
    {
        public int Id { get; set; }
        public string NameRole { get; set; } = string.Empty;
        public List<EmployerEntity> Employers { get; set; } = [];
    }
}
