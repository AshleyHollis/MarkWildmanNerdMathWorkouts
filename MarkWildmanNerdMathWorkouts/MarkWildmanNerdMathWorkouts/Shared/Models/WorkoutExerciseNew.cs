using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using MarkWildmanNerdMathWorkouts.Shared.Enums;
using MarkWildmanNerdMathWorkouts.Shared.ExcerciseStrategies;
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

        public WorkoutExerciseNew(string name, List<WorkoutDayOfWeek> workoutDays, WeightLevel weightLevel = WeightLevel.Unknown)
        {
            Name = name;
            WorkoutDays = workoutDays;
            WeightLevel = weightLevel;
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

        public override string ToString()
        {
            var flattenedExcercises = FlattenByDay();

            return string.Join(Environment.NewLine, flattenedExcercises.Select(a => string.Format("{0}|{1}|{2}|", a.WorkoutDays.Single().DayOfWeek.ToShortString(), a.Name, a.WorkoutDays.Single().WeightLevel.ToShortString())));
        }

        public List<string> GenerateWorkoutSchedule(RecoveryExcerciseStrategy excerciseStrategy)
        {
            var now = new DateTime(2021, 1, 1);
            const int numberOfWorkoutIncrementsToGenerate = 14;

            var workoutIncrements = excerciseStrategy.GenerateWorkoutIncrements(numberOfWorkoutIncrementsToGenerate);
            var workoutDates = now.Next(DateCalculationKind.AndThen, numberOfWorkoutIncrementsToGenerate, WorkoutDays.Select(a => a.DayOfWeek).ToArray());

            var workoutSchedules = workoutIncrements.Zip(workoutDates, (wi, wd) =>
            {
                return $"{wd.ToShortDateString()}|{wi}|";
            }).ToList();

            return workoutSchedules;
        }

        public List<string> GenerateWorkoutSchedule(TenSetsTenRepsToTwentyRepsThenIncreaseWeightExcerciseStrategy excerciseStrategy)
        {
            var now = new DateTime(2021, 1, 1);

            var startWeight = new Weight(35, WeightUnit.Pounds);
            var targetWeight = new Weight(70, WeightUnit.Pounds);
            var availableWeights = new List<Weight> { new Weight(35, WeightUnit.Pounds), new Weight(53, WeightUnit.Pounds), new Weight(70, WeightUnit.Pounds) };
            
            var workoutIncrements = excerciseStrategy.GenerateWorkoutIncrements(startWeight, targetWeight, availableWeights);
            var workoutDates = now.Next(DateCalculationKind.AndThen, workoutIncrements.Count, WorkoutDays.Select(a => a.DayOfWeek).ToArray());

            var workoutSchedules = workoutIncrements.Zip(workoutDates, (wi, wd) =>
            {
                return $"{wd.ToString("dd/MM/yyyy")}|{wi}|";
            }).ToList();

            return workoutSchedules;
        }

        public List<string> GenerateWorkoutSchedule(ThreeToFiveRungsThenIncreaseSetsToFiveThenIncreaseWeightReverseLaddersExcerciseStrategy excerciseStrategy)
        {
            var now = new DateTime(2021, 1, 1);

            var startWeight = new Weight(35, WeightUnit.Pounds);
            var targetWeight = new Weight(70, WeightUnit.Pounds);
            var availableWeights = new List<Weight> { new Weight(35, WeightUnit.Pounds), new Weight(53, WeightUnit.Pounds), new Weight(70, WeightUnit.Pounds) };

            var workoutIncrements = excerciseStrategy.GenerateWorkoutIncrements(startWeight, targetWeight, availableWeights);
            var workoutDates = now.Next(DateCalculationKind.AndThen, workoutIncrements.Count, WorkoutDays.Select(a => a.DayOfWeek).ToArray());

            var workoutSchedules = workoutIncrements.Zip(workoutDates, (wi, wd) =>
            {
                return $"{wd.ToString("dd/MM/yyyy")}|{wi}|";
            }).ToList();

            return workoutSchedules;
        }

        public List<string> GenerateWorkoutSchedule(TenMinutesTimeUnderTensionThenIncreaseWeightExcerciseStrategy excerciseStrategy)
        {
            var now = new DateTime(2021, 1, 1);

            var startWeight = new Weight(35, WeightUnit.Pounds);
            var targetWeight = new Weight(70, WeightUnit.Pounds);
            var availableWeights = new List<Weight> { new Weight(35, WeightUnit.Pounds), new Weight(53, WeightUnit.Pounds), new Weight(70, WeightUnit.Pounds) };

            var workoutIncrements = excerciseStrategy.GenerateWorkoutIncrements(startWeight, targetWeight, availableWeights);
            var workoutDates = now.Next(DateCalculationKind.AndThen, workoutIncrements.Count, WorkoutDays.Select(a => a.DayOfWeek).ToArray());

            var workoutSchedules = workoutIncrements.Zip(workoutDates, (wi, wd) =>
            {
                return $"{wd.ToString("dd/MM/yyyy")}|{wi}|";
            }).ToList();

            return workoutSchedules;
        }
    }
}