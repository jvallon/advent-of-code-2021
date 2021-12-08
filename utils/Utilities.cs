using System;
using System.IO;
using System.Collections.Generic;

namespace aoc_2021
{
    public static class Utilities
    {
        public static string[] GetInput(string path)
        {
            return File.ReadAllLines(path);
        }
        public static void PrintArray(int[] arr)
        {
            foreach (var i in arr)
            {
                System.Console.Write(i + ",");
            }
            System.Console.WriteLine();
        }
        public static void PrintArray(string[] arr)
        {
            foreach (var i in arr)
            {
                System.Console.Write(i + ",");
            }
            System.Console.WriteLine();
        }
    }
}