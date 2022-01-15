using MarkWildmanNerdMathWorkouts.Application.Requests.Identity;
using MarkWildmanNerdMathWorkouts.Application.Responses.Identity;
using MarkWildmanNerdMathWorkouts.Shared.Wrapper;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MarkWildmanNerdMathWorkouts.Client.Infrastructure.Managers.Identity.Roles
{
    public interface IRoleManager : IManager
    {
        Task<IResult<List<RoleResponse>>> GetRolesAsync();

        Task<IResult<string>> SaveAsync(RoleRequest role);

        Task<IResult<string>> DeleteAsync(string id);

        Task<IResult<PermissionResponse>> GetPermissionsAsync(string roleId);

        Task<IResult<string>> UpdatePermissionsAsync(PermissionRequest request);
    }
}