using Api.idHelper;
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
  private readonly IIdHelper<PlateOrder> _idHelper;

  public PlateOrderService(PlateOrderRepository repository, IMapper mapper, IIdHelper<PlateOrder> idHelper)
  {
    _repository = repository;
    _mapper = mapper;
    _idHelper = idHelper;
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
    var nextId = _idHelper.ObtenerUltimoId(await _repository.GetAll()) + 1;
    var mappedEntity = _mapper.Map<PlateOrder>((entity, nextId));
    
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