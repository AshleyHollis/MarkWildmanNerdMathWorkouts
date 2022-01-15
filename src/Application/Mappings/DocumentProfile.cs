using AutoMapper;
using MarkWildmanNerdMathWorkouts.Application.Features.Documents.Commands.AddEdit;
using MarkWildmanNerdMathWorkouts.Application.Features.Documents.Queries.GetById;
using MarkWildmanNerdMathWorkouts.Domain.Entities.Misc;

namespace MarkWildmanNerdMathWorkouts.Application.Mappings
{
    public class DocumentProfile : Profile
    {
        public DocumentProfile()
        {
            CreateMap<AddEditDocumentCommand, Document>().ReverseMap();
            CreateMap<GetDocumentByIdResponse, Document>().ReverseMap();
        }
    }
}