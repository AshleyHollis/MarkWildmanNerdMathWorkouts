using System.Collections.Generic;
using System.Threading.Tasks;
using MarkWildmanNerdMathWorkouts.Application.Interfaces.Common;
using MarkWildmanNerdMathWorkouts.Application.Requests.Identity;
using MarkWildmanNerdMathWorkouts.Application.Responses.Identity;
using MarkWildmanNerdMathWorkouts.Shared.Wrapper;

namespace MarkWildmanNerdMathWorkouts.Application.Interfaces.Services.Identity
{
    public interface IRoleClaimService : IService
    {
        Task<Result<List<RoleClaimResponse>>> GetAllAsync();

        Task<int> GetCountAsync();

        Task<Result<RoleClaimResponse>> GetByIdAsync(int id);

        Task<Result<List<RoleClaimResponse>>> GetAllByRoleIdAsync(string roleId);

        Task<Result<string>> SaveAsync(RoleClaimRequest request);

        Task<Result<string>> DeleteAsync(int id);
    }
}