using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent2021
{
    struct Readout
    {
        public List<string> input;
        public List<string> outputs;
        public int outputValue;
    }
    struct SevenSegmentDisplayMap
    {
        public int Top;
        public int TopLeft;
        public int TopRight;
        public int Middle;
        public int BottomLeft;
        public int BottomRight;
    }

    public static class Day8
    {
        public static bool In<T>(this T item, params T[] list)
    {
        return list.Contains(item);
    }
        public static void Part1()
        {
            Console.WriteLine("Day8P1");
            List<Readout> displays = File.ReadAllLines("input08.txt").ToArray().Select(x => new Readout()
                {
                    input = x.Split(" | ")[0].Split(" ").ToList(),
                    outputs = x.Split(" | ")[1].Split(" ").ToList()
                }).ToList();
            var result = displays.SelectMany(x => x.outputs).Count(y=>y.Length.In(2,4,3,7));
            Console.ReadLine();
        }

        public static void Part2()
        {
            Console.WriteLine("Day8P2");
            List<Readout> displays = File.ReadAllLines("input08.txt").ToArray().Select(x => new Readout()
            {
                input = x.Split(" | ")[0].Split(" ").ToList(),
                outputs = x.Split(" | ")[1].Split(" ").ToList()
            }).ToList();
            //for each output
            //find the 1 / 4 / 7 / 8 and what segments are lit
            //find the 3 (5 sections including the 1 sections)
            //find the 9 (6 sections, 3 plus one more)


            var result = displays.SelectMany(x => x.outputs).Count(y => y.Length.In(2, 4, 3, 7));
            Console.ReadLine();
        }
    }
}
