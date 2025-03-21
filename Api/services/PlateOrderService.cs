using Api.repositories;
using Api.services.interfaces;
using AutoMapper;
using Core.dtos.dtoID;
using Core.dtos.dtoNoID;
using Core.Entities;

namespace Api.services;

public class PlateOrderService : IPlateOrderService
{
  private readonly PlateOrderRepository _repository;
  private readonly IMapper _mapper;

  public PlateOrderService(PlateOrderRepository repository, IMapper mapper)
  {
    _repository = repository;
    _mapper = mapper;
  }
  
  public async Task<IEnumerable<PlateOrderDto>> GetAll()
  {
    var entities = await _repository.GetAll();
    var entitysDto = _mapper.Map<List<PlateOrderDto>>(entities);
    return entitysDto;
  }

  public async Task<PlateOrderDto?> GetById(int id)
  {
    var entity = await _repository.GetById(id);
    var entityDto = _mapper.Map<PlateOrderDto?>(entity);
    return entityDto;  
  }

  public async Task<bool> Delete(int id)
  {
    return await _repository.Delete(id);
  }

  public async Task<PlateOrderDto?> Add(PlateOrderNoIdDto entity)
  {
    var mappedEntity = _mapper.Map<PlateOrder>(entity);
    
    var newEntity = await _repository.Add(mappedEntity);
    var entityDto = _mapper.Map<PlateOrderDto?>(newEntity);
    
    return entityDto;
  }

  public async Task<PlateOrderDto> Put(PlateOrderDto entity)
  {
    var mappedEntity = _mapper.Map<PlateOrder>(entity);
    var newEntity = await _repository.Update(mappedEntity);
    var entityDto = _mapper.Map<PlateOrderDto>(newEntity);
    return entityDto;
  }
}
