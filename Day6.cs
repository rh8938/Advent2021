using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent2021
{
    public class Day6
    {
        public static void Part1()
        {
            Console.WriteLine("Day6P1");
            var input = File.ReadAllLines("input06.txt").ToList();
            var fishVals = input[0].Split(',').Select(x => int.Parse(x)).ToList();
            for (int i = 0; i < 80; i++)
            {
                Console.WriteLine($"Day {i}");
                Console.WriteLine($"FishVals Count {fishVals.Count()}");
                Console.WriteLine(String.Join(',', fishVals));
                for (int f = 0; f < fishVals.Count; f++)
                {
                    fishVals[f] -= 1;
                    if (fishVals[f] < 0)
                    {
                        fishVals[f] = 6;
                        fishVals.Add(9);
                    }
                }
            }
            Console.Write(fishVals.Count());
        }

        public static void Part2()
        {
            Console.WriteLine("Day6P2");
            var input = File.ReadAllLines("input06.txt").ToList();
            var fishVals = input[0].Split(',').Select(x => int.Parse(x)).ToList();

            long fish0 = fishVals.Count(x => x == 0);
            long fish1 = fishVals.Count(x => x == 1);
            long fish2 = fishVals.Count(x => x == 2);
            long fish3 = fishVals.Count(x => x == 3);
            long fish4 = fishVals.Count(x => x == 4);
            long fish5 = fishVals.Count(x => x == 5);
            long fish6 = fishVals.Count(x => x == 6);
            long fish7 = fishVals.Count(x => x == 7);
            long fish8 = fishVals.Count(x => x == 8);

            long decayed8 = 0;
            long decayed7 = 0;
            long decayed6 = 0;
            long decayed5 = 0;
            long decayed4 = 0;
            long decayed3 = 0;
            long decayed2 = 0;
            long decayed1 = 0;
            long decayed0 = 0;

            for (int i = 0; i < 256; i++)
            {
                Console.WriteLine("----------------");
                Console.WriteLine($"Day {i}");

                decayed8 = fish8;
                decayed7 = fish7;
                decayed6 = fish6;
                decayed5 = fish5;
                decayed4 = fish4;
                decayed3 = fish3;
                decayed2 = fish2;
                decayed1 = fish1;
                decayed0 = fish0;

                fish8 = decayed0;
                fish7 = decayed8;
                fish6 = decayed7 + decayed0;
                fish5 = decayed6;
                fish4 = decayed5;
                fish3 = decayed4;
                fish2 = decayed3;
                fish1 = decayed2;
                fish0 = decayed1;

                Console.WriteLine(fish8);
                Console.WriteLine(fish7);
                Console.WriteLine(fish6);
                Console.WriteLine(fish5);
                Console.WriteLine(fish4);
                Console.WriteLine(fish3);
                Console.WriteLine(fish2);
                Console.WriteLine(fish1);
                Console.WriteLine(fish0);
            }
            Console.Write(fish0 + fish8 + fish7 + fish6 + fish5 + fish4 + fish3 + fish2 + fish1);
        }
    }
}
