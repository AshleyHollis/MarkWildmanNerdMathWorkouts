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
    public class DensityCycleShould
    {
        /*
            Kettlebell Snatch Nerd Math part 2 - density cycle
            https://www.youtube.com/watch?v=HuNB0kfiUXk&t=310s
        */
        [Theory]
        [InlineData(16, Shared.Enums.WeightUnit.Kilograms, 20, 5, 10, 5, 7824, true)]
        [InlineData(16, Shared.Enums.WeightUnit.Kilograms, 20, 5, 20, 10, 15648, true)]
        public void Correctly_Create_WorkoutIncrements(int weight, Shared.Enums.WeightUnit weightUnit, int volumeCycleSets, int volumeCycleReps, int targetReps, int expectedCount, int expectedTotalWorkCapacity, bool isBilateral)
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
