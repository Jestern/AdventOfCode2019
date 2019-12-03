using System;
using AdventOfCode2019.Domain;
using AdventOfCode2019.IO;

namespace AdventOfCode2019
{
    class Program
    {
        private static IRepository repository;
        private static DayOneCommands dayOne;
        private static DayTwoCommands dayTwo;

        private static void SetUp()
        {
            repository = new InputRepository();
            dayOne = new DayOneCommands(repository);
            dayTwo = new DayTwoCommands(repository);
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Advent of Code 2019!");
            SetUp();
            Console.WriteLine($"Result of first half of Day one's problem: {dayOne.CalculateSumOfFuel()}");
            Console.WriteLine($"Result of second half of Day one's problem: {dayOne.CalculateSumOfFuelPlusFuel()}");
            Console.WriteLine($"Result of first half of Day two's problem: {dayTwo.RunIntcode(12, 2)}");
        }
    }
}
