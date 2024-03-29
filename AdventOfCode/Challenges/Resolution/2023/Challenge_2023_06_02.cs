using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Challenges.Resolution
{
    public class Challenge_2023_06_02 : IChallengeResolution
    {
        public int ChallengeYear => 2023;
        public int ChallengeDay => 6;
        public int ChallengePart => 2;

        public string ResolveChallenge(List<string> data)
        {
            var times = long.Parse(string.Join(null, data[0].Split(' ', System.StringSplitOptions.RemoveEmptyEntries).Skip(1)));
            var distances = long.Parse(string.Join(null, data[1].Split(' ', System.StringSplitOptions.RemoveEmptyEntries).Skip(1)));

            long winCount = 0;
            for (long buttonPressSpeed = 1; buttonPressSpeed < times; buttonPressSpeed++)
            {
                var remainingRaceTime = times - buttonPressSpeed;
                if (buttonPressSpeed * remainingRaceTime > distances) winCount++;
            }

            return $"{winCount}";
        }
    }
}
