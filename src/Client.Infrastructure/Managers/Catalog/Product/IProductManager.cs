using MarkWildmanNerdMathWorkouts.Application.Features.Products.Commands.AddEdit;
using MarkWildmanNerdMathWorkouts.Application.Features.Products.Queries.GetAllPaged;
using MarkWildmanNerdMathWorkouts.Application.Requests.Catalog;
using MarkWildmanNerdMathWorkouts.Shared.Wrapper;
using System.Threading.Tasks;

namespace MarkWildmanNerdMathWorkouts.Client.Infrastructure.Managers.Catalog.Product
{
    public interface IProductManager : IManager
    {
        Task<PaginatedResult<GetAllPagedProductsResponse>> GetProductsAsync(GetAllPagedProductsRequest request);

        Task<IResult<string>> GetProductImageAsync(int id);

        Task<IResult<int>> SaveAsync(AddEditProductCommand request);

        Task<IResult<int>> DeleteAsync(int id);

        Task<IResult<string>> ExportToExcelAsync(string searchString = "");
    }
}