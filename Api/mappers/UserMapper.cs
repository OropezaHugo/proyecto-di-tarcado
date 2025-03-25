using AutoMapper;
using Core.dtos.dtoID;
using Core.dtos.dtoNoID;
using Core.Entities;

namespace Api.mappers;

public class UserMapper: Profile
{
  public UserMapper()
  {
    CreateMap<UserDto, User>().ReverseMap();
    CreateMap<UserNoIdDto, User>()
      .ForMember(i => i.Name, x => x.MapFrom(n => n.Name))
      .ForMember(i => i.BirthDate, x => x.MapFrom(n => n.BirthDate))
      .ReverseMap();
  }
}
