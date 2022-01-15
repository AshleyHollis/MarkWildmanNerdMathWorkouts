using MarkWildmanNerdMathWorkouts.Application.Models.Chat;
using MarkWildmanNerdMathWorkouts.Application.Responses.Identity;
using MarkWildmanNerdMathWorkouts.Shared.Wrapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using MarkWildmanNerdMathWorkouts.Application.Interfaces.Chat;

namespace MarkWildmanNerdMathWorkouts.Client.Infrastructure.Managers.Communication
{
    public interface IChatManager : IManager
    {
        Task<IResult<IEnumerable<ChatUserResponse>>> GetChatUsersAsync();

        Task<IResult> SaveMessageAsync(ChatHistory<IChatUser> chatHistory);

        Task<IResult<IEnumerable<ChatHistoryResponse>>> GetChatHistoryAsync(string cId);
    }
}