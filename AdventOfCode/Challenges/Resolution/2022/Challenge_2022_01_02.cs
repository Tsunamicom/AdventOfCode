using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Challenges.Resolution
{
    public class Challenge_2022_01_02 : IChallengeResolution
    {
        public int ChallengeYear => 2022;
        public int ChallengeDay => 1;
        public int ChallengePart => 2;

        public string ResolveChallenge(List<string> data)
        {
            var topCalories = new List<int> { 0, 0, 0 };
            var carriedCals = 0;
            for (int i = 0; i < data.Count; i++)
            {
                _ = int.TryParse(data[i], out var currCals);
                carriedCals += currCals;
                if (string.IsNullOrEmpty(data[i]) || data.Count - 1 == i)
                {
                    topCalories.Add(carriedCals);
                    if(topCalories.Count > 3)
                    {
                        topCalories.Remove(topCalories.Min());
                    }
                    carriedCals = 0;
                }
            }

            return topCalories.Sum().ToString();
        }
    }
}