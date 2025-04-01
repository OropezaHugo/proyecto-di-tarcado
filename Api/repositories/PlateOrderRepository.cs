using Core.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Api.repositories;

public class PlateOrderRepository: IRepository<PlateOrder>
{
  private readonly EscaleContext _context;

  public PlateOrderRepository(EscaleContext context)
  {
    _context = context;
  }
  
  public async Task<IEnumerable<PlateOrder>> GetAll()
  {
    return await _context.PlateOrders.ToListAsync();
  }

  public async Task<PlateOrder?> GetById(int id)
  {
    return await _context.PlateOrders.FindAsync(id);
  }

  public async Task<bool> Delete(int id)
  {
    var plateOrder = await _context.PlateOrders.FindAsync(id);
    
    if (plateOrder == null)
      return false;
    
    _context.PlateOrders.Remove(plateOrder);
    await _context.SaveChangesAsync();
    return true;
  }

  public async Task<PlateOrder> Add(PlateOrder entity)
  {
    var plateExists = await _context.Plates.AnyAsync(i => i.Id == entity.PlateId);
    if(!plateExists)
      throw new Exception($"El plato con ID {entity.PlateId} no existe.");
    
    _context.PlateOrders.Add(entity);
    await _context.SaveChangesAsync();
    return entity;
  }

  public async Task<PlateOrder> Update(PlateOrder entity)
  {
    var existingPlateOrder = await _context.PlateOrders.AsNoTracking().FirstOrDefaultAsync(x => x.Id == entity.Id);

    if (existingPlateOrder != null)
    {
      var trackedPlateOrder = _context.PlateOrders.Local.FirstOrDefault(x => x.Id == existingPlateOrder.Id);
      if(trackedPlateOrder != null)
        _context.Entry(trackedPlateOrder).State = EntityState.Detached;
    }
    _context.PlateOrders.Update(entity);
    await _context.SaveChangesAsync();
    return entity;
  }
}
