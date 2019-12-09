using System.Collections.Generic;
using AdventOfCode2019.Domain;

namespace AdventOfCode2019.IO
{
    public interface IRepository
    {
        IEnumerable<int> GetDayOneInput();

        IEnumerable<int> GetDayTwoInput();

        Wires GetDayThreeInput();

        KeyValuePair<int, int> GetDayFourInput();

        IEnumerable<int> GetDayFiveInput();
    }
}