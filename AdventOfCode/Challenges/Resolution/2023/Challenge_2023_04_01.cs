using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Challenges.Resolution
{
    public class Challenge_2023_04_01 : IChallengeResolution
    {
        public int ChallengeYear => 2023;
        public int ChallengeDay => 4;
        public int ChallengePart => 1;

        public string ResolveChallenge(List<string> data)
        {
            var totalGameValues = 0;
            foreach (var line in data)
            {
                var gameValue = 0;
                var game = line.Split(':', System.StringSplitOptions.RemoveEmptyEntries);
                var gameResults = game[1].Split('|', System.StringSplitOptions.RemoveEmptyEntries);
                var winningEntries = gameResults[0].Split(' ', System.StringSplitOptions.RemoveEmptyEntries);
                var playedEntries = gameResults[1].Split(" ", System.StringSplitOptions.RemoveEmptyEntries);

                var winOverlap = playedEntries.Where(c => winningEntries.Contains(c)).ToList();

                if (winOverlap.Count > 0)
                {
                    gameValue = 1;
                    gameValue <<= (winOverlap.Count - 1);
                    totalGameValues += gameValue;
                }
            }

            return $"{totalGameValues}";
        }
    }
}
