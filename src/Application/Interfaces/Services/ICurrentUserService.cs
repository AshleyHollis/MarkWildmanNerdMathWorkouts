using MarkWildmanNerdMathWorkouts.Application.Interfaces.Common;

namespace MarkWildmanNerdMathWorkouts.Application.Interfaces.Services
{
    public interface ICurrentUserService : IService
    {
        string UserId { get; }
    }
}