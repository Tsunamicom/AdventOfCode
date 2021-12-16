using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Challenges.Resolution
{
    public class Challenge_2021_14_01 : IChallengeResolution
    {
        public int ChallengeYear => 2021;
        public int ChallengeDay => 14;
        public int ChallengePart => 1;

        public string ResolveChallenge(List<string> data)
        {
            const int steps = 10;

            var target = data[0];

            var instructions = data.GetRange(2, data.Count - 2).Select(c => c.Split(" -> "));
            var rules = instructions.ToDictionary(c => c[0], c => c[1]);

            var pairs = GetInitialPairs(target, instructions);

            for (int i = 0; i < steps; i++)
            {
                pairs = IterateStepPairs(rules, pairs);
            }

            var charCounts = GetCharCounts(target, pairs);

            var rtnVal = charCounts.Values.Max() - charCounts.Values.Min();

            return rtnVal.ToString();
        }

        /// <summary>
        /// Populate the initial pair counts based on the original string
        /// </summary>
        private static Dictionary<string, long> GetInitialPairs(string target, IEnumerable<string[]> instructions)
        {
            var pairs = new Dictionary<string, long>();
            foreach (var instruction in instructions)
            {
                pairs.TryAdd(instruction[0][0] + instruction[1], 0);
                pairs.TryAdd(instruction[1] + instruction[0][1], 0);
                pairs.TryAdd(instruction[0], 0);
            }

            for (int i = 0; i < target.Length - 1; i++)
            {
                var lookup = target.Substring(i, 2);
                pairs[lookup]++;
            }

            return pairs;
        }

        /// <summary>
        /// Iterate the pairs and handle inserts
        /// </summary>
        private static Dictionary<string, long> IterateStepPairs(Dictionary<string, string> rules, Dictionary<string, long> pairs)
        {
            var stepPairs = pairs.ToDictionary(c => c.Key, c => 0L);
            foreach (var pair in pairs)
            {
                stepPairs[pair.Key[0] + rules[pair.Key]] += pairs[pair.Key];
                stepPairs[rules[pair.Key] + pair.Key[1]] += pairs[pair.Key];
            }

            pairs = stepPairs.ToDictionary(c => c.Key, c => c.Value);
            return pairs;
        }

        /// <summary>
        /// Calculate the unique character counts for the overall set
        /// </summary>
        private static Dictionary<char, long> GetCharCounts(string target, Dictionary<string, long> pairs)
        {
            var charCounts = new Dictionary<char, long>();
            foreach (var pair in pairs)
            {
                if (charCounts.ContainsKey(pair.Key[0])) charCounts[pair.Key[0]] += pair.Value;
                else charCounts[pair.Key[0]] = pair.Value;
            }
            if (charCounts.ContainsKey(target.Last())) charCounts[target.Last()] += 1;
            else charCounts[target.Last()] = 1;
            return charCounts;
        }
    }
}