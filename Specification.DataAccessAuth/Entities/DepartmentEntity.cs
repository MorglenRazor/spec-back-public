using Specification.Core.Abstractions.BaseEntity;

namespace Specification.DataAccessAuth.Entities
{
    public class DepartmentEntity : IDepartmentBaseEntity
    {
        public Guid Id { get; set; }
        public string DepartmentName { get; set; } = string.Empty;
        public string DepShortName { get; set; } = string.Empty;
        public List<UserEntity> Employers { get; set; } = [];
    }
}
