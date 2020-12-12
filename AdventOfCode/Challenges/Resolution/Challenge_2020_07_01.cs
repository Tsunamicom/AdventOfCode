using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Challenges.Resolution
{
    public class Challenge_2020_07_01 : IChallengeResolution
    {
        public int ChallengeDay => 7;
        public int ChallengePart => 1;

        public string ResolveChallenge(List<string> data)
        {

            // <bag, bag that can contain it>
            var bagColors = new Dictionary<string, HashSet<string>>();

            foreach (var rule in data)
            {
                var ruleSplit = rule
                    .Replace(" bags", null)
                    .Replace(" bag", null)
                    .Replace(".", null)
                    .Split("contain");

                var targetBag = ruleSplit[0].Trim();
                var containsBags = ruleSplit[1].Split(',');
                for (int i = 0; i < containsBags.Length; i++)
                {
                    containsBags[i] = containsBags[i].Substring(2).Trim(); // we don't care about the number in this one
                }

                foreach (var bag in containsBags)
                {

                    if (!bagColors.ContainsKey(bag)) bagColors[bag] = new HashSet<string>() { targetBag };

                    else bagColors[bag].Add(targetBag);
                }
            }

            var bagCount = RummageThroughBags(bagColors, new HashSet<string>(), "shiny gold").Count();

            return bagCount.ToString();
        }

        /// <summary>
        /// Gets a collection of unique bags inside the target bag
        /// </summary>
        public HashSet<string> RummageThroughBags(Dictionary<string, HashSet<string>> bags, HashSet<string> seenBags, string target)
        {
            var checkedTargets = bags
                .Where(b => b.Key == target)
                .SelectMany(b => b.Value)
                .Where(b => !b.Contains("no"))
                .Distinct();

            foreach (var bag in checkedTargets)
            {
                seenBags.Add(bag);
                seenBags = RummageThroughBags(bags, seenBags, bag);
            }

            return seenBags;
        }
    }
}