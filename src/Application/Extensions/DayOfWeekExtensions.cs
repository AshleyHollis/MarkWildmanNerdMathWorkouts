using System;

namespace MarkWildmanNerdMathWorkouts.Application.Extensions
{
    public static class DayOfWeekExtensions
    {
        public static string ToShortString(this DayOfWeek dayOfWeek)
        {
            return dayOfWeek.ToString().Substring(0, 3);
        }
    }
}
