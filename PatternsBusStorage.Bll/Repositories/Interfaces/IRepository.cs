namespace PatternsBusStorage.Application.Repositories;

public interface IRepository<T>
{
    Task<T> GetById(int id);
    Task<IEnumerable<T>> GetAll();
    Task<T> Add(T entity);
    Task<T> Update(T entity);
    Task<string> Delete(int id);
}