using MarkWildmanNerdMathWorkouts.Shared.Managers;
using MudBlazor;
using System.Threading.Tasks;

namespace MarkWildmanNerdMathWorkouts.Client.Infrastructure.Managers.Preferences
{
    public interface IClientPreferenceManager : IPreferenceManager
    {
        Task<MudTheme> GetCurrentThemeAsync();

        Task<bool> ToggleDarkModeAsync();
    }
}