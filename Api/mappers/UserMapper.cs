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
    CreateMap<(UserNoIdDto, int), User>()
      .ForMember(i => i.Id, x => x.MapFrom(n => n.Item2))
      .ForMember(i => i.Name, x => x.MapFrom(n => n.Item1.Name))
      .ForMember(i => i.BirthDate, x => x.MapFrom(n => n.Item1.BirthDate))
      .ReverseMap();
  }
}