﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarkWildmanNerdMathWorkouts.Shared.Models
{
    public class WorkPerformed
    {
        public int Sets { get; set; }
        public int Reps { get; set; }
        public int Weight { get; set; }

        public int TotalReps => Sets * Reps;
        public int WorkCapacity => Sets * Reps * Weight;

        public override string ToString() => string.Format("{0} {1} {2} {3}", Weight, Sets, Reps, WorkCapacity);
    }
}
