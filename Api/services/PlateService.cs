using Api.idHelper;
using Api.repositories;
using Api.services.interfaces;
using AutoMapper;
using Core.dtos.dtoID;
using Core.dtos.dtoNoID;
using Core.Entities;

namespace Api.services;

public class PlateService: IPlateService
{
  private readonly PlateRepository _repository;
  private readonly IMapper _mapper;
  private readonly IIdHelper<Plate> _idHelper;

  public PlateService(PlateRepository repository, IMapper mapper, IIdHelper<Plate> idHelper)
  {
    _repository = repository;
    _mapper = mapper;
    _idHelper = idHelper;
  }
  
  public async Task<IEnumerable<PlateDto>> GetAll()
  {
    var entities = await _repository.GetAll();
    var entitysDto = _mapper.Map<List<PlateDto>>(entities);
    return entitysDto;
  }

  public async Task<PlateDto?> GetById(int id)
  {
    var entity = await _repository.GetById(id);
    var entityDto = _mapper.Map<PlateDto?>(entity);
    return entityDto;  
  }

  public async Task<bool> Delete(int id)
  {
    return await _repository.Delete(id);
  }

  public async Task<PlateDto?> Add(PlateNoIdDto entity)
  {
    var nextId = _idHelper.ObtenerUltimoId(await _repository.GetAll()) + 1;
    var mappedEntity = _mapper.Map<Plate>((entity, nextId));
    
    var newEntity = await _repository.Add(mappedEntity);
    var entityDto = _mapper.Map<PlateDto?>(newEntity);
    
    return entityDto;
  }

  public async Task<PlateDto> Put(PlateDto entity)
  {
    var mappedEntity = _mapper.Map<Plate>(entity);
    var newEntity = await _repository.Update(mappedEntity);
    var entityDto = _mapper.Map<PlateDto>(newEntity);
    return entityDto;
  }
}