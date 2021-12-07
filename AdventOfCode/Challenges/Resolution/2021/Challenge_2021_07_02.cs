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

            var minCost = long.MaxValue;

            for (int i = 0; i < positions.Count; i++)
            {
                var currentCost = 0;
                for (int j = 0; j < positions.Count; j++)
                {
                    var positionDiff = Math.Abs(positions[j] - i);
                    currentCost += positionDiff * (positionDiff + 1) / 2;
                }
                minCost = Math.Min(minCost, currentCost);
            }

            return minCost.ToString();
        }
    }
}