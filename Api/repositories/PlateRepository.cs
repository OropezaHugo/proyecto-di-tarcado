using Core.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Api.repositories;

public class PlateRepository: IRepository<Plate>
{
  private readonly EscaleContext _context;

  public PlateRepository(EscaleContext context)
  {
    _context = context;
  }
  
  public async Task<IEnumerable<Plate>> GetAll()
  {
    return await _context.Plates.ToListAsync();
  }

  public async Task<Plate?> GetById(int id)
  {
    return await _context.Plates.FindAsync(id);
  }

  public async Task<bool> Delete(int id)
  {
    var plate = await _context.Plates.FindAsync(id);
    
    if (plate == null)
      return false;
    
    _context.Plates.Remove(plate);
    await _context.SaveChangesAsync();
    return true;
  }

  public async Task<Plate> Add(Plate entity)
  {
    _context.Plates.Add(entity);
    await _context.SaveChangesAsync();
    return entity;
  }

  public async Task<Plate> Update(Plate entity)
  {
    var existingPlate = await _context.Plates
      .Include(x => x.PlateIngredients)
      .Include(x => x.UserPlates)
      .FirstOrDefaultAsync(x => x.Id == entity.Id);

    if (existingPlate != null)
    {
      var trackedPlate = _context.Plates.Local.FirstOrDefault(x => x.Id == entity.Id);
      if(trackedPlate != null)
        _context.Entry(trackedPlate).State = EntityState.Detached;
    }

    foreach (var plateIngredient in entity.PlateIngredients)
      _context.Entry(plateIngredient).State = EntityState.Detached;
    
    foreach (var plateIngredient in entity.UserPlates)
      _context.Entry(plateIngredient).State = EntityState.Detached;
    
    _context.Plates.Update(entity);
    await _context.SaveChangesAsync();
    return entity;
  }
}
