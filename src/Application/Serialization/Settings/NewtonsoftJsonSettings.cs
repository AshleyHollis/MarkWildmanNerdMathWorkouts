
using MarkWildmanNerdMathWorkouts.Application.Interfaces.Serialization.Settings;
using Newtonsoft.Json;

namespace MarkWildmanNerdMathWorkouts.Application.Serialization.Settings
{
    public class NewtonsoftJsonSettings : IJsonSerializerSettings
    {
        public JsonSerializerSettings JsonSerializerSettings { get; } = new();
    }
}