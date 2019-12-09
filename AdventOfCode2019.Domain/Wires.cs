using System.Collections.Generic;

namespace AdventOfCode2019.Domain
{
    public class Wires
    {
        public IList<WireSegment> FirstWire { get; private set; }
        public IList<WireSegment> SecondWire { get; private set; }

        public Wires()
        {
            FirstWire = new List<WireSegment>();
            SecondWire = new List<WireSegment>();
        }

        public static Wires CreateWires(string[] firstWire, string[] secondWire)
        {
            var result = new Wires();

            foreach (var movement in firstWire)
            {
                result.FirstWire.Add(WireSegment.ParseWireSegment(movement));
            }

            foreach (var movement in secondWire)
            {
                result.SecondWire.Add(WireSegment.ParseWireSegment(movement));
            }

            return result;
        }
    }
}