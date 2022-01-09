﻿using MarkWildmanNerdMathWorkouts.Shared.Enums;

namespace MarkWildmanNerdMathWorkouts.Shared.Helpers
{
    public static class WeightLevelExtensions
    {
        public static string ToShortString(this WeightLevel weightLevel)
        {
            switch (weightLevel)
            {
                case WeightLevel.Unknown:
                    return "";
                case WeightLevel.Light:
                    return "L";
                case WeightLevel.Medium:
                    return "M";
                case WeightLevel.Heavy:
                    return "H";
                default:
                    throw new ArgumentOutOfRangeException(nameof(weightLevel), weightLevel, "");
            }
        }
    }
}