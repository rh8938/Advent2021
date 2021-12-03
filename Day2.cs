using System;
using System.IO;
using System.Linq;

namespace Advent2021
{
    class Day2
    {

        public struct DirectionalInput
        {
            public string direction;
            public int magnitude;
        }

        public static void Day2P2()
        {
            //https://adventofcode.com/2021/day/2#part2
            Console.WriteLine("Day2P2");
            var navSteps = File.ReadAllLines("input02.txt").ToList().Select(x =>
            {
                var split = x.Split(' ');
                return new DirectionalInput() { direction = split[0], magnitude = int.Parse(split[1]) };
            });

            var aim = 0;
            var hPos = 0;
            var depth = 0;

            foreach (var item in navSteps)
            {
                switch (item.direction)
                {
                    case "up":
                        aim -= item.magnitude;
                        break;
                    case "down":
                        aim += item.magnitude;
                        break;
                    case "forward":
                        hPos += item.magnitude;
                        depth += (aim * item.magnitude);
                        break;
                }
            }
            Console.WriteLine(depth * hPos);
            Console.ReadLine();
        }

        public static void Day2p1()
        {
            //https://adventofcode.com/2021/day/2
            Console.WriteLine("Day2P1");
            var navSteps = File.ReadAllLines("input02.txt").ToList().Select(x =>
            new DirectionalInput() { direction = x.Split(' ')[0], magnitude = int.Parse(x.Split(' ')[1]) });

            var depth = 0;
            var hPos = 0;

            foreach (var item in navSteps)
            {
                switch (item.direction)
                {
                    case "up":
                        depth -= item.magnitude;
                        break;
                    case "down":
                        depth += item.magnitude;
                        break;
                    case "forward":
                        hPos += item.magnitude;
                        break;
                    case "backward":
                        hPos -= item.magnitude;
                        break;
                }
            }
            Console.WriteLine(depth * hPos);
            Console.ReadLine();
        }
    }
}