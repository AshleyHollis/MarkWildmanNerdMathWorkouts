using MarkWildmanNerdMathWorkouts.Application.Requests.Identity;
using MarkWildmanNerdMathWorkouts.Application.Responses.Identity;
using MarkWildmanNerdMathWorkouts.Shared.Wrapper;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MarkWildmanNerdMathWorkouts.Client.Infrastructure.Managers.Identity.Users
{
    public interface IUserManager : IManager
    {
        Task<IResult<List<UserResponse>>> GetAllAsync();

        Task<IResult> ForgotPasswordAsync(ForgotPasswordRequest request);

        Task<IResult> ResetPasswordAsync(ResetPasswordRequest request);

        Task<IResult<UserResponse>> GetAsync(string userId);

        Task<IResult<UserRolesResponse>> GetRolesAsync(string userId);

        Task<IResult> RegisterUserAsync(RegisterRequest request);

        Task<IResult> ToggleUserStatusAsync(ToggleUserStatusRequest request);

        Task<IResult> UpdateRolesAsync(UpdateUserRolesRequest request);

        Task<string> ExportToExcelAsync(string searchString = "");
    }
}