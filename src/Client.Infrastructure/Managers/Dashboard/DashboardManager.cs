using MarkWildmanNerdMathWorkouts.Client.Infrastructure.Extensions;
using MarkWildmanNerdMathWorkouts.Shared.Wrapper;
using System.Net.Http;
using System.Threading.Tasks;
using MarkWildmanNerdMathWorkouts.Application.Features.Dashboards.Queries.GetData;

namespace MarkWildmanNerdMathWorkouts.Client.Infrastructure.Managers.Dashboard
{
    public class DashboardManager : IDashboardManager
    {
        private readonly HttpClient _httpClient;

        public DashboardManager(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IResult<DashboardDataResponse>> GetDataAsync()
        {
            var response = await _httpClient.GetAsync(Routes.DashboardEndpoints.GetData);
            var data = await response.ToResult<DashboardDataResponse>();
            return data;
        }
    }
}