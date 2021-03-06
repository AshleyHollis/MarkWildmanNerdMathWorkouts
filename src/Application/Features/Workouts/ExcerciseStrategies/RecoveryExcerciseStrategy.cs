using System.Collections.Generic;

namespace MarkWildmanNerdMathWorkouts.Application.Features.Workouts.ExcerciseStrategies
{
    public class RecoveryExcerciseStrategy
    {
        public RecoveryExcerciseStrategy()
        {
        }

        public List<WorkoutIncrement> GenerateWorkoutIncrements(int numberOfWorkoutIncrementsToGenerate)
        {
            var workoutIncrements = new List<WorkoutIncrement>();
            for (int i = 0; i < numberOfWorkoutIncrementsToGenerate; i++)
            {
                workoutIncrements.Add(new WorkoutIncrement("Recovery"));
            }

            return workoutIncrements;
        }
    }
}