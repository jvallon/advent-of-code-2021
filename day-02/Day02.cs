using System;

namespace aoc_2021
{
    public static class Day02
    {
        public static int[] GetPosition(string[] data)
        {
            int[] pos = { 0, 0 };

            foreach (var line in data)
            {
                string[] step = line.Split(' ');
                string dir = step[0];
                int distance = Convert.ToInt32(step[1]);

                switch (dir)
                {
                    case "forward":
                        {
                            pos[0] += distance;
                            break;
                        }
                    case "up":
                        {
                            pos[1] -= distance;
                            break;
                        }
                    case "down":
                        {
                            pos[1] += distance;
                            break;
                        }
                }
            }

            return pos;
        }

        public static int[] GetPositionWithAim(string[] data)
        {
            int[] pos = { 0, 0 };
            int aim = 0;
            foreach (var line in data)
            {
                string[] step = line.Split(' ');
                string dir = step[0];
                int distance = Convert.ToInt32(step[1]);

                switch (dir)
                {
                    case "forward":
                        {
                            pos[0] += distance;
                            pos[1] += distance * aim;
                            break;
                        }
                    case "up":
                        {
                            aim -= distance;
                            break;
                        }
                    case "down":
                        {
                            aim += distance;
                            break;
                        }
                }
            }

            return pos;
        }
    }
}