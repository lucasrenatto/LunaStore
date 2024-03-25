using AutoMapper;
using LunaStore.Application.DTOs;
using LunaStore.Domain.Entities;

namespace LunaStore.Application.Mappings
{
    public class DomainToDTOMappingProfile : Profile
    {
        public DomainToDTOMappingProfile()
        {
            CreateMap<CategoryEntity, CategoryDTO>().ReverseMap();
            CreateMap<ProductEntity, ProductDTO>().ReverseMap();

        }
    }
}
