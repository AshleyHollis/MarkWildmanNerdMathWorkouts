using FluentAssertions;
using MarkWildmanNerdMathWorkouts.Shared.Models;
using Xunit;

namespace MarkWildmanNerdMathWorkouts.Tests
{
    public class ReverseLadderShould
    {
        [Theory]
        [InlineData(1, 1)]
        [InlineData(2, 3)]
        [InlineData(3, 6)]
        [InlineData(4, 10)]
        [InlineData(5, 15)]
        public void Calculate_Correct_RepsPerHand(int rungs,int expected)
        {
            // Arrange
            // Act
            var reverseLadder = new ReverseLadder(rungs);

            // Assert
            reverseLadder.RepsPerHand.Should().Be(expected);
        }

        [Theory]
        [InlineData(1, 2)]
        [InlineData(2, 6)]
        [InlineData(3, 12)]
        [InlineData(4, 20)]
        [InlineData(5, 30)]
        public void Calculate_Correct_TotalReps(int rungs, int expected)
        {
            // Arrange
            // Act
            var reverseLadder = new ReverseLadder(rungs);

            // Assert
            reverseLadder.TotalReps.Should().Be(expected);
        }
    }
}
