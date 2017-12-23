using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;

namespace AdventOfCode
{
    public class Problem10Part1
    {
        public static void Run()
        {
            var input = new int[] { 76, 1, 88, 148, 166, 217, 130, 0, 128, 254, 16, 2, 130, 71, 255, 229 };
            var list = Enumerable.Range(0, 256).ToArray();

            var currentPosition = 0;
            var skipSize = 0;

            foreach (var length in input)
            {
                Reverse(list, currentPosition, length);
                currentPosition += length + skipSize;
                skipSize++;
            }
        }

        public static void Reverse(int[] list, int currentPosition, int length)
        {
            int start = currentPosition;
            int end = currentPosition + length - 1;

            for (int i = 0; i < length / 2; i++)
            {
                var temp = list[start % list.Length];
                list[start % list.Length] = list[end % list.Length];
                list[end % list.Length] = temp;

                start++;
                end--;
            }
        }
    }


    public class Problem10Part2
    {
        public static void Run()
        {
            var input = "76,1,88,148,166,217,130,0,128,254,16,2,130,71,255,229";
            var lengths = input.Select(c => Encoding.ASCII.GetBytes(new char[] { c })[0]).ToList();
            lengths.AddRange(new List<byte> { 17, 31, 73, 47, 23 });

            var currentPosition = 0;
            var skipSize = 0;

            var list = Enumerable.Range(0, 256).ToArray();

            for (var i = 0; i < 64; i++)
            {
                foreach (var length in lengths)
                {
                    Problem10Part1.Reverse(list, currentPosition, length);
                    currentPosition += length + skipSize;
                    skipSize++;
                }
            }

            var squareHash = new List<int>();
            for(var i = 0; i < 16; i++)
            {
                var hash = list.Skip(i * 16).Take(16).Aggregate((total, next) => total ^ next);
                squareHash.Add(hash);
            }

            var output = string.Join("", squareHash.Select(h => h.ToString("X2")));
        }
    }
}
