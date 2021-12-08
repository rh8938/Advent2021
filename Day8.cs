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
            var result = displays.SelectMany(x => x.outputs).Count(y => y.Length.In(2, 4, 3, 7));
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

            var totVal = 0;
            for (int i = 0; i < displays.Count; i++)
            {
                Readout display = displays[i];
                for (int j = 0; j < display.input.Count(); j++)
                {
                    display.input[j] = String.Concat(display.input[j].OrderBy(c => c));
                }

                string[] cipher = new string[10];
                cipher[1] = display.input.Find(x => x.Length == 2); //c1
                cipher[4] = display.input.Find(x => x.Length == 4); //c4
                cipher[7] = display.input.Find(x => x.Length == 3); //c7
                cipher[8] = display.input.Find(x => x.Length == 7); //c8
                cipher[3] = display.input.Find(x => x.Length == 5 && (cipher[1].ToCharArray()).All(y => x.Contains(y))); //c3 Length of 5 and contains all of c1
                cipher[6] = display.input.Find(x => x.Length == 6 && !(cipher[1].ToCharArray()).All(y => x.Contains(y))); //c6 Length of 6 and doesnt contain all of c1
                cipher[9] = display.input.Find(x => x.Length == 6 && (cipher[4].ToCharArray()).All(y => x.Contains(y))); //c9 Length of 6 and contains all of c4
                cipher[0] = display.input.Find(x => x.Length == 6 && x != cipher[6] && x != cipher[9]); //c0 Last one of Length 6
                cipher[5] = display.input.Find(x => x.Length == 5 && x != cipher[3] && cipher[9].ToCharArray().Except(x.ToCharArray()).Count() == 1); //c5 Length 5, one different value than c9
                cipher[2] = display.input.Find(x => x.Length == 5 && x != cipher[5] && x != cipher[3]); //c2 Length 5, not c5 or c3

                string decoded = "";
                foreach (var item in display.outputs)
                {
                    var itemOrdered = String.Concat(item.OrderBy(c => c)); 
                    decoded += cipher.ToList().IndexOf(itemOrdered).ToString();
                }

                totVal += int.Parse(decoded);
            }
            Console.WriteLine(totVal);
        }
    }
}
