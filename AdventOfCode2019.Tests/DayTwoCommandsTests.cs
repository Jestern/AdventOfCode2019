using System.Collections.Generic;
using AdventOfCode2019.Domain;
using AdventOfCode2019.IO;
using Moq;
using NUnit.Framework;

namespace AdventOfCode2019.Tests
{
    public class DayTwoCommandsTests
    {
        private Mock<IRepository> repository;

        [SetUp]
        public void Setup()
        {
            repository = new Mock<IRepository>();
        }

        [Test]
        [Sequential]
        public void CalculateResultIntcode(
            [Values(new int[] { 1, 9, 10, 3, 2, 3, 11, 0, 99, 30, 40, 50 })] IEnumerable<int> intcode, 
            [Values(3500)] int result)
        {
            repository.Setup(r => r.GetDayTwoInput()).Returns(intcode);

            var dayTwo = new DayTwoCommands(repository.Object);

            Assert.AreEqual(result, dayTwo.RunIntcode());
        }
    }
}