using FluentAssertions;
using MarkWildmanNerdMathWorkouts.Application.Enums;
using MarkWildmanNerdMathWorkouts.Application.Features.Workouts;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace MarkWildmanNerdMathWorkouts.Tests
{
    public class DensityCycleShould
    {
        /*
            Kettlebell Snatch Nerd Math part 2 - density cycle
            https://www.youtube.com/watch?v=HuNB0kfiUXk&t=310s
        */
        [Theory]
        [InlineData(16, WeightUnit.Kilograms, 20, 5, 10, 5, 15648, true)]
        [InlineData(16, WeightUnit.Kilograms, 20, 5, 20, 10, 31296, true)]
        public void Correctly_Create_WorkoutIncrements(int weight, WeightUnit weightUnit, int volumeCycleSets, int volumeCycleReps, int targetReps, int expectedCount, int expectedTotalWorkCapacity, bool isBilateral)
        {
            var densityCycle = new DensityCycle(new Weight(weight, weightUnit), volumeCycleSets, volumeCycleReps, targetReps, true);
            var workouts = new List<WorkoutIncrement>();
            WorkoutIncrement workoutIncrement = null;
            

            while (workoutIncrement?.IsEndOfCycle != true)
            {
                workoutIncrement = densityCycle.Next();
                workouts.Add(workoutIncrement);
            }

            workouts.Should().HaveCount(expectedCount);
            workouts.Sum(a => a.WorkCapacity.Weight.Mass).Should().Be(expectedTotalWorkCapacity);
        }
    }
}
