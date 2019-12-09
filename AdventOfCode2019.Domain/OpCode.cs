using System;

namespace AdventOfCode2019.Domain
{
    public enum OpCode
    {
        Add = 1,
        Multiply = 2,
        Store = 3,
        Print = 4,
        JumpIfTrue = 5,
        JumpIfFalse = 6,
        LessThan = 7,
        Equals = 8,
        Terminate = 99
    }

    public static class OpCodeExtension
    {
        public static int Steps(this OpCode code)
        {
            return code switch
            {
                OpCode.Add => 4,
                OpCode.Multiply => 4,
                OpCode.Store => 2,
                OpCode.Print => 2,
                OpCode.JumpIfTrue => 3,
                OpCode.JumpIfFalse => 3,
                OpCode.LessThan => 4,
                OpCode.Equals => 4,
                OpCode.Terminate => 0,
                _ => throw new ArgumentOutOfRangeException(nameof(code), code, null)
            };
        }
    }
}