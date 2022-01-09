using FluentAssertions;
using MarkWildmanNerdMathWorkouts.Shared.Enums;
using MarkWildmanNerdMathWorkouts.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MarkWildmanNerdMathWorkouts.Tests
{
    public class WorkoutExerciseShould
    {
        /*
            Nerd Math for Kettlebells - determining Reverse Ladder Equivalent sets and reps for different weight
            https://www.youtube.com/watch?v=xzNqgTOPKXc
        */ 
        [Theory]
        [InlineData(16, WeightUnit.Kilograms, 5, 5, 2400, 20, 3, "20kgs x 10 x 3")]
        [InlineData(16, WeightUnit.Kilograms, 5, 5, 2400, 20, 4, "20kgs x 6 x 4")]
        [InlineData(16, WeightUnit.Kilograms, 5, 5, 2400, 20, 5, "20kgs x 4 x 5")]
        public void Calculate_Correct_NextWorkSet_Using_NewWeight(int currentWeight, WeightUnit weightUnit, int sets, int rungs, int currentWorkCapacity, int newWeight, int newRungCount, string expected)
        {
            // Arrange
            var reverseLadder = new ReverseLadder(rungs);
            var workoutExercise = new WorkoutExercise();
            var workPerformed = new WorkPerformed() { Sets = sets, Reps = reverseLadder.TotalReps, Weight = new Weight(currentWeight, weightUnit) };

            // Act
            workoutExercise.WorkPerformed.Add(workPerformed);
            var nextWorkSet = workoutExercise.CaculateNextExerciseUsingNewWeight(currentWorkCapacity, new Weight(newWeight, weightUnit), newRungCount);


            // Assert
            nextWorkSet.Should().Be(expected);
        }
    }
}
