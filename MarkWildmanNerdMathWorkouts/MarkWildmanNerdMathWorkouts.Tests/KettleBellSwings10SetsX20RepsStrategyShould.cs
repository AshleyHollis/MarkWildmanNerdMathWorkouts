using FluentAssertions;
using MarkWildmanNerdMathWorkouts.Shared;
using MarkWildmanNerdMathWorkouts.Shared.Enums;
using MarkWildmanNerdMathWorkouts.Shared.Helpers;
using MarkWildmanNerdMathWorkouts.Shared.Models;
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
                new object[] { 35, 70, new List<int>{35, 53, 70 }, string.Join(Environment.NewLine, new List<string> { 
                        "35 10 10 3500",
                        "35 10 11 3850",
                        "35 10 12 4200",
                        "35 10 13 4550",
                        "35 10 14 4900",
                        "35 10 15 5250",
                        "35 10 16 5600",
                        "35 10 17 5950",
                        "35 10 18 6300",
                        "35 10 19 6650",
                        "35 10 20 7000",
                        "53 10 10 5300",
                        "53 10 11 5830",
                        "53 10 12 6360",
                        "53 10 13 6890",
                        "53 10 14 7420",
                        "53 10 15 7950",
                        "53 10 16 8480",
                        "53 10 17 9010",
                        "53 10 18 9540",
                        "53 10 19 10070",
                        "53 10 20 10600",
                        "70 10 10 7000",
                        "70 10 11 7700",
                        "70 10 12 8400",
                        "70 10 13 9100",
                        "70 10 14 9800",
                        "70 10 15 10500",
                        "70 10 16 11200",
                        "70 10 17 11900",
                        "70 10 18 12600",
                        "70 10 19 13300",
                        "70 10 20 14000"
                    }
                )}
            };

            return allData;
        }

        [Theory]
        [MemberData(nameof(GetTestData))]
        public void Test1(int startWeight, int targetWeight, List<int> availableWeights, string expected)
        {
            /*  Increase reps from 10 to 20 then increase weight.
                Weights:  16kg (35lbs), 24kg (53lbs), 32kg (70lbs)
               
                Expectation:
                Format: Weight x Sets x Reps = Work Capacity
                35 x 10 x 10 = 3500
                35 x 10 x 15 = 5250
                35 x 10 x 20 = 7000
                53 x 10 x 10 = 5300
                53 x 10 x 15 = 7950
                53 x 10 x 20 = 10600
                70 x 10 x 10 = 7000
                70 x 10 x 15 = 10500
                70 x 10 x 20 = 14000

                Is 10 min of Kettlebelling enough - Part II - Yes - Nerd Math
                https://www.youtube.com/watch?v=lcECmuWTL3g
            */
            var kettleBellSwings10SetsX20RepsStrategy = new KettleBellSwings10SetsX20RepsStrategy(startWeight, targetWeight, availableWeights);
            var workouts = kettleBellSwings10SetsX20RepsStrategy.Generate();

            string.Join(Environment.NewLine, workouts.Select(x => x.ToString())).Should().Be(expected);
        }

        [Theory]
        [MemberData(nameof(GetTestData))]
        public void Test2(int startWeight, int targetWeight, List<int> availableWeights, string expected)
        {
            /*  Increase reps from 10 to 20 then increase weight.
                Weights:  16kg (35lbs), 24kg (53lbs), 32kg (70lbs)
               
                Expectation:
                Format: Weight x Sets x Reps = Work Capacity
                35 x 10 x 10 = 3500
                35 x 10 x 15 = 5250
                35 x 10 x 20 = 7000
                53 x 10 x 10 = 5300
                53 x 10 x 15 = 7950
                53 x 10 x 20 = 10600
                70 x 10 x 10 = 7000
                70 x 10 x 15 = 10500
                70 x 10 x 20 = 14000

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
    }
}