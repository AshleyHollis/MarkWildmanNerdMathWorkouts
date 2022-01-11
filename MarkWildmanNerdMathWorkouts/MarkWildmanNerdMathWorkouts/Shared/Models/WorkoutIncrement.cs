﻿namespace MarkWildmanNerdMathWorkouts.Shared.Models
{
    public record WorkoutIncrement
    {
        private string Title = "";
        public readonly Weight Weight = new Weight(0, Enums.WeightUnit.Unknown);
        public readonly int Reps;
        public readonly int Sets;
        public readonly TimeSpan TUT;
        public readonly bool IsEndOfCycle;

        public int TotalReps => Sets * Reps;
        public WorkCapacity WorkCapacity
        {
            get
            {
                if (TUT != TimeSpan.Zero)
                {
                    return new WorkCapacity(new TimeSpan(Sets * TUT.Ticks));
                }

                return new WorkCapacity(new Weight(Sets * Reps * Weight.Mass, Weight.Unit));
            }
        }

        public WorkoutIncrement(string title)
        {
            Title = title;
        }

        public WorkoutIncrement(Weight weight, int sets, int reps, bool isEndOfCycle = false)
        {
            Weight = weight;
            Sets = sets;
            Reps = reps;
            IsEndOfCycle = isEndOfCycle;
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

            return $"{Weight} X {Sets} X {Reps} = {WorkCapacity}";
        }
    }
}