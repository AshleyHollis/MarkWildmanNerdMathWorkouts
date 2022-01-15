using AutoMapper;
using MarkWildmanNerdMathWorkouts.Application.Features.Products.Commands.AddEdit;
using MarkWildmanNerdMathWorkouts.Domain.Entities.Catalog;

namespace MarkWildmanNerdMathWorkouts.Application.Mappings
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<AddEditProductCommand, Product>().ReverseMap();
        }
    }
}