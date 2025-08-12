namespace Specification.Core.Models;

public class Department
{
    private Department(Guid id, string name, string shortName)
    {
        Id = id;
        Name = name;
        ShortName = shortName;
    }

    public static (Department dep, string err) Create(Guid id, string name, string shortName)
    {
        Department dep = new Department(id, name, shortName);
        return (dep, "Без ошибок");
    }

    public Guid Id { get; }

    /// <summary>
    /// Наименование отдела
    /// </summary>
    public string Name { get; }

    /// <summary>
    /// Сокращеное наименование отдела
    /// </summary>
    public string ShortName { get; }
}
