using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace AdventOfCode.Challenges.Resolution
{
    public class Challenge_2020_07_02 : IChallengeResolution
    {
        public int ChallengeYear => 2020;
        public int ChallengeDay => 7;
        public int ChallengePart => 2;

        public string ResolveChallenge(List<string> data)
        {
            var bagRules = GetParsedRules(data);

            var containedBagCount = GetContainedBagCount(bagRules, "shiny gold");

            return containedBagCount.ToString();

        }

        /// <summary>
        /// Parses the rule set
        /// </summary>
        public Dictionary<string, List<Tuple<string, int>>> GetParsedRules(List<string> rulesData)
        {
            // <bag, bag that can contain it>
            var bagColorRules = new Dictionary<string, List<Tuple<string, int>>>();

            var containsBagPattern = new Regex(@"(\d)\s(.*)");

            foreach (var rule in rulesData)
            {
                var ruleSplit = rule
                    .Replace(" bags", null)
                    .Replace(" bag", null)
                    .Replace(".", null)
                    .Split("contain");

                var targetBag = ruleSplit[0].Trim();
                var containsBags = ruleSplit[1].Split(',');

                foreach (var bag in containsBags)
                {
                    var match = containsBagPattern.Match(bag);
                    if (match.Success)
                    {
                        int.TryParse(match.Groups[1].Value, out var bagColorCount);
                        var bagColor = match.Groups[2].Value;

                        var containedBag = new Tuple<string, int>(bagColor, bagColorCount);

                        if (!bagColorRules.ContainsKey(targetBag))
                        {
                            bagColorRules
                                .Add(targetBag, new List<Tuple<string, int>>() { containedBag });
                        }
                        else
                        {
                            bagColorRules[targetBag].Add(containedBag);
                        }
                    }
                }
            }
            return bagColorRules;
        }

        /// <summary>
        /// Counts the nested bags of the target bag
        /// </summary>
        public int GetContainedBagCount(Dictionary<string, List<Tuple<string, int>>> containedBags, string targetBag)
        {
            if (!containedBags.ContainsKey(targetBag))
                return 0;

            var target = containedBags[targetBag];

            var totalContainedBags = 0;

            foreach (var bag in target)
            {
                totalContainedBags += bag.Item2 + bag.Item2 * GetContainedBagCount(containedBags, bag.Item1);
            }

            return totalContainedBags;
        }
    }
}