using AutoMapper;
using Core.dtos.dtoID;
using Core.dtos.dtoNoID;
using Core.Entities;

namespace Api.mappers;

public class PlateIngredientMapper: Profile
{
  protected PlateIngredientMapper()
  {
    CreateMap<PlateIngredientDto, PlateIngredients>().ReverseMap();
    CreateMap<(PlateIngredientNoIdDto, int), PlateIngredients>()
      .ForMember(i => i.Id, x => x.MapFrom(n => n.Item2))
      .ForMember(i => i.PlateId, x => x.MapFrom(n => n.Item1.PlateId))
      .ForMember(i => i.IngredientId, x => x.MapFrom(n => n.Item1.IngredientId))
      .ReverseMap();
  }
}