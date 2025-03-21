namespace Api.repositories;

public interface IRepository<T>
{
  public Task<IEnumerable<T>> GetAll();
  public Task<T?> GetById(int id);
  public Task<bool> Delete(int id);
  public Task<T> Add(T entity);
  public Task<T> Update(T entity);
}
