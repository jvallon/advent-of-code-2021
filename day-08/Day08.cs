using System;
using System.Collections.Generic;
using System.Linq;

namespace aoc_2021
{
    public static class Day08
    {
        public static Dictionary<int, int> GetDigitMapBySegCount()
        {
            return new Dictionary<int, int>()
            {
                {2,1},{3,7},{4,4},{7,8}
            };
        }

        public static Dictionary<string, int> GetDigitMap()
        {
            return new Dictionary<string, int>(){
                {"abcefg",0},
                {"cf",1},
                {"acdeg",2},
                {"acdfg",3},
                {"bcdf",4},
                {"abdfg",5},
                {"abdefg",6},
                {"acf",7},
                {"abcdefg",8},
                {"abcdfg",9}
            };
        }
        public static int CountDigits(string[] data)
        {
            int count = 0;
            var dict = GetDigitMapBySegCount();
            foreach (var line in data)
            {
                var split = line.Split('|', StringSplitOptions.TrimEntries);
                var inputs = split[0].Split();
                var outputs = split[1].Split();

                foreach (var value in outputs)
                {
                    if (dict.ContainsKey(value.Length))
                    {
                        count++;
                    }
                }
            }

            return count;
        }

        /*
        7 - 1 reveals a
        0 - 8 reveals d
        8 - 6 reveals c
        8 - 9 revelas e

        */

        public static int SumOutputs(string[] data)
        {

        }
    }
}