using System;
using System.Collections.Generic;
using MarkWildmanNerdMathWorkouts.Shared.Enums;
using MarkWildmanNerdMathWorkouts.Shared.Helpers;

namespace MarkWildmanNerdMathWorkouts.Shared.Models
{
    public class WorkoutExerciseNew
    {
        private string Name;
        public readonly List<DayOfWeek> WorkoutDays;
        private WeightLevel WeightLevel;
        public readonly int Order;

        public WorkoutExerciseNew(string name, List<DayOfWeek> workoutDays, int order)
        {
            Name = name;
            WorkoutDays = workoutDays;
            Order = order;
        }

        public WorkoutExerciseNew(WorkoutExerciseNew workoutExercise, DayOfWeek day)
        {
            Name = workoutExercise.Name;
            WorkoutDays = new List<DayOfWeek> { day };
            WeightLevel = workoutExercise.WeightLevel;
            Order = workoutExercise.Order;
        }

        public WorkoutExerciseNew(string name, List<DayOfWeek> workoutDays, int order, WeightLevel weightLevel = WeightLevel.Unknown)
        {
            Name = name;
            WorkoutDays = workoutDays;
            WeightLevel = weightLevel;
            Order = order;
        }

        public override string ToString()
        {
            var flattenedExcercises = FlattenByDay();

            return string.Join(Environment.NewLine, flattenedExcercises.Select(a => string.Format("{0}|{1}|{2}|", a.WorkoutDays.Single().ToShortString(), a.Name, a.WeightLevel.ToShortString())));
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