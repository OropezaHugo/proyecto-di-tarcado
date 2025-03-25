using Core.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Api.repositories;

public class UserRepository: IRepository<User>
{
  private readonly EscaleContext _context;

  public UserRepository(EscaleContext context)
  {
    _context = context;
  }
  
  public async Task<IEnumerable<User>> GetAll()
  {
    return await _context.Users.ToListAsync();
  }

  public async Task<User?> GetById(int id)
  {
    return await _context.Users.FindAsync(id);
  }

  public async Task<bool> Delete(int id)
  {
    var user = await _context.Users.FindAsync(id);
    
    if (user == null)
      return false;
    
    _context.Users.Remove(user);
    await _context.SaveChangesAsync();
    return true;
  }

  public async Task<User> Add(User entity)
  {
    _context.Users.Add(entity);
    await _context.SaveChangesAsync();
    return entity;
  }

  public async Task<User> Update(User entity)
  {
    var existingUser = await _context.Users.AsNoTracking().FirstOrDefaultAsync(u => u.Id == entity.Id);
    
    if (existingUser != null)
    {
      var trackedUser = _context.Users.Local.FirstOrDefault(u => u.Id == entity.Id);
      if (trackedUser != null)
      {
        _context.Entry(trackedUser).State = EntityState.Detached;
      }
    }

    _context.Users.Update(entity);
    await _context.SaveChangesAsync();
    return entity;
  }
}
