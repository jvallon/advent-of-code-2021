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
        public static void PrintGrid(int[][] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < arr[i].Length; j++)
                {
                    System.Console.Write(arr[i][j] + ",");
                }
                System.Console.WriteLine();
            }
        }
        public static void PrintArray(string[] arr)
        {
            foreach (var i in arr)
            {
                System.Console.Write(i + ",");
            }
            System.Console.WriteLine();
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
    }
}