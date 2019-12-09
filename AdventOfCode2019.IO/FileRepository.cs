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
            var dayOneInput = File.ReadAllLines(GetPath("01_DayOne.txt")).First();
            var numbers = dayOneInput.Split(',');
            foreach (var number in numbers)
            {
                yield return int.Parse(number);
            }
        }

        public IEnumerable<int> GetDayTwoInput()
        {
            var dayTwoInput = File.ReadAllLines(GetPath("02_DayTwo.txt")).First();
            var numbers = dayTwoInput.Split(',');

            foreach (var number in numbers)
            {
                yield return int.Parse(number);
            }
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

        private static string GetPath(string filename)
        {
            return Path.Combine(AppContext.BaseDirectory, "Inputs", filename);
        }
    }
}
