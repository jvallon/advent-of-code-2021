using System;
using System.Collections.Generic;
using System.Linq;

namespace aoc_2021
{
    public static class Day09
    {
        public static List<int[]> GetLowPoints(int[][] grid)
        {
            var lowPoints = new List<int[]>();

            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[i].Length; j++)
                {
                    bool isLowPoint = true;
                    if (j > 0)
                    {
                        if (grid[i][j] >= grid[i][j - 1])
                        {
                            isLowPoint = false;
                        }
                    }

                    if (j < grid[i].Length - 1)
                    {
                        if (grid[i][j] >= grid[i][j + 1])
                        {
                            isLowPoint = false;
                        }
                    }

                    if (i > 0)
                    {
                        if (grid[i][j] >= grid[i - 1][j])
                        {
                            isLowPoint = false;
                        }
                    }

                    if (i < grid.Length - 1)
                    {
                        if (grid[i][j] >= grid[i + 1][j])
                        {
                            isLowPoint = false;
                        }
                    }

                    if (isLowPoint)
                    {
                        lowPoints.Add(new int[] { i, j });
                    }
                }
            }

            return lowPoints;
        }

        public static int[][] GetGrid(string[] data)
        {
            var grid = new int[data.Length][];
            for (int i = 0; i < data.Length; i++)
            {
                grid[i] = Array.ConvertAll(data[i].ToCharArray(), c => int.Parse(c.ToString()));
            }
            return grid;
        }

        public static int SumRisk(string[] data)
        {
            int sum = 0;
            var grid = GetGrid(data);
            var lowPoints = GetLowPoints(grid);

            foreach (var point in lowPoints)
            {
                sum += grid[point[0]][point[1]] + 1;
            }
            return sum;
        }

        public static int GetBasinSize(int[][] grid, int r, int c)
        {
            if (r < 0 || r > grid.Length - 1 || c < 0 || c > grid[r].Length - 1)
            {
                return 0;
            }

            if (grid[r][c] == 9)
            {
                return 0;
            }

            //flag as visited
            grid[r][c] = 9;

            return 1 + GetBasinSize(grid, r - 1, c) + GetBasinSize(grid, r + 1, c) + GetBasinSize(grid, r, c - 1) + GetBasinSize(grid, r, c + 1);
        }

        public static int GetBasins(string[] data)
        {
            var grid = GetGrid(data);
            var lowPoints = GetLowPoints(grid);
            var basinSizes = new List<int>();

            foreach (var point in lowPoints)
            {
                basinSizes.Add(GetBasinSize(grid, point[0], point[1]));
            }

            basinSizes.Sort();

            return basinSizes[basinSizes.Count - 1] * basinSizes[basinSizes.Count - 2] * basinSizes[basinSizes.Count - 3];
        }
    }
}