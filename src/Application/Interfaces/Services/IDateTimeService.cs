using System;

namespace MarkWildmanNerdMathWorkouts.Application.Interfaces.Services
{
    public interface IDateTimeService
    {
        DateTime NowUtc { get; }
    }
}