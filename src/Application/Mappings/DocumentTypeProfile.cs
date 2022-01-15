using AutoMapper;
using MarkWildmanNerdMathWorkouts.Application.Features.DocumentTypes.Commands.AddEdit;
using MarkWildmanNerdMathWorkouts.Application.Features.DocumentTypes.Queries.GetAll;
using MarkWildmanNerdMathWorkouts.Application.Features.DocumentTypes.Queries.GetById;
using MarkWildmanNerdMathWorkouts.Domain.Entities.Misc;

namespace MarkWildmanNerdMathWorkouts.Application.Mappings
{
    public class DocumentTypeProfile : Profile
    {
        public DocumentTypeProfile()
        {
            CreateMap<AddEditDocumentTypeCommand, DocumentType>().ReverseMap();
            CreateMap<GetDocumentTypeByIdResponse, DocumentType>().ReverseMap();
            CreateMap<GetAllDocumentTypesResponse, DocumentType>().ReverseMap();
        }
    }
}