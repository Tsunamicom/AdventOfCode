using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Challenges.Resolution
{
    public class Challenge_2022_03_01 : IChallengeResolution
    {
        public int ChallengeYear => 2022;

        public int ChallengeDay => 3;

        public int ChallengePart => 1;

        string alphabet = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";

        public string ResolveChallenge(List<string> data)
        {
            var prioritySum = 0;

            foreach (var rucksack in data)
            {
                var mid = rucksack.Length / 2; // lower bound

                var ruckSackList = rucksack.ToCharArray().ToList();

                var firstHalf = ruckSackList.GetRange(0, mid).ToHashSet();
                var secondHalf = ruckSackList.GetRange(mid, ruckSackList.Count - mid).ToHashSet();

                var similarValue = firstHalf.Intersect(secondHalf).First();

                var priorityScore = alphabet.IndexOf(similarValue) + 1;

                prioritySum += priorityScore;
            }

            return prioritySum.ToString();
        }
    }
}