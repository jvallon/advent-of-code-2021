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
    }
}