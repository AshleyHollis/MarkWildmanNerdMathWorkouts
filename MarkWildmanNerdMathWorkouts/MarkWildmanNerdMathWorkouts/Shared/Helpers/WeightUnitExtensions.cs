using MarkWildmanNerdMathWorkouts.Shared.Enums;

namespace MarkWildmanNerdMathWorkouts.Shared.Helpers
{
    public static class WeightUnitExtensions
    {
        public static string ToShortHandString(this WeightUnit weightUnit)
        {
            switch (weightUnit)
            {
                case WeightUnit.Kilograms:
                    return "kgs";
                case WeightUnit.Pounds:
                    return "lbs";
                default:
                    throw new ArgumentOutOfRangeException(nameof(weightUnit), weightUnit, "");
            }
        }
    }
}