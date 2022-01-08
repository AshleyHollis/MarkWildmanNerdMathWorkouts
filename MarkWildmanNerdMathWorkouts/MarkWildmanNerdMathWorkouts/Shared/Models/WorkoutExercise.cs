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
    }
}
