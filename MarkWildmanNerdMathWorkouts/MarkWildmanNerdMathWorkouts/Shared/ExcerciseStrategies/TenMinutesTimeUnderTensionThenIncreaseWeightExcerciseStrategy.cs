using MarkWildmanNerdMathWorkouts.Shared.Models;

namespace MarkWildmanNerdMathWorkouts.Shared.ExcerciseStrategies
{
    public class TenMinutesTimeUnderTensionThenIncreaseWeightExcerciseStrategy
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
            const int singleSet = 1;
            var startTUT = new TimeSpan(0, 1, 0);
            var targetTUT = new TimeSpan(0, 10, 0);
            var incrementTUT = new TimeSpan(0, 1, 0);

            var useableWeights = availableWeights.Where(x => x.Mass >= startWeight.Mass && x.Mass <= targetWeight.Mass).ToList();

            if (currentWorkoutIncrement == null) return new WorkoutIncrement(useableWeights.First(), singleSet, startTUT);

            if (currentWorkoutIncrement.TUT < targetTUT) return new WorkoutIncrement(currentWorkoutIncrement.Weight, singleSet, currentWorkoutIncrement.TUT.Add(incrementTUT));

            var nextWeight = useableWeights.FirstOrDefault(a => a.Mass > currentWorkoutIncrement.Weight.Mass);
            if (nextWeight == null)
            {
                return new WorkoutIncrement(currentWorkoutIncrement.Weight, currentWorkoutIncrement.Sets, currentWorkoutIncrement.TUT);
            }

            return new WorkoutIncrement(nextWeight, singleSet, startTUT);
        }
    }
}