using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Challenges.Resolution
{
    public class Challenge_2022_02_01 : IChallengeResolution
    {
        public int ChallengeYear => 2022;
        public int ChallengeDay => 2;
        public int ChallengePart => 1;

        enum Hand
        {
            Rock = 1,
            Paper = 2,
            Scissors = 3
        }

        public string ResolveChallenge(List<string> data)
        {
            var rounds = data.Select(x => x.Split(' '));

            var handValues = new Dictionary<string, Hand>
            {
                {"A", Hand.Rock },
                {"B", Hand.Paper },
                {"C", Hand.Scissors },
                {"X", Hand.Rock },
                {"Y", Hand.Paper },
                {"Z", Hand.Scissors },
            };

            var totalScore = 0;

            foreach (var round in rounds)
            {
                var opponentHandValue = handValues[round[0]];
                var myHandValue = handValues[round[1]];

                var win = false;
                var lose = false;

                // Lose Condition
                if (opponentHandValue == Hand.Rock && myHandValue == Hand.Scissors)
                {
                    lose = true;
                }
                // Win Condition
                else if (opponentHandValue == Hand.Scissors && myHandValue == Hand.Rock)
                {
                    win = true;
                }
                // Rock < Paper < Scissors
                else if ((int)opponentHandValue > (int)myHandValue)
                {
                    lose = true;
                }
                else if ((int)myHandValue > (int)opponentHandValue)
                {
                    win = true;
                }

                var handScore = (int)myHandValue + (win ? 6 : lose ? 0 : 3);
                totalScore += handScore;
            }

            return totalScore.ToString();
        }
    }
}