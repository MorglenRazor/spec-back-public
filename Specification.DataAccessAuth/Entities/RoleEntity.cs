namespace Specification.DataAccessAuth.Entities
{
    public class RoleEntity
    {
        public int Id { get; set; }
        public string NameRole { get; set; } = string.Empty;
        public List<UserEntity> Users { get; set; } = [];
    }
}
