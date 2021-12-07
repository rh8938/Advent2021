using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent2021
{
    public class Day7
    {
        public static void Part1()
        {
            Console.WriteLine("Day7P1");
            var input = File.ReadAllLines("input07.txt").ToList();
            var crabSubs = input[0].Split(',').Select(x => int.Parse(x)).ToList();
            crabSubs = crabSubs.OrderBy(x => x).ToList();
            double medianLine = 0;
            if (crabSubs.Count + 1 % 2 != 0)
            {
                medianLine = crabSubs[crabSubs.Count() / 2];
            }
            else
            {

                int c = crabSubs[(int)Math.Ceiling((double)crabSubs.Count / (double)2)];
                int f = crabSubs[(int)Math.Floor((double)crabSubs.Count / (double)2)];
                medianLine = (c + f) / 2;
            }

            double fuel = 0;
            for (int i = 0; i < crabSubs.Count; i++)
            {
                fuel += Math.Abs(medianLine - crabSubs[i]);
            }
            Console.WriteLine(fuel);

        }

        public static void Part2()
        {
            Console.WriteLine("Day7P1");
            var input = File.ReadAllLines("input07.txt").ToList();
            var crabSubs = input[0].Split(',').Select(x => int.Parse(x)).ToList();
            var maxCrab = crabSubs.Max();
            long bestSpot = 0;
            long bestFuel = int.MaxValue;

            for (int candidatePosition = 0; candidatePosition < maxCrab; candidatePosition++)
            {
                Debug.WriteLine(candidatePosition);
                long fuel = 0;
                for (int c = 0; c < crabSubs.Count; c++)
                {
                    for (int t = 0; t < Math.Abs(candidatePosition - crabSubs[c]); t++) //Triangle Number Time:  1 3 6 10 15 21 28 36 45
                    {
                        fuel += t+1;
                    }
                }
                if (fuel < bestFuel)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Debug.WriteLine("new best");
                    Console.ForegroundColor = ConsoleColor.White;
                    bestFuel = fuel;
                    bestSpot = candidatePosition;
                }
            }
            Console.WriteLine(bestFuel);
            Debug.WriteLine(bestSpot);
        }
    }
}
