using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AdventOfCode
{
    public class Problem12Part1
    {
        public class Program
        {
            public int Id { get; set; }
            public List<int> Children { get; set; }
            public bool Visited { get; set; }
        }

        public static List<Program> programs;

        public static void Run()
        {
            var input = File.ReadAllLines("Problem12.txt");
            programs = input.Select(line => new Program
            {
                Id = int.Parse(line.Split(" <-> ")[0]),
                Children = line.Split(" <-> ")[1].Split(", ").Select(n => int.Parse(n)).ToList()
            }).ToList();

            var sum = 0;
            FindChildren(0, ref sum);
        }

        private static void FindChildren(int id, ref int sum)
        {
            var program = programs.First(p => p.Id == id);
            if (program.Visited)
                return;

            program.Visited = true;
            sum += program.Children.Count(c => programs.First(p => p.Id == c).Visited == false);

            foreach (var child in program.Children)
            {
                FindChildren(child, ref sum);
            }
        }
    }

    public class Problem12Part2
    {
        public class Program
        {
            public int Id { get; set; }
            public List<int> Children { get; set; }
            public bool Visited { get; set; }
        }

        public static List<Program> programs;

        public static void Run()
        {
            var input = File.ReadAllLines("Problem12.txt");
            programs = input.Select(line => new Program
            {
                Id = int.Parse(line.Split(" <-> ")[0]),
                Children = line.Split(" <-> ")[1].Split(", ").Select(n => int.Parse(n)).ToList()
            }).ToList();

            int groups = 0;
            foreach (var id in programs.Select(p => p.Id))
            {
                int sum = 0;
                FindChildren(id, ref sum);

                if (sum != 0)
                    groups++;
            }
        }

        private static void FindChildren(int id, ref int sum)
        {
            var program = programs.First(p => p.Id == id);
            if (program.Visited)
                return;

            program.Visited = true;
            sum += program.Children.Count(c => programs.First(p => p.Id == c).Visited == false);

            if (program.Children[0] == id)
                sum++;

            foreach (var child in program.Children)
            {
                FindChildren(child, ref sum);
            }
        }
    }
}
