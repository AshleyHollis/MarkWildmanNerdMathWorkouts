using MarkWildmanNerdMathWorkouts.Application.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MarkWildmanNerdMathWorkouts.Application.Features.Workouts
{
    public class WorkoutProgram
    {
        public readonly string Code;
        public readonly string Name;
        public List<WorkoutExerciseNew> Excercises;
        public readonly List<WorkoutDayOfWeek> WorkoutDays;

        public WorkoutProgram(string code, string name, List<WorkoutDayOfWeek> workoutDays)
        {
            Excercises = new List<WorkoutExerciseNew>();

            Code = code;
            Name = name;
            WorkoutDays = workoutDays;
        }

        public WorkoutProgram(WorkoutProgram program, WorkoutDayOfWeek workoutDay)
        {
            Excercises = new List<WorkoutExerciseNew>();

            Code = program.Code;
            Name = program.Name;
            WorkoutDays = new List<WorkoutDayOfWeek> { workoutDay };
        }

        public void AddExcercise(WorkoutExerciseNew excercise)
        {
            if (Excercises.Any(a => a.Name.Equals(excercise.Name, StringComparison.OrdinalIgnoreCase)))
            {
                throw new InvalidOperationException("Cannot add excercise with same name. Try adding additional workout days instead.");
            }

            Excercises.Add(excercise);
        }

        public override string ToString()
        {
            var output = string.Empty;

            var flattenedWorkouts = FlattenWorkoutProgramsByDay();
            var programOutput = string.Join(Environment.NewLine, flattenedWorkouts.Select(a => string.Format("{0}|{1}|{2}|", a.WorkoutDays.Single().DayOfWeek.ToShortString(), a.Code, a.Name)));

            return programOutput;
        }

        private List<WorkoutProgram> FlattenWorkoutProgramsByDay()
        {
            var flattenedPrograms = new List<WorkoutProgram>();
            foreach (var day in WorkoutDays)
            {
                flattenedPrograms.Add(new WorkoutProgram(this, day));
            }

            return flattenedPrograms;
        }
    }
}