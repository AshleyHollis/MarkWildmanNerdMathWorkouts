using MarkWildmanNerdMathWorkouts.Application.Features.Documents.Commands.AddEdit;
using MarkWildmanNerdMathWorkouts.Application.Features.Documents.Queries.GetAll;
using MarkWildmanNerdMathWorkouts.Application.Requests.Documents;
using MarkWildmanNerdMathWorkouts.Shared.Wrapper;
using System.Threading.Tasks;
using MarkWildmanNerdMathWorkouts.Application.Features.Documents.Queries.GetById;

namespace MarkWildmanNerdMathWorkouts.Client.Infrastructure.Managers.Misc.Document
{
    public interface IDocumentManager : IManager
    {
        Task<PaginatedResult<GetAllDocumentsResponse>> GetAllAsync(GetAllPagedDocumentsRequest request);

        Task<IResult<GetDocumentByIdResponse>> GetByIdAsync(GetDocumentByIdQuery request);

        Task<IResult<int>> SaveAsync(AddEditDocumentCommand request);

        Task<IResult<int>> DeleteAsync(int id);
    }
}