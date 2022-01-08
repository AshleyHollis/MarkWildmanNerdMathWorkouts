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
    public class WorkoutExerciseShould
    {
        /*
            Nerd Math for Kettlebells - determining Reverse Ladder Equivalent sets and reps for different weight
            https://www.youtube.com/watch?v=xzNqgTOPKXc
        */ 
        [Theory]
        [InlineData(16, 5, 5, 2400, 20, 3, "20 x 10 x 3")]
        [InlineData(16, 5, 5, 2400, 20, 4, "20 x 6 x 4")]
        [InlineData(16, 5, 5, 2400, 20, 5, "20 x 4 x 5")]
        public void Calculate_Correct_NextWorkSet_Using_NewWeight(int currentWeight, int sets, int rungs, int currentWorkCapacity, int newWeight, int newRungCount, string expected)
        {
            // Arrange
            var reverseLadder = new ReverseLadder(rungs);
            var workoutExercise = new WorkoutExercise();
            var workPerformed = new WorkPerformed() { Sets = sets, Reps = reverseLadder.TotalReps, Weight = currentWeight };

            // Act
            workoutExercise.WorkPerformed.Add(workPerformed);
            var nextWorkSet = workoutExercise.CaculateNextExerciseUsingNewWeight(currentWorkCapacity, newWeight, newRungCount);


            // Assert
            nextWorkSet.Should().Be(expected);
        }
    }
}
