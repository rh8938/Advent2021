using System;
using System.IO;
using System.Linq;

namespace Advent2021
{
    class Day1
    {
        public static void Day1P1()
        {
            var depths = File.ReadAllLines("input01.txt").ToList().Select(x => int.Parse(x)).ToArray();
            int increasedDepths = 0;
            for (int i = 1; i < depths.Count(); i++)
            {
                if (depths[i] > depths[i - 1])
                {
                    increasedDepths++;
                }
            }
            Console.WriteLine(increasedDepths);
            Console.ReadLine();
        }
        public static void Day1P2()
        {
            //https://adventofcode.com/2021/day/1#part2
            //seems flawed, you only need to check the digits being added and removed each time, as 2 digits stay the same.
            Console.WriteLine("Day1");
            var depths = File.ReadAllLines("input01.txt").ToList().Select(x => int.Parse(x)).ToArray();
            int increasedDepths = 0;
            for (int i = 3; i < depths.Count(); i++)
            {
                if (depths[i] > depths[i - 3])
                {
                    increasedDepths++;
                }
            }
            Console.WriteLine(increasedDepths);
            Console.ReadLine();
        }

    }
}
