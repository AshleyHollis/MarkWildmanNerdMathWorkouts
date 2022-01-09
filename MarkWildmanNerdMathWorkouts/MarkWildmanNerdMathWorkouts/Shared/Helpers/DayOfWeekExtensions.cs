namespace MarkWildmanNerdMathWorkouts.Shared.Helpers
{
    public static class DayOfWeekExtensions
    {
        public static string ToShortString(this DayOfWeek dayOfWeek)
        {
            return dayOfWeek.ToString().Substring(0, 3);
        }
    }
}
