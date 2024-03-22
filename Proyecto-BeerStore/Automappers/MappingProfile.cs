using AutoMapper;
using Proyecto_BeerStore.DTOs;
using Proyecto_BeerStore.Models;

namespace Proyecto_BeerStore.Automappers;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<BeerInsertDto, Beer>();
        CreateMap<BeerUpdateDto, Beer>();
        CreateMap<Beer, BeerDto>().ForMember(b => b.Id,
            m => m.MapFrom(b => b.BeerId));
    }
}