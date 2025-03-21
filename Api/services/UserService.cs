using Api.idHelper;
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
  private readonly IIdHelper<User> _idHelper;

  public UserService(UserRepository repository, IMapper mapper, IIdHelper<User> idHelper)
  {
    _repository = repository;
    _mapper = mapper;
    _idHelper = idHelper;
  }
  
  public async Task<IEnumerable<UserDto>> GetAll()
  {
    var entities = await _repository.GetAll();
    var entitysDto = _mapper.Map<List<UserDto>>(entities);
    return entitysDto;
  }

  public async Task<UserDto?> GetById(int id)
  {
    var entity = await _repository.GetById(id);
    var entityDto = _mapper.Map<UserDto?>(entity);
    return entityDto;  
  }

  public async Task<bool> Delete(int id)
  {
    return await _repository.Delete(id);
  }

  public async Task<UserDto?> Add(UserNoIdDto entity)
  {
    var nextId = _idHelper.ObtenerUltimoId(await _repository.GetAll()) + 1;
    var mappedEntity = _mapper.Map<User>((entity, nextId));
    
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