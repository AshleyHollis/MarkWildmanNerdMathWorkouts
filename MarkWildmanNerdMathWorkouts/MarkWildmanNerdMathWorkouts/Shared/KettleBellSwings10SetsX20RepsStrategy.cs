using MarkWildmanNerdMathWorkouts.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarkWildmanNerdMathWorkouts.Shared
{
    public class KettleBellSwings10SetsX20RepsStrategy
    {
        private int startWeight;
        private int targetWeight;
        private List<int> availableWeights;

        public KettleBellSwings10SetsX20RepsStrategy(int startWeight, int targetWeight, List<int> availableWeights)
        {
            this.startWeight = startWeight;
            this.targetWeight = targetWeight;
            this.availableWeights = availableWeights;
        }

        public List<WorkPerformed> Generate()
        {
            var useableWeights = availableWeights.Where(x => x >= startWeight && x <= targetWeight).ToList();
            var workouts = new List<WorkPerformed>();

            foreach (var weight in useableWeights)
            {
                for (int i = 10; i <= 20; i++)
                {
                    workouts.Add(new WorkPerformed() { Weight = weight, Sets = 10, Reps = i });
                }
            }

            return workouts;
        }
    }
}
