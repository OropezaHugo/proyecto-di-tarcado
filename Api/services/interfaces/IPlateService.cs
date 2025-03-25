using Core.dtos.dtoID;
using Core.dtos.dtoNoID;

namespace Api.services.interfaces;

public interface IPlateService
{
  public Task<IEnumerable<PlateDto>> GetAll();
  public Task<PlateDto?> GetById(int id);
  public Task<bool> Delete(int id);
  public Task<PlateDto?> Add(PlateNoIdDto entity);
  public Task<PlateDto> Put(PlateDto entity);
}
