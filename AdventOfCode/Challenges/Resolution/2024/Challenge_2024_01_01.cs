using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Challenges.Resolution
{
    public class Challenge_2024_01_01 : IChallengeResolution
    {
        public int ChallengeYear => 2024;
        public int ChallengeDay => 1;
        public int ChallengePart => 1;

        public string ResolveChallenge(List<string> data)
        {
            var totalDistance = 0;

            var lists = data.Select(l => l.Split(' ', StringSplitOptions.RemoveEmptyEntries)).ToList();
            var firstList = lists.Select(c => int.Parse(c.ToList()[0])).Order().ToList();
            var secondList = lists.Select(c => int.Parse(c.ToList()[1])).Order().ToList();

            for (int i = 0; i < firstList.Count; i++)
            {
                var diff = Math.Abs(firstList[i] - secondList[i]);
                totalDistance += diff;
            }

            return totalDistance.ToString();
        }
    }
}
