using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarkWildmanNerdMathWorkouts.Application.Features.Workouts
{
    public class ReverseLadder
    {
        public int Rungs
        {
            get; protected set;
        }
        public int TotalReps => RepsPerHand * 2;
        public int RepsPerHand => GetTotalRepsPerHand();

        private int GetTotalRepsPerHand()
        {
            var totalReps = 0;
            for (int i = 1; i <= Rungs; i++)
            {
                totalReps += i;
            }

            return totalReps;
        }

        public ReverseLadder(int rungs)
        {
            Rungs = rungs;
        }
    }
}
