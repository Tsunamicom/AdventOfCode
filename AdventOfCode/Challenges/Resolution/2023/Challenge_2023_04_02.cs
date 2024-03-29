using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Challenges.Resolution
{
    public class Challenge_2023_04_02 : IChallengeResolution
    {
        public int ChallengeYear => 2023;
        public int ChallengeDay => 4;
        public int ChallengePart => 2;

        public string ResolveChallenge(List<string> data)
        {
            Dictionary<int, int> gameMultipliers = new();
            foreach (var line in data)
            {
                var game = line.Split(':', System.StringSplitOptions.RemoveEmptyEntries);
                _ = int.TryParse(game[0].Split(' ', System.StringSplitOptions.RemoveEmptyEntries)[1], out var gameId);
                var gameResults = game[1].Split('|', System.StringSplitOptions.RemoveEmptyEntries);
                var winningEntries = gameResults[0].Split(' ', System.StringSplitOptions.RemoveEmptyEntries);
                var playedEntries = gameResults[1].Split(" ", System.StringSplitOptions.RemoveEmptyEntries);

                var winOverlap = playedEntries.Where(c => winningEntries.Contains(c)).ToList();

                if (!gameMultipliers.ContainsKey(gameId)) { gameMultipliers[gameId] = 1; };

                if (winOverlap.Count > 0)
                {
                    for (int i = 1; i <= winOverlap.Count; i++)
                    {
                        if (!gameMultipliers.ContainsKey(gameId + i))
                        {
                            gameMultipliers[gameId + i] = 1 + gameMultipliers[gameId];
                        }
                        else
                        {
                            gameMultipliers[gameId + i] += (gameMultipliers[gameId]);
                        }
                    }
                }
            }

            var totalCards = gameMultipliers.Where(c => c.Key <= data.Count).Select(c => c.Value).Sum();

            return $"{totalCards}";
        }
    }
}
