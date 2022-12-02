using System;
using System.Collections.Generic;

namespace AdventOfCode.Challenges.Resolution
{
    public class Challenge_2022_01_01 : IChallengeResolution
    {
        public int ChallengeYear => 2022;
        public int ChallengeDay => 1;
        public int ChallengePart => 1;

        public string ResolveChallenge(List<string> data)
        {
            var maxCals = 0;
            var carriedCals = 0;
            for (int i = 0; i < data.Count; i++)
            {
                _ = int.TryParse(data[i], out var currCals);
                carriedCals += currCals;
                if (string.IsNullOrEmpty(data[i]) || data.Count - 1 == i)
                {
                    maxCals = Math.Max(maxCals, carriedCals);
                    carriedCals = 0;
                }
            }

            return maxCals.ToString();
        }
    }
}