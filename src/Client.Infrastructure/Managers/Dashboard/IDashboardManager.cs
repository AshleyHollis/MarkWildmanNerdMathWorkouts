using MarkWildmanNerdMathWorkouts.Shared.Wrapper;
using System.Threading.Tasks;
using MarkWildmanNerdMathWorkouts.Application.Features.Dashboards.Queries.GetData;

namespace MarkWildmanNerdMathWorkouts.Client.Infrastructure.Managers.Dashboard
{
    public interface IDashboardManager : IManager
    {
        Task<IResult<DashboardDataResponse>> GetDataAsync();
    }
}