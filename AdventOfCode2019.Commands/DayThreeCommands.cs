using System;
using System.Collections.Generic;
using System.Drawing;
using AdventOfCode2019.Domain;

namespace AdventOfCode2019.Commands
{
    public static class DayThreeCommands
    {
        private static readonly Point StartingPoint = new Point(0, 0);

        public static int CalculateDistanceWires(Wires wires)
        {
            var distance = int.MaxValue;

            var firstSegments = ConvertWireToSegments(wires.FirstWire);
            var secondSegments = ConvertWireToSegments(wires.SecondWire);

            foreach (var secondSegment in secondSegments)
            foreach (var firstSegment in firstSegments)
            {
                var doesIntersect = firstSegment.Intersect(secondSegment, out var intersectionPoint);

                if (!doesIntersect || firstSegment.FirstPoint == StartingPoint &&
                    secondSegment.FirstPoint == StartingPoint)
                {
                    continue;
                }

                var calculatedDistance = CalculateManhattanDistance(StartingPoint, intersectionPoint);
                distance = Math.Min(distance, calculatedDistance);
            }

            return distance;
        }

        public static int CalculateStepsWires(Wires wires)
        {
            var steps = int.MaxValue;

            var firstSegments = ConvertWireToSegments(wires.FirstWire);
            var secondSegments = ConvertWireToSegments(wires.SecondWire);

            foreach (var secondSegment in secondSegments)
            foreach (var firstSegment in firstSegments)
            {
                var doesIntersect = firstSegment.Intersect(secondSegment, out var intersectionPoint);

                if (!doesIntersect || firstSegment.FirstPoint == StartingPoint &&
                    secondSegment.FirstPoint == StartingPoint)
                {
                    continue;
                }

                var calculatedDistance = CalculateSteps(firstSegment, secondSegment, intersectionPoint);
                steps = Math.Min(steps, calculatedDistance);
            }

            return steps;
        }

        private static IEnumerable<Segment> ConvertWireToSegments(IList<WireSegment> wireSegments)
        {
            var segments = new List<Segment>();
            var firstPoint = StartingPoint;
            var steps = 0;

            foreach (var wireSegment in wireSegments)
            {
                steps += wireSegment.Distance;

                var segment = CreateSegment(firstPoint, wireSegment, steps);
                segments.Add(segment);
                firstPoint = segment.SecondPoint;
            }

            return segments;
        }

        private static Segment CreateSegment(Point startingPoint, WireSegment wire, int steps)
        {
            var segment = new Segment
            {
                FirstPoint = startingPoint,
                Steps = steps
            };

            var secondPoint = new Point(startingPoint.X, startingPoint.Y);

            switch (wire.MoveDirection)
            {
                case WireSegment.Direction.Up:
                    secondPoint.Y += wire.Distance;
                    break;
                case WireSegment.Direction.Down:
                    secondPoint.Y -= wire.Distance;
                    break;
                case WireSegment.Direction.Right:
                    secondPoint.X += wire.Distance;
                    break;
                case WireSegment.Direction.Left:
                    secondPoint.X -= wire.Distance;
                    break;
            }

            segment.SecondPoint = secondPoint;

            return segment;
        }

        private static int CalculateManhattanDistance(Point origin, Point point)
        {
            return Math.Abs(origin.X - point.X) + Math.Abs(origin.Y - point.Y);
        }

        private static int CalculateSteps(Segment firstSegment, Segment secondSegment, Point intersectionPoint)
        {
            var distanceFirstSegment = CalculateManhattanDistance(firstSegment.SecondPoint, intersectionPoint);

            var distanceSecondSegment = CalculateManhattanDistance(secondSegment.SecondPoint, intersectionPoint);

            return firstSegment.Steps + secondSegment.Steps - distanceFirstSegment - distanceSecondSegment;
        }

        private class Segment
        {
            public Point FirstPoint { get; set; }
            public Point SecondPoint { get; set; }
            public int Steps { get; set; }

            public bool Intersect(Segment otherSegment, out Point intersectionPoint)
            {
                intersectionPoint = new Point();

                float p0_x = FirstPoint.X;
                float p0_y = FirstPoint.Y;
                float p1_x = SecondPoint.X;
                float p1_y = SecondPoint.Y;
                float p2_x = otherSegment.FirstPoint.X;
                float p2_y = otherSegment.FirstPoint.Y;
                float p3_x = otherSegment.SecondPoint.X;
                float p3_y = otherSegment.SecondPoint.Y;

                var s1_x = p1_x - p0_x;
                var s1_y = p1_y - p0_y;
                var s2_x = p3_x - p2_x;
                var s2_y = p3_y - p2_y;

                var s = (-s1_y * (p0_x - p2_x) + s1_x * (p0_y - p2_y)) / (-s2_x * s1_y + s1_x * s2_y);
                var t = (s2_x * (p0_y - p2_y) - s2_y * (p0_x - p2_x)) / (-s2_x * s1_y + s1_x * s2_y);

                if (s >= 0 && s <= 1 && t >= 0 && t <= 1)
                {
                    intersectionPoint.X = (int) (p0_x + t * s1_x);
                    intersectionPoint.Y = (int) (p0_y + t * s1_y);
                    return true;
                }

                return false;
            }
        }
    }
}