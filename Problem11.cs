using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AdventOfCode
{
    public class Problem11Part1
    {
        class Point
        {
            public int X { get; set; }
            public int Y { get; set; }
            public int Z => -(X + Y);
        }

        public static void Run()
        {
            var directions = File.ReadAllText("Problem11.txt").Split(",");

            var startingPt = new Point { X = 0, Y = 0 };
            var currentPt = new Point { X = 0, Y = 0 };
            var maxDistance = 0;

            foreach (var d in directions)
            {
                if (d == "n")
                {
                    currentPt.Y++;
                }
                if (d == "ne")
                {
                    currentPt.X++;
                }
                if (d == "se")
                {
                    currentPt.X++;
                    currentPt.Y--;
                }
                if (d == "s")
                {
                    currentPt.Y--;
                }
                if (d == "sw")
                {
                    currentPt.X--;
                }
                if (d == "nw")
                {
                    currentPt.X--;
                    currentPt.Y++;
                }

                var dx = currentPt.X - startingPt.X;
                var dy = currentPt.Y - startingPt.Y;
                var dz = currentPt.Z - startingPt.Z;

                // I cheated a little
                // http://keekerdc.com/2011/03/hexagon-grids-coordinate-systems-and-distance-calculations/
                var distance = new List<int> { dx, dy, dz }.Max();
                if(distance > maxDistance)
                    maxDistance = distance;
            }
        }
    }

    public class Problem11Part2
    {
        public static void Run()
        {
            // See Part 1
        }
    }
}
