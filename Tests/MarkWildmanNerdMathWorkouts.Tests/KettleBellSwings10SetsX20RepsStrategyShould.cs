using FluentAssertions;
using MarkWildmanNerdMathWorkouts.Application.Enums;
using MarkWildmanNerdMathWorkouts.Application.Extensions;
using MarkWildmanNerdMathWorkouts.Application.Features.Workouts;
using MarkWildmanNerdMathWorkouts.Application.Features.Workouts.ExcerciseStrategies;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace MarkWildmanNerdMathWorkouts.Tests
{
    public class KettleBellSwings10SetsX20RepsStrategyShould
    {
        public static IEnumerable<object[]> GetTestData()
        {
            // Weight | Sets | Reps | Work Capacity
            var allData = new List<object[]>
            {
                new object[] { new Weight(35, WeightUnit.Pounds), new Weight(70, WeightUnit.Pounds), new List<Weight>{ new Weight(35, WeightUnit.Pounds), new Weight(53, WeightUnit.Pounds), new Weight(70, WeightUnit.Pounds) }, string.Join(Environment.NewLine, new List<string> { 
                        "35 lbs x 10 x 10 = 3500",
                        "35 lbs x 10 x 11 = 3850",
                        "35 lbs x 10 x 12 = 4200",
                        "35 lbs x 10 x 13 = 4550",
                        "35 lbs x 10 x 14 = 4900",
                        "35 lbs x 10 x 15 = 5250",
                        "35 lbs x 10 x 16 = 5600",
                        "35 lbs x 10 x 17 = 5950",
                        "35 lbs x 10 x 18 = 6300",
                        "35 lbs x 10 x 19 = 6650",
                        "35 lbs x 10 x 20 = 7000",
                        "53 lbs x 10 x 10 = 5300",
                        "53 lbs x 10 x 11 = 5830",
                        "53 lbs x 10 x 12 = 6360",
                        "53 lbs x 10 x 13 = 6890",
                        "53 lbs x 10 x 14 = 7420",
                        "53 lbs x 10 x 15 = 7950",
                        "53 lbs x 10 x 16 = 8480",
                        "53 lbs x 10 x 17 = 9010",
                        "53 lbs x 10 x 18 = 9540",
                        "53 lbs x 10 x 19 = 10070",
                        "53 lbs x 10 x 20 = 10600",
                        "70 lbs x 10 x 10 = 7000",
                        "70 lbs x 10 x 11 = 7700",
                        "70 lbs x 10 x 12 = 8400",
                        "70 lbs x 10 x 13 = 9100",
                        "70 lbs x 10 x 14 = 9800",
                        "70 lbs x 10 x 15 = 10500",
                        "70 lbs x 10 x 16 = 11200",
                        "70 lbs x 10 x 17 = 11900",
                        "70 lbs x 10 x 18 = 12600",
                        "70 lbs x 10 x 19 = 13300",
                        "70 lbs x 10 x 20 = 14000"
                    }
                )}
            };

            return allData;
        }

        [Theory]
        [MemberData(nameof(GetTestData))]
        public void Test1(Weight startWeight, Weight targetWeight, List<Weight> availableWeights, string expected)
        {
            /*  Increase reps from 10 to 20 then increase weight.
                Weights:  16kg (35lbs), 24kg (53lbs), 32kg (70lbs)
               
                Expectation:
                Format: Weight x Sets x Reps = Work Capacity
                35 lbs x 10 x 10 = 3500
                35 lbs x 10 x 15 = 5250
                35 lbs x 10 x 20 = 7000
                53 lbs x 10 x 10 = 5300
                53 lbs x 10 x 15 = 7950
                53 lbs x 10 x 20 = 10600
                70 lbs x 10 x 10 = 7000
                70 lbs x 10 x 15 = 10500
                70 lbs x 10 x 20 = 14000

                Is 10 min of Kettlebelling enough - Part II - Yes - Nerd Math
                https://www.youtube.com/watch?v=lcECmuWTL3g
            */
            var kettleBellSwings10SetsX20RepsStrategy = new KettleBellSwings10SetsX20RepsStrategy(startWeight, targetWeight, availableWeights);
            var workouts = kettleBellSwings10SetsX20RepsStrategy.Generate();

            string.Join(Environment.NewLine, workouts.Select(x => x.ToString())).Should().Be(expected);
        }

        [Theory]
        [MemberData(nameof(GetTestData))]
        public void Test2(Weight startWeight, Weight targetWeight, List<Weight> availableWeights, string expected)
        {
            /*  Increase reps from 10 to 20 then increase weight.
                Weights:  16kg (35lbs), 24kg (53lbs), 32kg (70lbs)
               
                Expectation:
                Format: Weight x Sets x Reps = Work Capacity
                35 lbs x 10 x 10 = 3500
                35 lbs x 10 x 15 = 5250
                35 lbs x 10 x 20 = 7000
                53 lbs x 10 x 10 = 5300
                53 lbs x 10 x 15 = 7950
                53 lbs x 10 x 20 = 10600
                70 lbs x 10 x 10 = 7000
                70 lbs x 10 x 15 = 10500
                70 lbs x 10 x 20 = 14000

                Is 10 min of Kettlebelling enough - Part II - Yes - Nerd Math
                https://www.youtube.com/watch?v=lcECmuWTL3g
            */

            var now = new DateTime(2021, 1, 1);
            var workoutDaysOfWeeks = new DayOfWeek[] { DayOfWeek.Monday, DayOfWeek.Wednesday };

            var kettleBellSwings10SetsX20RepsStrategy = new KettleBellSwings10SetsX20RepsStrategy(startWeight, targetWeight, availableWeights);
            var workouts = kettleBellSwings10SetsX20RepsStrategy.Generate();
            var workoutDates = now.Next(DateCalculationKind.AndThen, workouts.Count, workoutDaysOfWeeks).ToList();
            var workoutSessions = workouts.Zip(workoutDates, (w, wd) =>
            {
                var workoutSession = new WorkoutSession(wd, WorkoutType.KettleBell, WorkoutLevel.Unknown, WeightLevel.Unknown, HeartRateLevel.Unknown, ThoughtLevel.Unknown);
                var workoutExercise = new WorkoutExercise();
                workoutExercise.AddWorkPerformed(new WorkPerformed { Weight = w.Weight, Sets = w.Sets, Reps = w.Reps });
                workoutSession.AddWorkoutExcercise(workoutExercise);

                return workoutSession;
            }).ToList();

            string.Join(Environment.NewLine, workouts.Select(x => x.ToString())).Should().Be(expected);
            workoutDates.Should().HaveCount(33);
            workoutSessions.Should().HaveCount(33);
        }

        /*            
https://www.youtube.com/watch?v=R82K_GmdMvU

Lumidingo
1 month ago
​ @Brandon Huff  For a HL Nerd Math swing progression, you have 8 steps in the progression. Pick your starting weight, do four sessions. The next scheduled day, pick a higher weight, and start at the start of the progression (6 reps). Your two sessions that week will be L = 14 reps, H = 6 reps. Alternate each session. When you complete 20 reps at the light weight, that progression is complete. Next L day, pick a higher weight, start at 6 reps. This is now your new heavy day, your old heavy progression is now light day. Continue, alternating each session.

Think of heavy/light schedules as doing two different progressions a week, once each, rather than one progression twice a week.


Michael Ceasar
1 month ago
 @Brandon Huff  Depends do you have access to the heavier weights now,  how big are the jumps in weights, how much time do you have?. If you have the heavier weights now and the jumps are not that big 2kg or 1kg from one weight to the next you could probably do a 10 minutes x 14 reps for the light day, heavy 10 minutes x 6 reps. That's assuming you want to keep to ten minutes because you got time restrictions and you have the weights. At one point you will max out on weights and will have to add time, or complexity perhaps both.


Frank Cuccia
1 month ago
What type of swings are you doing? 2 hand swings, hand to hand, etc? I am not super familiar with Pavel's program you posted but what does help in progression is adding a volume cycle. Mark has gone over it extensively but the basics is you keep the reps the same and increase the sets. So instead of keeping the 10 sets and increasing reps each workout, in your case 18, pick a smaller rep range and add a set each workout. I would shoot for around 12 reps or so and increase the sets. So the 10x18 is 180 total reps, you would have to get to 15x12 to equal that. And once you get past that you can try increase the reps and reducing the sets. It's a gradual way to build your body to be able to do the overall work and then start to do it faster and more efficiently. The majority of my programs are volume cycles that turn into density cycles before the weight is changed. Hope this helps, good luck.
        */
    }
}