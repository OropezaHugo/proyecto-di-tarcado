using Core.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Api.repositories;

public class IngrdientsRepository : IRepository<Ingredient>
{
  private readonly EscaleContext _context;

  public IngrdientsRepository(EscaleContext context)
  {
    _context = context;
  }
  
  public async Task<IEnumerable<Ingredient>> GetAll()
  {
    return await _context.Ingredients.ToListAsync();
  }

  public async Task<Ingredient?> GetById(int id)
  {
    return await _context.Ingredients.FindAsync(id);
  }

  public async Task<bool> Delete(int id)
  {
    var ingredient = await _context.Ingredients.FindAsync(id);
    
    if (ingredient == null)
      return false;
    
    _context.Ingredients.Remove(ingredient);
    await _context.SaveChangesAsync();
    return true;
  }

  public async Task<Ingredient> Add(Ingredient entity)
  {
    _context.Ingredients.Add(entity);
    await _context.SaveChangesAsync();
    return entity;
  }

  public async Task<Ingredient> Update(Ingredient entity)
  {
    _context.Ingredients.Update(entity);
    await _context.SaveChangesAsync();
    return entity;
  }
}
