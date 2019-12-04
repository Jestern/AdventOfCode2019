using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode2019.IO;

namespace AdventOfCode2019.Domain
{
    public static class DayTwoCommands
    {
        public static int RunIntcode(IEnumerable<int> programMemory, int? firstArgument = null, int? secondArgument = null)
        {
            var programArray = programMemory.ToArray();

            if (firstArgument != null)
            {
                programArray[1] = firstArgument.Value;
            }

            if (secondArgument != null)
            {
                programArray[2] = secondArgument.Value;
            }

            for (var index = 0; index < programArray.Length; index += 4)
            {
                var opCode = programArray[index];

                if (opCode == (int) OpCodes.Terminate)
                {
                    break;
                }

                var firstPosition = programArray[index + 1];
                var secondPosition = programArray[index + 2];
                var resultPosition = programArray[index + 3];

                switch (opCode)
                {
                    case (int)OpCodes.Add:
                        Add(firstPosition, secondPosition, resultPosition, ref programArray);
                        break;
                    case (int)OpCodes.Multiply:
                        Multiply(firstPosition, secondPosition, resultPosition, ref programArray);
                        break;
                    default:
                        throw new ArgumentException($"Invalid OpCode: {opCode}");
                }
            }

            return programArray[0];
        }

        public static int FindNounAndVerb(IEnumerable<int>programMemory, int expectedResult, int startRange = 0, int endRange = 99)
        {
            for (var noun = startRange; noun < endRange; ++noun)
            {
                for (var verb = startRange; verb < endRange; ++verb)
                {
                    var result = RunIntcode(programMemory, noun, verb);
                    if (result == expectedResult)
                    {
                        return 100 * noun + verb;
                    }
                }
            }

            return -1;
        }

        private static void Add(int firstOperand, int secondOperand, int resultPosition, ref int[] programMemory)
        {
            programMemory[resultPosition] = programMemory[firstOperand] + programMemory[secondOperand];
        }

        private static void Multiply(int firstOperand, int secondOperand, int resultPosition, ref int[] programMemory)
        {
            programMemory[resultPosition] = programMemory[firstOperand] * programMemory[secondOperand];
        }
    }
}