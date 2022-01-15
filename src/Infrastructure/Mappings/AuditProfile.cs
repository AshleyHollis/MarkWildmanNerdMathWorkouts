using AutoMapper;
using MarkWildmanNerdMathWorkouts.Infrastructure.Models.Audit;
using MarkWildmanNerdMathWorkouts.Application.Responses.Audit;

namespace MarkWildmanNerdMathWorkouts.Infrastructure.Mappings
{
    public class AuditProfile : Profile
    {
        public AuditProfile()
        {
            CreateMap<AuditResponse, Audit>().ReverseMap();
        }
    }
}