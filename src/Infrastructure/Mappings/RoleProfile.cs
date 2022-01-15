using AutoMapper;
using MarkWildmanNerdMathWorkouts.Infrastructure.Models.Identity;
using MarkWildmanNerdMathWorkouts.Application.Responses.Identity;

namespace MarkWildmanNerdMathWorkouts.Infrastructure.Mappings
{
    public class RoleProfile : Profile
    {
        public RoleProfile()
        {
            CreateMap<RoleResponse, BlazorHeroRole>().ReverseMap();
        }
    }
}