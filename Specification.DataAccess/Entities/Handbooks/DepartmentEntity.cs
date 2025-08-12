using Specification.Core.Abstractions.BaseEntity;
using Specification.DataAccess.Entities.Auth;

namespace Specification.DataAccess.Entities.Handbooks;

/// <summary>
/// Справочник отдела
/// </summary>
public class DepartmentEntity
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string ShortName { get; set; } = string.Empty;
    public List<EmployerEntity> Employers { get; set; } = [];
    public List<StatusDeviceHandbookEntity> StatusWork { get; set; } = [];
}
