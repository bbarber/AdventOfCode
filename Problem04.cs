using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;

namespace AdventOfCode
{
    public class Problem04Part1
    {
        public static void Run()
        {
            var input = File.ReadAllLines("Problem04.txt");

            var numValid = input.Count(row =>
            {
                var words = row.Split(" ");
                return words.Length == words.Distinct().Count();
            });
        }
    }

    public class Problem04Part2
    {
        public static void Run()
        {
            var input = File.ReadAllLines("Problem04.txt");

            var numValid = input.Count(row =>
            {
                var words = row.Split(" ").Select(r => new String(r.OrderBy(w => w).ToArray()));
                return words.Count() == words.Distinct().Count();
            });
        }
    }
}
