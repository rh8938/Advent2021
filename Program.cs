using System;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace Advent2021
{
    class Program
    {
        static void Main(string[] args)
        {
            var sw = new Stopwatch();
            sw.Start();

            Day6.Part2();

            sw.Stop();


            Console.WriteLine();
            Console.WriteLine("Execution Time:");
            Console.WriteLine(sw.ElapsedMilliseconds);
            Console.ReadLine();
        }
    }
}
