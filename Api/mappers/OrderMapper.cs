using AutoMapper;
using Core.dtos.dtoID;
using Core.dtos.dtoNoID;
using Core.Entities;

namespace Api.mappers;

public class OrderMapper: Profile
{
  public OrderMapper()
  {
    CreateMap<OrderDto, Order>().ReverseMap();
    CreateMap<OrderNoIdDto, Order>()
      .ForMember(i => i.UserId, x => x.MapFrom(n => n.UserId))
      .ForMember(i => i.PlateOrderId, x => x.MapFrom(n => n.PlateOrderId))
      .ReverseMap();
  }
  
}
