namespace Specification.Core.Abstractions.Service;

public interface ITableService<T>
    where T : class
{
    Task<List<T>> Get(Guid id);
    Task Add(T model);
    Task Update(Guid id, T model);
    Task Delete(Guid id);
}
