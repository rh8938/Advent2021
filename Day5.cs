using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Advent2021
{
    public struct VentLine
    {
        public Vector2 start;
        public Vector2 end;
        public bool cardinal;
        public List<Vector2> path;
    }

    public class Day5
    {
        public static void Part1()
        {
            Console.WriteLine("Day5P1");
            var ventLines = File.ReadAllLines("input05.txt").ToList().Select(x =>
            {
                var split = x.Split(" -> ");
                var startSplit = split[0].Split(',').Select(x => int.Parse(x)).ToList();
                var endSplit = split[1].Split(',').Select(x => int.Parse(x)).ToList();
                Vector2 startVec = new Vector2(startSplit[0], startSplit[1]);
                Vector2 endVec = new Vector2(endSplit[0], endSplit[1]);
                List<Vector2> path = getPath(startVec, endVec);
                return new VentLine() { start = startVec, end = endVec, cardinal = isCardinal(startVec, endVec), path = path };
            }).ToList();
            var a = ventLines[1];

            var pathpoints = ventLines.SelectMany(x => x.path).ToList();
            var count = pathpoints.GroupBy(p => p).Where(q => q.Count() != 1).Select(q => q.Key).Distinct().ToList();
            Console.WriteLine(count);
        }

        public static bool isCardinal(Vector2 s, Vector2 e)
        {
            var combined = s - e;
            if (combined.X == 0 || combined.Y == 0)
            {
                return true;
            }
            return false;
        }

        public static List<Vector2> getPath(Vector2 s, Vector2 e)
        {
            if (!isCardinal(s, e))
            {
                return new List<Vector2>();
            }

            var res = new List<Vector2>();
            res.Add(s);

            var combined = s - e;

            if (combined.X == 0)
            {
                float dir = combined.Y / Math.Abs(combined.Y);
                for (int i = 0; i < Math.Abs(combined.Y); i++)
                {
                    s.Y -= dir;
                    res.Add(s);
                }
            }
            if (combined.Y == 0)
            {
                float dir = combined.X / Math.Abs(combined.X);
                for (int i = 0; i < Math.Abs(combined.X); i++)
                {
                    s.X -= dir;
                    res.Add(s);
                }
            }

            return res;
        }
    }
}
