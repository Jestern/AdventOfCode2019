using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using AdventOfCode2019.Domain;

namespace AdventOfCode2019.Commands
{
    public static class IntComputer
    {
        private static readonly IDictionary<OpCode, Func<int, int?, IList<OpMode>, int[], int>> Operations;
        public static string LogFile { get; private set; }
        static IntComputer()
        {
            Operations = new Dictionary<OpCode, Func<int, int?, IList<OpMode>, int[], int>>()
            {
                { OpCode.Add, Add },
                { OpCode.Multiply, Multiply },
                { OpCode.Store, Store },
                { OpCode.Print, Print },
                { OpCode.JumpIfTrue, JumpIfTrue },
                { OpCode.JumpIfFalse, JumpIfFalse },
                { OpCode.LessThan, LessThan },
                { OpCode.Equals,  Equals }
            };
        }
        public static int RunIntcode(IEnumerable<int> programMemory, int? input = null, int? firstArgument = null, int? secondArgument = null)
        {
            var programArray = programMemory.ToArray();

            LogFile = $"{DateTime.Now:yyyy-MM-dd_hh-mm-ss}_{Guid.NewGuid()}.log";

            if (firstArgument != null)
            {
                programArray[1] = firstArgument.Value;
            }

            if (secondArgument != null)
            {
                programArray[2] = secondArgument.Value;
            }
            
            for (var index = 0; index < programArray.Length;)
            {
                var operation = Operation.ParseOp(programArray[index]);

                if (operation.Code == OpCode.Terminate)
                {
                    break;
                }

                index = Operations[operation.Code](index, input, operation.Modes, programArray);
            }

            return programArray[0];
        }

        private static int ReadValue(int address, OpMode mode, int[] programMemory)
        {
            return mode switch
            {
                OpMode.ImmediateMode => programMemory[address],
                OpMode.PositionMode => programMemory[programMemory[address]],
                _ => throw new ArgumentOutOfRangeException(nameof(mode), mode, null),
            };
        }

        private static int Add(int index, int? input, IList<OpMode> modes, int[] programMemory)
        {
            var x = ReadValue(index + 1, modes[0], programMemory);
            var y = ReadValue(index + 2, modes[1], programMemory);
            var result = ReadValue(index + 3, OpMode.ImmediateMode, programMemory);

            programMemory[result] = x + y;

            return index + OpCode.Add.Steps();
        }

        private static int Multiply(int index, int? input, IList<OpMode> modes, int[] programMemory)
        {
            var x = ReadValue(index + 1, modes[0], programMemory);
            var y = ReadValue(index + 2, modes[1], programMemory);
            var result = ReadValue(index + 3, OpMode.ImmediateMode, programMemory);

            programMemory[result] = x * y;

            return index + OpCode.Multiply.Steps();
        }

        private static int Store(int index, int? input, IList<OpMode> modes, int[] programMemory)
        {
            var storeAddress = ReadValue(index + 1, OpMode.ImmediateMode, programMemory);

            programMemory[storeAddress] = input ?? 0;

            return index + OpCode.Store.Steps();
        }

        private static int Print(int index, int? input, IList<OpMode> modes, int[] programMemory)
        {
            var filename = Path.Combine(AppContext.BaseDirectory, LogFile);

            var result = ReadValue(index + 1, modes[0], programMemory);

            File.AppendAllLines(filename, new string[]{
                result.ToString()
            });

            return index + OpCode.Print.Steps();
        }

        private static int JumpIfTrue(int index, int? input, IList<OpMode> modes, int[] programMemory)
        {
            var firstParameter = ReadValue(index + 1, modes[0], programMemory);
            var secondParameter = ReadValue(index + 2, modes[1], programMemory);

            return firstParameter != 0 ? secondParameter : index + OpCode.JumpIfTrue.Steps();
        }

        private static int JumpIfFalse(int index, int? input, IList<OpMode> modes, int[] programMemory)
        {
            var firstParameter = ReadValue(index + 1, modes[0], programMemory);
            var secondParameter = ReadValue(index + 2, modes[1], programMemory);

            return firstParameter == 0 ? secondParameter : index + OpCode.JumpIfTrue.Steps();
        }

        private static int LessThan(int index, int? input, IList<OpMode> modes, int[] programMemory)
        {
            var firstArgument = ReadValue(index + 1, modes[0], programMemory);
            var secondArgument = ReadValue(index + 2, modes[1], programMemory);
            var result = ReadValue(index + 3, OpMode.ImmediateMode, programMemory);

            programMemory[result] = firstArgument < secondArgument ? 1 : 0;

            return index + OpCode.LessThan.Steps();
        }

        private static int Equals(int index, int? input, IList<OpMode> modes, int[] programMemory)
        {
            var firstArgument = ReadValue(index + 1, modes[0], programMemory);
            var secondArgument = ReadValue(index + 2, modes[1], programMemory);
            var result = ReadValue(index + 3, OpMode.ImmediateMode, programMemory);

            programMemory[result] = firstArgument == secondArgument ? 1 : 0;

            return index + OpCode.Equals.Steps();
        }
    }
}