namespace MarkWildmanNerdMathWorkouts.Shared.Models
{
    public class WorkoutIncrement
    {
        private string Title;

        public WorkoutIncrement(string title)
        {
            this.Title = title;
        }

        public override string ToString()
        {
            return Title;
        }
    }
}