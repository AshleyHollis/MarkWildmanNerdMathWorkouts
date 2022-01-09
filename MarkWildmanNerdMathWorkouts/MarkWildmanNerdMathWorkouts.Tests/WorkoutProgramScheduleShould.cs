using FluentAssertions;
using MarkWildmanNerdMathWorkouts.Shared.Models;
using System;
using System.Collections.Generic;
using Xunit;

namespace MarkWildmanNerdMathWorkouts.Tests
{
    public class WorkoutProgramScheduleShould
    {
        /*
            Nerd Math Viewer Program Analysis - Logan's ABC program
            https://www.youtube.com/watch?v=w0OQZNBJy2g 
        */
        [Fact]
        public void Test1()
        {
            var workoutProgramA = new WorkoutProgram("A", "Kettlebells", new List<DayOfWeek> { DayOfWeek.Monday, DayOfWeek.Thursday });
            workoutProgramA.AddExcercise("Clean & Press");
            workoutProgramA.AddExcercise("Swings");

            var workoutProgramB = new WorkoutProgram("B", "Mill/Squat", new List<DayOfWeek> { DayOfWeek.Tuesday, DayOfWeek.Friday });
            workoutProgramA.AddExcercise("Sheild Cast");
            workoutProgramA.AddExcercise("Squat");

            var workoutProgramC = new WorkoutProgram("B", "SA Club", new List<DayOfWeek> { DayOfWeek.Wednesday, DayOfWeek.Saturday });
            workoutProgramC.AddExcercise("Sheild Cast");
            workoutProgramC.AddExcercise("Balance");
            workoutProgramC.AddExcercise("Spike");

            var workoutProgramRec = new WorkoutProgram("REC", "Recovery", new List<DayOfWeek> { DayOfWeek.Sunday });
            workoutProgramRec.AddExcercise("Recovery");

            var workoutProgramSchedule = new WorkoutProgramSchedule();
            workoutProgramSchedule.AddProgram(workoutProgramA);
            workoutProgramSchedule.AddProgram(workoutProgramB);
            workoutProgramSchedule.AddProgram(workoutProgramC);
            workoutProgramSchedule.AddProgram(workoutProgramRec);

            var expectedToString = @"Sun|REC|Recovery
Mon|A|Kettlebells
Tue|B|Mill/Squat
Wed|B|SA Club
Thu|A|Kettlebells
Fri|B|Mill/Squat
Sat|B|SA Club";

            workoutProgramSchedule.ToString().Should().Be(expectedToString);
        }
    }
}
