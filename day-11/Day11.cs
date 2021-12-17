using System;
using System.Collections.Generic;
using System.Linq;

namespace aoc_2021
{
    public static class Day11
    {
        // public static int[,] grid;

        public static void FlashGrid(ref int[][] grid, int r, int c)
        {
            if (r < 0 || r > grid.Length - 1 || c < 0 || c > grid[r].Length - 1)
            {
                return;
            }


            if (grid[r][c] < 0) return;

            grid[r][c]++;

            if (grid[r][c] > 9)
            {
                grid[r][c] = -1;
                FlashGrid(ref grid, r - 1, c - 1);
                FlashGrid(ref grid, r - 1, c);
                FlashGrid(ref grid, r - 1, c + 1);

                FlashGrid(ref grid, r, c - 1);
                FlashGrid(ref grid, r, c + 1);

                FlashGrid(ref grid, r + 1, c - 1);
                FlashGrid(ref grid, r + 1, c);
                FlashGrid(ref grid, r + 1, c + 1);
            }
        }

        public static int GetFlashCount(string[] data, int steps)
        {
            int count = 0;

            var grid = Utilities.GetGrid(data);

            for (int step = 1; step <= steps; step++)
            {
                for (int i = 0; i < grid.Length; i++)
                {
                    for (int j = 0; j < grid[i].Length; j++)
                    {
                        grid[i][j]++;
                    }
                }

                for (int i = 0; i < grid.Length; i++)
                {
                    for (int j = 0; j < grid[i].Length; j++)
                    {
                        if (grid[i][j] > 9)
                        {
                            FlashGrid(ref grid, i, j);
                        }
                    }
                }

                for (int i = 0; i < grid.Length; i++)
                {
                    for (int j = 0; j < grid[i].Length; j++)
                    {
                        if (grid[i][j] == -1)
                        {
                            grid[i][j] = 0;
                            count++;
                        }
                    }
                }
            }
            return count;
        }

        public static void RunStep(ref int[][] grid)
        {
            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[i].Length; j++)
                {
                    grid[i][j]++;
                }
            }

            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[i].Length; j++)
                {
                    if (grid[i][j] > 9)
                    {
                        FlashGrid(ref grid, i, j);
                    }
                }
            }

            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[i].Length; j++)
                {
                    if (grid[i][j] == -1)
                    {
                        grid[i][j] = 0;
                    }
                }
            }
        }
        public static int GetSyncPulse(string[] data)
        {
            int step = 1;
            var grid = Utilities.GetGrid(data);
            while (true)
            {
                RunStep(ref grid);

                bool allsame = true;
                for (int i = 0; i < grid.Length; i++)
                {
                    for (int j = 0; j < grid[i].Length; j++)
                    {
                        if (grid[i][j] != 0)
                        {
                            allsame = false;
                            break;
                        }
                    }
                    if (!allsame) break;
                }
                if (allsame) break;
                step++;
            }
            return step;
        }
    }
}