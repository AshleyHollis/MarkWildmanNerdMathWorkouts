using AutoMapper;
using MarkWildmanNerdMathWorkouts.Application.Requests.Identity;
using MarkWildmanNerdMathWorkouts.Application.Responses.Identity;

namespace MarkWildmanNerdMathWorkouts.Client.Infrastructure.Mappings
{
    public class RoleProfile : Profile
    {
        public RoleProfile()
        {
            CreateMap<PermissionResponse, PermissionRequest>().ReverseMap();
            CreateMap<RoleClaimResponse, RoleClaimRequest>().ReverseMap();
        }
    }
}