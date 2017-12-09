using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;

namespace AdventOfCode
{
    public class Program
    {
        public string Name { get; set; }
        public int Weight { get; set; }
        public int SubWeight { get; set; }
        public int TotalWeight => Weight + SubWeight;

        public List<string> Children { get; set; }
    }


    public class Problem07Part1
    {
        public static void Run()
        {
            var input = File.ReadAllLines("Problem07.txt");
            var programs = input.Select(r =>
            {
                return new Program
                {
                    Name = r.Split(" (")[0],
                    Weight = int.Parse(r.Split(" (")[1].Split(")")[0]), //Goodluck
                    Children = r.Contains("->") ? r.Split("-> ")[1].Split(", ").ToList() : new List<string>()
                };
            }).ToList();

            var parent = programs.First(p => !programs.Any(p2 => p2.Children.Contains(p.Name)));
        }
    }


    public class Problem07Part2
    {
        public static void Run()
        {
            var input = File.ReadAllLines("Problem07.txt");
            var programs = input.Select(r =>
            {
                return new Program
                {
                    Name = r.Split(" (")[0],
                    Weight = int.Parse(r.Split(" (")[1].Split(")")[0]), //Goodluck
                    Children = r.Contains("->") ? r.Split("-> ")[1].Split(", ").ToList() : new List<string>()
                };
            }).ToList();
            
            foreach(var program in programs)
            {
                program.SubWeight = GetSubWeight(program, programs);
            }

            foreach(var program in programs.Where(p => p.Children.Any()))
            {
                var siblings = program.Children.Select(c => programs.First(p => p.Name == c)).ToList();
                if(siblings.GroupBy(s => s.TotalWeight).Count() != 1)
                {
                    // Winning
                }
            }

        }

        public static int GetSubWeight(Program program, List<Program> programs)
        {
            return program.Children.Sum(p => 
            {
                var childProgram = programs.First(p2 => p2.Name == p);
                var subWeight = GetSubWeight(childProgram, programs);
                return childProgram.Weight + subWeight;
            });
        }
    }
}
