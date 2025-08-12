namespace Specification.DataAccessAuth.Entities
{
    public class UserEntity
    {
        public Guid Id { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        public string ShortName { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string PositionName { get; set; } = string.Empty;
        public Guid DepartmentId { get; set; }
        public DepartmentEntity? Department { get; set; }
        public List<RoleEntity> Roles { get; set; } = [];
    }
}
