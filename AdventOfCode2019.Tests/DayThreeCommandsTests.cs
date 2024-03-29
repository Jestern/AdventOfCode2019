using System.Collections.Generic;
using AdventOfCode2019.Commands;
using AdventOfCode2019.Domain;
using AdventOfCode2019.IO;
using Moq;
using NUnit.Framework;

namespace AdventOfCode2019.Tests
{
    public class DayThreeCommandsTests
    {
        [Test]
        [Sequential]
        public void CalculateDistanceWiresTests(
            [Values("R8,U5,L5,D3",
                "R75,D30,R83,U83,L12,D49,R71,U7,L72",
                "R98,U47,R26,D63,R33,U87,L62,D20,R33,U53,R51")] string firstWire,
            [Values("U7,R6,D4,L4",
                "U62,R66,U55,R34,D71,R55,D58,R83",
                "U98,R91,D20,R16,D67,R40,U7,R15,U6,R7")] string secondWire,
            [Values(6, 159, 135)] int result)
        {
            var wires = Wires.CreateWires(firstWire.Split(','), secondWire.Split(','));

            Assert.AreEqual(result, DayThreeCommands.CalculateDistanceWires(wires));
        }

        [Test]
        [Sequential]
        public void CalculateStepsWiresTests(
            [Values("R8,U5,L5,D3",
                "R75,D30,R83,U83,L12,D49,R71,U7,L72",
                "R98,U47,R26,D63,R33,U87,L62,D20,R33,U53,R51")] string firstWire,
            [Values("U7,R6,D4,L4",
                "U62,R66,U55,R34,D71,R55,D58,R83",
                "U98,R91,D20,R16,D67,R40,U7,R15,U6,R7")] string secondWire,
            [Values(30, 610, 410)] int result)
        {
            var wires = Wires.CreateWires(firstWire.Split(','), secondWire.Split(','));

            Assert.AreEqual(result, DayThreeCommands.CalculateStepsWires(wires));
        }
    }
}