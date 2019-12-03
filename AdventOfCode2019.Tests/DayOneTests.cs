using System.Collections.Generic;
using AdventOfCode2019.Domain;
using AdventOfCode2019.IO;
using Moq;
using NUnit.Framework;

namespace AdventOfCode2019.Tests
{
    public class Tests
    {
        private Mock<IRepository> repository;

        [SetUp]
        public void Setup()
        {
            repository = new Mock<IRepository>();
        }

        [Test]
        [Sequential]
        public void CalculateSumOfFuelTests(
            [Values(12, 14, 1969, 100756)] int mass, 
            [Values(2, 2, 654, 33583)] int result)
        {
            repository.Setup(r => r.GetDayOneInput()).Returns(new List<int>() {mass});

            var dayOne = new DayOne(repository.Object);

            Assert.AreEqual(result, dayOne.CalculateSumOfFuel());
        }
    }
}