using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace aoc_2021
{
    public static class Day05
    {
        public static int[,] GetNewGrid()
        {
            var arr = new int[1000, 1000];
            return arr;
        }

        // not so useful when the grid is 1000x1000 
        public static void PrintGrid(int[,] arr, int maxdepth)
        {
            for (int i = 0; i < maxdepth; i++)
            {
                for (int j = 0; j < maxdepth; j++)
                {
                    System.Console.Write(arr[i, j]);
                }
                System.Console.WriteLine();
            }
        }

        public static int GetOverlappingPointsHV(string[] data)
        {
            var grid = GetNewGrid();
            foreach (var line in data)
            {
                var coord = line.Split(" -> ");
                var p1 = coord[0].Split(',');
                var p2 = coord[1].Split(',');
                var x1 = int.Parse(p1[0]);
                var y1 = int.Parse(p1[1]);
                var x2 = int.Parse(p2[0]);
                var y2 = int.Parse(p2[1]);

                if (x1 == x2)
                {
                    int lowerBound = y1 < y2 ? y1 : y2;
                    int upperBound = y2 > y1 ? y2 : y1;
                    for (int i = lowerBound; i <= upperBound; i++)
                    {
                        grid[i, x1]++;
                    }
                }

                if (y1 == y2)
                {
                    int lowerBound = x1 < x2 ? x1 : x2;
                    int upperBound = x2 > x1 ? x2 : x1;
                    for (int i = lowerBound; i <= upperBound; i++)
                    {
                        grid[y1, i]++;
                    }
                }
            }

            int count = 0;
            foreach (var p in grid)
            {
                if (p > 1)
                {
                    count++;
                }
            }
            return count;
        }
        public static int GetOverlappingPointsAll(string[] data)
        {
            var grid = GetNewGrid();
            foreach (var line in data)
            {
                var coord = line.Split(" -> ");
                var p1 = coord[0].Split(',');
                var p2 = coord[1].Split(',');
                var x1 = int.Parse(p1[0]);
                var y1 = int.Parse(p1[1]);
                var x2 = int.Parse(p2[0]);
                var y2 = int.Parse(p2[1]);


                if (x1 == x2)
                {
                    int lowerBound = y1 < y2 ? y1 : y2;
                    int upperBound = y2 > y1 ? y2 : y1;
                    for (int i = lowerBound; i <= upperBound; i++)
                    {
                        grid[i, x1]++;
                    }
                }

                else if (y1 == y2)
                {
                    int lowerBound = x1 < x2 ? x1 : x2;
                    int upperBound = x2 > x1 ? x2 : x1;
                    for (int i = lowerBound; i <= upperBound; i++)
                    {
                        grid[y1, i]++;
                    }
                }
                else
                {
                    grid[y2, x2]++;
                    while (x1 != x2 || y1 != y2)
                    {
                        grid[y1, x1]++;

                        x1 = x1 < x2 ? x1 + 1 : x1 - 1;
                        y1 = y1 < y2 ? y1 + 1 : y1 - 1;
                    }
                }
            }

            PrintGrid(grid, 10);
            int count = 0;
            foreach (var p in grid)
            {
                if (p > 1)
                {
                    count++;
                }
            }
            return count;
        }
    }
}