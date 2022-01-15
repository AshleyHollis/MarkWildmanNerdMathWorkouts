using System;

namespace MarkWildmanNerdMathWorkouts.Application.Features.Workouts
{
    public record WorkCapacity
    {
        public readonly TimeSpan TUT;
        public readonly Weight Weight = Weight.Default;

        public WorkCapacity(TimeSpan tut)
        {
            TUT = tut;
        }

        public WorkCapacity(Weight weight)
        {
            Weight = weight;
        }

        public override string ToString()
        {
            if (TUT != TimeSpan.Zero) return TUT.ToString();
            return Weight.ToString();
        }
    }
}