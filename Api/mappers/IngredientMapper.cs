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
    CreateMap<(IngredientNoIdDto, int), Ingredient>()
      .ForMember(i => i.Id, x => x.MapFrom(n => n.Item2))
      .ForMember(i => i.Name, x => x.MapFrom(n => n.Item1.Name))
      .ForMember(i => i.Price, x => x.MapFrom(n => n.Item1.Price))
      .ForMember(i => i.Stock, x => x.MapFrom(n => n.Item1.Stock))
      .ReverseMap();
  }
}