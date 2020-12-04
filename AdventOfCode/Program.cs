﻿using AdventOfCode.Challenges;
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
                {"1-1", new Challenge(new LocalFileAccess(".\\Files\\Day1.txt"), new Challenge_2020_01_01(), true) },  // Challenge Day 1, Part 1
                {"1-2", new Challenge(new LocalFileAccess(".\\Files\\Day1.txt"), new Challenge_2020_01_02(), true) },  // Challenge Day 1, Part 2
                {"2-1", new Challenge(new LocalFileAccess(".\\Files\\Day2.txt"), new Challenge_2020_02_01(), true) },  // Challenge Day 2, Part 1
                {"2-2", new Challenge(new LocalFileAccess(".\\Files\\Day2.txt"), new Challenge_2020_02_02(), true) },  // Challenge Day 2, Part 2
                {"3-1", new Challenge(new LocalFileAccess(".\\Files\\Day3.txt"), new Challenge_2020_03_01(), true) },  // Challenge Day 3, Part 1
                {"3-2", new Challenge(new LocalFileAccess(".\\Files\\Day3.txt"), new Challenge_2020_03_02(), true) },  // Challenge Day 3, Part 2
                {"4-1", new Challenge(new LocalFileAccess(".\\Files\\Day4.txt"), new Challenge_2020_04_01(), true) },  // Challenge Day 4, Part 1
                {"4-2", new Challenge(new LocalFileAccess(".\\Files\\Day4.txt"), new Challenge_2020_04_02(), true) },  // Challenge Day 4, Part 2
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
