using System.Linq;
using MarkWildmanNerdMathWorkouts.Shared.Constants.Localization;
using MarkWildmanNerdMathWorkouts.Shared.Settings;

namespace MarkWildmanNerdMathWorkouts.Server.Settings
{
    public record ServerPreference : IPreference
    {
        public string LanguageCode { get; set; } = LocalizationConstants.SupportedLanguages.FirstOrDefault()?.Code ?? "en-US";

        //TODO - add server preferences
    }
}