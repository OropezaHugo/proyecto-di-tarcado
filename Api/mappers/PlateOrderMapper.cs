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
    CreateMap<PlateOrderNoIdDto, PlateOrder>()
      .ForMember(i => i.PlateId, x => x.MapFrom(n => n.PlateId))
      .ForMember(i => i.Quantity, x => x.MapFrom(n => n.Quantity))
      .ReverseMap();
  }
}
