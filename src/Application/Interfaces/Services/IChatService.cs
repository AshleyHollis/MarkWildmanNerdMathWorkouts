using MarkWildmanNerdMathWorkouts.Application.Responses.Identity;
using MarkWildmanNerdMathWorkouts.Shared.Wrapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using MarkWildmanNerdMathWorkouts.Application.Interfaces.Chat;
using MarkWildmanNerdMathWorkouts.Application.Models.Chat;

namespace MarkWildmanNerdMathWorkouts.Application.Interfaces.Services
{
    public interface IChatService
    {
        Task<Result<IEnumerable<ChatUserResponse>>> GetChatUsersAsync(string userId);

        Task<IResult> SaveMessageAsync(ChatHistory<IChatUser> message);

        Task<Result<IEnumerable<ChatHistoryResponse>>> GetChatHistoryAsync(string userId, string contactId);
    }
}