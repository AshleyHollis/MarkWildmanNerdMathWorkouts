using MarkWildmanNerdMathWorkouts.Shared.Settings;
using System.Threading.Tasks;
using MarkWildmanNerdMathWorkouts.Shared.Wrapper;

namespace MarkWildmanNerdMathWorkouts.Shared.Managers
{
    public interface IPreferenceManager
    {
        Task SetPreference(IPreference preference);

        Task<IPreference> GetPreference();

        Task<IResult> ChangeLanguageAsync(string languageCode);
    }
}