using System;
using System.IO;
using System.Collections.Generic;
// using Utilities;
// using Day01;

namespace aoc_2021
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine($"Getting input from {args[2]}");
            var lines = Utilities.GetInput(args[2]);

            System.Console.WriteLine($"Executing day {args[1]}");
            switch (Convert.ToUInt16(args[1]))
            {
                case 1:
                    {
                        Console.WriteLine("Calculating increase");
                        Console.WriteLine($"P1: {Day01.CountDepthIncreases(lines)} depth increases");
                        System.Console.WriteLine($"P2: {Day01.CountDepthIncreasesWindow(lines)} window increases");
                        break;
                    }
                default:
                    {
                        System.Console.WriteLine("Invalid day");
                        break;
                    }
            }
        }
    }
}
