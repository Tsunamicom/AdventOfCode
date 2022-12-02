using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Challenges.Resolution
{
    public class Challenge_2021_21_01 : IChallengeResolution
    {
        public int ChallengeYear => 2021;
        public int ChallengeDay => 21;
        public int ChallengePart => 1;

        private static class GameConfiguration
        {
            public const int BoardSize = 10;
            public const int WinningScore = 1000;
            public const int DiceRollsPerTurn = 3;
            public const int DiceSize = 100;
        }

        private class Player
        {
            public int Position { get; set; }
            public long TotalScore { get; set; }
            public Player(int initialPosition)
            {
                Position = initialPosition;
                TotalScore = 0L;
            }
        }

        public string ResolveChallenge(List<string> data)
        {
            var playerData = data
                .Select(c => new Player(int.Parse(c.Split(": ").Last())))
                .ToList(); // Get Players and Initial Positions

            var diceRollGenerator = GenerateDiceRolls(GameConfiguration.DiceSize).GetEnumerator();

            var totalDiceRolls = 0L;
            while (playerData.All(c => c.TotalScore < 1000))
            {
                foreach (var player in playerData)
                {
                    var currentTurnDistance = 0;
                    for (int i = 0; i < GameConfiguration.DiceRollsPerTurn; i++)
                    {
                        currentTurnDistance += GetNextDiceRollValue(diceRollGenerator);
                        totalDiceRolls++;
                    }
                    player.Position = GetPlayerBoardPosition(GameConfiguration.BoardSize, player.Position, currentTurnDistance);
                    player.TotalScore += player.Position;

                    if (player.TotalScore >= GameConfiguration.WinningScore) break;
                }
            }

            var minScore = playerData.Min(c => c.TotalScore);

            var returnValue = minScore * totalDiceRolls;


            return $"{returnValue}";
        }

        /// <summary>
        /// Generator for indefinite dice rolling for values 1 - {diceSize} in consecutive order, wrapping to beginning when beyond maximum
        /// </summary>
        private IEnumerable<int> GenerateDiceRolls(int diceSize)
        {
            var lastDiceRoll = 0;

            while (true)
            {
                lastDiceRoll = (lastDiceRoll % diceSize) + 1; // (nextDiceRoll - 1) % 100 + 1
                yield return lastDiceRoll;
            }
        }

        /// <summary>
        /// Execute the generator and get the next value.
        /// </summary>
        private int GetNextDiceRollValue(IEnumerator<int> diceRollGenerator)
        {
            diceRollGenerator.MoveNext();
            return diceRollGenerator.Current;
        }

        /// <summary>
        /// For a circular board that enumerates from 1 - {boardSize}, determine where on the board the player will end up.
        /// </summary>
        private int GetPlayerBoardPosition(int boardSize, int startPosition, int spacesMoved)
        {
            return (startPosition + spacesMoved - 1) % boardSize + 1;
        }
    }
}