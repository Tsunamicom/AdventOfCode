using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Challenges.Resolution
{
    public class Challenge_2023_01_01 : IChallengeResolution
    {
        public int ChallengeYear => 2023;
        public int ChallengeDay => 1;
        public int ChallengePart => 1;

        public string ResolveChallenge(List<string> data)
        {
            var totalSum = 0;
            foreach (var line in data)
            {
                var firstDigit = line.ToList().First(c => int.TryParse(c.ToString(), out _));
                var lastDigit = line.ToList().Last(c => int.TryParse(c.ToString(), out _));
                var calibrationVal = int.TryParse($"{firstDigit}{lastDigit}", out var calVal);
                totalSum += calVal;
            }

            return totalSum.ToString();
        }
    }
}
