using FluentAssertions;
using MarkWildmanNerdMathWorkouts.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MarkWildmanNerdMathWorkouts.Tests
{
    public class WorkoutExerciseNewShould
    {
        [Fact]
        public void Correctly_Generate_Workout_Schedule_For_Recovery_Excercise()
        {
            var workoutExcercise = new WorkoutExerciseNew("Recovery", new List<WorkoutDayOfWeek> { new WorkoutDayOfWeek(DayOfWeek.Sunday, 1), new WorkoutDayOfWeek(DayOfWeek.Wednesday, 1), new WorkoutDayOfWeek(DayOfWeek.Saturday, 1) });
            var test = workoutExcercise.GenerateWorkoutSchedule(new RecoveryExcerciseStrategy());

            const string expected = @"3/01/2021|Recovery|
6/01/2021|Recovery|
9/01/2021|Recovery|
10/01/2021|Recovery|
13/01/2021|Recovery|
16/01/2021|Recovery|
17/01/2021|Recovery|
20/01/2021|Recovery|
23/01/2021|Recovery|
24/01/2021|Recovery|
27/01/2021|Recovery|
30/01/2021|Recovery|
31/01/2021|Recovery|
3/02/2021|Recovery|";

            string.Join(Environment.NewLine, test).Should().Be(expected);
        }
    }
}
