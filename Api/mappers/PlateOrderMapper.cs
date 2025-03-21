using AutoMapper;
using Core.dtos.dtoID;
using Core.dtos.dtoNoID;
using Core.Entities;

namespace Api.mappers;

public class PlateOrderMapper: Profile
{
  public PlateOrderMapper()
  {
    CreateMap<PlateOrderDto, PlateOrder>().ReverseMap();
    CreateMap<(PlateOrderNoIdDto, int), PlateOrder>()
      .ForMember(i => i.Id, x => x.MapFrom(n => n.Item2))
      .ForMember(i => i.PlateId, x => x.MapFrom(n => n.Item1.PlateId))
      .ForMember(i => i.Quantity, x => x.MapFrom(n => n.Item1.Quantity))
      .ReverseMap();
  }
}