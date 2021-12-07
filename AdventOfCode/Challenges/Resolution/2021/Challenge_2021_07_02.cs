using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Challenges.Resolution
{
    public class Challenge_2021_07_02 : IChallengeResolution
    {
        public int ChallengeYear => 2021;
        public int ChallengeDay => 7;
        public int ChallengePart => 2;

        public string ResolveChallenge(List<string> data)
        {
            var positions = data.First().Split(',').Select(int.Parse).ToList();

            var minCost = positions
                .Min(c => positions
                    .Select(p => Math.Abs(p - positions.IndexOf(c)))
                    .ToList()
                    .Sum(c => c * (c + 1) / 2));

            return minCost.ToString();
        }
    }
}