using System;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace aoc_2021
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine($"Getting input from {args[2]}");
            var lines = Utilities.GetInput(args[2]);

            System.Console.WriteLine($"Executing day {args[1]}");
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
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
                case 5:
                    {
                        Console.WriteLine("Day 5");
                        System.Console.WriteLine($"P1: {Day05.GetOverlappingPointsHV(lines)} ");
                        System.Console.WriteLine($"P2: {Day05.GetOverlappingPointsAll(lines)}");
                        break;
                    }
                case 6:
                    {
                        System.Console.WriteLine("Day 6");
                        System.Console.WriteLine($"P1: {Day06.RunGrowthSim(lines, 80)}");
                        System.Console.WriteLine($"P2: {Day06.RunGrowthSimFast(lines, 256)}");
                        break;
                    }
                case 7:
                    {
                        // var data = lines[0].Split(',');
                        System.Console.WriteLine("Day 7");
                        System.Console.WriteLine($"P1: {Day07.FuelCalc(lines)}");
                        System.Console.WriteLine($"P2: {Day07.FuelCalcExpo(lines)}");
                        break;
                    }
                case 8:
                    {
                        System.Console.WriteLine("Day 8");
                        System.Console.WriteLine($"P1: {Day08.CountDigits(lines)}");
                        break;
                    }
                case 9:
                    {
                        System.Console.WriteLine("Day 9");
                        System.Console.WriteLine($"P1: {Day09.SumRisk(lines)}");
                        System.Console.WriteLine($"P2: {Day09.GetBasins(lines)}");
                        break;
                    }
                case 10:
                    {
                        System.Console.WriteLine("Day 10");
                        System.Console.WriteLine($"P1: {Day10.GetSyntaxScore(lines)}");
                        System.Console.WriteLine($"P2: {Day10.GetCompletionScore(lines)}");
                        break;
                    }
                default:
                    {
                        System.Console.WriteLine("Invalid day");
                        break;
                    }
            }
            stopwatch.Stop();
            System.Console.WriteLine($"Executed in {stopwatch.Elapsed}");
        }
    }
}
