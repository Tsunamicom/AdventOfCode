using System.Collections.Generic;

namespace AdventOfCode.Challenges.Resolution
{
    public class Challenge_2023_02_01 : IChallengeResolution
    {
        public int ChallengeYear => 2023;
        public int ChallengeDay => 2;
        public int ChallengePart => 1;

        public string ResolveChallenge(List<string> data)
        {
            var maxCubes = new Dictionary<string, int>() {
                { "red", 12 },
                { "green", 13 },
                { "blue", 14 }
            };

            var idSum = 0;

            foreach (var line in data)
            {
                var cubes = new Dictionary<string, int>();

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
                        if (maxCubes[color] < colorCount)
                        {
                            goto EndOfGame;
                        }
                    }
                }

                idSum += gameId;

            EndOfGame: continue;
            }

            return idSum.ToString();
        }
    }
}
