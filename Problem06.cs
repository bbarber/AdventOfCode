using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;

namespace AdventOfCode
{
    public class Problem06Part1
    {
        public static void Run()
        {
            var input = "10	3	15	10	5	15	5	15	9	2	5	8	5	2	3	6";
            var bins = input.Split('\t').Select(n => int.Parse(n)).ToArray();
            var history = new List<string>();
            var cycles = 0;

            while (true)
            {
                cycles++;
                var max = bins.Max();
                var maxIndex = bins.ToList().IndexOf(max);
                bins[maxIndex] = 0;

                for (var i = 1; i <= max; i++)
                {
                    bins[(maxIndex + i) % bins.Length]++;
                }

                var memory = string.Join(",", bins);
                if (history.Contains(memory))
                    break;

                history.Add(memory);
            }
        }
    }

    public class Problem06Part2
    {
        public static void Run()
        {
            var input = "10	3	15	10	5	15	5	15	9	2	5	8	5	2	3	6";
            var bins = input.Split('\t').Select(n => int.Parse(n)).ToArray();
            var history = new List<string>();
            var cycles = 0;
            var looping = false;

            while (true)
            {
                cycles++;
                var max = bins.Max();
                var maxIndex = bins.ToList().IndexOf(max);
                bins[maxIndex] = 0;

                for (var i = 1; i <= max; i++)
                {
                    bins[(maxIndex + i) % bins.Length]++;
                }

                var memory = string.Join(",", bins);
                if (history.Count(h => h == memory) == 1 && !looping)
                {
                    cycles = 0;
                    looping = true;
                }
                if (history.Count(h => h == memory) == 2)
                {
                    // Winning
                }

                history.Add(memory);
            }
        }
    }
}
