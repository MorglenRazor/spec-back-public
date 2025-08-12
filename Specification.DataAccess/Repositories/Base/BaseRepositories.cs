namespace Specification.DataAccess.Repositories.Base;

/// <summary>
/// Реализует контекс базы
/// </summary>
/// <param name="dbContext">Контекст базы</param>
public abstract class BaseRepositories(SpecificationDataBaseContext dbContext)
{
     protected readonly SpecificationDataBaseContext DataBaseContext =  dbContext;
}
