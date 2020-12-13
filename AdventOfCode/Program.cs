using AdventOfCode.Challenges;
using AdventOfCode.Challenges.Resolution;
using AdventOfCode.DataAccess;
using AdventOfCode.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode
{
    class Program
    {
        static void Main(string[] args)
        {
            var challenges = new Dictionary<string, IChallenge>()
            {
                { "1-1", new Challenge(new LocalFileAccess(".\\Files\\Day01.txt"), new Challenge_2020_01_01()) },
                { "1-2", new Challenge(new LocalFileAccess(".\\Files\\Day01.txt"), new Challenge_2020_01_02()) },
                { "2-1", new Challenge(new LocalFileAccess(".\\Files\\Day02.txt"), new Challenge_2020_02_01()) },
                { "2-2", new Challenge(new LocalFileAccess(".\\Files\\Day02.txt"), new Challenge_2020_02_02()) },
                { "3-1", new Challenge(new LocalFileAccess(".\\Files\\Day03.txt"), new Challenge_2020_03_01()) },
                { "3-2", new Challenge(new LocalFileAccess(".\\Files\\Day03.txt"), new Challenge_2020_03_02()) },
                { "4-1", new Challenge(new LocalFileAccess(".\\Files\\Day04.txt"), new Challenge_2020_04_01()) },
                { "4-2", new Challenge(new LocalFileAccess(".\\Files\\Day04.txt"), new Challenge_2020_04_02()) },
                { "5-1", new Challenge(new LocalFileAccess(".\\Files\\Day05.txt"), new Challenge_2020_05_01()) },
                { "5-2", new Challenge(new LocalFileAccess(".\\Files\\Day05.txt"), new Challenge_2020_05_02()) },
                { "6-1", new Challenge(new LocalFileAccess(".\\Files\\Day06.txt"), new Challenge_2020_06_01()) },
                { "6-2", new Challenge(new LocalFileAccess(".\\Files\\Day06.txt"), new Challenge_2020_06_02()) },
                { "7-1", new Challenge(new LocalFileAccess(".\\Files\\Day07.txt"), new Challenge_2020_07_01()) },
                { "7-2", new Challenge(new LocalFileAccess(".\\Files\\Day07.txt"), new Challenge_2020_07_02()) },
                { "8-1", new Challenge(new LocalFileAccess(".\\Files\\Day08.txt"), new Challenge_2020_08_01()) },
                { "8-2", new Challenge(new LocalFileAccess(".\\Files\\Day08.txt"), new Challenge_2020_08_02()) },
                { "9-1", new Challenge(new LocalFileAccess(".\\Files\\Day09.txt"), new Challenge_2020_09_01()) },
                { "9-2", new Challenge(new LocalFileAccess(".\\Files\\Day09.txt"), new Challenge_2020_09_02()) },
                {"10-1", new Challenge(new LocalFileAccess(".\\Files\\Day10.txt"), new Challenge_2020_10_01()) },
                {"10-2", new Challenge(new LocalFileAccess(".\\Files\\Day10.txt"), new Challenge_2020_10_02()) },
                {"11-1", new Challenge(new LocalFileAccess(".\\Files\\Day11.txt"), new Challenge_2020_11_01()) },
                {"11-2", new Challenge(new LocalFileAccess(".\\Files\\Day11.txt"), new Challenge_2020_11_02()) },
                {"12-1", new Challenge(new LocalFileAccess(".\\Files\\Day12.txt"), new Challenge_2020_12_01()) },
                {"12-2", new Challenge(new LocalFileAccess(".\\Files\\Day12.txt"), new Challenge_2020_12_02()) },
                {"13-1", new Challenge(new LocalFileAccess(".\\Files\\Day13.txt"), new Challenge_2020_13_01()) },
                {"13-2", new Challenge(new LocalFileAccess(".\\Files\\Day13.txt"), new Challenge_2020_13_02()) },
                {"14-1", new Challenge(new LocalFileAccess(".\\Files\\Day14.txt"), new Challenge_2020_14_01()) },
                {"14-2", new Challenge(new LocalFileAccess(".\\Files\\Day14.txt"), new Challenge_2020_14_02()) },
        };

            // Allow for selection via console for specific or array of tests to run
            var selectedChallenges = args.Count() == 0
                ? challenges.Values
                : challenges.Where(c => args.Contains(c.Key)).Select(c => c.Value);

            var resolver = new ChallengeResolver(selectedChallenges.ToList());

            var results = resolver.GetChallengeResults().GetAwaiter().GetResult();

            foreach (var result in results)
            {
                Console.WriteLine($"Challenge Day-Part: {result.ChallengeDay}-{result.ChallengePart}");
                Console.WriteLine($"HasError: {result.HasError}");
                Console.WriteLine($"Resolve Time (ms): {result.ResolveTime}");
                Console.WriteLine($"Result: {result.Result}");
                Console.WriteLine("=========================================================");
                Console.WriteLine("");
            }
        }
    }
}
