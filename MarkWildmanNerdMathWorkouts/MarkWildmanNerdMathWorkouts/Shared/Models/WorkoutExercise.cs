namespace MarkWildmanNerdMathWorkouts.Shared.Models
{
    public class WorkoutExercise
    {
        public List<WorkPerformed> WorkPerformed { get; protected set; }
        public int WorkCapacity
        {
            get { return WorkPerformed.Sum(x => x.Reps * x.Sets * x.Weight); }
        }

        public WorkoutExercise()
        {
            WorkPerformed = new List<WorkPerformed>();
        }

        public string CaculateNextExerciseUsingNewWeight(int currentWorkCapacity, int newWeight, int newRungCount)
        {
            var reps = currentWorkCapacity / newWeight;
            var reverseLadder = new ReverseLadder(newRungCount);
            var newReps = reverseLadder.TotalReps;
            var sets = reps / newReps;

            return String.Format("{0} x {1} x {2}", newWeight, sets, reverseLadder.Rungs);
        }
    }
}
