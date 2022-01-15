using System;
using FluentAssertions;
using Xunit;
using MarkWildmanNerdMathWorkouts.Application.Enums;
using MarkWildmanNerdMathWorkouts.Application.Features.Workouts;

namespace MarkWildmanNerdMathWorkouts.Tests
{
    public class WorkoutSessionShould
    {
        [Theory]
        [InlineData(WorkoutType.KettleBell, WorkoutLevel.Recovery, "KB - R")]
        [InlineData(WorkoutType.KettleBell, WorkoutLevel.Light, "KB - L")]
        [InlineData(WorkoutType.KettleBell, WorkoutLevel.Heavy, "KB - H")]
        [InlineData(WorkoutType.Mace, WorkoutLevel.Recovery, "MA - R")]
        [InlineData(WorkoutType.Mace, WorkoutLevel.Light, "MA - L")]
        [InlineData(WorkoutType.Mace, WorkoutLevel.Heavy, "MA - H")]
        [InlineData(WorkoutType.ClubBell, WorkoutLevel.Recovery, "CB - R")]
        [InlineData(WorkoutType.ClubBell, WorkoutLevel.Light, "CB - L")]
        [InlineData(WorkoutType.ClubBell, WorkoutLevel.Heavy, "CB - H")]
        [InlineData(WorkoutType.BodyWeight, WorkoutLevel.Recovery, "BW - R")]
        [InlineData(WorkoutType.BodyWeight, WorkoutLevel.Light, "BW - L")]
        [InlineData(WorkoutType.BodyWeight, WorkoutLevel.Heavy, "BW - H")]
        public void Generate_Correct_Title(WorkoutType workoutType, WorkoutLevel workoutLevel, string expected)
        {
            // Arrange
            // Act
            var workoutSession = new WorkoutSession(DateTime.Today, workoutType, workoutLevel, WeightLevel.Light, HeartRateLevel.Light, ThoughtLevel.Light);

            // Assert
            workoutSession.Title.Should().Be(expected);
        }
    }
}
