using System;
using System.Collections.Generic;
using System.Linq;

namespace aoc_2021
{
    public static class Day07
    {

        public static void PrintArray(int[] arr)
        {
            foreach (var i in arr)
            {
                System.Console.Write(i + ",");
            }
            System.Console.WriteLine();
        }

        public static int GetMedian(int[] pos)
        {
            int median = 0;

            Array.Sort(pos);
            median = pos[pos.Length / 2 - 1];

            return median;
        }

        public static int GetAverage(int[] pos)
        {
            int avg = ((int)Math.Round(pos.Average()));
            return avg;
        }

        public static int FuelCalc(string[] data)
        {
            var pos = Array.ConvertAll(data[0].Split(','), x => int.Parse(x));

            int median = GetMedian(pos);
            int sum = 0;

            for (int i = 0; i < pos.Length; i++)
            {
                sum += Math.Abs(pos[i] - median);
            }
            return sum;
        }

        public static int[] GetFuelRateMap(int range)
        {
            var map = Enumerable.Range(0, range + 1).ToArray();

            for (int i = 1; i < map.Length; i++)
            {
                map[i] = map[i - 1] + i;
            }

            return map;
        }

        public static int FuelCalcExpo(string[] data)
        {
            var pos = Array.ConvertAll(data[0].Split(','), x => int.Parse(x));

            int avg = GetAverage(pos);
            System.Console.WriteLine($"{pos.Count()}, {pos.Sum()} Average distance is {avg}");
            int sum = 0;
            var map = GetFuelRateMap(pos.Max());
            for (int i = 0; i < pos.Length; i++)
            {
                sum += map[Math.Abs(pos[i] - avg)];
            }
            return sum;
        }
    }
}