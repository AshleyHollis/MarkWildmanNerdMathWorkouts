using System.Collections.Generic;

namespace MarkWildmanNerdMathWorkouts.Application.Responses.Identity
{
    public class GetAllUsersResponse
    {
        public IEnumerable<UserResponse> Users { get; set; }
    }
}