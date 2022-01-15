using AutoMapper;
using MarkWildmanNerdMathWorkouts.Application.Features.Brands.Commands.AddEdit;
using MarkWildmanNerdMathWorkouts.Application.Features.Brands.Queries.GetAll;
using MarkWildmanNerdMathWorkouts.Application.Features.Brands.Queries.GetById;
using MarkWildmanNerdMathWorkouts.Domain.Entities.Catalog;

namespace MarkWildmanNerdMathWorkouts.Application.Mappings
{
    public class BrandProfile : Profile
    {
        public BrandProfile()
        {
            CreateMap<AddEditBrandCommand, Brand>().ReverseMap();
            CreateMap<GetBrandByIdResponse, Brand>().ReverseMap();
            CreateMap<GetAllBrandsResponse, Brand>().ReverseMap();
        }
    }
}