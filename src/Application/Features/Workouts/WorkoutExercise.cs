using System;
using System.Collections.Generic;
using System.Linq;

namespace MarkWildmanNerdMathWorkouts.Application.Features.Workouts
{
    public class WorkoutExercise
    {
        public List<WorkPerformed> WorkPerformed { get; private set; }
        public int WorkCapacity
        {
            get { return WorkPerformed.Sum(x => x.WorkCapacity); }
        }

        public WorkoutExercise()
        {
            WorkPerformed = new List<WorkPerformed>();
        }

        public void AddWorkPerformed(WorkPerformed workPerformed)
        {
            WorkPerformed.Add(workPerformed);
        }

        public string CaculateNextExerciseUsingNewWeight(int currentWorkCapacity, Weight newWeight, int newRungCount)
        {
            var reps = currentWorkCapacity / newWeight.Mass;
            var reverseLadder = new ReverseLadder(newRungCount);
            var newReps = reverseLadder.TotalReps;
            var sets = reps / newReps;

            return String.Format("{0} x {1} x {2}", newWeight, sets, reverseLadder.Rungs);
        }
    }
}
