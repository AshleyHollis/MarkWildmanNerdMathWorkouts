using System;

namespace MarkWildmanNerdMathWorkouts.Application.Features.Workouts
{
    public record WorkoutIncrement
    {
        private string Title = "";
        public readonly Weight Weight = new Weight(0, Enums.WeightUnit.Unknown);
        public readonly int Reps;
        public readonly int Sets;
        public readonly TimeSpan TUT;
        public readonly bool IsEndOfCycle;
        public readonly bool IsBilateral;

        public int TotalReps => Sets * Reps;
        public WorkCapacity WorkCapacity
        {
            get
            {
                if (TUT != TimeSpan.Zero)
                {
                    return new WorkCapacity(new TimeSpan(Sets * TUT.Ticks));
                }

                var workCapacityWeight = IsBilateral ? Sets * Reps * Weight.Mass * 2 : Sets * Reps * Weight.Mass;
                return new WorkCapacity(new Weight(workCapacityWeight, Weight.Unit));
            }
        }

        public WorkoutIncrement(string title)
        {
            Title = title;
        }

        public WorkoutIncrement(Weight weight, int sets, int reps, bool isEndOfCycle = false, bool isBilateral = false)
        {
            Weight = weight;
            Sets = sets;
            Reps = reps;
            IsEndOfCycle = isEndOfCycle;
            IsBilateral = isBilateral;
        }

        public WorkoutIncrement(Weight weight, int sets, TimeSpan tut, bool isEndOfCycle = false)
        {
            Weight = weight;
            Sets = sets;
            TUT = tut;
            IsEndOfCycle = isEndOfCycle;
        }

        public override string ToString()
        {
            if (!string.IsNullOrEmpty(Title)) return Title;

            if (TUT != TimeSpan.Zero) return $"{Weight} X {Sets} X {TUT} = {WorkCapacity}";

            return $"{Weight} X {Sets} X {(IsBilateral ? $"{Reps}/{Reps}" : Reps)} = {WorkCapacity}";
        }
    }
}