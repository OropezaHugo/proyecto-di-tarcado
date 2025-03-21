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
    var ingredient = await _context.PlateIngredients.FindAsync(id);
    
    if (ingredient == null)
      return false;
    
    _context.PlateIngredients.Remove(ingredient);
    return true;
  }

  public async Task<PlateIngredients> Add(PlateIngredients entity)
  {
    _context.PlateIngredients.Add(entity);
    await _context.SaveChangesAsync();
    return entity;
  }

  public async Task<PlateIngredients> Update(PlateIngredients entity)
  {
    _context.PlateIngredients.Update(entity);
    await _context.SaveChangesAsync();
    return entity;
  }
}
