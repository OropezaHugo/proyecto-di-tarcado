using Core.dtos.dtoID;
using Core.dtos.dtoNoID;

namespace Api.services.interfaces;

public interface IPlateIngredientService
{
  public Task<IEnumerable<PlateIngredientDto>> GetAll();
  public Task<PlateIngredientDto?> GetById(int id);
  public Task<bool> Delete(int id);
  public Task<PlateIngredientDto?> Add(PlateIngredientNoIdDto entity);
  public Task<PlateIngredientDto> Put(PlateIngredientDto entity);
}