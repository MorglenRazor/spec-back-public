namespace Specification.Core.Abstractions.Service;

public interface IHandbookService<T>
    where T : class
{
    public Task<List<T>> Get();
    public Task Add(T model);
    public Task Update(int id, T model);
    public Task Delete(int id);
}
