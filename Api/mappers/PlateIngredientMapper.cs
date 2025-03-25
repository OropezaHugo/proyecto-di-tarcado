using AutoMapper;
using Core.dtos.dtoID;
using Core.dtos.dtoNoID;
using Core.Entities;

namespace Api.mappers;

public class PlateIngredientMapper: Profile
{
  public PlateIngredientMapper()
  {
    CreateMap<PlateIngredientDto, PlateIngredients>().ReverseMap();
    CreateMap<PlateIngredientNoIdDto, PlateIngredients>()
      .ForMember(i => i.PlateId, x => x.MapFrom(n => n.PlateId))
      .ForMember(i => i.IngredientId, x => x.MapFrom(n => n.IngredientId))
      .ReverseMap();
  }
}
