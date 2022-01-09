using MarkWildmanNerdMathWorkouts.Shared.Enums;

namespace MarkWildmanNerdMathWorkouts.Shared.Models
{
    public record WorkoutDayOfWeek : IComparable<WorkoutDayOfWeek>
    {
        public DayOfWeek DayOfWeek;
        public WeightLevel WeightLevel;
        public int Order;

        public WorkoutDayOfWeek(WorkoutDayOfWeek workoutDayOfWeek, int order)
        {
            DayOfWeek = workoutDayOfWeek.DayOfWeek;
            WeightLevel = workoutDayOfWeek.WeightLevel;
            Order = order;
        }

        public WorkoutDayOfWeek(DayOfWeek dayOfWeek, int order, WeightLevel weightLevel = WeightLevel.Unknown)
        {
            DayOfWeek = dayOfWeek;
            WeightLevel = weightLevel;
            Order = order;
        }

        public int CompareTo(WorkoutDayOfWeek? other)
        {
            if (other == null) return 1;

            if (DayOfWeek != other.DayOfWeek)
            {
                return DayOfWeek - other.DayOfWeek;
            }

            return Order - other.Order;
        }
    }
}