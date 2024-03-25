using AutoMapper;
using LunaStore.Application.DTOs;
using LunaStore.Application.Products.Commands;

namespace LunaStore.Application.Mappings
{
    public class DTOToCommandMappingProfile : Profile
    {
        public DTOToCommandMappingProfile()
        {
            CreateMap<ProductDTO, ProductCreateCommand>();
            CreateMap<ProductDTO, ProductUpdateCommand>();
        }
    }
}
