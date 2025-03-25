using AutoMapper;
using Core.dtos.dtoID;
using Core.dtos.dtoNoID;
using Core.Entities;

namespace Api.mappers;

public class PlateMapper: Profile
{
  public PlateMapper()
  {
    CreateMap<PlateDto, Plate>().ReverseMap();
    CreateMap<PlateNoIdDto, Plate>()
      .ForMember(i => i.Name, x => x.MapFrom(z => z.Name))
      .ForMember(i => i.Price, x => x.MapFrom(z => z.Price))
      .ReverseMap();
  }
}
