using AdventOfCode.Challenges;
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
            var challenges = new Dictionary<string, IChallenge>();

            //foreach (var c in ChallengeConfiguration.Challenges2020) challenges.TryAdd(c.Key, c.Value);
            foreach (var c in ChallengeConfiguration.Challenges2021) challenges.TryAdd(c.Key, c.Value);

            // Allow for selection via console for specific or array of tests to run
            var selectedChallenges = args.Count() == 0
                ? challenges.Values
                : challenges.Where(c => args.Contains(c.Key)).Select(c => c.Value);

            var resolver = new ChallengeResolver(selectedChallenges.ToList());

            var results = resolver.GetChallengeResults().GetAwaiter().GetResult();

            foreach (var result in results)
            {
                Console.WriteLine($"Challenge Year-Day-Part: {result.ChallengeYear}-{result.ChallengeDay}-{result.ChallengePart}");
                Console.WriteLine($"HasError: {result.HasError}");
                Console.WriteLine($"Resolve Time (ms): {result.ResolveTime}");
                Console.WriteLine($"Result: {result.Result}");
                Console.WriteLine("=========================================================");
                Console.WriteLine("");
            }
        }
    }
}
