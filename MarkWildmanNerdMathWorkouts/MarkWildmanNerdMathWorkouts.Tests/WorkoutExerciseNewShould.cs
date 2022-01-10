using FluentAssertions;
using MarkWildmanNerdMathWorkouts.Shared.Enums;
using MarkWildmanNerdMathWorkouts.Shared.ExcerciseStrategies;
using MarkWildmanNerdMathWorkouts.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MarkWildmanNerdMathWorkouts.Tests
{
    public class WorkoutExerciseNewShould
    {
        [Fact]
        public void Correctly_Generate_Workout_Schedule_For_Recovery_Excercise()
        {
            var workoutExcercise = new WorkoutExerciseNew("Recovery", new List<WorkoutDayOfWeek> { new WorkoutDayOfWeek(DayOfWeek.Sunday, 1), new WorkoutDayOfWeek(DayOfWeek.Wednesday, 1), new WorkoutDayOfWeek(DayOfWeek.Saturday, 1) });
            var test = workoutExcercise.GenerateWorkoutSchedule(new RecoveryExcerciseStrategy());

            const string expected = @"3/01/2021|Recovery|
6/01/2021|Recovery|
9/01/2021|Recovery|
10/01/2021|Recovery|
13/01/2021|Recovery|
16/01/2021|Recovery|
17/01/2021|Recovery|
20/01/2021|Recovery|
23/01/2021|Recovery|
24/01/2021|Recovery|
27/01/2021|Recovery|
30/01/2021|Recovery|
31/01/2021|Recovery|
3/02/2021|Recovery|";

            string.Join(Environment.NewLine, test).Should().Be(expected);
        }

        [Fact]
        public void Correctly_Generate_Workout_Schedule_For_Kettlebell_Swings_10Sets10RepsTo20Reps_Excercise()
        {
            var workoutExcercise = new WorkoutExerciseNew("Swings", new List<WorkoutDayOfWeek> { new WorkoutDayOfWeek(DayOfWeek.Monday, 2, WeightLevel.Light), new WorkoutDayOfWeek(DayOfWeek.Thursday, 2, WeightLevel.Heavy) });
            var test = workoutExcercise.GenerateWorkoutSchedule(new TenSetsTenRepsToTwentyRepsThenIncreaseWeightExcerciseStrategy());

            const string expected = @"04/01/2021|35lbs X 10 X 10 = 3500|
07/01/2021|35lbs X 10 X 11 = 3850|
11/01/2021|35lbs X 10 X 12 = 4200|
14/01/2021|35lbs X 10 X 13 = 4550|
18/01/2021|35lbs X 10 X 14 = 4900|
21/01/2021|35lbs X 10 X 15 = 5250|
25/01/2021|35lbs X 10 X 16 = 5600|
28/01/2021|35lbs X 10 X 17 = 5950|
01/02/2021|35lbs X 10 X 18 = 6300|
04/02/2021|35lbs X 10 X 19 = 6650|
08/02/2021|35lbs X 10 X 20 = 7000|
11/02/2021|53lbs X 10 X 10 = 5300|
15/02/2021|53lbs X 10 X 11 = 5830|
18/02/2021|53lbs X 10 X 12 = 6360|
22/02/2021|53lbs X 10 X 13 = 6890|
25/02/2021|53lbs X 10 X 14 = 7420|
01/03/2021|53lbs X 10 X 15 = 7950|
04/03/2021|53lbs X 10 X 16 = 8480|
08/03/2021|53lbs X 10 X 17 = 9010|
11/03/2021|53lbs X 10 X 18 = 9540|
15/03/2021|53lbs X 10 X 19 = 10070|
18/03/2021|53lbs X 10 X 20 = 10600|
22/03/2021|70lbs X 10 X 10 = 7000|
25/03/2021|70lbs X 10 X 11 = 7700|
29/03/2021|70lbs X 10 X 12 = 8400|
01/04/2021|70lbs X 10 X 13 = 9100|
05/04/2021|70lbs X 10 X 14 = 9800|
08/04/2021|70lbs X 10 X 15 = 10500|
12/04/2021|70lbs X 10 X 16 = 11200|
15/04/2021|70lbs X 10 X 17 = 11900|
19/04/2021|70lbs X 10 X 18 = 12600|
22/04/2021|70lbs X 10 X 19 = 13300|
26/04/2021|70lbs X 10 X 20 = 14000|";

            string.Join(Environment.NewLine, test).Should().Be(expected);
        }

        [Fact]
        public void Correctly_Generate_Workout_Schedule_For_Kettlebell_Clean_And_Press_3To5Rungs_ThenIncreaseSetsTo5_ThenIncreaseWeight_Excercise()
        {
            var workoutExcercise = new WorkoutExerciseNew("Swings", new List<WorkoutDayOfWeek> { new WorkoutDayOfWeek(DayOfWeek.Monday, 2, WeightLevel.Light), new WorkoutDayOfWeek(DayOfWeek.Thursday, 2, WeightLevel.Heavy) });
            var test = workoutExcercise.GenerateWorkoutSchedule(new ThreeToFiveRungsThenIncreaseSetsToFiveThenIncreaseWeightReverseLaddersExcerciseStrategy());

            const string expected = @"04/01/2021|35lbs X 1 X 3 = 105|
07/01/2021|35lbs X 1 X 4 = 140|
11/01/2021|35lbs X 1 X 5 = 175|
14/01/2021|35lbs X 2 X 3 = 210|
18/01/2021|35lbs X 2 X 4 = 280|
21/01/2021|35lbs X 2 X 5 = 350|
25/01/2021|35lbs X 3 X 3 = 315|
28/01/2021|35lbs X 3 X 4 = 420|
01/02/2021|35lbs X 3 X 5 = 525|
04/02/2021|35lbs X 4 X 3 = 420|
08/02/2021|35lbs X 4 X 4 = 560|
11/02/2021|35lbs X 4 X 5 = 700|
15/02/2021|35lbs X 5 X 3 = 525|
18/02/2021|35lbs X 5 X 4 = 700|
22/02/2021|35lbs X 5 X 5 = 875|
25/02/2021|53lbs X 1 X 3 = 159|
01/03/2021|53lbs X 1 X 4 = 212|
04/03/2021|53lbs X 1 X 5 = 265|
08/03/2021|53lbs X 2 X 3 = 318|
11/03/2021|53lbs X 2 X 4 = 424|
15/03/2021|53lbs X 2 X 5 = 530|
18/03/2021|53lbs X 3 X 3 = 477|
22/03/2021|53lbs X 3 X 4 = 636|
25/03/2021|53lbs X 3 X 5 = 795|
29/03/2021|53lbs X 4 X 3 = 636|
01/04/2021|53lbs X 4 X 4 = 848|
05/04/2021|53lbs X 4 X 5 = 1060|
08/04/2021|53lbs X 5 X 3 = 795|
12/04/2021|53lbs X 5 X 4 = 1060|
15/04/2021|53lbs X 5 X 5 = 1325|
19/04/2021|70lbs X 1 X 3 = 210|
22/04/2021|70lbs X 1 X 4 = 280|
26/04/2021|70lbs X 1 X 5 = 350|
29/04/2021|70lbs X 2 X 3 = 420|
03/05/2021|70lbs X 2 X 4 = 560|
06/05/2021|70lbs X 2 X 5 = 700|
10/05/2021|70lbs X 3 X 3 = 630|
13/05/2021|70lbs X 3 X 4 = 840|
17/05/2021|70lbs X 3 X 5 = 1050|
20/05/2021|70lbs X 4 X 3 = 840|
24/05/2021|70lbs X 4 X 4 = 1120|
27/05/2021|70lbs X 4 X 5 = 1400|
31/05/2021|70lbs X 5 X 3 = 1050|
03/06/2021|70lbs X 5 X 4 = 1400|
07/06/2021|70lbs X 5 X 5 = 1750|";

            string.Join(Environment.NewLine, test).Should().Be(expected);
        }
    }
}
