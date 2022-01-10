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

            const string expected = @"04/01/2021|35 lbs X 10 X 10 = 3500 lbs|
07/01/2021|35 lbs X 10 X 11 = 3850 lbs|
11/01/2021|35 lbs X 10 X 12 = 4200 lbs|
14/01/2021|35 lbs X 10 X 13 = 4550 lbs|
18/01/2021|35 lbs X 10 X 14 = 4900 lbs|
21/01/2021|35 lbs X 10 X 15 = 5250 lbs|
25/01/2021|35 lbs X 10 X 16 = 5600 lbs|
28/01/2021|35 lbs X 10 X 17 = 5950 lbs|
01/02/2021|35 lbs X 10 X 18 = 6300 lbs|
04/02/2021|35 lbs X 10 X 19 = 6650 lbs|
08/02/2021|35 lbs X 10 X 20 = 7000 lbs|
11/02/2021|53 lbs X 10 X 10 = 5300 lbs|
15/02/2021|53 lbs X 10 X 11 = 5830 lbs|
18/02/2021|53 lbs X 10 X 12 = 6360 lbs|
22/02/2021|53 lbs X 10 X 13 = 6890 lbs|
25/02/2021|53 lbs X 10 X 14 = 7420 lbs|
01/03/2021|53 lbs X 10 X 15 = 7950 lbs|
04/03/2021|53 lbs X 10 X 16 = 8480 lbs|
08/03/2021|53 lbs X 10 X 17 = 9010 lbs|
11/03/2021|53 lbs X 10 X 18 = 9540 lbs|
15/03/2021|53 lbs X 10 X 19 = 10070 lbs|
18/03/2021|53 lbs X 10 X 20 = 10600 lbs|
22/03/2021|70 lbs X 10 X 10 = 7000 lbs|
25/03/2021|70 lbs X 10 X 11 = 7700 lbs|
29/03/2021|70 lbs X 10 X 12 = 8400 lbs|
01/04/2021|70 lbs X 10 X 13 = 9100 lbs|
05/04/2021|70 lbs X 10 X 14 = 9800 lbs|
08/04/2021|70 lbs X 10 X 15 = 10500 lbs|
12/04/2021|70 lbs X 10 X 16 = 11200 lbs|
15/04/2021|70 lbs X 10 X 17 = 11900 lbs|
19/04/2021|70 lbs X 10 X 18 = 12600 lbs|
22/04/2021|70 lbs X 10 X 19 = 13300 lbs|
26/04/2021|70 lbs X 10 X 20 = 14000 lbs|";

            string.Join(Environment.NewLine, test).Should().Be(expected);
        }

        [Fact]
        public void Correctly_Generate_Workout_Schedule_For_Kettlebell_Clean_And_Press_3To5Rungs_ThenIncreaseSetsTo5_ThenIncreaseWeight_Excercise()
        {
            var workoutExcercise = new WorkoutExerciseNew("Clean and Press", new List<WorkoutDayOfWeek> { new WorkoutDayOfWeek(DayOfWeek.Monday, 2, WeightLevel.Light), new WorkoutDayOfWeek(DayOfWeek.Thursday, 2, WeightLevel.Heavy) });
            var test = workoutExcercise.GenerateWorkoutSchedule(new ThreeToFiveRungsThenIncreaseSetsToFiveThenIncreaseWeightReverseLaddersExcerciseStrategy());

            const string expected = @"04/01/2021|35 lbs X 1 X 3 = 105 lbs|
07/01/2021|35 lbs X 1 X 4 = 140 lbs|
11/01/2021|35 lbs X 1 X 5 = 175 lbs|
14/01/2021|35 lbs X 2 X 3 = 210 lbs|
18/01/2021|35 lbs X 2 X 4 = 280 lbs|
21/01/2021|35 lbs X 2 X 5 = 350 lbs|
25/01/2021|35 lbs X 3 X 3 = 315 lbs|
28/01/2021|35 lbs X 3 X 4 = 420 lbs|
01/02/2021|35 lbs X 3 X 5 = 525 lbs|
04/02/2021|35 lbs X 4 X 3 = 420 lbs|
08/02/2021|35 lbs X 4 X 4 = 560 lbs|
11/02/2021|35 lbs X 4 X 5 = 700 lbs|
15/02/2021|35 lbs X 5 X 3 = 525 lbs|
18/02/2021|35 lbs X 5 X 4 = 700 lbs|
22/02/2021|35 lbs X 5 X 5 = 875 lbs|
25/02/2021|53 lbs X 1 X 3 = 159 lbs|
01/03/2021|53 lbs X 1 X 4 = 212 lbs|
04/03/2021|53 lbs X 1 X 5 = 265 lbs|
08/03/2021|53 lbs X 2 X 3 = 318 lbs|
11/03/2021|53 lbs X 2 X 4 = 424 lbs|
15/03/2021|53 lbs X 2 X 5 = 530 lbs|
18/03/2021|53 lbs X 3 X 3 = 477 lbs|
22/03/2021|53 lbs X 3 X 4 = 636 lbs|
25/03/2021|53 lbs X 3 X 5 = 795 lbs|
29/03/2021|53 lbs X 4 X 3 = 636 lbs|
01/04/2021|53 lbs X 4 X 4 = 848 lbs|
05/04/2021|53 lbs X 4 X 5 = 1060 lbs|
08/04/2021|53 lbs X 5 X 3 = 795 lbs|
12/04/2021|53 lbs X 5 X 4 = 1060 lbs|
15/04/2021|53 lbs X 5 X 5 = 1325 lbs|
19/04/2021|70 lbs X 1 X 3 = 210 lbs|
22/04/2021|70 lbs X 1 X 4 = 280 lbs|
26/04/2021|70 lbs X 1 X 5 = 350 lbs|
29/04/2021|70 lbs X 2 X 3 = 420 lbs|
03/05/2021|70 lbs X 2 X 4 = 560 lbs|
06/05/2021|70 lbs X 2 X 5 = 700 lbs|
10/05/2021|70 lbs X 3 X 3 = 630 lbs|
13/05/2021|70 lbs X 3 X 4 = 840 lbs|
17/05/2021|70 lbs X 3 X 5 = 1050 lbs|
20/05/2021|70 lbs X 4 X 3 = 840 lbs|
24/05/2021|70 lbs X 4 X 4 = 1120 lbs|
27/05/2021|70 lbs X 4 X 5 = 1400 lbs|
31/05/2021|70 lbs X 5 X 3 = 1050 lbs|
03/06/2021|70 lbs X 5 X 4 = 1400 lbs|
07/06/2021|70 lbs X 5 X 5 = 1750 lbs|";

            string.Join(Environment.NewLine, test).Should().Be(expected);
        }

        [Fact]
        public void Correctly_Generate_Workout_Schedule_For_Kettlebell_ReverseTurkishGetUp_10MinsTimeUnderTension_ThenIncreaseWeight_Excercise()
        {
            var workoutExcercise = new WorkoutExerciseNew("Reverse Turkish Get Up", new List<WorkoutDayOfWeek> { new WorkoutDayOfWeek(DayOfWeek.Monday, 2, WeightLevel.Light), new WorkoutDayOfWeek(DayOfWeek.Thursday, 2, WeightLevel.Heavy) });
            var test = workoutExcercise.GenerateWorkoutSchedule(new TenMinutesTimeUnderTensionThenIncreaseWeightExcerciseStrategy());

            const string expected = @"04/01/2021|35 lbs X 1 X 00:01:00 = 00:01:00|
07/01/2021|35 lbs X 1 X 00:02:00 = 00:02:00|
11/01/2021|35 lbs X 1 X 00:03:00 = 00:03:00|
14/01/2021|35 lbs X 1 X 00:04:00 = 00:04:00|
18/01/2021|35 lbs X 1 X 00:05:00 = 00:05:00|
21/01/2021|35 lbs X 1 X 00:06:00 = 00:06:00|
25/01/2021|35 lbs X 1 X 00:07:00 = 00:07:00|
28/01/2021|35 lbs X 1 X 00:08:00 = 00:08:00|
01/02/2021|35 lbs X 1 X 00:09:00 = 00:09:00|
04/02/2021|35 lbs X 1 X 00:10:00 = 00:10:00|
08/02/2021|53 lbs X 1 X 00:01:00 = 00:01:00|
11/02/2021|53 lbs X 1 X 00:02:00 = 00:02:00|
15/02/2021|53 lbs X 1 X 00:03:00 = 00:03:00|
18/02/2021|53 lbs X 1 X 00:04:00 = 00:04:00|
22/02/2021|53 lbs X 1 X 00:05:00 = 00:05:00|
25/02/2021|53 lbs X 1 X 00:06:00 = 00:06:00|
01/03/2021|53 lbs X 1 X 00:07:00 = 00:07:00|
04/03/2021|53 lbs X 1 X 00:08:00 = 00:08:00|
08/03/2021|53 lbs X 1 X 00:09:00 = 00:09:00|
11/03/2021|53 lbs X 1 X 00:10:00 = 00:10:00|
15/03/2021|70 lbs X 1 X 00:01:00 = 00:01:00|
18/03/2021|70 lbs X 1 X 00:02:00 = 00:02:00|
22/03/2021|70 lbs X 1 X 00:03:00 = 00:03:00|
25/03/2021|70 lbs X 1 X 00:04:00 = 00:04:00|
29/03/2021|70 lbs X 1 X 00:05:00 = 00:05:00|
01/04/2021|70 lbs X 1 X 00:06:00 = 00:06:00|
05/04/2021|70 lbs X 1 X 00:07:00 = 00:07:00|
08/04/2021|70 lbs X 1 X 00:08:00 = 00:08:00|
12/04/2021|70 lbs X 1 X 00:09:00 = 00:09:00|
15/04/2021|70 lbs X 1 X 00:10:00 = 00:10:00|";

            string.Join(Environment.NewLine, test).Should().Be(expected);
        }
    }
}
