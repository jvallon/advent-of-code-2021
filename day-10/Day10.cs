using System;
using System.Collections.Generic;
using System.Linq;

namespace aoc_2021
{
    public static class Day10
    {
        static Dictionary<char, char> chunkmap = new Dictionary<char, char>(){
            {'{','}'},{'}','{'},
            {'(',')'},{')','('},
            {'[',']'},{']','['},
            {'<','>'},{'>','<'}
        };

        static Dictionary<char, int> invalidPoints = new Dictionary<char, int>(){
            {'}',1197},
            {')',3},
            {']',57},
            {'>',25137}
        };
        static Dictionary<char, int> completionPoints = new Dictionary<char, int>(){
            {'}',3},
            {')',1},
            {']',2},
            {'>',4}
        };

        static char[] open = { '(', '{', '[', '<' };
        static char[] close = { ')', '}', ']', '>' };

        static Stack<char> stack;
        public static int FindInvalidIndex(string line)
        {
            stack = new Stack<char>();
            stack.Push(line[0]);
            for (int i = 1; i < line.Length; i++)
            {
                if (open.Contains(line[i]))
                {
                    stack.Push(line[i]);
                }
                else if (stack.Peek() == chunkmap.GetValueOrDefault(line[i]))
                {
                    stack.Pop();
                }
                else
                {
                    return i;
                }
            }

            return -1;
        }
        public static int GetSyntaxScore(string[] data)
        {
            int score = 0;
            Dictionary<char, int> count = new Dictionary<char, int>();
            foreach (var line in data)
            {
                int idx = FindInvalidIndex(line);
                if (idx < 0)
                    continue;

                char invalidchar = line[idx];
                int val;
                if (count.TryGetValue(invalidchar, out val))
                {
                    count[invalidchar] = val + 1;
                }
                else
                {
                    count.Add(invalidchar, 1);
                }
            }

            foreach (var c in count)
            {
                score += c.Value * invalidPoints[c.Key];
            }
            return score;
        }

        public static double GetCompletionScore(string[] data)
        {
            List<double> scores = new List<double>();
            foreach (var line in data)
            {
                int idx = FindInvalidIndex(line);
                if (idx > 0)
                    continue;

                string comp = "";
                double linescore = 0;
                while (stack.Count() > 0)
                {
                    linescore = linescore * 5 + completionPoints[chunkmap[stack.Pop()]];
                    // comp += chunkmap[stack.Pop()];
                }
                System.Console.WriteLine(linescore);
                scores.Add(linescore);
            }

            scores.Sort();
            return scores[scores.Count / 2];
        }
    }
}