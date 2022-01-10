using MarkWildmanNerdMathWorkouts.Shared.Models;

namespace MarkWildmanNerdMathWorkouts.Shared.ExcerciseStrategies
{
    public class TenSetsTenRepsToTwentyRepsThenIncreaseWeightExcerciseStrategy
    {
        public List<WorkoutIncrement> GenerateWorkoutIncrements(Weight startWeight, Weight targetWeight, List<Weight> availableWeights)
        {
            var useableWeights = availableWeights.Where(x => x.Mass >= startWeight.Mass && x.Mass <= targetWeight.Mass).ToList();
            var workouts = new List<WorkoutIncrement>();

            foreach (var weight in useableWeights)
            {
                for (int i = 10; i <= 20; i++)
                {
                    workouts.Add(new WorkoutIncrement(weight, 10, i));
                }
            }

            return workouts;
        }
    }
}