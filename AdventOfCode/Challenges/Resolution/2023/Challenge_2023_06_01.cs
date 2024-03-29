using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Challenges.Resolution
{
    public class Challenge_2023_06_01 : IChallengeResolution
    {
        public int ChallengeYear => 2023;
        public int ChallengeDay => 6;
        public int ChallengePart => 1;

        public string ResolveChallenge(List<string> data)
        {
            var times = data[0].Split(' ', System.StringSplitOptions.RemoveEmptyEntries).Skip(1).Select(int.Parse).ToList();
            var distances = data[1].Split(' ', System.StringSplitOptions.RemoveEmptyEntries).Skip(1).Select(int.Parse).ToList();

            var wins = new List<int>();
            for (int race = 0; race < times.Count; race++)
            {
                var winCount = 0;
                for (int buttonPressSpeed = 1; buttonPressSpeed < times[race]; buttonPressSpeed++)
                {
                    var remainingRaceTime = times[race] - buttonPressSpeed;
                    if (buttonPressSpeed * remainingRaceTime > distances[race]) winCount++;
                }
                wins.Add(winCount);
            }

            var winMult = wins.Aggregate((a, b) => a * b);

            return $"{winMult}";
        }
    }
}
