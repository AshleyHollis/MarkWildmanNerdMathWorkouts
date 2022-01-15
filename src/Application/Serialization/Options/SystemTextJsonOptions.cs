using System.Text.Json;
using MarkWildmanNerdMathWorkouts.Application.Interfaces.Serialization.Options;

namespace MarkWildmanNerdMathWorkouts.Application.Serialization.Options
{
    public class SystemTextJsonOptions : IJsonSerializerOptions
    {
        public JsonSerializerOptions JsonSerializerOptions { get; } = new();
    }
}