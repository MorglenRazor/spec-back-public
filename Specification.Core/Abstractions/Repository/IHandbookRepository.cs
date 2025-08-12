namespace Specification.Core.Abstractions.Repository;

public interface IHandbookRepository<T>
    where T : class
{
    Task<List<T>> Get();
    Task Add(T model);
    Task Update(int id, T model);
    Task Delete(int id);
}
