using Api.repositories;
using Api.services.interfaces;
using AutoMapper;
using Core.dtos.dtoID;
using Core.dtos.dtoNoID;
using Core.Entities;

namespace Api.services;

public class OrderService: IOrderService
{
  private readonly OrderRepository _repository;
  private readonly IMapper _mapper;

  public OrderService(OrderRepository repository, IMapper mapper)
  {
    _repository = repository;
    _mapper = mapper;
  }
  
  public async Task<IEnumerable<OrderDto>> GetAll()
  {
    var entities = await _repository.GetAll();
    var entitysDto = _mapper.Map<List<OrderDto>>(entities);
    return entitysDto;
  }

  public async Task<OrderDto?> GetById(int id)
  {
    var entity = await _repository.GetById(id);
    var entityDto = _mapper.Map<OrderDto?>(entity);
    return entityDto;  
  }

  public async Task<bool> Delete(int id)
  {
    return await _repository.Delete(id);
  }

  public async Task<OrderDto?> Add(OrderNoIdDto entity)
  {
    var mappedEntity = _mapper.Map<Order>(entity);
    
    var newEntity = await _repository.Add(mappedEntity);
    var entityDto = _mapper.Map<OrderDto?>(newEntity);
    
    return entityDto;
  }

  public async Task<OrderDto> Put(OrderDto entity)
  {
    var mappedEntity = _mapper.Map<Order>(entity);
    var newEntity = await _repository.Update(mappedEntity);
    var entityDto = _mapper.Map<OrderDto>(newEntity);
    return entityDto;
  }
}
