using Core.dtos.dtoID;
using Core.dtos.dtoNoID;

namespace Api.services.interfaces;

public interface IPlateOrderService
{
  public Task<IEnumerable<PlateOrderDto>> GetAll();
  public Task<PlateOrderDto?> GetById(int id);
  public Task<bool> Delete(int id);
  public Task<PlateOrderDto?> Add(PlateOrderNoIdDto entity);
  public Task<PlateOrderDto> Put(PlateOrderDto entity);
}
