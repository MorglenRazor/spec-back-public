namespace Specification.Core.Abstractions.BaseEntity
{
    public interface IDepartmentBaseEntity
    {
        public Guid Id { get; set; }
        public string DepartmentName { get; set; }
        public string DepShortName { get; set; }
    }
}
