using FluentAssertions;
using MarkWildmanNerdMathWorkouts.Shared.Enums;
using MarkWildmanNerdMathWorkouts.Shared.Helpers;
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
            var workoutProgramA = new WorkoutProgram("A", "Kettlebells", new List<WorkoutDayOfWeek> { new WorkoutDayOfWeek(DayOfWeek.Monday, 1), new WorkoutDayOfWeek(DayOfWeek.Thursday, 1) });
            workoutProgramA.AddExcercise(new WorkoutExerciseNew("Clean & Press", workoutProgramA.WorkoutDays.CloneWithNewOrder(1)));
            workoutProgramA.AddExcercise(new WorkoutExerciseNew("Swings", workoutProgramA.WorkoutDays.CloneWithNewOrder(2)));

            var workoutProgramB = new WorkoutProgram("B", "Mill/Squat", new List<WorkoutDayOfWeek> { new WorkoutDayOfWeek(DayOfWeek.Tuesday, 1), new WorkoutDayOfWeek(DayOfWeek.Friday, 1) });
            workoutProgramB.AddExcercise(new WorkoutExerciseNew("Sheild Cast", workoutProgramB.WorkoutDays.CloneWithNewOrder(1)));
            workoutProgramB.AddExcercise(new WorkoutExerciseNew("Squat", workoutProgramB.WorkoutDays.CloneWithNewOrder(2)));

            var workoutProgramC = new WorkoutProgram("B", "SA Club", new List<WorkoutDayOfWeek> { new WorkoutDayOfWeek(DayOfWeek.Wednesday, 1), new WorkoutDayOfWeek(DayOfWeek.Saturday, 1) });
            workoutProgramC.AddExcercise(new WorkoutExerciseNew("Sheild Cast", workoutProgramC.WorkoutDays.CloneWithNewOrder(1)));
            workoutProgramC.AddExcercise(new WorkoutExerciseNew("Balance", workoutProgramC.WorkoutDays.CloneWithNewOrder(2)));
            workoutProgramC.AddExcercise(new WorkoutExerciseNew("Spike", workoutProgramC.WorkoutDays.CloneWithNewOrder(3)));

            var workoutProgramRec = new WorkoutProgram("REC", "Recovery", new List<WorkoutDayOfWeek> { new WorkoutDayOfWeek(DayOfWeek.Sunday, 1) });
            workoutProgramRec.AddExcercise(new WorkoutExerciseNew("Recovery", workoutProgramRec.WorkoutDays.CloneWithNewOrder(1)));

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
            var workoutProgramA = new WorkoutProgram("A", "Kettlebell Basic", new List<WorkoutDayOfWeek> { new WorkoutDayOfWeek(DayOfWeek.Sunday, 1), new WorkoutDayOfWeek(DayOfWeek.Monday, 1), new WorkoutDayOfWeek(DayOfWeek.Tuesday, 1), new WorkoutDayOfWeek(DayOfWeek.Wednesday, 1), new WorkoutDayOfWeek(DayOfWeek.Thursday, 1), new WorkoutDayOfWeek(DayOfWeek.Friday, 1), new WorkoutDayOfWeek(DayOfWeek.Saturday, 1) });

            workoutProgramA.AddExcercise(new WorkoutExerciseNew("Warmup", new List<WorkoutDayOfWeek> { new WorkoutDayOfWeek(DayOfWeek.Monday, 1), new WorkoutDayOfWeek(DayOfWeek.Tuesday, 1), new WorkoutDayOfWeek(DayOfWeek.Thursday, 1), new WorkoutDayOfWeek(DayOfWeek.Friday, 1) }));
            workoutProgramA.AddExcercise(new WorkoutExerciseNew("Cooldown", new List<WorkoutDayOfWeek> { new WorkoutDayOfWeek(DayOfWeek.Monday, 4), new WorkoutDayOfWeek(DayOfWeek.Tuesday, 4), new WorkoutDayOfWeek(DayOfWeek.Thursday, 4), new WorkoutDayOfWeek(DayOfWeek.Friday, 4) }));
            workoutProgramA.AddExcercise(new WorkoutExerciseNew("Swings", new List<WorkoutDayOfWeek> { new WorkoutDayOfWeek(DayOfWeek.Monday, 2, WeightLevel.Light), new WorkoutDayOfWeek(DayOfWeek.Thursday, 2, WeightLevel.Heavy) }));
            workoutProgramA.AddExcercise(new WorkoutExerciseNew("Clean and Press", new List<WorkoutDayOfWeek> { new WorkoutDayOfWeek(DayOfWeek.Monday, 3, WeightLevel.Heavy), new WorkoutDayOfWeek(DayOfWeek.Friday, 3, WeightLevel.Light) }));
            workoutProgramA.AddExcercise(new WorkoutExerciseNew("Turkish Get Ups", new List<WorkoutDayOfWeek> { new WorkoutDayOfWeek(DayOfWeek.Tuesday, 2, WeightLevel.Heavy), new WorkoutDayOfWeek(DayOfWeek.Thursday, 3, WeightLevel.Light) }));
            workoutProgramA.AddExcercise(new WorkoutExerciseNew("Squats", new List<WorkoutDayOfWeek> { new WorkoutDayOfWeek(DayOfWeek.Tuesday, 3, WeightLevel.Light), new WorkoutDayOfWeek(DayOfWeek.Friday, 2, WeightLevel.Heavy) }));            
            workoutProgramA.AddExcercise(new WorkoutExerciseNew("Recovery", new List<WorkoutDayOfWeek> { new WorkoutDayOfWeek(DayOfWeek.Sunday, 1), new WorkoutDayOfWeek(DayOfWeek.Wednesday, 1), new WorkoutDayOfWeek(DayOfWeek.Saturday, 1) }));

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
