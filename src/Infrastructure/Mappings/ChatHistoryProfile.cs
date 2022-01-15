using AutoMapper;
using MarkWildmanNerdMathWorkouts.Application.Interfaces.Chat;
using MarkWildmanNerdMathWorkouts.Application.Models.Chat;
using MarkWildmanNerdMathWorkouts.Infrastructure.Models.Identity;

namespace MarkWildmanNerdMathWorkouts.Infrastructure.Mappings
{
    public class ChatHistoryProfile : Profile
    {
        public ChatHistoryProfile()
        {
            CreateMap<ChatHistory<IChatUser>, ChatHistory<BlazorHeroUser>>().ReverseMap();
        }
    }
}