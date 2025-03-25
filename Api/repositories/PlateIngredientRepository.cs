using Core.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Api.repositories;

public class PlateIngredientRepository: IRepository<PlateIngredients>
{
  private readonly EscaleContext _context;

  public PlateIngredientRepository(EscaleContext context)
  {
    _context = context;
  }
  
  public async Task<IEnumerable<PlateIngredients>> GetAll()
  {
    return await _context.PlateIngredients.ToListAsync();
  }

  public async Task<PlateIngredients?> GetById(int id)
  {
    return await _context.PlateIngredients.FindAsync(id);
  }

  public async Task<bool> Delete(int id)
  {
    var plateIngredients = await _context.PlateIngredients.FindAsync(id);
    
    if (plateIngredients == null)
      return false;
    
    _context.PlateIngredients.Remove(plateIngredients);
    await _context.SaveChangesAsync();
    return true;
  }

  public async Task<PlateIngredients> Add(PlateIngredients entity)
  {
    var plateExists = await _context.Plates.AnyAsync(p => p.Id == entity.PlateId);
    if (!plateExists)
    {
      throw new Exception($"El plato con ID {entity.PlateId} no existe.");
    }
    
    var ingredientExists = await _context.Ingredients.AnyAsync(i => i.Id == entity.IngredientId);
    if (!ingredientExists)
    {
      throw new Exception($"El ingrediente con ID {entity.IngredientId} no existe.");
    }
    _context.PlateIngredients.Add(entity);
    await _context.SaveChangesAsync();
    return entity;
  }

  public async Task<PlateIngredients> Update(PlateIngredients entity)
  {
    var existingPlateIngredient = await _context.PlateIngredients.AsNoTracking().FirstOrDefaultAsync(i => i.Id == entity.Id);

    if (existingPlateIngredient != null)
    {
      var trackedPlateIngredient = _context.PlateIngredients.Local.FirstOrDefault(i => i.Id == existingPlateIngredient.Id);
      if(trackedPlateIngredient != null)
        _context.Entry(trackedPlateIngredient).State = EntityState.Detached;
    }
    
    _context.PlateIngredients.Update(entity);
    await _context.SaveChangesAsync();
    return entity;
  }
}
