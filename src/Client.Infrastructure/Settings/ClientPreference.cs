using System.Linq;
using MarkWildmanNerdMathWorkouts.Shared.Constants.Localization;
using MarkWildmanNerdMathWorkouts.Shared.Settings;

namespace MarkWildmanNerdMathWorkouts.Client.Infrastructure.Settings
{
    public record ClientPreference : IPreference
    {
        public bool IsDarkMode { get; set; }
        public bool IsRTL { get; set; }
        public bool IsDrawerOpen { get; set; }
        public string PrimaryColor { get; set; }
        public string LanguageCode { get; set; } = LocalizationConstants.SupportedLanguages.FirstOrDefault()?.Code ?? "en-US";
    }
}