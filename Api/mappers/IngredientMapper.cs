using AutoMapper;
using Core.dtos.dtoID;
using Core.dtos.dtoNoID;
using Core.Entities;

namespace Api.mappers;

public class IngredientMapper: Profile
{
  public IngredientMapper()
  {
    CreateMap<IngredientDto, Ingredient>().ReverseMap();
    CreateMap<IngredientNoIdDto, Ingredient>()
      .ForMember(i => i.Name, x => x.MapFrom(n => n.Name))
      .ForMember(i => i.Price, x => x.MapFrom(n => n.Price))
      .ForMember(i => i.Stock, x => x.MapFrom(n => n.Stock))
      .ReverseMap();
  }
}
