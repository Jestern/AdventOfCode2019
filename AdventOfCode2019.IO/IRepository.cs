using System.Collections.Generic;

namespace AdventOfCode2019.IO
{
    public interface IRepository
    {
        IEnumerable<int> GetDayOneInput();
    }
}