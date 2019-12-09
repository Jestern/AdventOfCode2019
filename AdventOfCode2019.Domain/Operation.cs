using System.Collections.Generic;

namespace AdventOfCode2019.Domain
{
    public class Operation
    {
        public OpCode Code { get; set; }
        public IList<OpMode> Modes { get; }

        public Operation()
        {
            Modes = new List<OpMode>();
        }

        public static Operation ParseOp(int operation)
        {
            var module = 100;

            var parsedOperation = new Operation();

            parsedOperation.Code = (OpCode) (operation % module);

            operation /= module;
            module = 10;

            for (var i = 0; i < 3; i++)
            {
                parsedOperation.Modes.Add((OpMode) (operation % module));
                operation /= module;
            }

            return parsedOperation;
        }
    }
}