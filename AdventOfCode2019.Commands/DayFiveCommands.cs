using System.Collections.Generic;

namespace AdventOfCode2019.Commands
{
    public class DayFiveCommands
    {
        public static string RunDiagnostics(IEnumerable<int> programMemory, int input)
        {
            IntComputer.RunIntcode(programMemory, input);
            return $"Diagnostics saved to file {IntComputer.LogFile}";
        }
    }
}