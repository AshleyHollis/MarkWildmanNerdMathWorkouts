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
        private Weight startWeight;
        private Weight targetWeight;
        private List<Weight> availableWeights;

        public KettleBellSwings10SetsX20RepsStrategy(Weight startWeight, Weight targetWeight, List<Weight> availableWeights)
        {
            this.startWeight = startWeight;
            this.targetWeight = targetWeight;
            this.availableWeights = availableWeights;
        }

        public List<WorkPerformed> Generate()
        {
            var useableWeights = availableWeights.Where(x => x.Mass >= startWeight.Mass && x.Mass <= targetWeight.Mass).ToList();
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
