using System.Collections.Generic;
using System.Threading.Tasks;
using MarkWildmanNerdMathWorkouts.Application.Features.DocumentTypes.Commands.AddEdit;
using MarkWildmanNerdMathWorkouts.Application.Features.DocumentTypes.Queries.GetAll;
using MarkWildmanNerdMathWorkouts.Shared.Wrapper;

namespace MarkWildmanNerdMathWorkouts.Client.Infrastructure.Managers.Misc.DocumentType
{
    public interface IDocumentTypeManager : IManager
    {
        Task<IResult<List<GetAllDocumentTypesResponse>>> GetAllAsync();

        Task<IResult<int>> SaveAsync(AddEditDocumentTypeCommand request);

        Task<IResult<int>> DeleteAsync(int id);

        Task<IResult<string>> ExportToExcelAsync(string searchString = "");
    }
}