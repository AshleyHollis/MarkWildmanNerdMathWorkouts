using MarkWildmanNerdMathWorkouts.Shared.Enums;
using MarkWildmanNerdMathWorkouts.Shared.Helpers;

namespace MarkWildmanNerdMathWorkouts.Shared.Models
{
    public record Weight
    {
        public int Mass { get; }
        public WeightUnit Unit { get; }

        public static Weight Default => new Weight(0, WeightUnit.Unknown);

        public Weight(int mass, WeightUnit unit)
        {
            Mass = mass;
            Unit = unit;
        }

        public override string ToString()
        {
            return string.Format("{0} {1}", Mass, Unit.ToShortHandString());
        }        
    }
}