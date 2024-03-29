using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Challenges.Resolution
{
    public class Challenge_2023_02_02 : IChallengeResolution
    {
        public int ChallengeYear => 2023;
        public int ChallengeDay => 2;
        public int ChallengePart => 2;

        public string ResolveChallenge(List<string> data)
        {
            var totalPowers = 0;
            foreach (var line in data)
            {
                var minCubes = new Dictionary<string, int>() {
                    { "red", 0 },
                    { "green", 0 },
                    { "blue", 0 }
                };

                var games = line.Split(": ");
                _ = int.TryParse(games[0].Replace("Game ", null), out var gameId);
                var handfuls = games[1].Split("; ");

                foreach (var handful in handfuls)
                {
                    var cubeCounts = handful.Split(", ");
                    foreach (var cubeVal in cubeCounts)
                    {
                        var colorVals = cubeVal.Split(" ");
                        _ = int.TryParse(colorVals[0], out var colorCount);
                        var color = colorVals[1];
                        if (minCubes[color] < colorCount)
                        {
                            minCubes[color] = colorCount;
                        }
                    }
                }

                var gamePower = minCubes.Values.Aggregate((a, b) => a * b);
                totalPowers += gamePower;
            }

            return totalPowers.ToString();
        }
    }
}
