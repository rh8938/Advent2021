using System;
using System.IO;
using System.Linq;

namespace Advent2021
{
    class Day3
    {
        internal static void Part1()
        {
            Console.WriteLine("Day3P1");
            var diagnosticsOutput = File.ReadAllLines("input03.txt").ToList().Select(x => x.ToCharArray().Select(c => c - '0').ToArray()).ToArray();
            int inputs = diagnosticsOutput.Length;
            string gammaString = "";
            string epsilonString = "";
            int rowLength = diagnosticsOutput[0].Length;
            for (int i = 0; i < rowLength; i++)
            {
                gammaString += diagnosticsOutput.Select(p => p[i]).Count(x => x != 0) > (inputs / 2) ? "1" : "0";
                epsilonString += diagnosticsOutput.Select(p => p[i]).Count(x => x == 0) > (inputs / 2) ? "1" : "0";
            }

            long gamma = Convert.ToInt32(gammaString,2);
            Console.WriteLine(gamma);
            long epsilon = Convert.ToInt32(epsilonString,2);
            Console.WriteLine(epsilon);
            Console.WriteLine(gamma * epsilon);
            Console.ReadLine();
        }
    }
}
