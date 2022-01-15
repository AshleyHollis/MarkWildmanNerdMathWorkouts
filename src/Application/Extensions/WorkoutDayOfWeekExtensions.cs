using MarkWildmanNerdMathWorkouts.Application.Features.Workouts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarkWildmanNerdMathWorkouts.Application.Extensions
{
    public static class WorkoutDayOfWeekExtensions
    {
        public static List<WorkoutDayOfWeek> CloneWithNewOrder(this List<WorkoutDayOfWeek> workoutDayOfWeeks, int order)
        {
            return workoutDayOfWeeks.Select(a => new WorkoutDayOfWeek(a, order)).ToList();
        }
    }
}
