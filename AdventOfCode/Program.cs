using AdventOfCode.Challenges;
using AdventOfCode.Challenges.Resolution;
using AdventOfCode.DataAccess;
using AdventOfCode.Repository;
using System;
using System.Collections.Generic;

namespace AdventOfCode
{
    class Program
    {
        static void Main(string[] args)
        {
            var challenges = new List<IChallenge>()
            {
                new Challenge(new LocalFileAccess(".\\Files\\Day1.txt"), new Challenge_2020_01_01(), true), // Challenge Day 1, Part 1
                new Challenge(new LocalFileAccess(".\\Files\\Day1.txt"), new Challenge_2020_01_02(), true)  // Challenge Day 1, Part 2
            };

            var resolver = new ChallengeResolver(challenges);

            var results = resolver.GetChallengeResults().GetAwaiter().GetResult();

            foreach (var result in results)
            {
                Console.WriteLine($"Challenge Day: {result.ChallengeDay}");
                Console.WriteLine($"Challenge Part: {result.ChallengePart}");
                Console.WriteLine($"HasError: {result.HasError}");
                Console.WriteLine($"Resolve Time (ms): {result.ResolveTime}");
                Console.WriteLine($"Result: {result.Result}");
                Console.WriteLine("=========================================================");
                Console.WriteLine();
            }
            
            Console.ReadKey();
        }
    }
}
