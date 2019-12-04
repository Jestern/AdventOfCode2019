using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

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

        private string GetPath(string filename)
        {
            return Path.Combine(AppContext.BaseDirectory, "Inputs", filename);
        }
    }
}
