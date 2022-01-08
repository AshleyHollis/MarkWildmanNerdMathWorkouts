using System;
using Xunit;
using static System.DayOfWeek;
using MarkWildmanNerdMathWorkouts.Shared.Helpers;

namespace MarkWildmanNerdMathWorkouts.Tests
{
    public class DateTimeExtensionsShould
    {
        private readonly DateTime now = new(2021, 1, 1);

        [Fact]
        public void Now_is_a_friday()
        {
            Assert.Equal(Friday, now.DayOfWeek);
        }

        [Fact]
        public void Next_saturday_is_January_2nd()
        {
            var result = now.Next(Saturday);
            Assert.Equal(new DateTime(2021, 1, 2), result);
        }

        [Fact]
        public void Next_friday_is_January_8th()
        {
            var result = now.Next(Friday);
            Assert.Equal(new DateTime(2021, 1, 8), result);
        }

        [Fact]
        public void Next_friday_and_saturday_are_January_2nd_and_8th()
        {
            var results = now.Next(Saturday, Friday);

            Assert.Equal(2, results.Count);
            Assert.Equal(new DateTime(2021, 1, 2), results[0]);
            Assert.Equal(new DateTime(2021, 1, 8), results[^1]);
        }

        [Fact]
        public void Next_saturday_then_next_saturday_are_January_2nd_and_9th()
        {
            var results = now.Next(DateCalculationKind.AndThen, Saturday, Saturday);

            Assert.Equal(2, results.Count);
            Assert.Equal(new DateTime(2021, 1, 2), results[0]);
            Assert.Equal(new DateTime(2021, 1, 9), results[^1]);
        }

        [Fact]
        public void Calculate_Correctly_Next_5_Mondays_And_Fridays()
        {
            var results = now.Next(DateCalculationKind.AndThen, 5, Monday, Friday);

            Assert.Equal(10, results.Count);
            Assert.Equal(new DateTime(2021, 1, 4), results[0]);
            Assert.Equal(new DateTime(2021, 1, 8), results[1]);
            Assert.Equal(new DateTime(2021, 1, 11), results[2]);
            Assert.Equal(new DateTime(2021, 1, 15), results[3]);
            Assert.Equal(new DateTime(2021, 1, 18), results[4]);
            Assert.Equal(new DateTime(2021, 1, 22), results[5]);
            Assert.Equal(new DateTime(2021, 1, 25), results[6]);
            Assert.Equal(new DateTime(2021, 1, 29), results[7]);
            Assert.Equal(new DateTime(2021, 2, 1), results[8]);
            Assert.Equal(new DateTime(2021, 2, 5), results[9]);
        }
    }
}
