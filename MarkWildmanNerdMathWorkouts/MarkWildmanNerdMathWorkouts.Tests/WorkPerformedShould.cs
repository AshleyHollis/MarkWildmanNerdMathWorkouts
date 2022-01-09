using FluentAssertions;
using Xunit;
using MarkWildmanNerdMathWorkouts.Shared.Models;
using MarkWildmanNerdMathWorkouts.Shared.Enums;

namespace MarkWildmanNerdMathWorkouts.Tests
{
    public class WorkPerformedShould
    {
        /*  Is 10 min of Kettlebelling enough - Part II - Yes - Nerd Math
        https://www.youtube.com/watch?v=lcECmuWTL3g 
        */
        [Theory]
        [InlineData(35, WeightUnit.Pounds, 10, 10, 3500)]
        [InlineData(35, WeightUnit.Pounds, 10, 15, 5250)]
        [InlineData(35, WeightUnit.Pounds, 10, 20, 7000)]
        [InlineData(53, WeightUnit.Pounds, 10, 10, 5300)]
        [InlineData(53, WeightUnit.Pounds, 10, 15, 7950)]
        [InlineData(53, WeightUnit.Pounds, 10, 20, 10600)]
        [InlineData(70, WeightUnit.Pounds, 10, 10, 7000)]
        [InlineData(70, WeightUnit.Pounds, 10, 15, 10500)]
        [InlineData(70, WeightUnit.Pounds, 10, 20, 14000)]
        public void Calculate_Correct_WorkCapacity_With_Single_Set(int weight, WeightUnit weightUnit, int sets, int reps, int expected)
        {
            // Arrange
            var practiceExercise = new WorkoutExercise();
            var workPerformed = new WorkPerformed() { Sets = sets, Reps = reps, Weight = new Weight(weight, weightUnit) };

            // Act
            practiceExercise.WorkPerformed.Add(workPerformed);

            // Assert
            practiceExercise.WorkCapacity.Should().Be(expected);
        }

        /*
            Nerd Math for Kettlebells - determining Reverse Ladder Equivalent sets and reps for different weight
            https://www.youtube.com/watch?v=xzNqgTOPKXc
        */
        [Theory]
        [InlineData(16, WeightUnit.Pounds, 5, 5, 150, 2400)]
        [InlineData(20, WeightUnit.Pounds, 10, 3, 120, 2400)]
        public void Calculate_Correct_WorkCapacity_With_ReverseLadder(int weight, WeightUnit weightUnit, int sets, int rungs, int expectedReps, int expectedWorkCapacity)
        {
            // Arrange
            var reverseLadder = new ReverseLadder(rungs);
            var practiceExercise = new WorkoutExercise();
            var workPerformed = new WorkPerformed() { Sets = sets, Reps = reverseLadder.TotalReps, Weight = new Weight(weight, weightUnit) };

            // Act
            practiceExercise.WorkPerformed.Add(workPerformed);

            // Assert
            workPerformed.TotalReps.Should().Be(expectedReps);
            practiceExercise.WorkCapacity.Should().Be(expectedWorkCapacity);
        }

        [Fact]
        public void Calculate_Correct_WorkCapacity_With_Double_Set()
        {
            // Arrange
            var practiceExercise = new WorkoutExercise();

            // Act
            practiceExercise.WorkPerformed.Add(new WorkPerformed() { Sets = 2, Reps = 10, Weight = new Weight(53, WeightUnit.Pounds) });
            practiceExercise.WorkPerformed.Add(new WorkPerformed() { Sets = 8, Reps = 10, Weight = new Weight(35, WeightUnit.Pounds) });

            // Assert
            practiceExercise.WorkCapacity.Should().Be(3860);
        }
    }
}
