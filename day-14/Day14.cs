using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;


namespace aoc_2021
{
    public static class Day14
    {
        public static Dictionary<string, char> GetInsertionRules(string[] data)
        {
            var dict = new Dictionary<string, char>();

            for (int i = 2; i < data.Length; i++)
            {
                // ain't pretty
                dict.Add(data[i].Substring(0, 2), data[i][6]);
            }

            return dict;
        }

        public static HashSet<char> alphabet = new HashSet<char>()
        {
            'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q',
            'R',
            'S',
            'T',
            'U',
            'V',
            'W',
            'X',
            'Y',
            'Z'
        };

        public static string BuildPolymer(string polymer, Dictionary<string, char> map)
        {
            string newpolymer = "" + polymer[0];
            for (int i = 0; i < polymer.Length - 1; i++)
            {
                newpolymer += map[polymer.Substring(i, 2)].ToString() + polymer[i + 1];
            }
            return newpolymer;
        }


        public static int GetPolymerCount(string[] data, int steps)
        {
            int result = 0;
            string polymer = data[0];
            var rules = GetInsertionRules(data);
            for (int i = 0; i < steps; i++)
            {
                polymer = BuildPolymer(polymer, rules);
            }

            var counts = new Dictionary<char, int>();

            foreach (var letter in alphabet)
            {
                if (polymer.Count(x => x == letter) > 0)
                    counts.Add(letter, polymer.Count(x => x == letter));
            }

            return counts.Max(x => x.Value) - counts.Min(x => x.Value);
        }

        public static string BuildPolymerRecursive(string polymer, Dictionary<string, char> map, int steps)
        {
            System.Console.WriteLine(polymer);
            if (steps == 0) return "";

            string newpolymer = polymer[0].ToString();
            for (int i = 0; i < polymer.Length - 1; i++)
            {
                newpolymer += BuildPolymerRecursive(map[polymer.Substring(i, 2)].ToString() + polymer[i + 1].ToString(), map, steps - 1);
            }
            return newpolymer;
        }
        public static int GetPolymerCountBetter(string[] data, int steps)
        {
            string polymer = data[0];
            string res = BuildPolymerRecursive(polymer, GetInsertionRules(data), 2);
            System.Console.WriteLine(res);
            return 0;
        }
    }
}