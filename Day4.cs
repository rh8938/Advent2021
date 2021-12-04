using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent2021
{
    public class Day4
    {
        public static void Part1()
        {
            Console.WriteLine("Day4P1");
            var bingoInput = File.ReadAllLines("input04.txt").ToList();
            var numbers = bingoInput[0].Split(',').Select(x => int.Parse(x)).ToList();
            var bingoCards = new List<BingoGrid>();
            for (int i = 2; i < bingoInput.Count; i = i + 6)
            {
                var grid = new BingoGrid();
                grid.grid = new List<int[]>();
                grid.grid.Add(bingoInput[i].Trim().Replace("  ", " ").Split(' ').Select(x => int.Parse(x)).ToArray());
                grid.grid.Add(bingoInput[i + 1].Trim().Replace("  ", " ").Split(' ').Select(x => int.Parse(x)).ToArray());
                grid.grid.Add(bingoInput[i + 2].Trim().Replace("  ", " ").Split(' ').Select(x => int.Parse(x)).ToArray());
                grid.grid.Add(bingoInput[i + 3].Trim().Replace("  ", " ").Split(' ').Select(x => int.Parse(x)).ToArray());
                grid.grid.Add(bingoInput[i + 4].Trim().Replace("  ", " ").Split(' ').Select(x => int.Parse(x)).ToArray());
                bingoCards.Add(grid);
            }
            for (int i = 4; i < numbers.Count(); i++) //start at number 5, no winner before then
            {
                foreach (var bingoCard in bingoCards)
                {
                    var result = CheckWinner(bingoCard.grid, numbers.GetRange(0, i));
                    if (result.winner)
                    {
                        Console.WriteLine(result.score);
                        break;
                    }
                }
            }
            Console.Read();
        }

        public static void Part2()
        {
            Console.WriteLine("Day4P2");
            var bingoInput = File.ReadAllLines("input04.txt").ToList();
            var numbers = bingoInput[0].Split(',').Select(x => int.Parse(x)).ToList();
            var bingoCards = new List<BingoGrid>();
            for (int i = 2; i < bingoInput.Count; i = i + 6)
            {
                var grid = new BingoGrid();
                grid.grid = new List<int[]>();
                grid.grid.Add(bingoInput[i].Trim().Replace("  ", " ").Split(' ').Select(x => int.Parse(x)).ToArray());
                grid.grid.Add(bingoInput[i + 1].Trim().Replace("  ", " ").Split(' ').Select(x => int.Parse(x)).ToArray());
                grid.grid.Add(bingoInput[i + 2].Trim().Replace("  ", " ").Split(' ').Select(x => int.Parse(x)).ToArray());
                grid.grid.Add(bingoInput[i + 3].Trim().Replace("  ", " ").Split(' ').Select(x => int.Parse(x)).ToArray());
                grid.grid.Add(bingoInput[i + 4].Trim().Replace("  ", " ").Split(' ').Select(x => int.Parse(x)).ToArray());
                bingoCards.Add(grid);
            }
            for (int i = 4; i < numbers.Count(); i++) //start at number 5, no winner before then
            {
                List<int> matches = new List<int>(); 
                for (int j = 0; j < bingoCards.Count; j++)
                {
                    BingoGrid bingoCard = bingoCards[j];
                    var result = CheckWinner(bingoCard.grid, numbers.GetRange(0, i));
                    if (result.winner)
                    {
                        if (bingoCards.Count() > 1)
                        {
                            matches.Add(j);
                        }
                        else
                        {
                            Console.WriteLine(result.score);
                            break;
                        }
                    }
                }
                Console.WriteLine("number " + numbers[i]);
                Console.WriteLine("elims " + matches.Count);
                matches.Reverse();
                for (int m = 0; m < matches.Count; m++)
                {
                    bingoCards.RemoveAt(matches[m]);
                }
                Console.WriteLine($"Remaining: {bingoCards.Count}");
            }
            Console.Read();
        }

        public static Result CheckWinner(List<int[]> candidate, List<int> sequence)
        {
            for (int i = 0; i < candidate.Count(); i++)
            {
                if (sequence.Contains(candidate[i][0])
                    && sequence.Contains(candidate[i][1])
                    && sequence.Contains(candidate[i][2])
                    && sequence.Contains(candidate[i][3])
                    && sequence.Contains(candidate[i][4]))
                {
                    int[] flat = new int[25];
                    Array.Copy(candidate[0], flat, 5);
                    Array.Copy(candidate[1], 0, flat, 5, 5);
                    Array.Copy(candidate[2], 0, flat, 10, 5);
                    Array.Copy(candidate[3], 0, flat, 15, 5);
                    Array.Copy(candidate[4], 0, flat, 20, 5);
                    var resultArray = flat.ToList().Where(x => !sequence.Contains(x));

                    return new Result() { winner = true, score = resultArray.Sum() * sequence.Last() };
                }
            }
            for (int i = 0; i < candidate[i].Length - 1; i++)
            {
                if (sequence.Contains(candidate[0][i])
                   && sequence.Contains(candidate[1][i])
                   && sequence.Contains(candidate[2][i])
                   && sequence.Contains(candidate[3][i])
                   && sequence.Contains(candidate[4][i]))
                {
                    int[] flat = new int[25];
                    Array.Copy(candidate[0], flat, 5);
                    Array.Copy(candidate[1], 0, flat, 5, 5);
                    Array.Copy(candidate[2], 0, flat, 10, 5);
                    Array.Copy(candidate[3], 0, flat, 15, 5);
                    Array.Copy(candidate[4], 0, flat, 20, 5);
                    var resultArray = flat.ToList().Where(x => !sequence.Contains(x));

                    return new Result() { winner = true, score = resultArray.Sum() * sequence.Last() };
                }
            }
            return new Result() { winner = false, score = 0 };
        }

        public struct BingoGrid
        {
            public new List<int[]> grid;
        }

        public struct Result
        {
            public bool winner;
            public int score;
        }

    }
}
