using System;
using System.Collections.Generic;

namespace aoc_2021
{
    public static class Day03
    {

        public static int GetPowerConsumption(string[] data)
        {
            string gamma = "";
            string epsilon = "";
            for (int i = 0; i < data[0].Length; i++)
            {
                int ones = 0;
                int zeroes = 0;
                foreach (var line in data)
                {
                    if (line[i] == '1')
                    {
                        ones++;
                    }
                    else
                    {
                        zeroes++;
                    }
                }

                gamma = ones > zeroes ? gamma + "1" : gamma + "0";
                epsilon = zeroes > ones ? epsilon + "1" : epsilon + "0";
            }

            return Convert.ToInt32(gamma, 2) * Convert.ToInt32(epsilon, 2);
        }

        public static char GetMostCommon(string[] data, int pos)
        {
            int ones = 0;
            int zeroes = 0;
            foreach (var line in data)
            {
                if (line[pos] == '1')
                {
                    ones++;
                }
                else
                {
                    zeroes++;
                }
            }

            if (ones >= zeroes)
            {
                return '1';
            }

            return '0';
        }
        public static char GetLeastCommon(string[] data, int pos)
        {
            int ones = 0;
            int zeroes = 0;
            foreach (var line in data)
            {
                if (line[pos] == '1')
                {
                    ones++;
                }
                else
                {
                    zeroes++;
                }
            }

            if (ones < zeroes)
            {
                return '1';
            }

            return '0';
        }

        public static int GetOxygenRating(string[] data)
        {
            int len = data[0].Length;
            var list = new List<string>(data);
            for (int i = 0; i < len; i++)
            {
                var tmp = new List<string>();
                char cmn = GetMostCommon(list.ToArray(), i);
                // System.Console.WriteLine($"common {cmn}, pos {i}");
                for (int j = 0; j < list.Count; j++)
                {
                    // System.Console.WriteLine($"{list[j]},{list[j][i]}");
                    if (list[j][i] == cmn)
                    {
                        tmp.Add(list[j]);
                    }
                }
                list = tmp;
                if (list.Count == 1)
                {
                    break;
                }
            }

            return Convert.ToInt32(list[0], 2);
        }

        public static int GetCO2Rating(string[] data)
        {
            int len = data[0].Length;
            var list = new List<string>(data);
            for (int i = 0; i < len; i++)
            {
                var tmp = new List<string>();
                char cmn = GetLeastCommon(list.ToArray(), i);
                // System.Console.WriteLine($"common {cmn}, pos {i}");
                for (int j = 0; j < list.Count; j++)
                {
                    // System.Console.WriteLine($"{list[j]},{list[j][i]}");
                    if (list[j][i] == cmn)
                    {
                        tmp.Add(list[j]);
                    }
                }
                list = tmp;

                if (list.Count == 1)
                {
                    break;
                }
            }

            return Convert.ToInt32(list[0], 2);
        }
    }

}