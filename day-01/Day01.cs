using System;

namespace aoc_2021
{
    public static class Day01
    {
        public static int CountDepthIncreases(string[] data)
        {
            int depthPrev = 0;
            int countInc = 0;
            foreach (var line in data)
            {
                int depth = Convert.ToInt32(line);
                if (depth > depthPrev)
                {
                    countInc++;
                }
                depthPrev = depth;
            }

            return countInc - 1;
        }

        public static int CountDepthIncreasesWindow(string[] data)
        {
            int depthPrevSum = 0;
            int countInc = 0;
            for (int p2 = 2; p2 < data.Length; p2++)
            {
                int depthSum =
                    Convert.ToInt32(data[p2 - 0]) +
                    Convert.ToInt32(data[p2 - 1]) +
                    Convert.ToInt32(data[p2 - 2]);

                if (depthSum > depthPrevSum)
                    countInc++;

                depthPrevSum = depthSum;
            }

            return countInc - 1;
        }
    }
}