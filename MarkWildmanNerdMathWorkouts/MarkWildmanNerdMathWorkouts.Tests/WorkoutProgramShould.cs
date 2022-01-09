﻿using MarkWildmanNerdMathWorkouts.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MarkWildmanNerdMathWorkouts.Shared.Models;

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
    }
}
