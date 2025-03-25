using Api.repositories;
using Api.services.interfaces;
using AutoMapper;
using Core.dtos.dtoID;
using Core.dtos.dtoNoID;
using Core.Entities;

namespace Api.services;

public class IngredientsService: IIngredientService
{
  private readonly IngrdientsRepository _repository;
  private readonly IMapper _mapper;

  public IngredientsService(IngrdientsRepository repository, IMapper mapper)
  {
    _repository = repository;
    _mapper = mapper;
  }


  public async Task<IEnumerable<IngredientDto>> GetAll()
  {
    var entities = await _repository.GetAll();
    var entitysDto = _mapper.Map<List<IngredientDto>>(entities);
    return entitysDto;
  }

  public async Task<IngredientDto?> GetById(int id)
  {
    var entity = await _repository.GetById(id);
    var entityDto = _mapper.Map<IngredientDto?>(entity);
    return entityDto;  
  }

  public async Task<bool> Delete(int id)
  {
    return await _repository.Delete(id);
  }

  public async Task<IngredientDto?> Add(IngredientNoIdDto entity)
  {
    var mappedEntity = _mapper.Map<Ingredient>(entity);
    
    var newEntity = await _repository.Add(mappedEntity);
    var entityDto = _mapper.Map<IngredientDto?>(newEntity);
    
    return entityDto;
  }

  public async Task<IngredientDto> Put(IngredientDto entity)
  {
    var mappedEntity = _mapper.Map<Ingredient>(entity);
    var newEntity = await _repository.Update(mappedEntity);
    var entityDto = _mapper.Map<IngredientDto>(newEntity);
    return entityDto;
  }
}
