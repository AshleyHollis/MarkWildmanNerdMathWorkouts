using System;
using System.Collections.Generic;
using MarkWildmanNerdMathWorkouts.Shared.Enums;
using MarkWildmanNerdMathWorkouts.Shared.Helpers;

namespace MarkWildmanNerdMathWorkouts.Shared.Models
{
    public class WorkoutExerciseNew
    {
        private string Name;
        public readonly List<WorkoutDayOfWeek> WorkoutDays;
        private WeightLevel WeightLevel;

        public WorkoutExerciseNew(string name, List<WorkoutDayOfWeek> workoutDays)
        {
            Name = name;
            WorkoutDays = workoutDays;
        }

        public WorkoutExerciseNew(WorkoutExerciseNew workoutExercise, WorkoutDayOfWeek day)
        {
            Name = workoutExercise.Name;
            WorkoutDays = new List<WorkoutDayOfWeek> { day };
            WeightLevel = workoutExercise.WeightLevel;
        }

        public WorkoutExerciseNew(string name, List<WorkoutDayOfWeek> workoutDays, WeightLevel weightLevel = WeightLevel.Unknown)
        {
            Name = name;
            WorkoutDays = workoutDays;
            WeightLevel = weightLevel;
        }

        public override string ToString()
        {
            var flattenedExcercises = FlattenByDay();

            return string.Join(Environment.NewLine, flattenedExcercises.Select(a => string.Format("{0}|{1}|{2}|", a.WorkoutDays.Single().DayOfWeek.ToShortString(), a.Name, a.WorkoutDays.Single().WeightLevel.ToShortString())));
        }

        private List<WorkoutExerciseNew> FlattenByDay()
        {
            var flattenedExcercises = new List<WorkoutExerciseNew>();
            foreach (var day in WorkoutDays)
            {
                flattenedExcercises.Add(new WorkoutExerciseNew(this, day));
            }

            return flattenedExcercises;
        }
    }
}