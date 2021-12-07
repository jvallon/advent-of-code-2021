using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace aoc_2021
{
    public static class Day06
    {
        public static void PrintList(List<int> list)
        {
            foreach (var item in list)
            {
                Console.Write($"{item},");
            }
            System.Console.WriteLine();
        }
        // check out this naive approach. gotta work on my algorithm skills D:
        public static int RunGrowthSim(string[] data, int daysToRun)
        {
            var fish = new List<int>(data[0].Split(',').Select(x => int.Parse(x)));

            for (int day = 0; day < 22; day++)
            {
                int numFishToAdd = 0;
                for (int i = 0; i < fish.Count(); i++)
                {
                    if (fish[i] == 0)
                    {
                        fish[i] = 6;
                        numFishToAdd++;
                    }
                    else
                    {
                        fish[i]--;
                    }
                }

                for (int i = 0; i < numFishToAdd; i++)
                {
                    fish.Add(8);
                }
            }
            return fish.Count();
        }

        // don't need to keep track of every single state, just the number of fish at each state
        public static long RunGrowthSimFast(string[] data, long daysToRun)
        {
            var fish = data[0].Split(',').Select(x => long.Parse(x));
            var allFish = new long[9];
            foreach (var f in fish)
            {
                allFish[f]++;
            }

            for (long i = 0; i < daysToRun; i++)
            {
                var tmp = allFish[0];
                for (long j = 0; j < allFish.Length - 1; j++)
                {
                    allFish[j] = allFish[j + 1];

                }
                allFish[6] += tmp;
                allFish[allFish.Length - 1] = tmp;
            }

            return allFish.Sum();
        }
    }
}