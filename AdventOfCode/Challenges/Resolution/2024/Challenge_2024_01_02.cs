using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Challenges.Resolution
{
    public class Challenge_2024_01_02 : IChallengeResolution
    {
        public int ChallengeYear => 2024;
        public int ChallengeDay => 1;
        public int ChallengePart => 2;

        public string ResolveChallenge(List<string> data)
        {
            long totalDistance = 0;

            var lists = data.Select(l => l.Split(' ', StringSplitOptions.RemoveEmptyEntries)).ToList();
            var firstList = lists.Select(c => int.Parse(c.ToList()[0])).Order().ToList();
            var secondList = lists.Select(c => int.Parse(c.ToList()[1])).Order().ToList();

            for (int i = 0; i < firstList.Count; i++)
            {
                long simScore = firstList[i] * secondList.Count(p => p == firstList[i]);
                totalDistance += simScore;
            }

            return totalDistance.ToString();
        }
    }
}
