using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;

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

        private static void Reverse(int[] list, int currentPosition, int length)
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
        }
    }
}
