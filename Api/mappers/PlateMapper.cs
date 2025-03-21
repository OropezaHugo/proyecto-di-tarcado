using AutoMapper;
using Core.dtos.dtoID;
using Core.dtos.dtoNoID;
using Core.Entities;

namespace Api.mappers;

public class PlateMapper: Profile
{
  protected PlateMapper()
  {
    CreateMap<PlateDto, Plate>().ReverseMap();
    CreateMap<(PlateNoIdDto, int), Plate>()
      .ForMember(i => i.Id, x => x.MapFrom(n => n.Item2))
      .ForMember(i => i.Name, x => x.MapFrom(n => n.Item1.Name))
      .ForMember(i => i.Price, x => x.MapFrom(n => n.Item1.Price))
      .ReverseMap();
  }
}