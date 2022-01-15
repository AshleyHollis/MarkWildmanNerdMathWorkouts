using AutoMapper;
using MarkWildmanNerdMathWorkouts.Infrastructure.Models.Identity;
using MarkWildmanNerdMathWorkouts.Application.Responses.Identity;

namespace MarkWildmanNerdMathWorkouts.Infrastructure.Mappings
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserResponse, BlazorHeroUser>().ReverseMap();
            CreateMap<ChatUserResponse, BlazorHeroUser>().ReverseMap()
                .ForMember(dest => dest.EmailAddress, source => source.MapFrom(source => source.Email)); //Specific Mapping
        }
    }
}