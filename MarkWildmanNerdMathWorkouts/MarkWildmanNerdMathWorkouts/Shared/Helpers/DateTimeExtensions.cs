using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarkWildmanNerdMathWorkouts.Shared.Helpers
{
    public static class DateTimeExtensions
    {
        public static DateTime Next(this DateTime from, DayOfWeek dayOfTheWeek)
        {
            var date = from.Date.AddDays(1);
            var days = ((int)dayOfTheWeek - (int)date.DayOfWeek + 7) % 7;
            return date.AddDays(days);
        }

        public static IReadOnlyList<DateTime> Next(this DateTime from, params DayOfWeek[] days)
        {
            return Next(from, DateCalculationKind.And, days);
        }

        public static IReadOnlyList<DateTime> Next(this DateTime from, DateCalculationKind calculationKind, params DayOfWeek[] days)
        {
            return Next(from, calculationKind, days.Length, days);
        }

        public static IReadOnlyList<DateTime> Next(this DateTime from, DateCalculationKind calculationKind, int numberOfDaysRequired, params DayOfWeek[] days)
        {
            if (days == null)
                return Array.Empty<DateTime>();

            DateTime? result = null;
            var results = new List<DateTime>();

            // And means, we don't want to duplicate data
            days = calculationKind == DateCalculationKind.And
                ? days.Distinct().ToArray()
                : days;

            while (results.Count < numberOfDaysRequired)
            {
                foreach (var dayOfWeek in days)
                {
                    result = calculationKind == DateCalculationKind.And || result is null
                        ? Next(from, dayOfWeek)
                        : Next(result.Value, dayOfWeek);

                    results.Add(result.Value);
                }
            }

            return results.Take(numberOfDaysRequired).ToList();
        }
    }
}