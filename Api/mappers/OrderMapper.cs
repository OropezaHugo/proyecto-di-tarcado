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
    CreateMap<(OrderNoIdDto, int), Order>()
      .ForMember(i => i.Id, x => x.MapFrom(n => n.Item2))
      .ForMember(i => i.UserId, x => x.MapFrom(n => n.Item1.UserId))
      .ForMember(i => i.PlateOrderId, x => x.MapFrom(n => n.Item1.PlateOrderId))
      .ReverseMap();
  }
  
}