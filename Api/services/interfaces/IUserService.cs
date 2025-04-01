using Core.dtos.dtoID;
using Core.dtos.dtoNoID;

namespace Api.services.interfaces;

public interface IUserService
{
  public Task<IEnumerable<UserDto>> GetAll();
  public Task<UserDto?> GetById(Guid id);
  public Task<bool> Delete(Guid id);
  public Task<UserDto?> Add(UserNoIdDto entity);
  public Task<UserDto> Put(UserDto entity);
  public Task<IEnumerable<UserDto>> GetUsersByBirthday(DateTime birthday);
  public Task<IEnumerable<UserDto>> GetUsersByBirthdayRange(DateTime start, DateTime end);
}
