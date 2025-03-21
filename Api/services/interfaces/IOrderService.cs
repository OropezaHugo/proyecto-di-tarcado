using Core.dtos.dtoID;
using Core.dtos.dtoNoID;

namespace Api.services.interfaces;

public interface IOrderService
{
  public Task<IEnumerable<OrderDto>> GetAll();
  public Task<OrderDto?> GetById(int id);
  public Task<bool> Delete(int id);
  public Task<OrderDto?> Add(OrderNoIdDto entity);
  public Task<OrderDto> Put(OrderDto entity);
}