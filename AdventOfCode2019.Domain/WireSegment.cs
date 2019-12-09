namespace AdventOfCode2019.Domain
{
    public class WireSegment
    {
        public enum Direction
        {
            Up,
            Down,
            Right,
            Left
        }

        public Direction MoveDirection { get; set; }
        public int Distance { get; set; }

        public static WireSegment ParseWireSegment(string wire)
        {
            var charDirection = wire.ToUpper()[0];
            var distance = int.Parse(wire.Substring(1));

            var direction = charDirection switch
            {
                'D' => WireSegment.Direction.Down,
                'R' => WireSegment.Direction.Right,
                'L' => WireSegment.Direction.Left,
                'U' => WireSegment.Direction.Up
            };

            return new WireSegment()
            {
                Distance = distance,
                MoveDirection = direction
            };
        }
    }
}