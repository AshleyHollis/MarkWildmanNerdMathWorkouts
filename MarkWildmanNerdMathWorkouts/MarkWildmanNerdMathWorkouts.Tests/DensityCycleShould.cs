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
        [Fact]
        public void Correctly_Create_5_WorkoutIncrements()
        {
            var densityCycle = new DensityCycle(new Weight(16, Shared.Enums.WeightUnit.Kilograms), 20, 5, 10, true);
            var workouts = new List<WorkoutIncrement>();
            WorkoutIncrement workoutIncrement = null;
            

            while (workoutIncrement?.IsEndOfCycle != true)
            {
                workoutIncrement = densityCycle.Next();
                workouts.Add(workoutIncrement);
            }

            workouts.Should().HaveCount(5);
            workouts.Sum(a => a.WorkCapacity.Weight.Mass).Should().Be(7824);
        }

        [Fact]
        public void Correctly_Create_10_WorkoutIncrements()
        {
            var densityCycle = new DensityCycle(new Weight(16, Shared.Enums.WeightUnit.Kilograms), 20, 5, 20, true);
            var workouts = new List<WorkoutIncrement>();
            WorkoutIncrement workoutIncrement = null;


            while (workoutIncrement?.IsEndOfCycle != true)
            {
                workoutIncrement = densityCycle.Next();
                workouts.Add(workoutIncrement);
            }

            workouts.Should().HaveCount(10);
            workouts.Sum(a => a.WorkCapacity.Weight.Mass).Should().Be(15648);
        }
    }
}
