using MarkWildmanNerdMathWorkouts.Shared.Models;

namespace MarkWildmanNerdMathWorkouts.Shared.ExcerciseStrategies
{
    public class ThreeToFiveRungsThenIncreaseSetsToFiveThenIncreaseWeightReverseLaddersExcerciseStrategy
    {
        public List<WorkoutIncrement> GenerateWorkoutIncrements(Weight startWeight, Weight targetWeight, List<Weight> availableWeights)
        {
            var workouts = new List<WorkoutIncrement>();
            WorkoutIncrement currentWorkoutIncrement = null;

            while (true)
            {
                var nextWorkoutIncrement = Next(startWeight, targetWeight, availableWeights, currentWorkoutIncrement);
                if (currentWorkoutIncrement == nextWorkoutIncrement) break;
                
                workouts.Add(nextWorkoutIncrement);
                currentWorkoutIncrement = nextWorkoutIncrement;
            };

            return workouts;
        }

        public static WorkoutIncrement Next(Weight startWeight, Weight targetWeight, List<Weight> availableWeights, WorkoutIncrement? currentWorkoutIncrement)
        {
            const int startRungs = 3;
            const int startSets = 1;
            const int maxRungs = 5;
            const int maxSets = 5;

            var useableWeights = availableWeights.Where(x => x.Mass >= startWeight.Mass && x.Mass <= targetWeight.Mass).ToList();
            if (currentWorkoutIncrement == null) return new WorkoutIncrement(useableWeights.First(), startSets, startRungs);

            if (currentWorkoutIncrement.Reps < maxRungs)
            {
                return IncreaseReps(currentWorkoutIncrement);
            }

            if (currentWorkoutIncrement.Sets < maxSets)
            {
                return IncreaseSets(currentWorkoutIncrement, startRungs);
            }

            return IncreaseWeight(currentWorkoutIncrement, startRungs, startSets, useableWeights);
        }

        private static WorkoutIncrement IncreaseWeight(WorkoutIncrement currentWorkoutIncrement, int startRungs, int startSets, List<Weight> useableWeights)
        {
            var nextWeight = useableWeights.FirstOrDefault(a => a.Mass > currentWorkoutIncrement.Weight.Mass);
            if (nextWeight == null)
            {
                return new WorkoutIncrement(currentWorkoutIncrement.Weight, currentWorkoutIncrement.Sets, currentWorkoutIncrement.Reps);
            }

            return new WorkoutIncrement(nextWeight, startSets, startRungs);
        }

        private static WorkoutIncrement IncreaseSets(WorkoutIncrement currentWorkoutIncrement, int startRungs)
        {
            return new WorkoutIncrement(currentWorkoutIncrement.Weight, currentWorkoutIncrement.Sets + 1, startRungs);
        }

        private static WorkoutIncrement IncreaseReps(WorkoutIncrement currentWorkoutIncrement)
        {
            return new WorkoutIncrement(currentWorkoutIncrement.Weight, currentWorkoutIncrement.Sets, currentWorkoutIncrement.Reps + 1);
        }
    }
}