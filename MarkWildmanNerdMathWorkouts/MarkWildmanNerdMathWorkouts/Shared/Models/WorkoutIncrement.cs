namespace MarkWildmanNerdMathWorkouts.Shared.Models
{
    public record WorkoutIncrement
    {
        private string Title = "";
        public readonly Weight Weight = new Weight(0, Enums.WeightUnit.Unknown);
        public readonly int Reps;
        public readonly int Sets;

        public int TotalReps => Sets * Reps;
        public int WorkCapacity => Sets * Reps * Weight.Mass;

        public WorkoutIncrement(string title)
        {
            Title = title;
        }

        public WorkoutIncrement(Weight weight, int sets, int reps)
        {
            Weight = weight;
            Sets = sets;
            Reps = reps;
        }

        public override string ToString()
        {
            if (!string.IsNullOrEmpty(Title)) return Title;

            return $"{Weight} X {Sets} X {Reps} = {WorkCapacity}";
        }
    }
}