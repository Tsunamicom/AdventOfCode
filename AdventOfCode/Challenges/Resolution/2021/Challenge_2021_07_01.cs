using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Challenges.Resolution
{
    public class Challenge_2021_07_01 : IChallengeResolution
    {
        public int ChallengeYear => 2021;
        public int ChallengeDay => 7;
        public int ChallengePart => 1;

        public string ResolveChallenge(List<string> data)
        {
            var positions = data.First().Split(',').Select(int.Parse).ToList();

            var minCost = long.MaxValue;

            for (int i = 0; i < positions.Count; i++)
            {
                var currentCost = 0;
                for (int j = 0; j < positions.Count; j++)
                {
                    currentCost += Math.Abs(positions[j] - i);
                }
                minCost = Math.Min(minCost, currentCost);
            }

            return minCost.ToString();
        }
    }
}