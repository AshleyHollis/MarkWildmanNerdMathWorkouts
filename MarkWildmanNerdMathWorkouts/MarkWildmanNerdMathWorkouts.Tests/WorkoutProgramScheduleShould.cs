using FluentAssertions;
using MarkWildmanNerdMathWorkouts.Shared.Enums;
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
        public void Correctly_Output_Logans_ABC_ProgramSchedule_And_Excercises()
        {
            var workoutProgramA = new WorkoutProgram("A", "Kettlebells", new List<DayOfWeek> { DayOfWeek.Monday, DayOfWeek.Thursday });
            workoutProgramA.AddExcercise(new WorkoutExerciseNew("Clean & Press", workoutProgramA.WorkoutDays, 1));
            workoutProgramA.AddExcercise(new WorkoutExerciseNew("Swings", workoutProgramA.WorkoutDays, 2));

            var workoutProgramB = new WorkoutProgram("B", "Mill/Squat", new List<DayOfWeek> { DayOfWeek.Tuesday, DayOfWeek.Friday });
            workoutProgramA.AddExcercise(new WorkoutExerciseNew("Sheild Cast", workoutProgramB.WorkoutDays, 1));
            workoutProgramA.AddExcercise(new WorkoutExerciseNew("Squat", workoutProgramB.WorkoutDays, 2));

            var workoutProgramC = new WorkoutProgram("B", "SA Club", new List<DayOfWeek> { DayOfWeek.Wednesday, DayOfWeek.Saturday });
            workoutProgramC.AddExcercise(new WorkoutExerciseNew("Sheild Cast", workoutProgramC.WorkoutDays, 1));
            workoutProgramC.AddExcercise(new WorkoutExerciseNew("Balance", workoutProgramC.WorkoutDays, 2));
            workoutProgramC.AddExcercise(new WorkoutExerciseNew("Spike", workoutProgramC.WorkoutDays, 3));

            var workoutProgramRec = new WorkoutProgram("REC", "Recovery", new List<DayOfWeek> { DayOfWeek.Sunday });
            workoutProgramRec.AddExcercise(new WorkoutExerciseNew("Recovery", workoutProgramRec.WorkoutDays, 1));

            var workoutProgramSchedule = new WorkoutProgramSchedule();
            workoutProgramSchedule.AddProgram(workoutProgramA);
            workoutProgramSchedule.AddProgram(workoutProgramB);
            workoutProgramSchedule.AddProgram(workoutProgramC);
            workoutProgramSchedule.AddProgram(workoutProgramRec);

            var expectedToString = @"Sun|REC|Recovery|
Mon|A|Kettlebells|
Tue|B|Mill/Squat|
Wed|B|SA Club|
Thu|A|Kettlebells|
Fri|B|Mill/Squat|
Sat|B|SA Club|

Sun|Recovery||
Mon|Clean & Press||
Mon|Swings||
Tue|Sheild Cast||
Tue|Squat||
Wed|Sheild Cast||
Wed|Balance||
Wed|Spike||
Thu|Clean & Press||
Thu|Swings||
Fri|Sheild Cast||
Fri|Squat||
Sat|Sheild Cast||
Sat|Balance||
Sat|Spike||";

            workoutProgramSchedule.ToString().Should().Be(expectedToString);
        }

        [Fact]
        public void Correctly_Output_Kettlebell_Basic_A_ProgramSchedule_And_Excercises()
        {
            var workoutProgramA = new WorkoutProgram("A", "Kettlebell Basic", new List<DayOfWeek> { DayOfWeek.Sunday, DayOfWeek.Monday, DayOfWeek.Tuesday, DayOfWeek.Wednesday, DayOfWeek.Thursday,DayOfWeek.Friday, DayOfWeek.Saturday });
            
            workoutProgramA.AddExcercise(new WorkoutExerciseNew("Warmup", new List<DayOfWeek> { DayOfWeek.Monday, DayOfWeek.Tuesday, DayOfWeek.Thursday, DayOfWeek.Friday }, 1));
            workoutProgramA.AddExcercise(new WorkoutExerciseNew("Cooldown", new List<DayOfWeek> { DayOfWeek.Monday, DayOfWeek.Tuesday, DayOfWeek.Thursday, DayOfWeek.Friday }, 4));
            workoutProgramA.AddExcercise(new WorkoutExerciseNew("Swings", new List<DayOfWeek> { DayOfWeek.Monday }, 2, WeightLevel.Light));
            workoutProgramA.AddExcercise(new WorkoutExerciseNew("Clean and Press", new List<DayOfWeek> { DayOfWeek.Monday }, 3, WeightLevel.Heavy));
            workoutProgramA.AddExcercise(new WorkoutExerciseNew("Turkish Get Ups", new List<DayOfWeek> { DayOfWeek.Tuesday }, 2, WeightLevel.Heavy));
            workoutProgramA.AddExcercise(new WorkoutExerciseNew("Squats", new List<DayOfWeek> { DayOfWeek.Tuesday }, 3, WeightLevel.Light));
            workoutProgramA.AddExcercise(new WorkoutExerciseNew("Swings", new List<DayOfWeek> { DayOfWeek.Thursday }, 2, WeightLevel.Heavy));
            workoutProgramA.AddExcercise(new WorkoutExerciseNew("Turkish Get Ups", new List<DayOfWeek> { DayOfWeek.Thursday }, 3, WeightLevel.Light));
            workoutProgramA.AddExcercise(new WorkoutExerciseNew("Squats", new List<DayOfWeek> { DayOfWeek.Friday }, 2, WeightLevel.Heavy));
            workoutProgramA.AddExcercise(new WorkoutExerciseNew("Clean and Press", new List<DayOfWeek> { DayOfWeek.Friday }, 3, WeightLevel.Light));
            workoutProgramA.AddExcercise(new WorkoutExerciseNew("Recovery", new List<DayOfWeek> { DayOfWeek.Sunday, DayOfWeek.Wednesday, DayOfWeek.Saturday }, 1));

            var workoutProgramSchedule = new WorkoutProgramSchedule();
            workoutProgramSchedule.AddProgram(workoutProgramA);

            var expectedToString = @"Sun|A|Kettlebell Basic|
Mon|A|Kettlebell Basic|
Tue|A|Kettlebell Basic|
Wed|A|Kettlebell Basic|
Thu|A|Kettlebell Basic|
Fri|A|Kettlebell Basic|
Sat|A|Kettlebell Basic|

Sun|Recovery||
Mon|Warmup||
Mon|Swings|L|
Mon|Clean and Press|H|
Mon|Cooldown||
Tue|Warmup||
Tue|Turkish Get Ups|H|
Tue|Squats|L|
Tue|Cooldown||
Wed|Recovery||
Thu|Warmup||
Thu|Swings|H|
Thu|Turkish Get Ups|L|
Thu|Cooldown||
Fri|Warmup||
Fri|Squats|H|
Fri|Clean and Press|L|
Fri|Cooldown||
Sat|Recovery||";

            workoutProgramSchedule.ToString().Should().Be(expectedToString);
        }
    }
}
