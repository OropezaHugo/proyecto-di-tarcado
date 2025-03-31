using Core.Entities;

namespace Api.repositories;

public interface IUserRepository
{
    
    public Task<IEnumerable<User>> GetAll();
    public Task<User?> GetById(Guid id);
    public Task<bool> Delete(Guid id);
    public Task<User> Add(User entity);
    public Task<User> Update(User entity);
}