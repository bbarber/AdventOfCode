using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;

namespace AdventOfCode
{
    public class Problem09Part1
    {
        public static void Run()
        {
            var input = File.ReadAllText("Problem09.txt").ToCharArray();
            for(var i = 0; i < input.Length; i++)
            {
                if(input[i] == '!')
                {
                    input[i] = '*';
                    input[i + 1] = '*';
                }
                    
            }

            var cleaned = new String(input).Replace("*", "");

            var isGarbage = false;
            var garbageStart = 0;
            var garbageEnd = 0;
            var garbages = new List<dynamic>();

            for(var i = 0; i < cleaned.Length; i++)
            {
                if(isGarbage && cleaned[i] == '>')
                {
                    isGarbage = false;
                    garbageEnd = i;
                    garbages.Add(new
                    {
                        start = garbageStart,
                        end = garbageEnd
                    });
                }

                if(!isGarbage && cleaned[i] == '<')
                {
                    isGarbage = true;
                    garbageStart = i;
                }
            }

            var temp = cleaned.ToCharArray();
            foreach (var garbage in garbages)
            {
                for(var i = garbage.start; i <= garbage.end; i++)
                {
                    temp[i] = '*';
                }
            }

            // No longer contains garbage
            cleaned = new string(temp).Replace("*", "");

            var level = 0;
            var sum = 0;
            foreach (var c in cleaned)
            {
                if(c == '{')
                {
                    level++;
                    sum += level;
                }
                if(c == '}')
                {
                    level--;
                }
            }

            var totalGarbage = garbages.Sum(g => (g.end - g.start) - 1);
        }
    }


    public class Problem09Part2
    {
        public static void Run()
        {
            // See above
            Problem09Part1.Run();
        }
    }
}
