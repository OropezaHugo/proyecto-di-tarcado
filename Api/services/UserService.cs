using Api.repositories;
using Api.services.interfaces;
using AutoMapper;
using Core.dtos.dtoID;
using Core.dtos.dtoNoID;
using Core.Entities;

namespace Api.services;

public class UserService:  IUserService
{
  private readonly UserRepository _repository;
  private readonly IMapper _mapper;

  public UserService(UserRepository repository, IMapper mapper)
  {
    _repository = repository;
    _mapper = mapper;
  }
  
  public async Task<IEnumerable<UserDto>> GetAll()
  {
    var entities = await _repository.GetAll();
    var entitysDto = _mapper.Map<List<UserDto>>(entities);
    return entitysDto;
  }

  public async Task<UserDto?> GetById(Guid id)
  {
    var entity = await _repository.GetById(id);
    var entityDto = _mapper.Map<UserDto?>(entity);
    return entityDto;  
  }

  public async Task<bool> Delete(Guid id)
  {
    return await _repository.Delete(id);
  }

  public async Task<UserDto?> Add(UserNoIdDto entity)
  {
    var mappedEntity = _mapper.Map<User>(entity);
    
    var newEntity = await _repository.Add(mappedEntity);
    var entityDto = _mapper.Map<UserDto?>(newEntity);
    
    return entityDto;
  }

  public async Task<UserDto> Put(UserDto entity)
  {
    var mappedEntity = _mapper.Map<User>(entity);
    var newEntity = await _repository.Update(mappedEntity);
    var entityDto = _mapper.Map<UserDto>(newEntity);
    return entityDto;
  }
}
