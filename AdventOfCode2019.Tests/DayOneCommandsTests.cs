using System.Collections.Generic;
using AdventOfCode2019.Domain;
using AdventOfCode2019.IO;
using Moq;
using NUnit.Framework;

namespace AdventOfCode2019.Tests
{
    public class DayOneCommandsTests
    {
        [Test]
        [Sequential]
        public void CalculateSumOfFuelTests(
            [Values(12, 14, 1969, 100756)] int mass, 
            [Values(2, 2, 654, 33583)] int result)
        {
            var masses = new List<int>()
            {
                mass
            };

            Assert.AreEqual(result, DayOneCommands.CalculateSumOfFuel(masses));
        }

        [Test]
        [Sequential]
        public void CalculateSumOfFuelPlusFuelTests(
            [Values(14, 1969, 100756)] int mass,
            [Values(2, 966, 50346)] int result)
        {
            var masses = new List<int>()
            {
                mass
            };

            Assert.AreEqual(result, DayOneCommands.CalculateSumOfFuelPlusFuel(masses));
        }
    }
}