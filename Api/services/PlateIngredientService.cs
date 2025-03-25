using Api.repositories;
using Api.services.interfaces;
using AutoMapper;
using Core.dtos.dtoID;
using Core.dtos.dtoNoID;
using Core.Entities;

namespace Api.services;

public class PlateIngredientService: IPlateIngredientService
{
  private readonly PlateIngredientRepository _repository;
  private readonly IMapper _mapper;

  public PlateIngredientService(PlateIngredientRepository repository, IMapper mapper)
  {
    _repository = repository;
    _mapper = mapper;
  }
  
  public async Task<IEnumerable<PlateIngredientDto>> GetAll()
  {
    var entities = await _repository.GetAll();
    var entitysDto = _mapper.Map<List<PlateIngredientDto>>(entities);
    return entitysDto;
  }

  public async Task<PlateIngredientDto?> GetById(int id)
  {
    var entity = await _repository.GetById(id);
    var entityDto = _mapper.Map<PlateIngredientDto?>(entity);
    return entityDto;  
  }

  public async Task<bool> Delete(int id)
  {
    return await _repository.Delete(id);
  }

  public async Task<PlateIngredientDto?> Add(PlateIngredientNoIdDto entity)
  {
    var mappedEntity = _mapper.Map<PlateIngredients>(entity);
    
    var newEntity = await _repository.Add(mappedEntity);
    var entityDto = _mapper.Map<PlateIngredientDto?>(newEntity);
    
    return entityDto;
  }

  public async Task<PlateIngredientDto> Put(PlateIngredientDto entity)
  {
    var mappedEntity = _mapper.Map<PlateIngredients>(entity);
    var newEntity = await _repository.Update(mappedEntity);
    var entityDto = _mapper.Map<PlateIngredientDto>(newEntity);
    return entityDto;
  }
}
