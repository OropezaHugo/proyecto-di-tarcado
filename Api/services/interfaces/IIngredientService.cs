using Core.dtos.dtoID;
using Core.dtos.dtoNoID;
using Core.Entities;

namespace Api.services.interfaces;

public interface IIngredientService
{
  public Task<IEnumerable<IngredientDto>> GetAll();
  public Task<IngredientDto?> GetById(int id);
  public Task<bool> Delete(int id);
  public Task<IngredientDto?> Add(IngredientNoIdDto entity);
  public Task<IngredientDto> Put(IngredientDto entity);
}