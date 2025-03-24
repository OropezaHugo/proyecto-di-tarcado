using Core.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Api.repositories;

public class OrderRepository: IRepository<Order>
{
  private readonly EscaleContext _context;

  public OrderRepository(EscaleContext context)
  {
    _context = context;
  }
  
  public async Task<IEnumerable<Order>> GetAll()
  {
    return await _context.Orders.ToListAsync();
  }

  public async Task<Order?> GetById(int id)
  {
    return await _context.Orders.FindAsync(id);
  }

  public async Task<bool> Delete(int id)
  {
    var order = await _context.Orders.FindAsync(id);
    
    if (order == null)
      return false;
    
    _context.Orders.Remove(order);
    await _context.SaveChangesAsync();
    return true;
  }

  public async Task<Order> Add(Order entity)
  {
    _context.Orders.Add(entity);
    await _context.SaveChangesAsync();
    return entity;
  }

  public async Task<Order> Update(Order entity)
  {
    _context.Orders.Update(entity);
    await _context.SaveChangesAsync();
    return entity;
  }
}
