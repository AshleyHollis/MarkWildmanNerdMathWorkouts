using System;
using System.Collections.Generic;
using System.Linq;
using MarkWildmanNerdMathWorkouts.Shared.Enums;
using MarkWildmanNerdMathWorkouts.Shared.Helpers;

namespace MarkWildmanNerdMathWorkouts.Shared.Models
{
    public class WorkoutExerciseNew
    {
        public readonly string Name;
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

        public List<string> GenerateWorkoutSchedule(RecoveryExcerciseStrategy recoveryExcerciseStrategy)
        {
            var now = new DateTime(2021, 1, 1);
            const int numberOfWorkoutIncrementsToGenerate = 14;

            var workoutIncrements = recoveryExcerciseStrategy.GenerateWorkoutIncrements(numberOfWorkoutIncrementsToGenerate);
            var workoutDates = now.Next(DateCalculationKind.AndThen, numberOfWorkoutIncrementsToGenerate, WorkoutDays.Select(a => a.DayOfWeek).ToArray());

            var workoutSchedules = workoutIncrements.Zip(workoutDates, (wi, wd) =>
            {
                return $"{wd.ToShortDateString()}|{wi}|";
            }).ToList();

            return workoutSchedules;
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