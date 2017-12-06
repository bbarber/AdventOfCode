using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;

namespace AdventOfCode
{    
    public class Problem03Part1
    {
        public static void Run()
        {
           
            var gridSize = 10000;
            var grid = new int[gridSize + 1, gridSize + 1];

            grid[gridSize / 2, gridSize / 2] = 1;

            var i = gridSize / 2;
            var j = gridSize / 2;
            var direction = Direction.Down;

            for(var n = 2; n <= 265159; n++)
            {       
                var left = direction == Direction.Down 
                    ?  Direction.Right 
                    : (Direction)(((int)direction) + 1);

                var lefti = i;
                var leftj = j;

                    if(left == Direction.Down)
                        lefti += 1;
                    if(left == Direction.Up)
                        lefti -= 1;
                    if(left == Direction.Right)
                        leftj += 1;
                    if(left == Direction.Left)
                        leftj -= 1;

                // Not available
                if(grid[lefti,leftj] != 0)
                {
                    if(direction == Direction.Down)
                        i += 1;
                    if(direction == Direction.Up)
                        i -= 1;
                    if(direction == Direction.Right)
                        j += 1;
                    if(direction == Direction.Left)
                        j -= 1;
                }
                else    
                {
                    i = lefti;
                    j = leftj;
                    direction = left;
                }

                grid[i,j] = n;                
            };


            var source = new Point(0, 0);
            var target = new Point(0, 0);

            for(var i2 = 0; i2 < gridSize; i2++)
            {
                for(var j2 = 0; j2 < gridSize; j2++)
                {
                    if(grid[i2,j2] == 1)
                    {
                        source.X = i2;
                        source.Y = j2;
                    }
                    else if(grid[i2,j2] == 265149)
                    {
                        target.X = i2;
                        target.Y = j2;
                    }
                }
            }

            var distance = Math.Abs(target.X - source.X) + Math.Abs(target.Y - source.Y);


            // Print
            // for(var i2 = 0; i2 < gridSize; i2++)
            // {
            //     for(var j2 = 0; j2 < gridSize; j2++)
            //     {
            //         Console.Write(grid[i2,j2] + "   ");
            //     }
            //     Console.WriteLine();
            // }
        }

        
    }

    public class Problem03Part2
    {
        public static void Run()
        {
           
            var gridSize = 10000;
            var grid = new int[gridSize + 1, gridSize + 1];

            grid[gridSize / 2, gridSize / 2] = 1;

            var i = gridSize / 2;
            var j = gridSize / 2;
            var direction = Direction.Down;

            for(var n = 0; n <= 265159;)
            {       
                var left = direction == Direction.Down 
                    ?  Direction.Right 
                    : (Direction)(((int)direction) + 1);

                var lefti = i;
                var leftj = j;

                    if(left == Direction.Down)
                        lefti += 1;
                    if(left == Direction.Up)
                        lefti -= 1;
                    if(left == Direction.Right)
                        leftj += 1;
                    if(left == Direction.Left)
                        leftj -= 1;

                // Not available
                if(grid[lefti,leftj] != 0)
                {
                    if(direction == Direction.Down)
                        i += 1;
                    if(direction == Direction.Up)
                        i -= 1;
                    if(direction == Direction.Right)
                        j += 1;
                    if(direction == Direction.Left)
                        j -= 1;
                }
                else    
                {
                    i = lefti;
                    j = leftj;
                    direction = left;
                }

                var n2 = 0;
                n2 += grid[i - 1, j - 1];
                n2 += grid[i - 1, j + 0];
                n2 += grid[i - 1, j + 1];
                n2 += grid[i + 0, j + 1];
                n2 += grid[i + 0, j - 1];
                n2 += grid[i + 1, j + 1];
                n2 += grid[i + 1, j + 0];
                n2 += grid[i + 1, j - 1];

                grid[i,j] = n2;          

                n = n2;
            };


            var source = new Point(0, 0);
            var target = new Point(0, 0);

            for(var i2 = 0; i2 < gridSize; i2++)
            {
                for(var j2 = 0; j2 < gridSize; j2++)
                {
                    if(grid[i2,j2] == 1)
                    {
                        source.X = i2;
                        source.Y = j2;
                    }
                    else if(grid[i2,j2] == 265149)
                    {
                        target.X = i2;
                        target.Y = j2;
                    }
                }
            }

            var distance = Math.Abs(target.X - source.X) + Math.Abs(target.Y - source.Y);


            // Print
            // for(var i2 = 0; i2 < gridSize; i2++)
            // {
            //     for(var j2 = 0; j2 < gridSize; j2++)
            //     {
            //         Console.Write(grid[i2,j2] + "   ");
            //     }
            //     Console.WriteLine();
            // }
        }

        
    }

    public enum Direction
    {
        Right = 0,
        Up = 1,
        Left = 2,
        Down = 3
    }

   
}
