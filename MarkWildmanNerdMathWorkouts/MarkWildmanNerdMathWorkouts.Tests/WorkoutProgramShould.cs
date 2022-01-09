using FluentAssertions;
using MarkWildmanNerdMathWorkouts.Shared.Enums;
using MarkWildmanNerdMathWorkouts.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MarkWildmanNerdMathWorkouts.Tests;

public class WorkoutProgramShould
{
    [Fact]
    public void Correctly_Add_2_Differant_Excercises()
    {
        // Arrange
        var workoutProgramA = new WorkoutProgram("A", "Kettlebell Basic", new List<WorkoutDayOfWeek> { new WorkoutDayOfWeek(DayOfWeek.Sunday, 1), new WorkoutDayOfWeek(DayOfWeek.Monday, 1), new WorkoutDayOfWeek(DayOfWeek.Tuesday, 1), new WorkoutDayOfWeek(DayOfWeek.Wednesday, 1), new WorkoutDayOfWeek(DayOfWeek.Thursday, 1), new WorkoutDayOfWeek(DayOfWeek.Friday, 1), new WorkoutDayOfWeek(DayOfWeek.Saturday, 1) });
        
        // Act
        workoutProgramA.AddExcercise(new WorkoutExerciseNew("Swings", new List<WorkoutDayOfWeek> { new WorkoutDayOfWeek(DayOfWeek.Monday, 2, WeightLevel.Light) }));
        workoutProgramA.AddExcercise(new WorkoutExerciseNew("Turkish Get Ups", new List<WorkoutDayOfWeek> { new WorkoutDayOfWeek(DayOfWeek.Tuesday, 2, WeightLevel.Heavy) }));

        // Assert
        workoutProgramA.Excercises.Should().HaveCount(2);
    }

    [Fact]
    public void Error_If_Excercise_Same_Name_Is_Added()
    {
        // Arrange
        var workoutProgramA = new WorkoutProgram("A", "Kettlebell Basic", new List<WorkoutDayOfWeek> { new WorkoutDayOfWeek(DayOfWeek.Sunday, 1), new WorkoutDayOfWeek(DayOfWeek.Monday, 1), new WorkoutDayOfWeek(DayOfWeek.Tuesday, 1), new WorkoutDayOfWeek(DayOfWeek.Wednesday, 1), new WorkoutDayOfWeek(DayOfWeek.Thursday, 1), new WorkoutDayOfWeek(DayOfWeek.Friday, 1), new WorkoutDayOfWeek(DayOfWeek.Saturday, 1) });
        workoutProgramA.AddExcercise(new WorkoutExerciseNew("Swings", new List<WorkoutDayOfWeek> { new WorkoutDayOfWeek(DayOfWeek.Monday, 2, WeightLevel.Light) }));

        // Act
        // Assert
        var ex = Assert.Throws<InvalidOperationException>(() => workoutProgramA.AddExcercise(new WorkoutExerciseNew("Swings", new List<WorkoutDayOfWeek> { new WorkoutDayOfWeek(DayOfWeek.Thursday, 2, WeightLevel.Heavy) })));
        Assert.Equal("Cannot add excercise with same name. Try adding additional workout days instead.", ex.Message);
    }
}
