using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Advent2021
{
    class Day3
    {
        internal static void Part1()
        {
            Console.WriteLine("Day3P1");
            int[][] diagnosticsOutput = File.ReadAllLines("input03.txt").ToList().Select(x => x.ToCharArray().Select(c => c - '0').ToArray()).ToArray();
            int inputs = diagnosticsOutput.Length;
            string gammaString = "";
            string epsilonString = "";
            int rowLength = diagnosticsOutput[0].Length;
            for (int i = 0; i < rowLength; i++)
            {
                gammaString += diagnosticsOutput.Select(p => p[i]).Count(x => x != 0) > (inputs / 2) ? "1" : "0";
                epsilonString += diagnosticsOutput.Select(p => p[i]).Count(x => x == 0) > (inputs / 2) ? "1" : "0";
            }

            long gamma = Convert.ToInt32(gammaString, 2);
            Console.WriteLine(gamma);
            long epsilon = Convert.ToInt32(epsilonString, 2);
            Console.WriteLine(epsilon);
            Console.WriteLine(gamma * epsilon);
            Console.ReadLine();
        }
        internal static void Part2()
        {
            Console.WriteLine("Day3P2");
            var diagnosticsOutput = File.ReadAllLines("input03.txt").ToList().Select(x => x.ToCharArray().Select(c => c - '0').ToArray()).ToArray();
            int inputs = diagnosticsOutput.Count();
            int rowLength = diagnosticsOutput[0].Length;
            var oxygenList = diagnosticsOutput.ToList();
            var carbonList = diagnosticsOutput.ToList();

            for (int i = 0; i < rowLength; i++)
            {
                double halfOxyCount = (double)oxygenList.Count / 2;
                double halfCarbonCount = (double)carbonList.Count / 2;

                int oxyZeroCount = oxygenList.Select(p => p[i]).Count(x => x == 0);
                int carbonZeroCount = carbonList.Select(p => p[i]).Count(x => x == 0);

                var oxygenValue = oxyZeroCount > halfOxyCount ? 0 : 1;
                var carbonValue = carbonZeroCount <= halfCarbonCount ? 0 : 1;

                if (oxygenList.Count > 1)
                {
                    oxygenList = oxygenList.Where(p => p[i] == oxygenValue).ToList();
                }

                if (carbonList.Count > 1)
                {
                    carbonList = carbonList.Where(p => p[i] == carbonValue).ToList();
                }
            }
            string oxygenString = string.Join("", oxygenList[0]);
            string carbonString = string.Join("", carbonList[0]);
            long oxygen = Convert.ToInt32(oxygenString, 2);
            long carbon = Convert.ToInt32(carbonString, 2);
            Console.WriteLine($"Oxygen = {oxygen}");
            Console.WriteLine($"Carbon = {carbon}");
            Console.WriteLine($"Life Support = {oxygen * carbon}");
            Console.ReadLine();
        }
    }

}
