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
                {"1-1", new Challenge(new LocalFileAccess(".\\Files\\Day1.txt"), new Challenge_2020_01_01(), true) },
                {"1-2", new Challenge(new LocalFileAccess(".\\Files\\Day1.txt"), new Challenge_2020_01_02(), true) },
                {"2-1", new Challenge(new LocalFileAccess(".\\Files\\Day2.txt"), new Challenge_2020_02_01(), true) },
                {"2-2", new Challenge(new LocalFileAccess(".\\Files\\Day2.txt"), new Challenge_2020_02_02(), true) },
                {"3-1", new Challenge(new LocalFileAccess(".\\Files\\Day3.txt"), new Challenge_2020_03_01(), true) },
                {"3-2", new Challenge(new LocalFileAccess(".\\Files\\Day3.txt"), new Challenge_2020_03_02(), true) },
                {"4-1", new Challenge(new LocalFileAccess(".\\Files\\Day4.txt"), new Challenge_2020_04_01(), true) },
                {"4-2", new Challenge(new LocalFileAccess(".\\Files\\Day4.txt"), new Challenge_2020_04_02(), true) },
                {"5-1", new Challenge(new LocalFileAccess(".\\Files\\Day5.txt"), new Challenge_2020_05_01(), true) },
                {"5-2", new Challenge(new LocalFileAccess(".\\Files\\Day5.txt"), new Challenge_2020_05_02(), true) },
                {"6-1", new Challenge(new LocalFileAccess(".\\Files\\Day6.txt"), new Challenge_2020_06_01(), true) },
                {"6-2", new Challenge(new LocalFileAccess(".\\Files\\Day6.txt"), new Challenge_2020_06_02(), true) },
                {"7-1", new Challenge(new LocalFileAccess(".\\Files\\Day7.txt"), new Challenge_2020_07_01(), true) },
                {"7-2", new Challenge(new LocalFileAccess(".\\Files\\Day7.txt"), new Challenge_2020_07_02(), true) },
                {"8-1", new Challenge(new LocalFileAccess(".\\Files\\Day8.txt"), new Challenge_2020_08_01(), true) },
                {"8-2", new Challenge(new LocalFileAccess(".\\Files\\Day8.txt"), new Challenge_2020_08_02(), true) },
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
