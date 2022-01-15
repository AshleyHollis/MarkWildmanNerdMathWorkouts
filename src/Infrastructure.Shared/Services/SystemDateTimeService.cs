using MarkWildmanNerdMathWorkouts.Application.Interfaces.Services;
using System;

namespace MarkWildmanNerdMathWorkouts.Infrastructure.Shared.Services
{
    public class SystemDateTimeService : IDateTimeService
    {
        public DateTime NowUtc => DateTime.UtcNow;
    }
}