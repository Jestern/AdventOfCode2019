using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AdventOfCode2019.Domain;

namespace AdventOfCode2019.IO
{
    public class FileRepository : IRepository
    {
        public IEnumerable<int> GetDayOneInput()
        {
            return ReadIntSeparatedByDelimiter(GetPath("01_DayOne.txt"), ',');
        }

        public IEnumerable<int> GetDayTwoInput()
        {
            return ReadIntSeparatedByDelimiter(GetPath("02_DayTwo.txt"), ',');
        }

        public Wires GetDayThreeInput()
        {
            var dayThreeInput = File.ReadAllLines(GetPath("03_DayThree.txt"));
            var firstWire = dayThreeInput.First().Split(',');
            var secondWire = dayThreeInput.Last().Split(',');

            return Wires.CreateWires(firstWire, secondWire);
        }

        public KeyValuePair<int, int> GetDayFourInput()
        {
            var dayFourInput = File.ReadAllLines(GetPath("04_DayFour.txt"));
            var splitValues = dayFourInput.First().Split('-');

            return new KeyValuePair<int, int>(int.Parse(splitValues.First()), int.Parse(splitValues.Last()));
        }

        public IEnumerable<int> GetDayFiveInput()
        {
            return ReadIntSeparatedByDelimiter(GetPath("05_DayFive.txt"), ',');
        }

        private static string GetPath(string filename)
        {
            return Path.Combine(AppContext.BaseDirectory, "Inputs", filename);
        }

        private static IEnumerable<int> ReadIntSeparatedByDelimiter(string filename, char delimiter)
        {
            var dayInput = File.ReadAllLines(filename).First();
            var numbers = dayInput.Split(delimiter);
            foreach (var number in numbers)
            {
                yield return int.Parse(number);
            }
        }
    }
}
