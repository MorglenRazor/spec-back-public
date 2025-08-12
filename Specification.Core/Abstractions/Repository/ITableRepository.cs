namespace Specification.Core.Abstractions.Repository;

public interface ITableRepository<T>
    where T : class
{
    Task<List<T>> Get(Guid id);
    Task Add(T model);
    Task Update(Guid id, T model);
    Task Delete(Guid id);
}
