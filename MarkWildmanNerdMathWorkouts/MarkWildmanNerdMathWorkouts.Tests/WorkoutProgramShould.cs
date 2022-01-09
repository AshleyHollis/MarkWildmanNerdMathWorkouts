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
    /*
        Nerd Math Viewer Program Analysis - Logan's ABC program
        https://www.youtube.com/watch?v=w0OQZNBJy2g 
    */
    [Fact]
    public void Test1()
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
        workoutProgramRec.AddExcercise(new WorkoutExerciseNew("Recovery", workoutProgramRec.WorkoutDays, 2));
    }
}
