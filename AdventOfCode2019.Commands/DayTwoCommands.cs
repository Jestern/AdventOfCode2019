using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode2019.Domain;
using AdventOfCode2019.IO;

namespace AdventOfCode2019.Commands
{
    public static class DayTwoCommands
    {
        public static int RunIntcode(IEnumerable<int> programMemory, int? firstArgument = null, int? secondArgument = null)
        {
            return IntComputer.RunIntcode(programMemory, null, firstArgument, secondArgument);
        }

        public static int FindNounAndVerb(IEnumerable<int>programMemory, int expectedResult, int startRange = 0, int endRange = 99)
        {
            for (var noun = startRange; noun < endRange; ++noun)
            {
                for (var verb = startRange; verb < endRange; ++verb)
                {
                    var result = IntComputer.RunIntcode(programMemory, null, noun, verb);
                    if (result == expectedResult)
                    {
                        return 100 * noun + verb;
                    }
                }
            }

            return -1;
        }
    }
}