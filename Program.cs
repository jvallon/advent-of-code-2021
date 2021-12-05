using System;
using System.IO;
using System.Collections.Generic;

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
                case 2:
                    {
                        Console.WriteLine("Calculating position");
                        var pos = Day02.GetPosition(lines);
                        Console.WriteLine($"P1: {pos[0] * pos[1]} ");
                        var posAim = Day02.GetPositionWithAim(lines);
                        Console.WriteLine($"P1: {posAim[0] * posAim[1]} ");
                        break;
                    }
                case 3:
                    {
                        Console.WriteLine("Calculating power consumption");
                        var power = Day03.GetPowerConsumption(lines);
                        Console.WriteLine($"P1: {power} ");
                        System.Console.WriteLine($"P2: {Day03.GetOxygenRating(lines) * Day03.GetCO2Rating(lines)}");
                        break;
                    }
                case 4:
                    {
                        Console.WriteLine("Playing bingo");
                        System.Console.WriteLine($"P1: {Day04.GetFirstWinScore(lines)}");
                        System.Console.WriteLine($"P2: {Day04.GetLastWinScore(lines)}");
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
