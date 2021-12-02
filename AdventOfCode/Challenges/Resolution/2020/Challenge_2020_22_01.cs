using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Challenges.Resolution
{
    public class Challenge_2020_22_01 : IChallengeResolution
    {
        public int ChallengeYear => 2020;
        public int ChallengeDay => 22;
        public int ChallengePart => 1;

        public string ResolveChallenge(List<string> data)
        {
            var playerCards = GetPlayerCards(data);

            var winnerResults = GetWinnerResults(playerCards);

            var score = CalculateWinnerScore(winnerResults.ToList());

            return score.ToString();
        }

        /// <summary>
        /// Parses the input to gather the card allocation for each player
        /// </summary>
        private List<LinkedList<int>> GetPlayerCards(List<string> cardSplit)
        {
            cardSplit.Add(null);

            var playerCards = new List<LinkedList<int>>();

            var currentPlayerCards = new LinkedList<int>();
            foreach (var cardAssignment in cardSplit)
            {
                if (string.IsNullOrEmpty(cardAssignment) || cardAssignment.StartsWith("Player"))
                {
                    if (currentPlayerCards.Any())
                    {
                        playerCards.Add(new LinkedList<int>(currentPlayerCards));
                        currentPlayerCards.Clear();
                    }
                }
                else
                {
                    currentPlayerCards.AddLast(int.Parse(cardAssignment));
                }
            }

            return playerCards;
        }

        /// <summary>
        /// Plays out the game, following the rules, and returns the results of the game.  Assumes cards have distinct values.
        /// </summary>
        private LinkedList<int> GetWinnerResults(List<LinkedList<int>> playerCards)
        {
            while (true)
            {
                var maxTopCard = playerCards
                    .Max(c => c.First.Value);

                var winningPlayerList = playerCards
                    .FirstOrDefault(p => p.First.Value == maxTopCard);

                var losingPlayerList = playerCards
                    .FirstOrDefault(p => p.First.Value != maxTopCard);

                var winningTargetNode = winningPlayerList.First;
                winningPlayerList.Remove(winningTargetNode);
                winningPlayerList.AddLast(winningTargetNode);

                var losingTargetNode = losingPlayerList.First;
                losingPlayerList.Remove(losingTargetNode);
                winningPlayerList.AddLast(losingTargetNode);


                if (playerCards.Any(p => !p.Any()))
                {
                    return winningPlayerList;
                }
            }
        }

        /// <summary>
        /// Calculates the winner's score based on the scoring rules
        /// </summary>
        private long CalculateWinnerScore(List<int> winnerResults)
        {
            long score = 0;

            for (int i = 0; i < winnerResults.Count; i++)
            {
                score += winnerResults[i] * (winnerResults.Count - i);
            }

            return score;
        }
    }
}