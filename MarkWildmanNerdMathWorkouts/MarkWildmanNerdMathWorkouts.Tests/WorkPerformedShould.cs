using FluentAssertions;
using Xunit;
using MarkWildmanNerdMathWorkouts.Shared.Models;

namespace MarkWildmanNerdMathWorkouts.Tests
{    
    public class WorkPerformedShould
    {
        /*  Is 10 min of Kettlebelling enough - Part II - Yes - Nerd Math
        https://www.youtube.com/watch?v=lcECmuWTL3g 
        */
        [Theory]
        [InlineData(35, 10, 10, 3500)]
        [InlineData(35, 10, 15, 5250)]
        [InlineData(35, 10, 20, 7000)]
        [InlineData(53, 10, 10, 5300)]
        [InlineData(53, 10, 15, 7950)]
        [InlineData(53, 10, 20, 10600)]
        [InlineData(70, 10, 10, 7000)]
        [InlineData(70, 10, 15, 10500)]
        [InlineData(70, 10, 20, 14000)]
        public void Calculate_Correct_WorkCapacity_With_Single_Set(int weight, int sets, int reps, int expected)
        {
            // Arrange
            var practiceExercise = new WorkoutExercise();
            var workPerformed = new WorkPerformed() { Sets = sets, Reps = reps, Weight = weight };

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
        [InlineData(16, 5, 5, 150, 2400)]
        public void Calculate_Correct_WorkCapacity_With_ReverseLadder(int weight, int sets, int rungs, int expectedReps, int expected)
        {
            // Arrange
            var reverseLadder = new ReverseLadder(rungs);
            var practiceExercise = new WorkoutExercise();

            // Act
            practiceExercise.WorkPerformed.Add(new WorkPerformed() { Sets = sets, Reps = reverseLadder.TotalReps, Weight = weight });

            // Assert
            practiceExercise.WorkCapacity.Should().Be(expected);
        }

        [Fact]
        public void Calculate_Correct_WorkCapacity_With_Double_Set()
        {
            // Arrange
            var practiceExercise = new WorkoutExercise();

            // Act
            practiceExercise.WorkPerformed.Add(new WorkPerformed() { Sets = 2, Reps = 10, Weight = 53 });
            practiceExercise.WorkPerformed.Add(new WorkPerformed() { Sets = 8, Reps = 10, Weight = 35 });

            // Assert
            practiceExercise.WorkCapacity.Should().Be(3860);
        }
    }
}
